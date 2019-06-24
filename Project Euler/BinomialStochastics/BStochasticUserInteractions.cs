using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler
{
     /// <summary>
     /// User I/O interactions on binomial stochastic variables.
     /// Initialize interactions with RunInteractions()
     /// </summary>
     class BStochasticUserInteractions
     {
          private XVar xVar = new XVar { number = 0, probability = 0.5 };
          public int Rate { get; set; } // property carrying the [r]ate of success used in calculations                                        

          int sentOnTask = 0; // when a method 'sends out' a method (from this class specifically) as a task (runs that method to get a result)
                              // add +1 to sentOnTask; if sentOnTask is greater than 0 when ExitMethod() is run, it means that the method should not 
                              // run the MainUserLoop() - but return to the caller method.                              
                              // NB: when I forget; it's implementation is best understood by starting with CheckValuesForBadness()

          internal void RunInteractions()
          {               
               InitializeFactorialsList();
               ConsoleUtils.WindowAdjust(5);
               Splash();
               MainUserLoop();
          }



          internal void InitializeFactorialsList() // if the factorials-list is not initialized, all calculations will be done 'from scratch' at runtime
          {
               BinomialStochasticVariables.factorialsList = FactorialListActions.GetFactorialsList();
          }

          public void Splash()
          {
               Console.ForegroundColor = ConsoleColor.DarkGray;
               Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||||||||||| Hand-crafted by KCN, 2019");
               Console.ForegroundColor = ConsoleColor.Blue;
               Console.Write("" +
                   "|||||||||||||||||||||||||||||||||||||||||||||||||||||||||\n" +
                   "|||||||||||||||||||||||||||||||||||||||||||||||||||||||||\n" +
                   "||||||||||||||||||||||||||||||||||||||||||||||||");
               Console.ForegroundColor = ConsoleColor.DarkMagenta;
               Console.Write("\t\tIf the unlikely is not in some sense real\n");
               Console.ResetColor();
               Console.Write("|||||||||||||||||||||||||||||||||||||||");
               Console.ForegroundColor = ConsoleColor.DarkMagenta;
               Console.Write("\t\t\t\tour predictions, plans and hopes would be about nothing. Which is weird.\n");
               Console.ResetColor();
               Console.Write("|||||||||||||||||||||||||\n");
               Console.ForegroundColor = ConsoleColor.DarkGray;
               //Console.Write("\t\t\t\t\tAnd what does it mean that something\n");
               Console.ResetColor();
               Console.Write("|||||||||||||||||\n");
               Console.ForegroundColor = ConsoleColor.DarkGray;
               //Console.Write("\t\t\t\t\t\t\twith the unknown.\n");
               Console.ResetColor();
               Console.Write("||||||||||||\n" +
                   "|||||||||\n" +
                   "||||||\n");
               Console.ForegroundColor = ConsoleColor.Blue;
               Console.Write("||||| Welcome to"); Console.ForegroundColor = ConsoleColor.Green; Console.Write(" Unlikely Numbers!\n");
               Console.ForegroundColor = ConsoleColor.Blue;
               Console.Write("||||\t\t\t"); Console.Write("v 0.22 \n");
               Console.ForegroundColor = ConsoleColor.Blue;
               Console.Write("|||\t\t"); Console.ForegroundColor = ConsoleColor.Green; Console.Write("by Kian C. Nielsen \n");
               Console.ForegroundColor = ConsoleColor.Blue;
               Console.Write("||| A random number of options await you. \n|||\n" +
                               "||| ATM the program will do numbers on binomial likelyhoods.\n" +
                               "||| Next update will feature better explanations...\n||\n" +
                               "||| And I might make a regular windows user friendly version (WPF) of the same functionality,\n" +
                               "||| because I do realize that most people promptly give up in a combination\n" +
                               "||| of boredom and fear of the unknown when they see a console window.\n|| \n");
               Console.ForegroundColor = ConsoleColor.Gray;
               Console.WriteLine("||| To export; select text and copy - works fine.\n||");

               Console.ResetColor();
          }


          internal void MainUserLoop()
          {
               Console.WriteLine("|||You now have the following options:\n" +
                   "||Press [1] Define a new bionomial stochastic variable:\t\t X~b(n,p) (here an XVar) \n" +
                   "||Press [2] Work out different properties of your XVar.\n" +
                   "||Press [3] Work with the Point Distributive Function:\t\t X~b(n,p) P(X=r) :|: binomPdf(n,p,r)\n" +
                   "||Press [4] Work with the Cumulative Distributive Function:\t P(X<=r) & P(X>=r) :|: binomCdf(n,p,r)\n" +
                   "||Press [0] To end the stochastic fun.");
               int response = Access.FetchInt(-1, "||> ");
               Console.WriteLine("||> {0} selected.", response);
               switch (response)
               {
                    case 1:
                         CreateXVar();
                         break;
                    case 2:
                         WorkWithPropertiesOfXVar();
                         break;
                    case 3:
                         WorkWithPointChance();
                         break;
                    case 4:
                         WorkWithCumulativeChance();
                         break;
                    case 0:
                         return;
                    default:
                         MainUserLoop();
                         return;
               }
          }

          internal void CreateXVar()
          {
               Console.WriteLine("||\n||| Creating an Xvar binomial stochastic variable: X~b( n , p )\n" +
                   "||");
               double n, p;
               Console.ForegroundColor = ConsoleColor.White;
               n = Access.FetchDouble(2, "|| Please input the number variable [n] >> ");
               p = Access.FetchDouble(2, "|| Please input the probability variable ( 0,0 , ... , 1,0) [p] >> ");
               xVar = new XVar { number = n, probability = p };
               Console.ForegroundColor = ConsoleColor.Blue;
               Console.WriteLine("||\n||| Created XVar: \tX~b( {0} , {1} )\n||", xVar.number, xVar.probability);
               Console.ResetColor();
               MethodExit();
          }

          internal void WorkWithPointChance()
          {
               Console.WriteLine("|||Working with the Point Distributive Function:\n" +
             "||Press [1] Calculate the probability of a single rate [r] of success:\t X~b( n , p ) P( X = r ) \n" +
             "||Press [2] Get list of probability of all possible rates of success: \t X~b( n , p ) P( X = r ) [r = [0,1..,n] .\n" +
             "||Press [0] To go back to main options.");
               int response = Access.FetchInt(-1, "||> ");
               Console.WriteLine("||> {0} selected.\n||", response);
               switch (response)
               {
                    case 1:
                         ChanceOfSingleRateSuccess();
                         break;
                    case 2:
                         ListChanceOfAllSingleRatesSuccess();
                         break;
                    default:
                         MainUserLoop();
                         return;
               }

               MethodExit();
          }

          private void ChanceOfSingleRateSuccess()
          {
               Console.WriteLine("|||Calculate the chance of a specific rate [r] of success\n" +
           "|| given the probability of a success [p] among [n] elements:\t X~b(n,p) P(X=r)\n||");

               CheckValuesForBadness();
               Rate = FetchRate();

               Console.WriteLine("||\n||| The likelyhood of {0} success' = {1}% : X~b( {2} , {3} ) P(X = {0}) = {4}\n||",
                    Rate, 100 * Math.Round(BinomialStochasticVariables.binomPdf(xVar, Rate), 3), xVar.number, xVar.probability,
                    Math.Round(BinomialStochasticVariables.binomPdf(xVar, Rate), 5));
               Console.WriteLine("|| Enter to continue.");
               Console.ReadLine();
          }

          private void ListChanceOfAllSingleRatesSuccess()
          {
               Console.WriteLine("|||\n|| List of the chances of all specific rates [r] of success\n" +
           "|| given the probability of a success [p] among [n] elements: X~b(n,p) P(X=r)\n||");

               CheckValuesForBadness();

               bool longList = DecideListLength();

               for (int i = 0; i <= xVar.number; i++)
               {
                    double binomPdf = BinomialStochasticVariables.binomPdf(xVar, i);

                    if (binomPdf > 0.0002 | longList)
                    {
                         ColorCodeIntervals(binomPdf);

                         Console.WriteLine("||| Chance of {0} success = {1}% :\tX~b( {2} , {3} ) P(X = {0}) = {4}\t\t {5}",
                                             i, 100 * Math.Round(binomPdf, 4), xVar.number, xVar.probability,
                                             Math.Round(binomPdf, 5), Access.Dash(binomPdf));
                    }
               }
               Console.ResetColor();
               Console.ReadLine();
          }

          private static void ColorCodeIntervals(double binom) // this method needs to be backed up by a Console.ResetColor() after the look
          {
               Console.ForegroundColor = ConsoleColor.Green;
               if ((binom <= 0.051)) { Console.ForegroundColor = ConsoleColor.Blue; }
               if ((binom <= 0.025)) { Console.ForegroundColor = ConsoleColor.DarkRed; }
               if ((binom >= 0.949)) { Console.ForegroundColor = ConsoleColor.Magenta; }
               if ((binom >= 0.975)) { Console.ForegroundColor = ConsoleColor.Cyan; }
          }

          private static bool DecideListLength()
          {
               Console.WriteLine("|| Your list might be long, would you like to chop off very unlikely results? [ ~< 0,025% ]\n" +
                   "|| Press [1] for shorter list.\n" +
                   "|| Press [2] for longer list.");
               int response = Access.FetchInt(-1, "|| > ");
               Console.WriteLine("|| > {0} selected.\n|| ", response);
               bool longList = true;
               switch (response)
               {
                    case 1:
                         longList = false;
                         break;
                    case 2:
                         longList = true;
                         break;
                    default:
                         break;
               }

               return longList;
          }

          void WorkWithPropertiesOfXVar()
          {
               Console.WriteLine("||\n||| Working out useful properties of supplied XVar.");
               CheckValuesForBadness();

               double tempMy = BinomialStochasticVariables.My(xVar);
               Console.WriteLine("||\n|| > Expected value E(X) or my: X~b( n , p ) E(X) = n * p");
               Console.ForegroundColor = ConsoleColor.Green;
               Console.WriteLine("||| Expected value E(X) or my:\n||| > X~b( {0} , {1} ) E(X) = {0} * {1} = {2}",
                   xVar.number, xVar.probability, tempMy);
               Console.ResetColor();

               double tempVariance = BinomialStochasticVariables.Variance(xVar);
               Console.Write("||\n|| > Binomial Variance Var(X): X~b( n , p )  Var(X) = n * p * (1 - p)");
               Console.ForegroundColor = ConsoleColor.DarkBlue;
               Console.Write("\t\tI made this up, but the values it produces make sense; \n");
               Console.ForegroundColor = ConsoleColor.Green;
               Console.Write("|| Variance Var(X):");
               Console.ForegroundColor = ConsoleColor.DarkBlue;
               Console.Write("\t\t\t\t\t\t\t\tand the sense of the formula is parallel to variance proper, Var(X).\n");
               Console.ForegroundColor = ConsoleColor.Green;
                   Console.Write("||| > X~b( {0} , {1} )  Var(X) = {0} * {1} * (1 - {1}) = {2}\n",
                   xVar.number, xVar.probability, Math.Round(tempVariance, 7));
               Console.ResetColor();

               double tempDeviation = BinomialStochasticVariables.Deviation(xVar);
               Console.WriteLine("||\n|| > Mean Deviance / sigma(X): X~b( n , p )  sigma(X) = squareroot of Var(x) \n" +
                   "|| So  sigma(X) = squareroot of (n * p * (1 - p))");
               Console.ForegroundColor = ConsoleColor.Green;
               Console.WriteLine("|| Deviation sigma(X):" +
                   "\n||| > X~b( {0} , {1} )  Var(X) = sqr({2}) = squareroot of ( {0} * {1} * (1 - {1} )) = {3}",
                   xVar.number, xVar.probability, Math.Round(tempVariance, 3), Math.Round(tempDeviation, 7));
               Console.ResetColor();
               //Console.WriteLine("||");

               double negStandardDeviation = Math.Round(tempMy - tempDeviation, 2);
               double neg2ndDeviation = Math.Round(tempMy - tempDeviation * 2, 2);
               double neg3rdDeviation = Math.Round(tempMy - tempDeviation * 3, 2);
               double posStandardDeviation = Math.Round(tempMy + tempDeviation, 2);
               double pos2ndDeviation = Math.Round(tempMy + tempDeviation * 2, 2);
               double pos3rdDeviation = Math.Round(tempMy + tempDeviation * 3, 2);

               Console.WriteLine("" +
                   "||\n|| > Normal Distribution for X ~b( {0} , {1} ):\n" +
                   "|| Case: ", xVar.number, xVar.probability);
               Console.ForegroundColor = ConsoleColor.DarkGreen;
               Console.WriteLine(
               "|| \tLow --- \tLow --  \tLow - \t\tMean \t\tHigh + \t\tHigh ++ \tHigh +++ ");
               Console.ForegroundColor = ConsoleColor.Green;
               if (neg3rdDeviation <= 0) { Console.ForegroundColor = ConsoleColor.DarkMagenta; } // to represent the impossibility of a negative deviation, go dark magenta
               Console.Write("|||\t{0}", neg3rdDeviation);
               if (neg2ndDeviation <= 0) { Console.ForegroundColor = ConsoleColor.DarkMagenta; } // to represent the impossibility of a negative deviation, go dark magenta
               Console.Write("\t\t{0}", neg2ndDeviation);
               Console.ForegroundColor = ConsoleColor.Green;
               Console.Write("\t\t{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\n",
                   negStandardDeviation, tempMy, posStandardDeviation, pos2ndDeviation, pos3rdDeviation);
               Console.ResetColor();

               double confidenceCoefficient = Math.Sqrt(xVar.probability * (1 - xVar.probability)) / Math.Sqrt(xVar.number);
               double confidenceIntervalLowPoint = xVar.probability - 2 * confidenceCoefficient;
               double confidenceIntervalHighPoint = xVar.probability + 2 * confidenceCoefficient;
               //double confidenceIntLow = 0;

               Console.WriteLine("" +
                   "||\n||| > 95% Confidence Interval 'using' XVar ~b( n = {0} , p = {1} );\n" +
                   "|| where {0} is 'interpreted' as sample size \t\t[n] = {0} \t[ Number of cases included in experiment. ]\n" +
                   "|| and {1} is 'treated' as estimated likelyhood\t[p] = {1}\n" +
                   "|| [ [p] of your XVar is treated as if:\t\t\t[p] = rate of queried quality found in sample / sample size ]", Math.Round(xVar.number, 2), Math.Round(xVar.probability, 2));
               //Console.ForegroundColor = ConsoleColor.Green;
               Console.Write("" +
                   "|| Assuming that the sample size {0} is representative of the total population in question,\n" +
                   "|| it might be concluded with confidence that the actual percentage in that total population is\n||| " +
                   "\t\t\t\t\tbetween\t", xVar.number);
               Console.ForegroundColor = ConsoleColor.DarkGreen;
               Console.Write("\t\t{0}%\t", Math.Round(confidenceIntervalLowPoint * 100, 2));
               Console.ResetColor();

               Console.Write(" and\t");

               Console.ForegroundColor = ConsoleColor.DarkGreen;
               Console.Write("{0}%.\n", Math.Round(confidenceIntervalHighPoint * 100, 2));
               Console.ResetColor();

               Console.Write("||\n");
               Console.ForegroundColor = ConsoleColor.DarkBlue;
               Console.Write("|| End of list. Press enter to continue.\n");
               Console.ReadLine();
               Console.ResetColor();

               MethodExit();

          }

          void WorkWithCumulativeChance()
          {
               Console.WriteLine("|||Working with the Cumulative Distributive Function:\n" +
                               "||Press [1] Calculate the probability of AT MOST rate [r] of success:\t\t X~b( n , p ) P( X <= r ) \n" +
                               "||Press [2] Calculate the probability of NO LESS THAN rate [r] of success: \t X~b( n , p ) P( X >= r )\n" +
                               "||Press [3] List cumulative chances of AT MOST [r] successes of (all [r]): \t X~b( n , p ) P( X <= r ) [r = 0,..,n] \n" +
                               "||Press [4] List cumulative chances of NO LESS [r] successes (all [r]): \t X~b( n , p ) P( X >= r ) [r = 0,..,n] \n" +
                               "||Press [0] To go back to main options.");
               int response = Access.FetchInt(-1, "||> ");
               Console.WriteLine("||> {0} selected.\n||", response);
               switch (response)
               {
                    case 1:
                         CalculateChanceOfAtLeastRateSuccess();
                         break;
                    case 2:
                         CalculateChanceOfNoLessThanRateSuccess();
                         break;
                    case 3:
                         ListOfBinomCdf();
                         break;
                    case 4:
                         ListOfBinomICdf();
                         break;
                    default:
                         MainUserLoop();
                         return;
               }

               Console.WriteLine("Thank you for working with Cumulative Chance!");

               MethodExit();
          }

          void CalculateChanceOfAtLeastRateSuccess()
          {
               Console.WriteLine("|||Calculate the probability of EQUAL OR LESS than rate [r] of success: X~b( n , p ) P( X <= r )\n" +
                                   "|| given the probability [p] of a success among [n] elements: X~b(n,p) P(X=r)\n||");

               CheckValuesForBadness();
               Rate = FetchRate();

               Console.WriteLine("||\n||| Chance of no more than {0} success' = {1}% : X~b( {2} , {3} ) P(X <= {0}) = {4}\n||",
                    Rate, 100 * Math.Round(BinomialStochasticVariables.binomCdf(xVar, Rate), 5), xVar.number, xVar.probability,
                    Math.Round(BinomialStochasticVariables.binomCdf(xVar, Rate), 5));
               Console.WriteLine("|| Enter to continue.");
               Console.ReadLine();
          }

          void CalculateChanceOfNoLessThanRateSuccess()
          {
               Console.WriteLine("|||Calculate the chance of EQUAL TO OR MORE than rate [r] of success: X~b( n , p ) P( X >= r )\n" +
                                   "|| given the probability of a success [p] among [n] elements: X~b(n,p) P(X=r)\n||");

               CheckValuesForBadness();
               Rate = FetchRate();

               Console.WriteLine("||\n||| Chance of {0} or more success' = {1}% : X~b( {2} , {3} ) P(X >= {0}) = {4}\n||",
                    Rate, 100 * Math.Round(BinomialStochasticVariables.binomICdf(xVar, Rate), 5), xVar.number, xVar.probability,
                    Math.Round(BinomialStochasticVariables.binomICdf(xVar, Rate), 7));
               Console.WriteLine("|| Enter to continue.");
               Console.ReadLine();
          }

          private void ListOfBinomCdf()
          {
               Console.WriteLine("|||\n" +
                                   "|| List of cumulative likelyhoods of AT MOST rate [r] success': X~b( n , p ) P( X <= r ) [r = 0,..,n]\n" +
                                   "|| given the probability [p] of a success among [n] elements: X~b(n,p) P(X=r)\n||");

               CheckValuesForBadness();

               bool longList = DecideListLength();

               for (int i = 0; i <= xVar.number; i++)
               {
                    double binomCdf = BinomialStochasticVariables.binomCdf(xVar, i);
                    if (binomCdf > 0.0025 && binomCdf < 0.98 | longList)
                    {
                         //Console.ForegroundColor = ConsoleColor.Green;
                         //if ((binomCdf <= 0.05)) { Console.ForegroundColor = ConsoleColor.DarkRed; }
                         //if ((binomCdf >= 0.95)) { Console.ForegroundColor = ConsoleColor.DarkYellow; }
                         ColorCodeIntervals(binomCdf);

                         Console.WriteLine("||| Chance of {0} or less success' = {1}%:\t X~b( {2} , {3} ) P(X <= {0}) = {4} \t\t {5}",
                              i, 100 * Math.Round(binomCdf, 4), xVar.number, xVar.probability,
                              Math.Round(binomCdf, 5), Access.Dash(binomCdf/*, 4*/));

                         if (binomCdf > 0.9999)
                         {
                              break;
                         }
                    }
               }
               Console.ResetColor();

               Console.ReadLine();
          }

          private void ListOfBinomICdf()
          {
               Console.WriteLine("|||\n||  X~b( n , p ) P( X >= r ) [r = 0,..,n]\n|| List of cumulative likelyhoods of AT LEAST rate [r] success':\n" +
           "|| given the probability of a success [p] among [n] elements: X~b(n,p) P(X=r)\n||");

               CheckValuesForBadness();

               bool longList = DecideListLength();

               int iterationsOfBinomCdf = (int)xVar.number; // number of times the binomCdf() will run; changed if only a non-longList is demanded by user

               int iterationStartingPoint = 0; // will be 0 if traversing all values; set to xVars My value if going for short list

               //Here is implemented a way of cutting off the list that uses the actual numbers of the 
               // xVar - doesn't make much difference... which is cool.
               DetermineIterationDetails(longList, ref iterationsOfBinomCdf, ref iterationStartingPoint);
               for (int i = iterationStartingPoint; i <= iterationsOfBinomCdf; i++)
               {
                    double binomICdf = BinomialStochasticVariables.binomICdf(xVar, i);
                    //if (binomICdf > 0.0025 && binomICdf < 0.951 | longList)
                    //{

                    ColorCodeIntervals(binomICdf);
                    Console.WriteLine("||| Chance of {0} or more success' = {1}%:\t X~b( {2} , {3} ) P(X >= {0}) = {4} \t\t {5}",
                         i, 100 * Math.Round(binomICdf, 4), xVar.number, xVar.probability,
                         Math.Round(binomICdf, 7), Access.Dash(binomICdf/*, 3*/));
                    //}

               }
               Console.ResetColor();
               Console.ReadLine();
          }

          private void DetermineIterationDetails(bool longList, ref int iterationsOfBinomCdf, ref int iterationStartingPoint)
          {
               if (!longList)
               {
                    double mean = BinomialStochasticVariables.My(xVar);
                    double dev = BinomialStochasticVariables.Deviation(xVar);

                    iterationStartingPoint = (int)(mean - 3 * dev);
                    if (iterationStartingPoint <= 0) { iterationStartingPoint = 0; }
                    iterationsOfBinomCdf = (int)(6 * dev + mean);
                    if (iterationsOfBinomCdf > xVar.number)
                    {
                         iterationsOfBinomCdf = (int)xVar.number;
                    }
               }
          }

          private static int FetchRate()
          {
               return Access.FetchInt(0, "|| Please input the rate/number of success' [r] >> ");
          }

          private void MethodExit()
          {
               if (sentOnTask > 0)
               {
                    sentOnTask -= 1;
                    return;
               }
               else { MainUserLoop(); }
          }

          private void CheckValuesForBadness()
          {

               //if (Rate == 0) { Rate = FetchRate(); }
               if (xVar.number == 0) { sentOnTask += 1; CreateXVar(); } // if the number of spaces in the possibility space == 0, that is impossible, and a better XVar needs to be created

          }

     }
}
