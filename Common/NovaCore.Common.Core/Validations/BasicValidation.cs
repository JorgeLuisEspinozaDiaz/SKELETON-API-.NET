using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovaCore.Common.Core.Validations
{
    public class BasicValidation
    {
        public static bool IsNullOrEmpty(string value)
        {
            return string.IsNullOrEmpty(value);
        }
        public static bool IsNullOrWhiteSpace(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
        public static bool IsNull(object value)
        {
            return value == null;
        }
        public static bool IsNotNull(Guid value)
        {
            return value != Guid.Empty;
        }
        public static bool IsNull(int value)
        {
            return value != 0;
        }
        public static bool IsNull(decimal value)
        {
            return value == 0;
        }
        public static bool IsNull(DateTime value)
        {
            return value == DateTime.MinValue;
        }
        public static bool IsNull(DateTime? value)
        {
            return value == null;
        }
        public static bool IsNotNull(bool value)
        {
            return value != null;
        }
        public static bool IsNull(bool? value)
        {
            return value == null;
        }
        public static bool IsNull<T>(IEnumerable<T> value)
        {
            return value == null || !value.Any();
        }
        public static bool IsHour(string hora)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(hora, @"^([0-1][0-9]|2[0-3]):[0-5][0-9]$");
        }
        public static bool CompareHours(string horaInicio, string horaFin)
        {
            if (TimeSpan.TryParse(horaInicio, out TimeSpan inicio) &&
                TimeSpan.TryParse(horaFin, out TimeSpan fin))
            {
                return inicio < fin;
            }
            return false;
        }

    }
}