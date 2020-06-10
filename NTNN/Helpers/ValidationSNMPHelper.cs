using SnmpSharpNet;
using System;
using System.Windows.Media.Animation;

namespace NTNN.Helpers
{
    public static class ValidationSNMPHelper
    {
        public static int GetInteger(AsnType obj, int defaultValue)
        {
            if (obj.Type == AsnType.INTEGER)
                return ((Integer32)obj).Value;
            return defaultValue;
        }
        public static uint GetUnsignedInteger(AsnType obj, uint defaultValue)
        {
            if (obj is Counter32 c)
                return c.Value;
            return defaultValue;
        }

        public static TimeSpan GetTimeSpan(AsnType obj, TimeSpan defaultValue)
        {
            if (obj is TimeTicks tt)
                return (TimeSpan)tt;
            return defaultValue;
        }
    }
}
