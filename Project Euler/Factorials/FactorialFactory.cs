using System;
using System.Collections.Generic;
using System.Numerics;

namespace Project_Euler
{
     class FactorialFactory // this is not a general purpose class and should be renamed at some point
     {
          //List<BigInteger> bigIntegers;

               /// <summary>
               /// 
               /// </summary>
               /// <param name="numberOfIncrements"></param>
               /// <param name="verbose"></param>
               /// <returns></returns>
          internal List<BigInteger> GenerateListOfFactorials(int numberOfIncrements, bool verbose = false)
          {
               var list = new List<BigInteger>(); // list that will be returned upon method completion; for factorials

               BigInteger tempFactorial = 1;

               for (int i = 0; i < numberOfIncrements; i++)
               {
                    try
                    {
                         if (verbose)
                         {
                              tempFactorial = Access.Factorial((double)i, true);
                         }
                         else
                         {
                              tempFactorial = Access.Factorial((double)i);
                         }
                         list.Add(tempFactorial);
                    }
                    catch (OutOfMemoryException e) // smooth exception handling, maybe
                    {
                         Console.ForegroundColor = ConsoleColor.Red;
                         Console.WriteLine("||\n|| Your numbers are too great! \n|| Generation of list had to be terminated.\n||\n" +
                             "The partial list created WILL be returned as is. This is normal, almost anticipated.\n|| ");
                         Console.WriteLine("|| Message from Debugger: {0}", e.Message);
                         Console.ResetColor();
                         break;
                    }

               }

               Console.WriteLine("List successfully written");

               return list;
          }

     }
}
