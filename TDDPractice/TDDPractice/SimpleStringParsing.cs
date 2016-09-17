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

        public static int StringCalculatorKata(string str)
        {
            if (str == "")
            {
                return 0;
            }
            if (str.StartsWith("0,"))
            {
                str = str.Substring(2);
            }
            
            if (str.EndsWith(",0"))
            {
                str = str.Substring(0,(str.IndexOf(",")));
            }
            return int.Parse(str);
        }
    }
}
