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

        public static int StringCalculatorKata(string str)
        {
            if (str == "") return 0;

            if(str.StartsWith("//")) str = str.Replace(str[2], ',').Replace("//,\n", "");

            var stringarray = str.Replace('\n',',').Split(',');
                        
            if(str.Contains('-'))
                HandleNegatives(stringarray);

            return stringarray.Select(strNum => int.Parse(strNum))
                              .Aggregate((x, y) => x + y);
        }
    }
}
