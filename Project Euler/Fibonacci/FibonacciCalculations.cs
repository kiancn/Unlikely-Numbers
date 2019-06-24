using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler
{
    class FibonacciCalculations
    {
        public static int CalculateFibonacciNumber(int sequenceIncrement)
        {

            int newValue = 1;
            int recentValue = 1;
            int result = 0;
            List<int> series = new List<int>();

            for (int i = 0; i < sequenceIncrement - 1; i++) // the is no chance in math that maxNumericValue will be reached by i
            {
                result = recentValue + newValue; // the actual f.sequence incrementing
                recentValue = newValue;
                newValue = result; // the actual f.sequence incrementing; remembering that now the new value is the recent one

            }
            return result;
        }

        public static List<FibonacciGainQualities> GainPropertyTest(int testSize, int numberOfRounds = 5, int productFactor = 10, bool trueADDorFalsePRODUCT = false,bool showFlavorText = true)
        {
            int lastIteration = 0;
            List<FibonacciGainQualities> interestingNumbers = new List<FibonacciGainQualities>();
            int seriesMaxNumeric = testSize;

            for (int i = 0; i < numberOfRounds; i++)
            {
                var fibSeries = new FibonacciSeries { }; // create Fibonacci Series Object
                fibSeries.fibonacciSeries = fibSeries.CalculateSeries(1, seriesMaxNumeric); // generate appropriately capped Fib series
                int sumOfFibInts = Access.SumOfIntList(fibSeries.fibonacciSeries); // generate/get the sum of the found series
                List<int> equalFibs = Access.RemoveModulusFromList(fibSeries.fibonacciSeries, 2, 0); // generate the list containing only equal results
                int sumOfEqualFibInts = Access.SumOfIntList(equalFibs); // get/generate the sum of the equal-results-list

                if (Access.ApproximatelyEqual(sumOfFibInts / 2, sumOfEqualFibInts)) // if the sum of the fibonacci series bounded at x and the same series including only equal results
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    
                    /// if a) current reached fiq-seq-iteration-number (FSIN) 
                    /// is NOT equal to last signifacnt iteration, 
                    /// and b) if showflavortext=true - display flavor text:
                    if (fibSeries.iterationReached != lastIteration && showFlavorText) 
                    {
                        Console.WriteLine(">>The Fibonacci Series  go up to {0}  <<\n", seriesMaxNumeric);
                        Access.PrintList(fibSeries.fibonacciSeries, 5);
                        Console.Write("\n>>The sum of Fibonacci series up to is {0}  <<\n", seriesMaxNumeric);
                        Access.PrintList(equalFibs, 5);
                        Console.Write(">>The sum of the Fibonacci Series including only equal results is {0}  <<<\n", sumOfEqualFibInts);
                        Console.WriteLine("Analysis:\n All fibs minus the sum of equal fibs: {0} - {1} = {2}\n" +
                                          " All fibs divided by two:              {0} / 2 = {3}\n", sumOfFibInts, sumOfEqualFibInts, sumOfFibInts - sumOfEqualFibInts, sumOfFibInts / 2);

                    }
                    var interestingNumberSet = new FibonacciGainQualities(fibSeries.iterationReached, fibSeries.fibonacciSeries.Last<int>(), sumOfFibInts, sumOfEqualFibInts);
                    if (interestingNumbers.Count < 1) // if the list is empty, simply add new FibonacciGainQualities item to it
                    {
                        interestingNumbers.Add(interestingNumberSet);
                    }
                    else if (interestingNumbers.Last().iterationNumber != interestingNumberSet.iterationNumber) // else, make sure a relevantly similar item is not already on the list; then add it                        
                    {
                        interestingNumbers.Add(interestingNumberSet);
                        lastIteration = fibSeries.iterationReached;
                    }
                }
                else
                {
                    if (fibSeries.iterationReached != lastIteration && showFlavorText)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nSeries with max {0} yielded result not of interest.", seriesMaxNumeric);
                        Console.WriteLine("\n All fibs minus the sum of equal fibs: {0} - {1} = {2}" +
                        "\n All fibs divided by two:              {0} / 2 = {3}\n", sumOfFibInts, sumOfEqualFibInts, sumOfFibInts - sumOfEqualFibInts, sumOfFibInts / 2);
                        lastIteration = fibSeries.iterationReached;
                    }
                }
                Console.ResetColor();


                if (!trueADDorFalsePRODUCT)
                {
                    seriesMaxNumeric = seriesMaxNumeric * productFactor;
                    if (seriesMaxNumeric * productFactor >= Int32.MaxValue || seriesMaxNumeric * productFactor < 0)
                    {
                        Console.WriteLine("Incrementing series of Fibonacci Number ended to prevent value overflow error,\n" +
                            "with last functional max being {0}", seriesMaxNumeric);
                        Console.WriteLine("Info: << seriesMaxNumeric * productFactor >= Int32.MaxValue >> || << seriesMaxNumeric * productFactor < 0 >> {0}\n", seriesMaxNumeric);
                        Console.WriteLine("[{0}] Rounds done. Returning list of {1} interesting numbers.\n", i, interestingNumbers.Count);
                        break;
                    }
                }
                else
                {
                    seriesMaxNumeric = seriesMaxNumeric + productFactor;
                }
                if (/*i%100==0 |*/ i == numberOfRounds-1) // chopping up the number of feedback reports the user gets, here by a factor 10
                {
                    Console.WriteLine("[{0}] Rounds done. Returning list of {1} interesting numbers", i, interestingNumbers.Count);
                }
                
            }
            //Console.WriteLine("[{0}] Rounds done. Returning list of {1} interesting numbers", i, interestingNumbers.Count);
            return interestingNumbers;
        }

        public static void ListFoundNumbers(List<FibonacciGainQualities> listOfInterestingNumbers)
        {
            Console.WriteLine("Listing the {0} found interesting relative numbers:", listOfInterestingNumbers.Count);
            for (int i = 0; i < listOfInterestingNumbers.Count; i++)
            {
                Console.WriteLine("||  Ceiling numeric {0} ||  Iteration #{1} ||   Fib#{1}: {2} ||   Sum of series: {3} || Sum of only equals: {4} "
                    , listOfInterestingNumbers[i].seriesMaxNumeric, listOfInterestingNumbers[i].iterationNumber, FibonacciCalculations.CalculateFibonacciNumber(listOfInterestingNumbers[i].iterationNumber), listOfInterestingNumbers[i].sumOfFibInts, (double)listOfInterestingNumbers[i].sumOfEqualFibInts);

            }
        }

        public static int PropertyTest(int testSize, int resultValue = 0) //
        {
            int seriesLength = testSize;
            var fibSeries = new FibonacciSeries { };
            fibSeries.fibonacciSeries = fibSeries.CalculateSeries(1, seriesLength);
            int sumOfFibInts = Access.SumOfIntList(fibSeries.fibonacciSeries);
            List<int> equalFibs = Access.RemoveModulusFromList(fibSeries.fibonacciSeries, 2, 0);
            int sumOfEqualFibInts = Access.SumOfIntList(equalFibs);

            Console.WriteLine("\nThe Fibonacci Series  go up to {0}\n", seriesLength);
            Access.PrintList(fibSeries.fibonacciSeries, 5);
            Console.Write("The sum of Fibonacci series up to is {0}\n", seriesLength);
            Access.PrintList(equalFibs, 5);
            Console.Write("The sum of the Fibonacci Series including only equal results is {0}\n", sumOfEqualFibInts);
            Console.WriteLine("\n Lets have a look:" +
                            "\n All fibs minus the sum of equal fibs: {0} - {1} = {2}" +
                            "\n All fibs divided by two:              {0} / 2 = {3}\n\n", sumOfFibInts, sumOfEqualFibInts, sumOfFibInts - sumOfEqualFibInts, sumOfFibInts / 2);

            Console.ReadLine();
            return seriesLength;
        }

        public static void RandomDemonstationOfRemarkableFibonacciSequences()
        {
            DemonstrateSolution();


            List<FibonacciGainQualities> listOfSmallInterestingNumbers;
            List<FibonacciGainQualities> listOfGrandInterestingNumbers;

            Console.WriteLine("Processing Fibonacci series, looking for sums fibonacci numbers with the property that\n" +
                "half that sum number is equal to the sum of the same series including only equal fibonacci number.\n\n" +
                "The first couple of them look like this:\n" +
                "Here starting with a ceiling of 10 incrementing that ceiling tenfold.\n" +
                "A hundred test are planned, but fewer are done because of Int32 size limits.");
            listOfSmallInterestingNumbers = FibonacciCalculations.GainPropertyTest(10, 100, 2,false, false);
            Console.WriteLine("List of fib numbers found doing a short sequence with a *2 increment to checked highest Fibinonacci number value");
            ListFoundNumbers(listOfSmallInterestingNumbers);
            //Console.ReadLine();
            //listOfGrandInterestingNumbers = FibonacciCalculations.GainPropertyTest(40, 600, 10, false, false);



            //Console.WriteLine("");
            //Console.WriteLine("List of productively found interesting fibonacci numbers");
            //ListFoundNumbers(listOfGrandInterestingNumbers);
        }

        public static void DemonstrateSolution() // Solution bounded to the max by 4.000.000, meaning that only fib numbers below 4.000.000 are included
        {
            var fibSeq = new FibonacciSeries();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("This is the solution to problem 2 on the Euler Project.\n" +
                "But mainly I enjoy the funny recurring property of many limited fabunacci series!");

            //Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            int sumOfFib = Access.SumOfIntList(fibSeq.fibonacciSeries);
            Console.WriteLine("\n What is the sum of every Fibonacci numbers under 4.000.000?\n" +
    "<><> The answer is {0}", sumOfFib);
            //Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Access.PrintList(fibSeq.fibonacciSeries, 5);

            var modulatedList = Access.RemoveModulusFromList(fibSeq.fibonacciSeries, 2, 0);
            int sumOfEqualFib = Access.SumOfIntList(modulatedList);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nThe solution to problem 2 on Project Euler, namely " +
                "\nwhat is the sum of the even Fibonacci numbers under 4.000.000?\n" +
                "<><>The answer is {0} . \n\n", sumOfEqualFib);
            Console.ForegroundColor = ConsoleColor.Blue;
            Access.PrintList(modulatedList, 5);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nIt seems a funny property emerges. Thesis: half the sum of all \n" +
                "fibonacci numbers is roughly equal to the sum of all equal fibonacci numbers.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(
                "Lets have a look:" +
                "\n All fibs minus the sum of equal fibs: {0} - {1} = {2}" +
                "\n All fibs divided by two:              {0} / 2 = {3}\n\n", sumOfFib, sumOfEqualFib, sumOfFib - sumOfEqualFib, sumOfFib / 2);
            Console.ResetColor();
            Console.ReadLine();
        }

    }
}
