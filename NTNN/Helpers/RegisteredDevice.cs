using GNS3_API.Helpers;

using NTNN.DAL;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;

namespace NTNN.Helpers
{
    public class RegisteredDevice
    {
        public int RegisteredDevicePK { get; private set; }
        public string IP { get; private set; }
        public string Name { get; private set; }
        public string Hostname { get; private set; }
        public DeviceType Type { get; private set; }
        public short Port { get; private set; }

        public IPAddress GetIPAddress => IPAddress.Parse(IP);

        public RegisteredDevice()
        {
            RegisteredDevicePK = 0;
        }

        public RegisteredDevice(int RegisteredDevicePK)
        {
            LoadRegisteredDevice(RegisteredDevicePK, this);
        }

        public RegisteredDevice(int RegisteredDevicePK, string IP, string Name, string Hostname, DeviceType Type, short Port)
            : this(IP, Name, Hostname, Type, Port)
        {
            this.RegisteredDevicePK = RegisteredDevicePK;
        }

        public RegisteredDevice(string IP, string Name, string Hostname, DeviceType Type, short Port)
        {
            this.IP = IP;
            this.Name = Name;
            this.Hostname = Hostname;
            this.Type = Type;
            this.Port = Port;
        }

        private static void LoadRegisteredDevice(int RegisteredDevicePK, RegisteredDevice device)
        {
            try
            {
                using (SqlCommand sql = new SqlCommand("GetRegisteredDevice"))
                {
                    sql.CommandType = System.Data.CommandType.StoredProcedure;
                    sql.Parameters.AddWithValue("@RegisteredDevicePK", RegisteredDevicePK);
                    using (var reader = DataAccess.ExecuteReader(sql))
                    {
                        device.RegisteredDevicePK = ValidationHelper.GetInteger(reader["RegisteredDevicePK"], 0);
                        device.IP = string.Join(".", ValidationHelper.GetBinary(reader["IP"], new byte[1]));
                        device.Name = ValidationHelper.GetString(reader["Name"], null);
                        device.Hostname = ValidationHelper.GetString(reader["Hostname"], null);
                        if (Enum.TryParse<DeviceType>(ValidationHelper.GetString(reader["Type"], null), out var temp))
                            device.Type = temp;
                        device.Port = ValidationHelper.GetShort(reader["Port"], 161);
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingHelper.LogEntry(SystemCategories.GeneralError, $"{ex.Message} {ex.StackTrace}");
            }
        }

        #region static
        public static List<RegisteredDevice> GetRegisteredDevices()
        {
            List<RegisteredDevice> devices = new List<RegisteredDevice>();
            try
            {
                using (SqlCommand sql = new SqlCommand("GetRegisteredDevices"))
                {
                    sql.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var reader = DataAccess.ExecuteReader(sql))
                    {
                        while (reader.Read())
                        {
                            var device = new RegisteredDevice
                            {
                                RegisteredDevicePK = ValidationHelper.GetInteger(reader["RegisteredDevicePK"], 0),
                                IP = string.Join(".", ValidationHelper.GetBinary(reader["IP"], new byte[1])),
                                Name = ValidationHelper.GetString(reader["Name"], null),
                                Hostname = ValidationHelper.GetString(reader["Hostname"], null),
                                Port = ValidationHelper.GetShort(reader["Port"], 161)

                            };
                            if (Enum.TryParse<DeviceType>(ValidationHelper.GetString(reader["Type"], null), out var temp))
                                device.Type = temp;

                            

                            devices.Add(device);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingHelper.LogEntry(SystemCategories.GeneralError, $"{ex.Message} {ex.StackTrace}");
                throw;
            }
            return devices;
        }
        public static RegisteredDevice GetRegisteredDevice(int RegisteredDevicePK)
        {
            try
            {
                using (SqlCommand sql = new SqlCommand("GetRegisteredDevice"))
                {
                    sql.CommandType = System.Data.CommandType.StoredProcedure;
                    sql.Parameters.AddWithValue("@RegisteredDevicePK", RegisteredDevicePK);
                    using (var reader = DataAccess.ExecuteReader(sql))
                    {
                        RegisteredDevice device = new RegisteredDevice
                        {
                            RegisteredDevicePK = ValidationHelper.GetInteger(reader["RegisteredDevicePK"], 0),
                            IP = string.Join(".", ValidationHelper.GetBinary(reader["IP"], new byte[1])),
                            Name = ValidationHelper.GetString(reader["Name"], null),
                            Hostname = ValidationHelper.GetString(reader["Hostname"], null),
                            Port = ValidationHelper.GetShort(reader["Port"], 161)
                        };
                        if (Enum.TryParse<DeviceType>(ValidationHelper.GetString(reader["Type"], null), out var temp))
                            device.Type = temp;
                        return device;
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingHelper.LogEntry(SystemCategories.GeneralError, $"{ex.Message} {ex.StackTrace}");
                throw;
            }
        }
        public static void AddRegisteredDevice(string IP, string Name, string Hostname, DeviceType type, short port)
        {
            try
            {
                using (SqlCommand sql = new SqlCommand("AddRegisteredDevice"))
                {
                    sql.CommandType = System.Data.CommandType.StoredProcedure;
                    sql.Parameters.AddWithValue("@IP", IP);
                    sql.Parameters.AddWithValue("@Name", Name);
                    sql.Parameters.AddWithValue("@Hostname", Hostname);
                    sql.Parameters.AddWithValue("@Type", type.ToString());
                    sql.Parameters.AddWithValue("@Port", port);
                    DataAccess.ExecuteNonQuery(sql);
                }
            }
            catch (Exception ex)
            {
                LoggingHelper.LogEntry(SystemCategories.GeneralError, $"{ex.Message} {ex.StackTrace}");
                throw;
            }
        }
        public static bool RemoveRegisteredDevice(int RegisteredDevicePK)
        {
            try
            {
                using (SqlCommand sql = new SqlCommand("DelRegisteredDevice"))
                {
                    sql.CommandType = System.Data.CommandType.StoredProcedure;
                    sql.Parameters.AddWithValue("@RegisteredDevicePK", RegisteredDevicePK);
                    var param = new SqlParameter("@Result", System.Data.SqlDbType.Bit)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    sql.Parameters.Add(param);
                    DataAccess.ExecuteNonQuery(sql);
                    return ValidationHelper.GetBoolean(param.Value, false);
                }
            }
            catch (Exception ex)
            {
                LoggingHelper.LogEntry(SystemCategories.GeneralError, $"{ex.Message} {ex.StackTrace}");
                throw;
            }
        }
        public static bool UpdateRegisteredDevice(string newName, DeviceType newType, short newPort, int RegisteredDevicePK)
        {
            try
            {
                using (SqlCommand sql = new SqlCommand("UpdateRegisteredDevice"))
                {
                    sql.CommandType = System.Data.CommandType.StoredProcedure;
                    sql.Parameters.AddWithValue("@RegisteredDevicePK", RegisteredDevicePK);
                    sql.Parameters.AddWithValue("@Name", newName);
                    sql.Parameters.AddWithValue("@Type", newType.ToString());
                    sql.Parameters.AddWithValue("@Port", newPort);
                    var param = new SqlParameter("@Result", System.Data.SqlDbType.Bit)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    sql.Parameters.Add(param);
                    using (var reader = DataAccess.ExecuteReader(sql))
                    {
                        return ValidationHelper.GetBoolean(param.Value, false);
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingHelper.LogEntry(SystemCategories.GeneralError, $"{ex.Message} {ex.StackTrace}");
                throw;
            }
        }
        #endregion

        public void Deconstruct(out string IP, out string Name, out string Hostname, out string Type, out int Port)
        {
            IP = this.IP;
            Name = this.Name;
            Hostname = this.Hostname;
            Type = this.Type.ToString();
            Port = this.Port;
        }

        public void Deconstruct(out KeyValuePair<string, string>[] pairs)
        {
            pairs = new KeyValuePair<string, string>[6];
            pairs[0] = new KeyValuePair<string, string>("RegisteredDevicePK", RegisteredDevicePK.ToString());
            pairs[1] = new KeyValuePair<string, string>("IP", IP);
            pairs[2] = new KeyValuePair<string, string>("Name", Name);
            pairs[3] = new KeyValuePair<string, string>("Hostname", Hostname);
            pairs[4] = new KeyValuePair<string, string>("Type", Type.ToString());
            pairs[5] = new KeyValuePair<string, string>("Port", Port.ToString());
        }
    }

    public enum DeviceType
    {
        PC
        ,Router
        //,Switch
        //,Printer
    }
}
