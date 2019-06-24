using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler
{
    class FibonacciSeries // is an object able to create a list of fibonacci numbers
    {       
        public List<int> fibonacciSeries;
        public int iterationReached = 0;

        public FibonacciSeries()
        {
            this.fibonacciSeries = CalculateSeries();
        }

        public List<int> CalculateSeries(int baseNumber = 1, int maxNumericValue = 4000000)
        {
            int newValue = baseNumber;
            int recentValue = baseNumber;
            int result = 0;
            List<int> series = new List<int>();

            for (int i = 0; i < maxNumericValue; i++) // the is no chance in math that maxNumericValue will be reached by i
            {                
               result = recentValue + newValue; // the actual f.sequence incrementing
             
                if (result >= maxNumericValue) // if recentvalue above max value quit the cycle.
                {
                    return series;
                }

                series.Add(result); // if the recent value was not higher than max, add it to list

                recentValue = newValue; // the new becomes the old
                newValue = result; // the actual f.sequence incrementing; remembering that now the result value is the mostest new one
                iterationReached = i;
            }

            return series;
        }

        
    }
}
