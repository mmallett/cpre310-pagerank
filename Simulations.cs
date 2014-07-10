using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace CprE_310_PageRank
{
    /// <summary>
    /// Implementation of Iterative power algorithm, and a shell of the
    /// Monte Carlo simulation are contained in this file.
    /// </summary>
    class Simulations
    {
        public const double p = .15; //damping constant declared

        public static void Iteration(DataFields data)
        {
            Stopwatch stopWatch = new Stopwatch(); //performance evaluation code
            stopWatch.Start(); 
            GlobalVariables.g_iterations = 0;

            bool stop = false;
            while (!stop) // loop runs until old page rank and new page rank are within .001 of each other
            {
                GlobalVariables.g_iterations++;
                double change = 0;
                foreach (Node x in data.nodeList) // for every node on the graph
                {
                    //GlobalVariables.g_iterations++;// performance evaluation

                    x.LastPageRank = x.PageRank;
                    double sum = 0;
                    foreach (Node y in x.InboundList) // for every inbound edge of current node
                    {
                        sum += y.PageRank * (1.0 /((double) y.OutboundList.Count)); // calculate the summation of destination pageRank times 1/outbound link count
                    }
                    x.PageRank = (1.0 - p) + p * sum; // multiply summation by damping factor and add to leading term to complete algorithm iteration

                    change += Math.Abs(x.PageRank - x.LastPageRank);
                }

                if (change < .001) //see if we need to go another iteration
                {
                    stop = true;
                }

            }

            stopWatch.Stop();
            GlobalVariables.g_simTime = stopWatch.Elapsed;
        }

        /// <summary>
        /// Not complete, I wasn't sure if I had to do both algorithms. I later got clarification on this.
        /// I thought you might be interested in seeing what I had so far for the Monte Carlo simulation
        /// </summary>
        /// <param name="data"></param>
        public static void MonteCarlo(DataFields data)
        {
            Random r = new Random(); //generates 'psuedorandom' values for Monte Carlo simulation

            // want to get smaller range on random numbers to achieve faster simulation
            int max = 0;
            foreach (Node n in data.nodeList)
            {
                if (n.Tag > max)
                {
                    max = n.Tag;
                }
            } //this one run through the list will save time in the long run, by limiting random range to inside the graph

            bool stop = false;

            while (!stop)
            {
                int rand = r.Next(max);
                if (data.nodeList.Contains(rand))
                {
                    //dont have to do
                }
            }


        }
    }
}
