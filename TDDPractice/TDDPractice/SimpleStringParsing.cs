using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDPractice
{
    public static class SimpleStringParsing
    {
         /// <summary>
        /// Tries to convert a string to an integer and return the result.
        /// Raises an ArgumentException in the event of invalid input.
        /// </summary>
        /// <param name="str">The string to be converted</param>
        /// <returns>The integer value matching str</returns>
        public static int StringToInt(string str)
        {
            //This is basically a re-write of int.Parse, and could be replaced with it
            int ret;
            if (int.TryParse(str, out ret))
            {
                return ret;
            }
            
            throw new ArgumentException();
        

        }
         /// <summary>
        /// Raises a general exception regardless of input. Exception message
        /// will contain a comma seperted list of all negative numbers in 'strings'
        /// </summary>
        /// <param name="strings">A collection of integer-representing strings</param>

        public static void HandleNegatives(IEnumerable<string> strings)
        {
             //Create a string of all negative numbers for use in the error message
            var negatives = 
                (from value in strings
                 where value[0] == '-'
                 select value).Aggregate((x, y) => x + "," + y);

            throw new Exception("negatives not allowed: " + negatives);
        }
         /// <summary>
        /// Takes a string that represents a list of integers seperated by arbitrary delimeters and attempts to standardize said string.
        /// The standardised output format will be a comma seperated list of numbers as a string.
        /// Acceptable input formats include:
        /// - strings where commas and/or new-lines are used as delimeters
        /// - strings which start with '//' can specify a any number of custom delimeters in square brackets eg "//[+][*]\n1*2+6"" --> 1,2,6
        /// </summary>
        /// <param name="str">A list of numbers with optional custom delimeters</param>
        /// <returns>A comma (only) seperated list of integers</returns>

        public static string SanitizeString(string str)
        {
            //Check if the user has said they want custom delimeters

            if (str.StartsWith("//"))
            {
                string delimstr;
                 //Based on the string format, find a substring that contains custom delimeters

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
             //replace 'standard' delimeters with commas

            return str.Replace("[,]", "").Replace("//\n", "").Replace('\n', ',');
        }
         /// <summary>
        /// Take a string represnting a list of numbers, cleans said string, and returns the integer
        /// sum of all values in the list.
        /// Negative numbers will raise an exception, and numbers greater than 1000 will not be counted.
        /// </summary>
        /// <param name="str">A list of numbers with arbitrary delimeters seprating elements</param>
        /// <returns>The sum of all numbers in the list between 0 and 1000 (inclusive)</returns>
        public static int StringCalculatorKata(string str)


        public static int StringCalculatorKata(string str)
        {
            if (str == "") return 0;
            //ensure the string is formatted as a comma seperated list


            str = SanitizeString(str);                

            var stringarray = str.Split(',');
                        
            if(str.Contains('-'))
                HandleNegatives(stringarray);
              //Return the sum of all numbers from 0 to 1000


            return stringarray
                        .Select(strNum => int.Parse(strNum))
                        .Where(x => x<1001)
                        .Sum();
        }
    }
}
