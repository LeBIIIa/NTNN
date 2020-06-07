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

        public IPAddress GetIPAddress => IPAddress.Parse(IP);

        public RegisteredDevice()
        {
            RegisteredDevicePK = 0;
        }

        public RegisteredDevice(int RegisteredDevicePK)
        {
            LoadRegisteredDevice(RegisteredDevicePK, this);
        }

        public RegisteredDevice(int RegisteredDevicePK, string IP, string Name, string Hostname, DeviceType Type)
            : this(IP, Name, Hostname, Type)
        {
            this.RegisteredDevicePK = RegisteredDevicePK;
        }

        public RegisteredDevice(string IP, string Name, string Hostname, DeviceType Type)
        {
            this.IP = IP;
            this.Name = Name;
            this.Hostname = Hostname;
            this.Type = Type;
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
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingHelper.LogEntry(SystemCategories.GeneralError, ex.Message + " " + ex.StackTrace);
            }
        }

        public static string GetIPFromBinary(byte[] ipv4)
        {
            if (ipv4.Length != 4)
                return null;
            try
            {
                using (SqlCommand sql = new SqlCommand("SELECT dbo.fnDisplayIPv4(@binIP) as strIP"))
                {
                    sql.Parameters.AddWithValue("@binIP", ipv4);
                    using (var reader = DataAccess.ExecuteReader(sql))
                    {
                        return ValidationHelper.GetString(reader["strIP"], null);
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingHelper.LogEntry(SystemCategories.GeneralError, ex.Message + " " + ex.StackTrace);
            }
            return null;
        }
        public static byte[] GetIPToBinary(string ipv4)
        {
            try
            {
                using (SqlCommand sql = new SqlCommand("SELECT dbo.fnBinaryIPv4(@strIP) as binIP"))
                {
                    sql.CommandType = System.Data.CommandType.StoredProcedure;
                    sql.Parameters.AddWithValue("@strIP", ipv4);
                    using (var reader = DataAccess.ExecuteReader(sql))
                    {
                        return ValidationHelper.GetBinary(reader["binIP"], new byte[4]);
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingHelper.LogEntry(SystemCategories.GeneralError, ex.Message + " " + ex.StackTrace);
            }
            return null;
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
                                Hostname = ValidationHelper.GetString(reader["Hostname"], null)
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
                LoggingHelper.LogEntry(SystemCategories.GeneralError, ex.Message + " " + ex.StackTrace);
            }
            return devices;
        }
        public static RegisteredDevice GetRegisteredDevice(int RegisteredDevicePK)
        {
            RegisteredDevice device = null;
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
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingHelper.LogEntry(SystemCategories.GeneralError, ex.Message + " " + ex.StackTrace);
            }
            return device;
        }
        public static void AddRegisteredDevice(string IP, string Name, string Hostname, DeviceType type)
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
                    DataAccess.ExecuteNonQuery(sql);
                }
            }
            catch (Exception ex)
            {
                LoggingHelper.LogEntry(SystemCategories.GeneralError, ex.Message + " " + ex.StackTrace);
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
                LoggingHelper.LogEntry(SystemCategories.GeneralError, ex.Message + " " + ex.StackTrace);
            }
            return false;
        }
        public static bool UpdateRegisteredDevice(string newName, DeviceType newType, int RegisteredDevicePK)
        {
            try
            {
                using (SqlCommand sql = new SqlCommand("UpdateRegisteredDevice"))
                {
                    sql.CommandType = System.Data.CommandType.StoredProcedure;
                    sql.Parameters.AddWithValue("@RegisteredDevicePK", RegisteredDevicePK);
                    sql.Parameters.AddWithValue("@Name", newName);
                    sql.Parameters.AddWithValue("@Type", newType.ToString());
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
                LoggingHelper.LogEntry(SystemCategories.GeneralError, ex.Message + " " + ex.StackTrace);
            }
            return false;
        }
        #endregion

        public void Deconstruct(out string IP, out string Name, out string Hostname, out string Type)
        {
            IP = this.IP;
            Name = this.Name;
            Hostname = this.Hostname;
            Type = this.Type.ToString();
        }

        public void Deconstruct(out KeyValuePair<string, string>[] pairs)
        {
            pairs = new KeyValuePair<string, string>[5];
            pairs[0] = new KeyValuePair<string, string>("RegisteredDevicePK", RegisteredDevicePK.ToString());
            pairs[1] = new KeyValuePair<string, string>("IP", IP);
            pairs[2] = new KeyValuePair<string, string>("Name", Name);
            pairs[3] = new KeyValuePair<string, string>("Hostname", Hostname);
            pairs[4] = new KeyValuePair<string, string>("Type", Type.ToString());
        }
    }

    public enum DeviceType
    {
        PC
        , Router
        , Switch
        //,Printer
    }
}
