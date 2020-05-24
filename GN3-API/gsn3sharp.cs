using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using GNS3_API.Helpers;
using log4net.Core;

namespace GNS3_API {
    
    /// <summary>
    /// Main class of the namespace. Handles a GNS3 project through its methods. You can list all the nodes
    /// of the project, activate them all at once...
    /// </summary>
    /// <remarks>
    /// Contains several methods to interact with a GNS3 project
    /// </remarks>
    public class GNS3sharp {

        public event Action<SystemCategories, string> LogEvent;
        /// <summary>
        /// ID of the project that the object is handling
        /// </summary>
        /// <value>String ID</value>
        public string ProjectID { get; }

        /// <summary>
        /// IP where the GNS3 server is hosted
        /// </summary>
        /// <value>String IP</value>
        public string Host { get; }

        /// <summary>
        /// Port where the server is hosted
        /// </summary>
        /// <value>Port number</value>
        public ushort Port { get; }

        private List<Dictionary<string,object>> nodesJSON;
        /// <summary>
        /// JSON list with info about the nodes inside the project. The list is not filtered
        /// </summary>
        /// <value>Dictionary: key is the node field and the value its value</value>
        public List<Dictionary<string,object>> NodesJSON{
            get {
                ExtractNodesDictionary(
                    $"http://{Host}:{Port}/v2/projects/{ProjectID}/nodes"
                );
                return nodesJSON;
            }
        }

        /// <summary>
        /// JSON list with info about the links inside the project. The list is not filtered
        /// </summary>
        /// <value>Dictionary: key is the link field and the value its value</value>
        private List<Dictionary<string,object>> linksJSON;
        public List<Dictionary<string,object>> LinksJSON{
            get {
                ExtractLinksDictionary(
                    $"http://{Host}:{Port.ToString()}/v2/projects/{ProjectID}/links"
                );
                return linksJSON;
            }
        }

        /// <summary>
        /// List of nodes contained in the project
        /// </summary>
        /// <value>Array of <c>Node</c></value>
        public Node[] Nodes { get; private set; }

        /// <summary>
        /// List of links contained in the project
        /// </summary>
        /// <value>List of <c>Link</c></value>
        public List<Link> Links { get; private set; }

        /// <summary>
        /// Map between nodes and their names
        /// </summary>
        /// <returns>Dictionary. The key is the name of the node and the value its object</returns>
        private Dictionary<string, Node> nodesByName = new Dictionary<string, Node>();

        /// <summary>
        /// Map between nodes and their IDs
        /// </summary>
        /// <returns>Dictionary. The key is the ID of the node and the value its object</returns>
        private Dictionary<string, Node> nodesByID = new Dictionary<string, Node>();

        /// <summary>
        /// HTTP client used to interact with the REST API
        /// </summary>
        private static readonly HttpClient HTTPclient = new HttpClient();

        /// <summary>
        /// Auth credentials
        /// </summary>
        private static NetworkCredential networkCredential;


        public string NotificationUrlListener => $"{Host}:{Port}/v2/projects/{ProjectID}/notifications/ws";

        ///////////////////////////// Constructors ////////////////////////////////////////////

        /// <summary>
        /// Wrong constructor. It can not be accessed
        /// </summary>
        private GNS3sharp() => LoggingHelper.LogEntry(SystemCategories.GeneralError, "You need the project ID");

        /// <summary>
        /// Take all the necessary info from a GNS3 project. Initialize a handler object that allows to manage the project
        /// </summary>
        /// <param name="_projectID">ID of the GNS3 project</param>
        /// <param name="_host">Addres where the GNS3 server is. By default is "localhost"</param>
        /// <param name="_port">Port of the host where the GNS3 server is. By default is 3080</param>
        public GNS3sharp(string _projectID, Action<SystemCategories, string> @event, string _host = "localhost", ushort _port = 3080) {
            this.ProjectID = _projectID; this.Host = _host; this.Port = _port;
            LogEvent += @event;
            // Defines the URL where the info is
            string baseURL = $"http://{_host}:{_port}/v2/projects/{_projectID}";
            // Extract that info
            LogEvent?.Invoke(SystemCategories.GeneralDebug, $"Extracting nodes information from URL: {baseURL}/nodes... ");
            ExtractNodesDictionary($"{baseURL}/nodes");
            LogEvent?.Invoke(SystemCategories.GeneralDebug, $"Extracting links information from URL: {baseURL}/links... ");
            ExtractLinksDictionary($"{baseURL}/links");
            if (this.nodesJSON != null && this.linksJSON != null){
                // Create the nodes related to that info
                Nodes = GetNodes(nodesJSON);
                Links = GetLinks(linksJSON);
                try{
                    SaveLinksInfoInNodes(Links);
                } catch(Exception err){
                    LogEvent?.Invoke(SystemCategories.GeneralError,
                        $"Ups, something went wrong. Unable to save the link info in the nodes: {err}"
                    );
                }
            } else{
                LogEvent?.Invoke(SystemCategories.GeneralError,
                    "Information about the nodes or the links couldn't be reached. The instance will be " +
                    "unusable"
                );
            }
            
        }

