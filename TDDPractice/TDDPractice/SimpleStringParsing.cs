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

            var stringarray = str.Split(',');
            int temp = 0;
            foreach (var num in stringarray)
            {
                temp += int.Parse(num);
            }
            return temp;
        }
    }
}
