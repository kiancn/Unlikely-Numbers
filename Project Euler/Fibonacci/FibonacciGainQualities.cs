using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler
{
    struct FibonacciGainQualities
    {
        public int iterationNumber;
        public int seriesMaxNumeric;
        public int sumOfFibInts;
        public int sumOfEqualFibInts;

        public FibonacciGainQualities(int iterationNumber, int seriesMaxNumeric, int sumOfFibInts, int sumOfEqualFibInts)
        {
            this.iterationNumber = iterationNumber;
            this.seriesMaxNumeric = seriesMaxNumeric;
            this.sumOfFibInts = sumOfFibInts;
            this.sumOfEqualFibInts = sumOfEqualFibInts;
        }
    }
}
