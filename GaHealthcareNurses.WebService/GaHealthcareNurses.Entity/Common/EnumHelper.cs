using System;
using System.ComponentModel;
using System.Reflection;

namespace GaHealthcareNurses.Entity.Common
{
    public static class EnumHelper
    {
        public static string GetDescription(System.Enum @enum)
        {
            if (@enum == null)
                return null;

            string description = @enum.ToString();
            try
            {
                FieldInfo fi = @enum.GetType().GetField(@enum.ToString());

                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes.Length > 0)
                    description = attributes[0].Description;
            }
            catch (Exception)
            {
                // _logger.ErrorException("Error in GetDescription Method", ex);
                throw;
            }
            return description;
        }
    }
}
