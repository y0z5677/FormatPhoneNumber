using System;
using System.Text.RegularExpressions;

namespace FormatPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please Enter a Phone Number:");
                var phone = Console.ReadLine();
                string str = Format(phone);
                if (str != null)
                {
                    Console.WriteLine("the format phone number : " + str);
                }
                else
                {
                    Console.WriteLine("the phone number is not valid");
                }

                Console.WriteLine("Please enter 'continue' to continue");

                var b = Console.ReadLine();
                if (b != "continue")
                {
                    break;
                }
            }
        }

        public static String Format(string phone)
        {
            string pattern = @"^\+?[1-9]?[1-9]?[-\.]?\(?\d{3}\)?[-\.]? *\d{3}[-\.]? *\d{4}$";

            Match mc = Regex.Match(phone, pattern);

            if (mc.Success)
            {
                if (mc.Value.StartsWith("+"))
                    return mc.Value.Replace("(", "").Replace(")", "").Replace("-","");
                else
                {
                    var p = mc.Value.Replace("(", "").Replace(")", "").Replace("-", "").Replace(".", "");
                    if (p.Length == 10)
                        return string.Concat("+1", mc.Value.Replace("(", "").Replace(")", "").Replace("-", "").Replace(".", ""));
                    else 
                        return string.Concat("+", mc.Value.Replace("(", "").Replace(")", "").Replace("-", "").Replace(".", ""));
                }
            }
            else
            {
                return null;
            }
        }

    }
}
