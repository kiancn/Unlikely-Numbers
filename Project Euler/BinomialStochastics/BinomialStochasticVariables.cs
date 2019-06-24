using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler
{
    class BinomialStochasticVariables
    {
        public static List<BigInteger> factorialsList = null;   // used for cpu-light factorialCalculations

        // middelværdi
        public static double My(XVar xVar)
        {
            double middleValue = xVar.number * xVar.probability;
            return middleValue;
        }
        public static double Variance(XVar xVar) // pseudo-variance; my binomial alternative to Variance Var(X) proper... look it up
        {
            double variance = xVar.number * xVar.probability * (1 - xVar.probability);
            return variance;
        }
        // Spredning // Deviation
        public static double Deviation(XVar xVar)
        {
            double deviation = Math.Sqrt(Variance(xVar));
            return deviation;
        }

        public static double BinomialCoefficient(XVar xVar, double numberOfSuccess)
        {
            BigInteger bCoef = Access.Factorial(xVar.number) / (Access.Factorial(numberOfSuccess) * Access.Factorial(xVar.number - numberOfSuccess));
            double calculatedBCoefficient = (double)bCoef;

            return calculatedBCoefficient;
        }

        public static double BinomialCoefficient(XVar xNumber, /*int*/ double rate, List<BigInteger> listOfFactorials) // everything can go wrong if the list is not properly setup, so make sure :)
        {
            if (factorialsList == null || factorialsList.Count <= xNumber.number) // if no list of factorials are defined, run the manually factorializing version of the method, get result and proceed...
            {
                var alternativeBinCoefCalculation = BinomialCoefficient(xNumber, rate);
                if (factorialsList.Count <= xNumber.number)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("*");
                    Console.ResetColor();
                }
                return alternativeBinCoefCalculation;
                //factorialsList = FactorialListActions.GetFactorialsList();
                //listOfFactorials = factorialsList;
            } 

            //BigInteger bCoef = Access.Factorial(xVar.number) / (Access.Factorial(factorialIndex) * Access.Factorial(xVar.number - factorialIndex));
            //BigInteger bCoef = listOfFactorials[(int)numberFactorial.number] / listOfFactorials[rateFactorial] * listOfFactorials[(int)numberFactorial.number-rateFactorial]; // broken
            BigInteger bCoef = factorialsList[(int)xNumber.number] / (factorialsList[(int)rate] * factorialsList[(int)xNumber.number - (int)rate]); // workz
            double calculatedBCoefficient = (double)bCoef;

            return calculatedBCoefficient;
        }

        // returns the likelyhood of exactly rateOfSuccess success's given xVar.number of elements and an xVar.probability of success
        // the name is short for binomial Point distributed function
        public static double binomPdf(XVar xVar, double rateOfSuccess, bool decorate = false)
        {
            List<BigInteger> proxyList = null;
            double likelyhood = BinomialCoefficient(xVar, rateOfSuccess, proxyList) * Math.Pow(xVar.probability, rateOfSuccess) * Math.Pow((1 - xVar.probability), xVar.number - rateOfSuccess);
            if (decorate) { Console.WriteLine("binomPdf(number = {0}, probability = {1}, rate = {2}) = {3}", xVar.number, xVar.probability, rateOfSuccess, likelyhood); }
            return likelyhood;
        }

        // returns the likelyhood of equal to or less rateOfItems# success's given xVar.number of elements and an xVar.probability of success
        // the name is short for binomial Cumulative distributed function
        public static double binomCdf(XVar xVar, double rateOfSuccess, bool decorate = false)
        {
            double cumulativeLikelyhood = 0;

            for (int i = 0; i <= rateOfSuccess; i++)
            {
                double tempPdfNumber;
                if (decorate) { tempPdfNumber = binomPdf(xVar, i, true); } else { tempPdfNumber = binomPdf(xVar, i); }

                if (tempPdfNumber <= 1 && tempPdfNumber >= 0)
                {
                    cumulativeLikelyhood += tempPdfNumber;
                }

            }
            if (decorate)
            {
                Console.WriteLine("binomCdf(number = {0}, probability = {1}, rate = {2}) = {3}", xVar.number, xVar.probability, rateOfSuccess, cumulativeLikelyhood);
            }

            return cumulativeLikelyhood;
        }

        /// returns the likelyhood
        // returns the likelyhood of equal to or less rateOfItems# success's given xVar.number of elements and an xVar.probability of success
        // the name is short for binomial Inverted cumulative distributed function.
        // Notice that the binomCdf has the 'i - 1' detail: Probability(X = rate of success <=i) == Probability(X = rate of success >= i-1) 
        public static double binomICdf(XVar xVar, double rateOfLeastOrEqualSuccess, bool decorate = false)
        {
            double cumulativeLikelyhoodOfAtLeast;
            cumulativeLikelyhoodOfAtLeast = 1 - binomCdf(xVar, rateOfLeastOrEqualSuccess - 1);
            if (decorate) { Console.WriteLine("binomICdf(number = {0}, probability = {1}, rate = {2}) = {3}", xVar.number, xVar.probability, rateOfLeastOrEqualSuccess, cumulativeLikelyhoodOfAtLeast); }
            return cumulativeLikelyhoodOfAtLeast;

        }
    }
}
