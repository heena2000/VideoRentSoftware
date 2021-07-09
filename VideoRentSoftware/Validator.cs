using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRentSoftware
{
    public static class Validator
    {
        public static bool CheckNumber(string str)
        {
            try
            {
                int.Parse(str.Trim());
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool CheckFloat(string str)
        {
            try
            {
                float.Parse(str.Trim());
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool CheckEmpty(string str)
        {
            return str.Trim().Length == 0;
        }

        public static bool CheckPhone(string str)
        {
            if (str.Trim().Length == 0)
            {
                return false;
            }
            for (int index = 0; index < str.Length; index++)
            {
                if (!char.IsDigit(str[index]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
