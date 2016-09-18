using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDPractice
{
    public static class SimpleStringParsing
    {
        public static int StringToInt(string str)
        {
            int ret;
            if (int.TryParse(str, out ret))
            {
                return ret;
            }
            
            throw new ArgumentException();
        }

        public static void HandleNegatives(IEnumerable<string> strings)
        {
            var negatives = 
                (from value in strings
                 where value[0] == '-'
                 select value).Aggregate((x, y) => x + "," + y);

            throw new Exception("negatives not allowed: " + negatives);
        }

        public static string SanitizeString(string str)
        {
            if (str.StartsWith("//"))
            {
                string delimstr;
                if (str.Contains("["))
                {
                    delimstr = str.Substring(3, str.IndexOf('\n') - 4);
                    str = str.Remove(0, 5 + delimstr.Length);
                }
                else
                {
                    delimstr = str.Substring(2, str.IndexOf('\n') - 2);
                    str = str.Remove(0, 3 + delimstr.Length);
                }

                var delimarr = delimstr.Split(new string[] { "][" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var symbol in delimarr)
                {
                    str = str.Replace(symbol, ",");
                }
            }
            return str.Replace("[,]", "").Replace("//\n", "").Replace('\n', ',');
        }

        public static int StringCalculatorKata(string str)
        {
            if (str == "") return 0;

            str = SanitizeString(str);                

            var stringarray = str.Split(',');
                        
            if(str.Contains('-'))
                HandleNegatives(stringarray);

            return stringarray
                        .Select(strNum => int.Parse(strNum))
                        .Where(x => x<1001)
                        .Sum();
        }
    }
}
