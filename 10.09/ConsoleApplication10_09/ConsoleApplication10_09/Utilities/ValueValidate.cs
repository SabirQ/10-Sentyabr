using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication10_09.Utilities
{
    public class ValueValidate
    {
        public static bool CheckName(ref string name)
        {
            if (String.IsNullOrEmpty(name)) return false;
            if (name.Length<3||name.Length>30) return false;
            for (int i = 0; i < name.Length; i++)
            {
                if (!Char.IsLetter(name[i]))
                {
                    return false;
                }
            }
            name = Capitalize(name);
            return true;
        }
        public static string Capitalize(string name)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Char.ToUpper(name[0]));
            for (int i = 1; i < name.Length; i++)
            {
                builder.Append(name[i]);
            }
            return builder.ToString();
        }
        public static bool CheckMail(string mail)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return regex.IsMatch(mail);
        }
        public static bool CheckPhone(string phone)
        {
            Regex regex = new Regex("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$");
            return regex.IsMatch(phone);
        }
    }
}
