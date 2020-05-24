using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Globalization;
using System.Threading;
using NTNN.Helpers;
using GNS3_API.Helpers;

namespace NTNN.Helpers
{
    public static class ValidationHelper
    {
        // Fields
        private static Regex boolExp = new Regex("^(0|1|true|false)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static Regex emailExp = new Regex(@"^[A-Za-z0-9_-]+(\.[A-Za-z0-9_-]+)*@[A-Za-z0-9_-]+(\.[A-Za-z0-9_-]+)+$", RegexOptions.Compiled);
        private static Regex intExp = new Regex(@"^(\+|-)?\d+$", RegexOptions.Compiled);
        private static Hashtable mDoubleExps = new Hashtable();


        // Methods
        public static bool AreEmails(object value)
        {
            if ((value == null) || (value == DBNull.Value))
            {
                return false;
            }
            foreach (string str in value.ToString().Split(new char[] { ';' }))
            {
                if (!IsEmail(str))
                {
                    return false;
                }
            }
            return true;
        }

        public static byte[] GetBinary(object value, byte[] defaultValue)
        {
            if ((value == null) || (value == DBNull.Value))
            {
                return defaultValue;
            }
            try
            {
                return (byte[])value;
            }
            catch (Exception ex)
            {
                LoggingHelper.LogEntry(SystemCategories.GeneralError, ex.Message + " " + ex.StackTrace);
                return defaultValue;
            }
        }

        public static bool GetBoolean(object value, bool defaultValue)
        {
            string str;
            if (!IsBoolean(value))
            {
                return defaultValue;
            }
            if (!(value is string))
            {
                return Convert.ToBoolean(value);
            }
            if (((str = ((string)value).ToLower()) == null) || ((str != "true") && (str != "1")))
            {
                return false;
            }
            return true;
        }

        public static DateTime GetDateTime(object value, DateTime defaultValue)
        {
            return GetDateTime(value, defaultValue, null);
        }

        public static DateTime? GetDateTime(object value, DateTime? defaultValue)
        {
            return GetDateTime(value, defaultValue, null);
        }

        public static DateTime? GetDateTime(object value, DateTime? defaultValue, IFormatProvider format)
        {
            if ((value == null) || (value == DBNull.Value))
            {
                return defaultValue;
            }
            try
            {
                return DateTime.Parse(value.ToString(), format);
            }
            catch (Exception ex)
            {
                LoggingHelper.LogEntry(SystemCategories.GeneralError, ex.Message + " " + ex.StackTrace);
                return defaultValue;
            }
        }

        public static DateTime GetDateTime(object value, DateTime defaultValue, IFormatProvider format)
        {
            if ((value == null) || (value == DBNull.Value))
            {
                return defaultValue;
            }
            try
            {
                return DateTime.Parse(value.ToString(), format);
            }
            catch (Exception ex)
            {
                LoggingHelper.LogEntry(SystemCategories.GeneralError, ex.Message + " " + ex.StackTrace);
                return defaultValue;
            }
        }

        public static double GetDBDouble(object value, double defaultValue)
        {
            CultureInfo cInfo = new CultureInfo("en-US");
            if (!IsDouble(value, cInfo))
            {
                return defaultValue;
            }
            return Convert.ToDouble(value, cInfo);
        }

        public static double GetDouble(object value, double defaultValue)
        {
            if (!IsDouble(value))
            {
                return defaultValue;
            }
            return Convert.ToDouble(value);
        }

        private static Regex GetDoubleExp(CultureInfo currentUICulture = null)
        {
            if (currentUICulture == null)
                currentUICulture = Thread.CurrentThread.CurrentUICulture;
            string ietfLanguageTag = currentUICulture.IetfLanguageTag;
            Regex regex = (Regex)mDoubleExps[ietfLanguageTag];
            if (regex == null)
            {
                regex = new Regex(@"^(\+|-)?(\d*\" + currentUICulture.NumberFormat.NumberDecimalSeparator + @"?\d+)((e|E)(\+|-)?\d+)?$", RegexOptions.Compiled);
                mDoubleExps[ietfLanguageTag] = regex;
            }
            return regex;
        }

        public static Guid GetGuid(object value, Guid defaultValue)
        {
            if ((value == null) || (value == DBNull.Value))
            {
                return defaultValue;
            }
            try
            {
                return new Guid(value.ToString());
            }
            catch (Exception ex)
            {
                LoggingHelper.LogEntry(SystemCategories.GeneralError, ex.Message + " " + ex.StackTrace);
                return defaultValue;
            }
        }

        public static int GetInteger(object value, int defaultValue)
        {
            if (!IsInteger(value))
            {
                return defaultValue;
            }
            return Convert.ToInt32(value);
        }

        public static string GetString(object value, string defaultValue)
        {
            if ((value != null) && (value != DBNull.Value))
            {
                return value.ToString();
            }
            return defaultValue;
        }

        public static char GetChar(object value, char defaultValue)
        {
            if ((value != null) && (value != DBNull.Value))
            {
                return Convert.ToChar(value);
            }
            return defaultValue;
        }

        public static bool IsBoolean(object value)
        {
            if ((value != null) && (value != DBNull.Value))
            {
                return boolExp.Match(value.ToString()).Success;
            }
            return false;
        }

        public static bool IsDouble(object value, CultureInfo currentUICulture = null)
        {
            if ((value != null) && (value != DBNull.Value))
            {
                if (currentUICulture == null)
                    currentUICulture = Thread.CurrentThread.CurrentUICulture;
                return GetDoubleExp(currentUICulture).Match(Convert.ToString(value, currentUICulture)).Success;
            }
            return false;
        }

        public static bool IsFloat(object value)
        {
            if ((value != null) && (value != DBNull.Value))
            {
                return GetDoubleExp().Match(value.ToString()).Success;
            }
            return false;
        }

        public static bool IsEmail(object value)
        {
            if ((value != null) && (value != DBNull.Value))
            {
                return emailExp.Match(value.ToString()).Success;
            }
            return false;
        }

        public static bool IsGuid(object value)
        {
            if ((value == null) || (value == DBNull.Value))
            {
                return false;
            }
            return (GetGuid(value, Guid.Empty) != Guid.Empty);
        }

        public static bool IsInteger(object value)
        {
            if ((value != null) && (value != DBNull.Value))
            {
                return intExp.Match(value.ToString()).Success;
            }
            return false;
        }

        public static bool IsPositiveNumber(object value)
        {
            if ((value == null) || (value == DBNull.Value))
            {
                return false;
            }
            if (!intExp.Match(value.ToString()).Success && !GetDoubleExp().Match(value.ToString()).Success)
            {
                return false;
            }
            return !value.ToString().StartsWith("-");
        }

    }
}
