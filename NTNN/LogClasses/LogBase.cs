using GNS3_API.Helpers;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTNN.LogClasses
{
    public abstract class LogBase
    {
        [JsonIgnore]
        public int RegisteredDeviceFK { get; set; }

        public virtual void Log()
        {
            try
            {
                string json = JsonConvert.SerializeObject(this, Formatting.Indented);
                string type = GetType().ToString();
                using (SqlCommand cmd = new SqlCommand("LogRegisteredDeviceInfo"))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RegisteredDeviceFK", RegisteredDeviceFK);
                    cmd.Parameters.AddWithValue("@LogJSON", json);
                    cmd.Parameters.AddWithValue("@ClassType", type);
                    DAL.DataAccess.ExecuteNonQuery(cmd);
                }
            }
            catch (Exception ex)
            {
                LoggingHelper.LogEntry(SystemCategories.GeneralError, $"{ex.Message} {ex.StackTrace}");
            }
        }
    }
}