        ///////////////////////////////// Methods ////////////////////////////////////////////
        
        /// <summary>
        /// Set credentials with user and password
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        public static void SetCredentials(string user, string password)
        {
            if (string.IsNullOrEmpty(user.Trim()))
                networkCredential = null;
            else
                networkCredential = new NetworkCredential(user, password);
        }

        /// <summary>
        /// Return a dictionary with all the info about nodes downloaded it from the GNS3 server
        /// </summary>
        /// <param name="URI">Where the resource (a JSON) is in the server</param>
        private void ExtractNodesDictionary(string URI){
            nodesJSON = ExtractDictionary(URI, "z");    
        }

        public bool UpdateProject()
        {
            bool ret = false;
            
            if (NodesJSON != null && LinksJSON != null)
            {
                Nodes = GetNodes(nodesJSON);
                Links = GetLinks(linksJSON);
                try
                {
                    SaveLinksInfoInNodes(Links);
                }
                catch (Exception err)
                {
                    LogEvent?.Invoke(SystemCategories.GeneralError,
                        $"Ups, something went wrong. Unable to save the link info in the nodes: {err}"
                    );
                }
                ret = true;
            }
            else
            {
                LogEvent?.Invoke(SystemCategories.GeneralError,
                    "Information about the nodes or the links couldn't be reached. The instance will be " +
                    "unusable"
                );
            }
            return ret;
        }

        /// <summary>
        /// Return a dictionary with all the info about links downloaded it from the GNS3 server
        /// </summary>
        /// <param name="URI">Where the resource (a JSON) is in the server</param>
        private void ExtractLinksDictionary(string URI){
            linksJSON = ExtractDictionary(URI, "suspend");    
        }

        // It returns a dictionary with information about the nodes of the project
        /// <summary>
        /// Download and extract information from a JSON contained at a certain URI in the server
        /// </summary>
        /// <param name="URI">Where the resource (a JSON) is in the server</param>
        /// <param name="lastKey">Last key of the array of elements in the JSON</param>
        /// <returns>List of dictionaries which correspond to an array of JSONs</returns>
        internal static List<Dictionary<string,object>> ExtractDictionary(string URI, string lastKey){
            
            // Extract a JSON from a GET request
            string ExtractJSONString(string local_URI){
                // Variable with a string with all the JSON info
                string local_json;
                try{
                    // Get the info from the JSON file you can access from the GNS3 Rest service
                    using (System.Net.WebClient GNS3NodesProject = new System.Net.WebClient()){
                        if (networkCredential != null)
                            GNS3NodesProject.Credentials = networkCredential;
                        local_json = GNS3NodesProject.DownloadString(local_URI);
                    }
                } catch(Exception err){
                    // Server not open
                    LoggingHelper.LogEntry(SystemCategories.GeneralError, string.Format("Impossible to connect to URL {0}: {1}", local_URI, err.Message));
                    local_json = null;
                }

                return local_json;
            }

            // Raw string
            string json = ExtractJSONString(URI);

            // Creates a list of dictionaries. It will be used to store the JSON info and
            // get the values from it
            List<Dictionary<string,object>> dictList = new List<Dictionary<string,object>>();
            if(json == "[]"){
                LoggingHelper.LogEntry(SystemCategories.GeneralError, "JSON is empty");
                dictList = null;
            } else if (string.IsNullOrEmpty(json) == false){
                dictList = DeserializeJSONList(json, lastKey);
            } else{
                dictList = null;
            }
            return dictList;

        }

