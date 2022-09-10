using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PracticalCoding_pt1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test1();
        }


        private static void Test1()
        {
            Console.WriteLine("Enter some text and press enter:");
            string InputStr = Console.ReadLine();

            if (InputStr.ToUpper() == "AUTOTEST")
            {
                RmvNonAscii("Räksmörgås, søme string");
                RmvNonAscii2("Räksmörgås, søme string");
            }
            else
            {
                RmvNonAscii(InputStr);
                RmvNonAscii2(InputStr);
            }

            Console.WriteLine($"{ System.Environment.NewLine}Have a nice day !");
            Console.ReadLine();
        }

        private static void RmvNonAscii(string sInput = "")
        {
            string msg, sOutput;

            if (!string.IsNullOrWhiteSpace(sInput) && sInput.Length > 1)
            {
                sOutput = Regex.Replace(sInput, @"[^\u0020-\u007E]", string.Empty);
                msg = $"Original string: { sInput } { System.Environment.NewLine }After removing non asci chars string: { sOutput }.";
            }
            else
            {
                msg = "You have entered empty or too short string, sorry, try again next time!";
            }

            Console.WriteLine(msg);
        }

        private static void RmvNonAscii2(string sInput = "")
        {
            string asAscii = Encoding.ASCII.GetString(
                                Encoding.Convert(
                                    Encoding.UTF8
                                    , Encoding.GetEncoding(Encoding.ASCII.EncodingName, new EncoderReplacementFallback(string.Empty), new DecoderExceptionFallback())
                                    , Encoding.UTF8.GetBytes(sInput)
                                )
                             );

            string msg = $"{System.Environment.NewLine} Using methode 2, result is: {asAscii}";
            Console.WriteLine(msg);
        }


    }
}
