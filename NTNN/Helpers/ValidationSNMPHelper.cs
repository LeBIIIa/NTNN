using SnmpSharpNet;

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
    }
}
