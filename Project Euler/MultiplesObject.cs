using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler
{
    class MultiplesObject // multipleObjects are good for taking a number and delivering a list of multiples of this number up to a max number
    {
        int baseNumber;
        int maxNumber;
        List<int> multiplesList;
        private static int ceilingNumber = 0;


        public List<int> MultiplesList { get => multiplesList; }
        public int BaseNumber { get => baseNumber; }
        public static int CeilingNumber { get => ceilingNumber; }

        public MultiplesObject(int baseNumber, int maxNumber) // cooking up an object
        {
            this.baseNumber = baseNumber;
            this.maxNumber = maxNumber;
            multiplesList = new List<int>();
            multiplesList = CalculateMultiples(this.baseNumber, this.maxNumber);
        }

        public static MultiplesObject CreateAndShowMultiplesObject(ref int tempBaseNumber, ref int tempMaxNumber)
        {
            if (ceilingNumber == 0) // Only once should the ceiling value be set
            {
            tempMaxNumber = Access.FetchInt(tempMaxNumber, "\n Input a number representing the positive limit for calculating multiples: ");
                ceilingNumber = tempMaxNumber;
            }
            else
            {
                tempMaxNumber = ceilingNumber;
            }

            tempBaseNumber = Access.FetchInt(tempBaseNumber, "\n Input a positive whole number to do multiples on: ");

            var mObject = new MultiplesObject(tempBaseNumber, tempMaxNumber);
            mObject.ListMultiples();
            return mObject;
        }

        internal List<int> CalculateMultiples(int baseN, int maxN)
        {
            List<int> tempList = new List<int>();

            for (int i = 1; i < maxN; i++)
            {
                if (i % baseN == 0)
                {
                    tempList.Add(i);
                }
            }
            return tempList;
        }

        public void ListMultiples()
        {
            Console.WriteLine("\nListing all multiples of {0} from {0} to {1}", baseNumber, maxNumber);
            Console.Write("List of {0} multiples = [ ", multiplesList.Count, maxNumber);
            for (int i = 0; i < multiplesList.Count; i++)
            {
                Console.Write("{0},", multiplesList[i]);
            }
            Console.Write(" ] List ends. \n");
            
        }
    }
}
