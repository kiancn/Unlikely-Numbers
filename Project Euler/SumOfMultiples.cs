using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler
{
    public static class SumOfMultiples
    {
        public static int GenerateSumOfTwoMultiples()
        {
            int tempBaseNumber = 0;
            int tempMaxNumber = 0;

            Console.WriteLine("\n|||<> Here is the functional solution to the problem of \n" +
                "||| > the sum of multiples of any positive whole number below a maximum value \n" +
                "||| > and the multiples of any other positive whole number below the same max value.\n");
            Console.WriteLine("\n|||<> Creating first list of multiples.");
            var mObject1 = MultiplesObject.CreateAndShowMultiplesObject(ref tempBaseNumber, ref tempMaxNumber);
            Console.WriteLine("\n|||<> Creating second list of multiples.");
            var mObject2 = MultiplesObject.CreateAndShowMultiplesObject(ref tempBaseNumber, ref tempMaxNumber);
                        Console.WriteLine("\n|||<> Creating a third list consisting of the combination of first two lists, not accepting doubles.\n Press enter.");
            Console.ReadLine();
            List<int> combinedMultiples = Access.CombineListsNoDoubling(mObject1.MultiplesList, mObject2.MultiplesList, true);
            int sumOfLists = Access.SumOfIntList(combinedMultiples);
            Console.WriteLine("\n|||<>The sum of the multiples of {0} and the multiples of {1} below {2} \n " +
                                "|||<> =  {3}", mObject1.BaseNumber, mObject2.BaseNumber, MultiplesObject.CeilingNumber, sumOfLists);
            return sumOfLists;
        }
        

    }
}
