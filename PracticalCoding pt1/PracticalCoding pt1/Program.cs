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
            //TestRemoveNonAsciiFromString();
            //TestFindDeviders();
            //TestReversString();
            TestFindDuplicates();
        }


        private static void TestRemoveNonAsciiFromString()
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

            Console.WriteLine($"{ System.Environment.NewLine }Have a nice day !");
            Console.ReadLine();
        }

        public static void TestFindDeviders()
        {
            FindeDeviders(); //list all number in list divisible by given dividers
            FindeDeviders2(); //fore each number, in list, divisible by three write "Fuzz" and each number divisible by five write "Buzz"
            Console.ReadLine();
        }

        public static void TestReversString()
        {
            Console.WriteLine("Enter some text and press enter:");
            string InputStr = Console.ReadLine();
            ReversString(InputStr);

            Console.ReadLine();
        }

        public static void TestFindDuplicates()
        { 
            Console.WriteLine("Enter some text and press enter:");
            string inputStr = Console.ReadLine();

            FindDuplicatesLoop(inputStr);
            Console.WriteLine(System.Environment.NewLine);
            FindDupliactesList(inputStr);
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

            string msg = $"{ System.Environment.NewLine } Using methode 2, result is: { asAscii }";
            Console.WriteLine(msg);
        }

        private static void FindeDeviders()
        {
            Console.WriteLine("Enter upper limit for numers array and press enter:");
            string InputStr = Console.ReadLine();
            int UpperLimit = 0;
            int.TryParse(InputStr, out UpperLimit);

            Console.WriteLine("Enter deviders separated by comma and press enter:");
            InputStr = Console.ReadLine();
            List<int> Deviders = new List<int>(Array.ConvertAll(InputStr.Split(','), int.Parse));

            if (Deviders.Count > 0 && UpperLimit > 1)
            {
                List<int> NumberList = new List<int>();

                for (int number = 1; number <= UpperLimit; number++)
                {
                    foreach (int Devider in Deviders)
                    {
                        if ((number % Devider) == 0)
                        {
                            NumberList.Add(number);
                        }
                    }
                }

                if (NumberList.Count > 0)
                {
                    Console.WriteLine(String.Join(", ", NumberList));
                }
            }
        }

        private static void FindeDeviders2()
        {
            Console.WriteLine("Enter upper limit for numers array and press enter:");
            string InputStr = Console.ReadLine();
            int UpperLimit = 0;

            int.TryParse(InputStr, out UpperLimit);

            if (UpperLimit > 0)
            {
                string output = string.Empty;
                //TO DO:
                //Console.WriteLine("Enter deviders separated by comma and press enter:");
                //InputStr = Console.ReadLine();

                //List<int> DevidersList = new List<int>(Array.ConvertAll(InputStr.Split(','), int.Parse));
                List<int> NumerbLilst = new List<int>(Enumerable.Range(1, UpperLimit));

                NumerbLilst.ForEach(x => {

                    if (x % 3 == 0)
                    {
                        output = string.Concat(output, "Fuzz");
                    }

                    if (x % 5 == 0)
                    {
                        output = string.Concat(output, "Buzz");
                    }

                    output = string.Concat(output, System.Environment.NewLine);
                });

                Console.WriteLine(output);
            }
        }

        private static void ReversString(string Input = "")
        {
            char[] charArray = Input.ToCharArray();
            //Array.Reverse(charArray);
            //Console.WriteLine(new string(charArray));

            Console.WriteLine(new string(Input.Reverse().ToArray()));
        }

        private static void FindDuplicatesLoop(string input)
        {
            var duliactes = new List<string>();
            var lstStrings = input.Split(' ');

            for (int i = 0; i < lstStrings.Length; i++)
            {
                for (int j = i + 1; j < lstStrings.Length; j++)
                {
                    if (lstStrings[i].ToLower() == lstStrings[j].ToLower())
                    {
                        duliactes.Add(lstStrings[i].ToLower());
                    }
                }
            }

            Console.WriteLine(String.Join(",", duliactes));
        }

        private static void FindDupliactesList(string input)
        {
            List<string> strDuplicates = new List<string>();
            List<string> chkList = new List<string>();
            List<string> lstStrings = new List<string>(input.Split(' ').ToList());
            string result = string.Empty;

            lstStrings.ForEach(stringToCheck => {
                if (!chkList.Contains(stringToCheck))
                {
                    chkList.Add(stringToCheck);
                }
                else
                {
                    strDuplicates.Add(stringToCheck);
                }
            });

            if (strDuplicates.Count > 0)
            {
                result = String.Join(",", strDuplicates);
            }
            else
            {
                result = "No duplicates found!";
            }

            Console.WriteLine(result);
        }
    }
}
