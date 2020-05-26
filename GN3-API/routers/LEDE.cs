using System;
using System.Collections.Generic;

namespace GNS3_API
{

    /// <summary>
    /// Representation of a LEDE type of node
    /// <remarks>
    /// Define methods that are only available for this appliance
    /// </remarks>
    /// </summary>
    public class LEDE : OpenWRT{

        private const string label = "LEDE";
        /// <summary>
        /// Label you must set in the name of the node at the GNS3 project
        /// <para>Name of the node must look like "[LEDE]Name"</para>
        /// </summary>
        /// <value>Label as a string</value>
        new public static string Label { get => label; }

        /// <summary>
        /// Constructor by default. Every property is empty
        /// </summary>
        internal LEDE() : base() {}

        /// <summary>
        /// Constructor for any kind of <c>Node</c>. It must be called from a <c>GNS3sharp</c> object
        /// </summary>
        /// <param name="_consoleHost">IP of the machine where the node is hosted</param>
        /// <param name="_port">Port of the machine where the node is hosted</param>
        /// <param name="_name">Name of the node stablished in the project</param>
        /// <param name="_id">ID the node has implicitly</param>
        /// <param name="_ports">Array of dictionaries that contains information about every network interface</param>
        internal LEDE(string _consoleHost, ushort _port, string _name, string _id, Status status, GNS3sharp parent,
            Dictionary<string,dynamic>[] _ports) : 
            base(_consoleHost, _port, _name, _id, status, parent, _ports){}

        /// <summary>
        /// Constructor that replicates a router from another node
        /// </summary>
        /// <param name="clone">Node you want to make the copy from</param>
        public LEDE(Node clone) : base(clone){}

    }
}