        /// <summary>
        /// Desearialize a certain JSON and store it in a list of dictionaries.
        /// </summary>
        /// <param name="json">JSON downloaded from the server as a string</param>
        /// <param name="lastKey">Last key of the array of elements in the JSON</param>
        /// <returns>List of dictionaries which correspond to an array of JSONs</returns>
        private static List<Dictionary<string,object>> DeserializeJSONList(string json, string lastKey){
            
            // Return variable
            List<Dictionary<string,object>> dictList = new List<Dictionary<string,object>>();
            // JSON array object
            JArray jsonArray = JArray.Parse(json);
            Dictionary<string,object> tempDict = new Dictionary<string, object>();

            // Variables in which store the JSON info temporaly
            string name; object value;        
            if (jsonArray.HasValues){
                foreach (JObject jO in jsonArray.Children<JObject>()) {
                    foreach (JProperty jP in jO.Properties()) {                
                        name = jP.Name;
                        value = (object)jP.Value;
                        tempDict.Add(name,value);
                        // The last key of every node
                        if (jP.Name.Equals(lastKey)) {
                            // If we do not copy the content of the dictionary into another
                            // we will be copying by reference and erase the content once
                            // we 'clear' the dict
                            Dictionary<string, object> copyDict = new Dictionary<string, object>(tempDict);
                            dictList.Add(copyDict);
                            tempDict.Clear();
                        }
                    }
                }
            }
            return dictList;
        }
        
        /// <summary>
        /// Save information within a <c>Node</c> property of links attached to it
        /// </summary>
        /// <param name="listOfLinks">List of links which attached nodes will store the information of the links</param>
        private void SaveLinksInfoInNodes(List<Link> listOfLinks){
            foreach (Link link in listOfLinks){
                foreach(Node node in link.Nodes){
                    if(node != null)
                        node.LinksAttached.Add(link);
                }
            }
        }

