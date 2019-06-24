using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler
{
    static class FactorialListActions
    {
        public static string location = "C:/UnlikelyNumbers/FactorialList.fl"; // saving and loading defaults to this location/string; change to change

        public static List<BigInteger> GenerateFileWithListOfFactorials(int maxFactorialToFetch, bool verbose = false, string specifiedlocation = "C:/UnlikelyNumbers/FactorialList.fl")
        {
            FactorialFactory facFactory = new FactorialFactory();
            List<BigInteger> listOfFactorials = facFactory.GenerateListOfFactorials(maxFactorialToFetch,verbose);
            Console.WriteLine("List created at lenght {0}", listOfFactorials.Count);
            //Console.ReadLine();

            DataListObject<BigInteger> listData = new DataListObject<BigInteger>("Factorials", "No notes. None.", listOfFactorials, "Factorial");

            if (verbose) // print list if verbose = true; not default
            {
                listData.PrintList();
            }          

            var handler = new DataListHandler<BigInteger>(listData);
            if (specifiedlocation != "C:/UnlikelyNumbers/FactorialList.fl")
            {
                location = specifiedlocation; // if a location is specified in arguments, set the public location-string to be equal to the specified one.
            }
            handler.SaveObject(location);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("File Creation Complete.");
            Console.ResetColor();
            //Console.ReadLine();
            return listOfFactorials; // returning the list of BigInts for convenience of logging, reporting, transparancy
        }

        public static DataListObject<BigInteger> LoadListOfFactorialsFromFile(string location = "C:/UnlikelyNumbers/FactorialList.fl")
        {
            DataListObject<BigInteger> listData = new DataListObject<BigInteger>();
            var handler = new DataListHandler<BigInteger>(listData);

            var loadedListDataObject = handler.LoadList(location);

            //loadedListDataObject.PrintList();
            //Console.ReadLine();
            return loadedListDataObject;
        }

        public static List<BigInteger> GetFactorialsList()
        {            
            //string location = "C:/Temp/FactorialsList/factorials.fl"; // need to use reflection to find folder location to pinpoint file location in actual build
            DataListObject<BigInteger> loaded = FactorialListActions.LoadListOfFactorialsFromFile(location);
            List<BigInteger> listOfFactorials = loaded.List;
            return listOfFactorials;
        }

          static void QuickAndDirtyFactorialListCreation(string location = "D:/DataDump/facList001.fl", bool showTextDuringListCreation = false)
          {
               Stopwatch stopwatch = new Stopwatch();
               stopwatch.Start();   // leisure/debugging purposes         

               int factorialsToCreate = Access.FetchInt(10, "Type the number of the highest factorial that you wish to create > "); // user can input number of factorials to create
               FactorialListActions.GenerateFileWithListOfFactorials(factorialsToCreate, showTextDuringListCreation, location);

               stopwatch.Stop();

               if (showTextDuringListCreation)
               {
                    BinomialStochasticVariables.factorialsList = FactorialListActions.GetFactorialsList();
                    for (int i = 0; i < BinomialStochasticVariables.factorialsList.Count; i++)
                    {
                         Console.WriteLine("Factorial of {0}: {1}", i, BinomialStochasticVariables.factorialsList[i]);
                    }
               }

               Console.WriteLine("It took this much time to complete list creation: {0}" +
                   "\nEnding sequence, probably program. All is good. Press enter.", stopwatch.Elapsed);
          }
     }
}
