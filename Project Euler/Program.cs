using System;

namespace Project_Euler
{
    class Program
    {
        //public static string location;

        static void Main(string[] args)
        {
               #region demonstrating bits and boobs -
               //SumOfMultiples.GenerateSumOfTwoMultiples();
               //FibonacciCalculations.DemonstrateSolution();
               //FibonacciCalculations.RandomDemonstationOfRemarkableFibonacciSequences();

               //QuickAndDirtyFactorialListCreation();
               //QuickAndDirtyFactorialListCreation("D:/DataDump/facList10.fl", false);
               //QuickAndDirtyFactorialListCreation("D:/DataDump/facList3.fl",false);
               //ASCIIDrawing.DrawExample();
               #endregion

               /// The Binomial Stochastic Calculations Program
               var bs = new BStochasticUserInteractions();
               bs.RunInteractions();

               Console.ReadLine();
        }

    }
}