        /// <summary>
        /// Given a certain link and its nodes JSON string, add the link into the correct port of the nodes
        /// </summary>
        /// <param name="link">A concrete link</param>
        /// <param name="nodesJSON">JSON as a string which has information about the nodes attached to the link</param>
        private void MatchLinkWithNodePorts(Link link, string nodesJSON){
            
            List<Dictionary<string,object>> dictList = null;
            try{
                dictList = DeserializeJSONList(nodesJSON, "port_number");
            } catch (Exception err){
                LogEvent?.Invoke(SystemCategories.GeneralError, string.Format(
                    "Some problem occured while trying to gather information about the nodes connect to the link: {0}",
                    err.Message
                ));
            }

            if (dictList.Count > 0){
                // Iterates through the JSON dictionary
                foreach (Dictionary<string, object> nodeTemp in dictList){
                    // Iterates through the nodes the link connects
                    foreach (Node node in link.Nodes){
                        if (node != null && node.ID.Equals(nodeTemp["node_id"].ToString())){
                            // Search for the port that matches the found one
                            var foundPort = node.Ports.Where(
                                x => (
                                    x["adapterNumber"].ToString() == nodeTemp["adapter_number"].ToString() &&
                                    x["portNumber"].ToString() == nodeTemp["port_number"].ToString()
                                )
                            );
                            // If exists, add the link into the key "link" of the ports list
                            // of dictionaries of the node
                            if (foundPort.Count() > 0) foundPort.First()["link"] = link;
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Create an array with the nodes in the project
        /// </summary>
        /// <param name="JSON">JSON with the information about nodes as dictionary</param>
        /// <returns>An array of nodes</returns>
        private Node[] GetNodes(List<Dictionary<string,object>> JSON){
            // Return variable
            Node[] listOfNodes = new Node[JSON.Count];

            // Extract the ports a node has
            Dictionary<string,dynamic>[] GetNodeListOfPorts(Dictionary<string, object> node)
            {
                // Return variable
                List<Dictionary<string,dynamic>> ports = new List<Dictionary<string,dynamic>>();

                try{
                    // Extract a dictionary with the ports defined in the project nodes JSON
                    Dictionary<string,object>[] portsRaw = DeserializeJSONList(
                        node["ports"].ToString(), "short_name"
                    ).ToArray();
                    foreach(Dictionary<string,object> nodePort in portsRaw){
                        ports.Add(
                            new Dictionary<string,dynamic>(){
                                {"adapterNumber", UInt16.Parse(nodePort["adapter_number"].ToString())},
                                {"portNumber", UInt16.Parse(nodePort["port_number"].ToString())},
                                {"link", null}
                            } 
                        );
                    }
                } catch (Exception err){
                    LogEvent?.Invoke(SystemCategories.GeneralError, $"Something went wrong while extracting the ports info: {err}");
                }

                return ports.ToArray();
            }

            System.Reflection.ConstructorInfo ctor; int i = 0;
            try{
                nodesByName = new Dictionary<string, Node>();
                nodesByID = new Dictionary<string, Node>();
                foreach (Dictionary<string, object> node in JSON){
                    try{
                        LogEvent?.Invoke(SystemCategories.GeneralInformation, $"Gathering information for node #{i}... ");

                        // Get the main constructor of the node type
                        ctor = Aux.NodeType(node["name"].ToString()).GetConstructors(
                            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
                        ).Last();

                        Status status;

                        switch (node["status"].ToString())
                        {
                            case "started":
                                status = Status.Start;
                                break;
                            case "stopped":
                                status = Status.Stop;
                                break;
                            case "suspended":
                                status = Status.Suspend;
                                break;
                            default:
                                status = Status.Unknown;
                                break;
                        }

                        // Invoke the previous constructor and create the instance through it
                        listOfNodes[i] = (Node)ctor.Invoke(
                            new object[]{
                                node["console_host"].ToString(), 
                                ushort.Parse(node["console"].ToString()), 
                                node["name"].ToString(),
                                node["node_id"].ToString(),
                                status,
                                GetNodeListOfPorts(node)
                            }
                        );
                        
                        nodesByName.Add(listOfNodes[i].Name, listOfNodes[i]);
                        nodesByID.Add(listOfNodes[i].ID, listOfNodes[i]);
                    } catch(Exception err1){
                        LogEvent?.Invoke(SystemCategories.GeneralError, string.Format(
                            "Impossible to save the configuration for the node #{0}: {1}", 
                            i.ToString(), err1.Message
                        ));
                    }
                    i++;
                }
            } catch(Exception err2){
                LogEvent?.Invoke(SystemCategories.GeneralError, string.Format(
                    "Some problem occured while saving the nodes information: {0}",
                    err2.Message
                ));
                listOfNodes = null;
            }

            return listOfNodes;
        }

        /// <summary>
        /// Create an array with the links in the project
        /// </summary>
        /// <param name="JSON">JSON with the information about links as dictionary</param>
        /// <returns>An array of links</returns>
        private List<Link> GetLinks(List<Dictionary<string,object>> JSON){
            // Return variable
            List<Link> listOfLinks = new List<Link>();
            // Function that returns the nodes connected by the link
            Node[] GetNodesConnectedByLink(string nodesJSON){
                // Return variable
                Node[] nodesList = new Node[2];
                List<Dictionary<string,object>> dictList = null;
                try{
                    dictList = DeserializeJSONList(nodesJSON, "port_number");
                } catch (Exception err){
                    LogEvent?.Invoke(SystemCategories.GeneralError, string.Format(
                        "Some problem occured while trying to gather information about the nodes connect to the link: {0}",
                        err.Message
                    ));
                }
                if (dictList.Count > 0){
                    ushort idx = 0;
                    foreach (Dictionary<string, object> node in dictList){
                        try{
                            nodesList[idx++] = nodesByID[node["node_id"].ToString()];
                        } catch(Exception){
                            LogEvent?.Invoke(SystemCategories.GeneralError,
                                $"Unknown node with ID: {node["node_id"]}"
                            );
                        }
                    }
                }
                return nodesList;
            }
            // Extract a certain filter of the link
            int ExtractFilter(JObject filtJSON, string filter){
                
                int filterValue = 0;

                try{
                    if (filter.Equals("latency"))
                        filterValue = filtJSON.Property("delay").First.ToObject<int[]>()[0];
                    else if (filter.Equals("jitter"))
                        filterValue = filtJSON.Property("delay").First.ToObject<int[]>()[1];
                    else
                        filterValue = filtJSON.Property(filter).First.ToObject<int[]>()[0];
                } catch (Exception){}
                
                return filterValue;
            }

            JObject filtersJSON; int i = 0;
            Dictionary<string, string> serverInfo = new Dictionary<string, string>(){
                {"host", this.Host}, {"port", this.Port.ToString()},
                {"projectID", this.ProjectID}
            };
            try{
                string nodesJSON;
                foreach(Dictionary<string, object> link in JSON){
                    try{
                        LogEvent?.Invoke(SystemCategories.GeneralInformation, $"Gathering information for link #{i}... ");
                        filtersJSON = JObject.Parse(link["filters"].ToString());
                        nodesJSON = link["nodes"].ToString();
                        if (filtersJSON.HasValues){
                            // If the link has some filter activates
                            listOfLinks.Add(new Link(
                                link["link_id"].ToString(),
                                GetNodesConnectedByLink(nodesJSON),
                                serverInfo, HTTPclient,
                                ExtractFilter(filtersJSON, "frequency_drop"),
                                ExtractFilter(filtersJSON, "packet_loss"),
                                ExtractFilter(filtersJSON, "latency"),
                                ExtractFilter(filtersJSON, "jitter"),
                                ExtractFilter(filtersJSON, "corrupt")
                            ));
                        } else{
                            // If don't
                            listOfLinks.Add(new Link(
                                link["link_id"].ToString(),
                                GetNodesConnectedByLink(nodesJSON),
                                serverInfo, HTTPclient
                            ));
                        }
                        MatchLinkWithNodePorts(listOfLinks.Last(), nodesJSON);
                        i++;
                    } catch(Exception err1){
                        LogEvent?.Invoke(SystemCategories.GeneralError,
                            $"Impossible to save the configuration for the link #{i}: {err1.Message}"
                        );
                    }
                }
            } catch(Exception err2){
                LogEvent?.Invoke(SystemCategories.GeneralError,
                    $"Some problem occured while saving the links information: {err2.Message}"
                );
                listOfLinks = null;
            }

            return listOfLinks;
        }

        /// <summary>
        /// Initialize all nodes in the GNS3 project
        /// </summary>
        /// <returns>Array of booleans. Every element determines whether the node has been succesfully started or not</returns>
        public bool[] StartProject(){
            return ChangeProjectStatus(Status.Start);
        }

        /// <summary>
        /// Stop all nodes in the GNS3 project
        /// </summary>
        /// <returns>Array of booleans. Every element determines whether the node has been succesfully stopped or not</returns>
        public bool[] StopProject(){
            return ChangeProjectStatus(Status.Stop);
        }

        /// <summary>
        /// Change the status of the project
        /// </summary>
        /// <param name="status">"start" or "stop"</param>
        /// <returns>Array of booleans. Every element determines whether the node has succesfully changed its status or not</returns>
        private bool[] ChangeProjectStatus(Status status){

            // String with all the messages received
            int numNodes = Nodes.Length;
            bool[] changeOK = new bool[numNodes];

            if (status == Status.Start)
                LogEvent?.Invoke(SystemCategories.GeneralInformation, "Activating all the nodes in the project...");
            else
                LogEvent?.Invoke(SystemCategories.GeneralInformation, "Deactivating all the nodes in the project...");
            for (ushort i = 0; i < numNodes; i++){
                ChangeNodeStatus(Nodes[i], status);
            }

            // If everything goes right, it returns info about every node
            return changeOK;
        }

        /// <summary>
        /// Initialize a single node
        /// </summary>
        /// <param name="node">Node that will be initialized</param>
        /// <returns>True if the node was started, False otherwise</returns>
        public bool StartNode(Node node){
            return ChangeNodeStatus(node, Status.Start);
        }

        /// <summary>
        /// Stop a single node
        /// </summary>
        /// <param name="node">Node that will be stopped</param>
        /// <returns>True if the node was stopped, False otherwise</returns>
        public bool StopNode(Node node){
            return ChangeNodeStatus(node, Status.Stop);
        }

        /// <summary>
        /// Suspend a single node
        /// </summary>
        /// <param name="node">Node that will be stopped</param>
        /// <returns>True if the node was stopped, False otherwise</returns>
        public bool SuspendNode( Node node )
        {
            return ChangeNodeStatus(node, Status.Suspend);
        }

        /// <summary>
        /// Suspend a single node
        /// </summary>
        /// <param name="node">Node that will be stopped</param>
        /// <returns>True if the node was stopped, False otherwise</returns>
        public bool ReloadNode( Node node )
        {
            return ChangeNodeStatus(node, Status.Reload);
        }

        /// <summary>
        /// Change a single node status
        /// </summary>
        /// <param name="node">Node whose status will be switched</param>
        /// <param name="status">"start" or "stop"</param>
        /// <returns>True if the node status was switched, False otherwise</returns>
        private bool ChangeNodeStatus(Node node, Status status){
            // Return variable
            bool responseStatus;

            if (node != null){

            // First part of the URL
            string URLHeader = $"http://{Host}:{Port}/v2/projects/{ProjectID}/nodes";

            // Pack the content we will send
            ByteArrayContent byteContent = null;
            try{
                string content = JsonConvert.SerializeObject(new Dictionary<string, string> { { "", "" } });
                byteContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(content));
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            } catch(JsonSerializationException err){
                LogEvent?.Invoke(SystemCategories.GeneralError, string.Format("Impossible to serialize the JSON to send it to the API: {0}", err.Message));
            }

            if (byteContent != null){
                try{
                    responseStatus = HTTPclient.PostAsync(
                        $"{URLHeader}/{node.ID}/{status.ToString().ToLower()}", byteContent
                    ).Result.IsSuccessStatusCode;
                } catch(HttpRequestException err){
                    LogEvent?.Invoke(SystemCategories.GeneralError, string.Format("Some problem occured with the HTTP connection: {0}", err.Message));
                    responseStatus = false;
                } catch(Exception err){
                    LogEvent?.Invoke(SystemCategories.GeneralError, string.Format("Impossible to {2} node {0}: {1}", node.Name, err.Message, status.ToString()));
                    responseStatus = false;
                }
            } else{
                responseStatus = false;
            }
            } else {
                LogEvent?.Invoke(SystemCategories.GeneralError, string.Format("Impossible to {1} node {0}: the node is null", node.Name, status.ToString()));
                responseStatus = false;
            }

            if (responseStatus && status != Status.Reload)
                node.SetStatus(status);

            return responseStatus;

        }

        /// <summary>
        /// Create a new link in the project between two nodes
        /// </summary>
        /// <param name="node1">Node 1 where the link will be attached</param>
        /// <param name="node2">Node 2 where the link will be attached</param>
        /// <param name="frequencyDrop">Parameter that measure the frequency drop of the link</param>
        /// <param name="packetLoss">Parameter that measure the packet loss of the link</param>
        /// <param name="latency">Parameter that measure the latency of the link</param>
        /// <param name="jitter">Parameter that measure the jitter of the link</param>
        /// <param name="corrupt">Parameter that measure the corruption of the link</param>
        /// <returns></returns>
        public bool SetLink(Node node1, Node node2, 
            int frequencyDrop=0, int packetLoss=0,
            int latency=0, int jitter=0, int corrupt=0){
            
            bool linkCreated;
            if (node1 != null && node2 != null){
                // URL where send the data
                string URL = ($"http://{Host}:{Port}/v2/projects/{ProjectID}/links");

                // Get a certain key of the new link
                object ExtractKeyNewLink(string JSONLink, string key){
                    // Return variable
                    object newID = null;

                    // Parse the JSON string into an object
                    JObject jO = JObject.Parse(JSONLink);      
                    if (jO.HasValues){
                        foreach (JProperty jP in jO.Properties()) {                
                            if (jP.Name.ToString().Equals(key)){
                                newID = (object)jP.Value;
                                break;
                            }
                        }
                    }

                    return newID;
                }

                var freePort1 = node1.Ports.Where( x => (x["link"] == null) );
                var freePort2 = node2.Ports.Where( x => (x["link"] == null) );
                if (freePort1.Count() > 0 && freePort2.Count() > 0){
                    // Free ports map
                    Dictionary<string, dynamic>[] chosenPorts =  new Dictionary<string, dynamic>[2]{
                        freePort1.First(), freePort2.First()
                    };
                    // Dictionary for the JSON message which contains the nodes info
                    Dictionary<string, dynamic>[] nodesInfo = new Dictionary<string, dynamic>[2]{
                        new Dictionary<string, dynamic>(){
                            {"adapter_number", chosenPorts[0]["adapterNumber"]},
                            {"node_id", $"{node1.ID}"}, {"port_number", chosenPorts[0]["portNumber"]}
                        },
                        new Dictionary<string, dynamic>(){
                            {"adapter_number", chosenPorts[1]["adapterNumber"]},
                            {"node_id", $"{node2.ID}"}, {"port_number", chosenPorts[1]["portNumber"]}
                        }
                    };
                    // Dictionary for the JSON message which contains the filters info
                    Dictionary<string, int[]> filtersInfo = new Dictionary<string, int[]>{
                        {"frequency_drop", new int[1]{frequencyDrop}}, {"packet_loss", new int[1]{packetLoss}},
                        {"delay", new int[2]{latency,jitter}}, {"corrupt", new int[1]{corrupt}}
                    };

                    try{

                        // Pack the content we will send
                        string content = JsonConvert.SerializeObject(new Dictionary<string, dynamic> { 
                            { "nodes", nodesInfo }, { "filters" , filtersInfo }
                        });
                        ByteArrayContent byteContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(content));
                        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        // Send it. It returns a string with the info about the link
                        var res = HTTPclient.PostAsync(
                            $"{URL}", byteContent
                        ).Result;
                        if (!res.IsSuccessStatusCode){
                            LogEvent?.Invoke(SystemCategories.GeneralError, "Impossible to create the link: the status of the response is not success");
                            linkCreated = false;
                        } else{
                            string responseString = res.Content.ReadAsStringAsync().Result.ToString();
                            // Extract the ID from the new link created
                            string newID = ExtractKeyNewLink(responseString, "link_id").ToString();

                            if (newID == null){
                                LogEvent?.Invoke(SystemCategories.GeneralError, "Impossible to create the link: impossible to get its ID");
                                linkCreated = false;
                            } else{
                                Dictionary<string, string> serverInfo = new Dictionary<string, string>(){
                                    {"host", this.Host}, {"port", this.Port.ToString()},
                                    {"projectID", this.ProjectID},
                                };
                                // Adds the new link to our list
                                Link newLink = new Link(
                                    newID,
                                    new Node[2]{node1, node2},
                                    serverInfo, HTTPclient,
                                    frequencyDrop,
                                    packetLoss,
                                    latency,
                                    jitter,
                                    corrupt
                                );
                                // Add the new link to the project list of links
                                Links.Add(newLink);
                                // Add the new link to each node list of links
                                SaveLinksInfoInNodes(new List<Link>(){newLink});
                                // And then match the nodes ports
                                MatchLinkWithNodePorts(newLink, ExtractKeyNewLink(responseString, "nodes").ToString());
                                linkCreated = true;
                            }
                        }
                    } catch(JsonSerializationException err){
                        LogEvent?.Invoke(SystemCategories.GeneralError, string.Format("Impossible to serialize the JSON to send it to the API: {0}", err.Message));
                        linkCreated = false;
                    } catch(HttpRequestException err){
                        LogEvent?.Invoke(SystemCategories.GeneralError, $"Some problem occured with the HTTP connection: {err.Message}");
                        linkCreated = false;
                    } catch(Exception err){
                        LogEvent?.Invoke(SystemCategories.GeneralError, $"Impossible to create the link: {err.Message}");
                        linkCreated = false;
                    }
                } else {
                    LogEvent?.Invoke(SystemCategories.GeneralError, "Some of the chosen nodes has not any free port");
                    linkCreated = false;
                }
            } else{
                LogEvent?.Invoke(SystemCategories.GeneralError, "Some of the chosen nodes doesn't exist");
                linkCreated = false;
            }

            return linkCreated;
        }

        /// <summary>
        /// Find the link two nodes share
        /// </summary>
        /// <param name="node1">Node 1</param>
        /// <param name="node2">Node 2</param>
        /// <returns>The link that connects node1 and node2, or null if nothing could be found</returns>
        public Link GetLinkByNodes(Node node1, Node node2){
            // Return variable
            Link link;

            if (node1 != null && node2 != null){
                Link[] linkNode1 = node1.LinksAttached.ToArray();
                Link[] linkNode2 = node2.LinksAttached.ToArray();
                if (linkNode1 != null && linkNode2 != null){
                    var sharedLink = linkNode1.Intersect(linkNode2);
                    if (sharedLink.Count() > 0){
                        // In case the nodes share at least one common 
                        // link, it gets the first one
                        link = sharedLink.First();
                    } else{
                        link = null;
                    }
                } else{
                    link = null;
                }
            } else{
                LogEvent?.Invoke(SystemCategories.GeneralError, "Some of the chosen nodes doesn't exist");
                link = null;
            }

            return link;
        }

        /// <summary>
        /// Edit a link according to the parameters introduced
        /// </summary>
        /// <param name="link">Link whose parameters are going to be changed</param>
        /// <param name="frequencyDrop">Parameter that measure the frequency drop of the link</param>
        /// <param name="packetLoss">Parameter that measure the packet loss of the link</param>
        /// <param name="latency">Parameter that measure the latency of the link</param>
        /// <param name="jitter">Parameter that measure the jitter of the link</param>
        /// <param name="corrupt">Parameter that measure the corruption of the link</param>
        /// <returns>True if the operation was succesfully completed, False otherwise</returns>
        public bool EditLink(Link link,
            int frequencyDrop=-10, int packetLoss=-10,
            int latency=-10, int jitter=-10, int corrupt=-10
            ){
            // Return variable
            bool linkEdited;
            if (link != null)
                linkEdited = link.EditLink(
                    frequencyDrop, packetLoss, latency,
                    jitter, corrupt
                );
            else 
                linkEdited = false;

            return linkEdited;
        }

        /// <summary>
        /// Edit a link according to the parameters introduced
        /// </summary>
        /// <param name="node1">Node 1 attached to the link</param>
        /// <param name="node2">Node 2 attached to the link</param>
        /// <param name="frequencyDrop">Parameter that measure the frequency drop of the link</param>
        /// <param name="packetLoss">Parameter that measure the packet loss of the link</param>
        /// <param name="latency">Parameter that measure the latency of the link</param>
        /// <param name="jitter">Parameter that measure the jitter of the link</param>
        /// <param name="corrupt">Parameter that measure the corruption of the link</param>
        /// <returns>True if the operation was succesfully completed, False otherwise</returns>
        public bool EditLink(Node node1, Node node2,
            int frequencyDrop=-10, int packetLoss=-10,
            int latency=-10, int jitter=-10, int corrupt=-10
            ){
            // Return variable
            bool linkEdited;
            if (node1 != null && node2 != null){
                linkEdited = this.EditLink(
                    GetLinkByNodes(node1, node2),
                    frequencyDrop, packetLoss,
                    latency, jitter, corrupt
                );
            }
            else{
                LogEvent?.Invoke(SystemCategories.GeneralError, "Some of the chosen nodes doesn't exist");
                linkEdited = false;
            }

            return linkEdited;

        }

        /// <summary>
        /// Remove a link from the project
        /// </summary>
        /// <param name="link">Link to remove</param>
        /// <returns>True if the operation was succesfully completed, False otherwise</returns>
        public bool RemoveLink(Link link){
            // Return variable
            bool linkRemoved;
            if (link != null){
                string URLHeader = $"http://{Host}:{Port}/v2/projects/{ProjectID}/links";

                try{

                    if (HTTPclient.DeleteAsync($"{URLHeader}/{link.ID}").Result.IsSuccessStatusCode){
                        foreach(Node node in link.Nodes){
                            node.LinksAttached.Remove(link);
                            node.Ports.Single( x => x["link"] == link )["link"] = null;
                        }
                        this.Links.Remove(link); link = null;
                        linkRemoved = true;
                    } else{
                        linkRemoved = false;
                    }

                } catch(HttpRequestException err){
                    LogEvent?.Invoke(SystemCategories.GeneralError, $"Some problem occured with the HTTP connection: {err.Message}");
                    linkRemoved = false;
                } catch(Exception err){
                    LogEvent?.Invoke(SystemCategories.GeneralError, $"Impossible to remove the link: {err.Message}");
                    linkRemoved = false;
                }
            } else{
                linkRemoved = false;
            }

            return linkRemoved;
        }

        /// <summary>
        /// Remove a link from the project
        /// </summary>
        /// <param name="node1">Node 1 attached to the link</param>
        /// <param name="node2">Node 2 attached to the link</param>
        /// <returns>True if the operation was succesfully completed, False otherwise</returns>
        public bool RemoveLink(Node node1, Node node2){
            // Return variable
            bool linkRemoved;

            if (node1 != null && node2 != null)
                linkRemoved = this.RemoveLink(GetLinkByNodes(node1, node2));
            else{
                LogEvent?.Invoke(SystemCategories.GeneralError, "Some of the chosen nodes doesn't exist");
                linkRemoved = false;
            }

            return linkRemoved;
        }

        /// <summary>
        /// Find the node that corresponds to a certain name
        /// </summary>
        /// <param name="name">Name of the node to find</param>
        /// <returns>Node found. A casting to the concrete type of node is compulsory in order to use its methods. Returns null if nothing could be found</returns>
        public Node GetNodeByName(string name){
            
            Node foundNode = null;
            try{
                foundNode = nodesByName[name];
            } catch{}
            return foundNode;

        }

        /// <summary>
        /// Find the node that corresponds to a certain ID
        /// </summary>
        /// <param name="ID">ID of the node to find</param>
        /// <returns>Node found. A casting to the concrete type of node is compulsory in order to use its methods. Returns null if nothing could be found</returns>
        public Node GetNodeByID(string ID){
            
            Node foundNode = null;
            try{
                foundNode = nodesByID[ID];
            } catch{}
            return foundNode;

        }

    }
}