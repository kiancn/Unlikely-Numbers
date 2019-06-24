using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler
{
    public static class Access // static utility methods for my future self
    {

        public static int FetchInt(int tempNumber, string message) // useful for getting a positive integer from user (tempNumber can be useful for error checking)
        {
            bool baseValuesAttained = false;
            while (!baseValuesAttained)
            {
                Console.Write(message);
                string suppliedString = Console.ReadLine();
                bool numberReturned = Int32.TryParse(suppliedString, out int result);
                if (numberReturned)
                {
                    tempNumber = Int32.Parse(suppliedString);
                    if (tempNumber >= 0 && tempNumber < int.MaxValue)
                    {
                        baseValuesAttained = true;
                    }
                }
                if (!baseValuesAttained)
                {
                    Console.WriteLine("Bad values. Try again.");
                }
            }
            return tempNumber;
        }

        public static double FetchDouble(double tempNumber, string message) // useful for getting an a positive double from user (tempNumber can be useful for error checking)
        {
            bool baseValuesAttained = false;
            while (!baseValuesAttained)
            {
                Console.Write(message);
                string suppliedString = Console.ReadLine();
                bool numberReturned = Double.TryParse(suppliedString, out double result);
                if (numberReturned)
                {
                    tempNumber = Double.Parse(suppliedString);
                    if (tempNumber >= 0 && tempNumber < double.MaxValue) // some funny business here; should I never accept negative numbers?
                    {
                        baseValuesAttained = true;
                    }
                }
                if (!baseValuesAttained)
                {
                    Console.WriteLine("Bad values. Try again.");
                }
            }
            return tempNumber;
        }
        public static List<int> CombineListsNoDoubling(List<int> list1, List<int> list2, bool giveReport = false)
        {
            var combinedList = new List<int>(); // there is a combined list to be filled

            for (int i = 0; i < list1.Count; i++) // for each item in list1 ...
            {
                if (!list2.Contains(list1[i])) // if the item is NOT also in list2
                {
                    combinedList.Add(list1[i]); // add it to the combined list
                }
            }                                   // now all the values in list1 that are not also in list2 are in combinedList

            combinedList.AddRange(list2); // and now we add the items on list2 to the combinedList. No doubling

            if (giveReport)
            {
                PrintList(combinedList);
            }

            return combinedList;
        }

        public static int SumOfIntList(List<int> list)
        {
            int sumOfList = 0;

            for (int i = 0; i < list.Count; i++)
            {
                sumOfList += list[i];
            }

            return sumOfList;
        }
        public static List<int> RemoveModulusFromList(List<int> candidateList, int modulusValue, int modulusEquals)
        {
            var tempList = new List<int>();

            for (int i = 0; i < candidateList.Count; i++)
            {
                if (candidateList[i] % modulusValue == modulusEquals) // set to zero 'to select' multiples of the modulusValue
                {
                    tempList.Add(candidateList[i]);
                }
            }
            return tempList;
        }

        public static bool ApproximatelyEqual(int n1, int n2)
        {
            bool trueEnough = false;

            if (n1 == n2)
            {
                trueEnough = true;
            }
            else if (n1 == n2 + 1 | n1 == n2 - 1)
            {
                trueEnough = true;
            }
            else
            {
                trueEnough = false;
            }
            return trueEnough;

        }

        public static BigInteger Factorial(double number)
        {
            BigInteger factorial = new BigInteger(number);
            //BigInteger factorial = BigInteger.Parse(number);
            for (int i = (int)number - 1; i > 0; i--)
            {
                try
                {
                    factorial = i * factorial;
                }
                catch (OutOfMemoryException e)
                {
                    Console.WriteLine("||" +
                        "\n|| Your numbers are too great!" +
                        "\n|| Generation of list had to be terminated." +
                        "\n|| The numbers collected so far will be returned from method." +
                        "\n|| Do not trust result if this happens during calculations.\n||");
                    Console.ReadLine();
                }
            }
            if (number == 0)
            {
                factorial = 1;
            }
            Console.ResetColor();
            return factorial;
        }

        public static BigInteger Factorial(double number, bool verbose = true,int divisor = 2)
        {

            BigInteger factorial = new BigInteger(number);
            //BigInteger factorial = BigInteger.Parse(number);
            for (int i = (int)number - 1; i > 0; i--)
            {
                factorial = i * factorial;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("|| Factorial of\t{0} \t at step\t{1}  = \n ",number, i + 1);
                Console.Write("|| {0} \n", Access.Dash(i));
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("||");
                Console.ForegroundColor = ConsoleColor.Blue;
                //Console.Write(" Factorial  {0}!  at step  {0}  = \n ", i);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(" Pronounce this number and get a prize: {0} \n", factorial);
                if (i % 2 == 0)
                {
                    if (i + 1 != number) // always keep the last factorial calculated, for pleasure.
                        Console.Clear();
                }
            }
            if (number <= 0) 
            {
                factorial = 1;
            }
            Console.ResetColor();
            return factorial;
        }

        public static string Dash(double dashingDouble, int divisor = 1) //
        {
            StringBuilder dashes = new StringBuilder();
            //string dashes = "";



            if (dashingDouble > 0)
            {
                if (dashingDouble < 1)
                {
                    dashingDouble *= 100;
                }
                if (dashingDouble >= 1)
                {
                    for (int i = 1; i < dashingDouble; i++)
                    {
                        if (i % divisor == 0)
                        {
                            dashes.Append("|");
                            //dashes += "|";
                        }
                    }
                }
                if (dashingDouble < 1)
                {
                    dashes.Append("'");
                }
            }
            return dashes.ToString();
        }

        public static void PrintList(List<int> list, int breakInterval = 12) // prints a list, mostly coloring
        {
            Console.Write("List contains {0} members:\n", list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write("[ {0}, ", list[i]);
                }
                else if (i == list.Count - 1)
                {
                    Console.Write(" {0} ]\n ", list[i]);
                }
                else
                if (i % breakInterval > 0)
                {
                    Console.Write(" {0},", list[i]);
                }
                else /// create a line break if i is divisible with no remainder to the number breakInterval (so default break is every 12 items)
                {
                    Console.Write("|\n{0},", list[i]);
                }
            }
            //Console.WriteLine("\n Press enter to continue.\n");
        }

        public static void WriteAt(string s, int x, int y) // x = horizontal, y = vertical/row (the honor goes to microsoft; sometimes the help documents are good)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Write("_error occured_\n");
                return;
                //Console.Clear();
                //Console.WriteLine(e.Message);
            }
        }
    }
}
