using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CprE_310_PageRank
{
    /// <summary>
    /// Allows ease of access of variables used in different files
    /// </summary>
    class GlobalVariables
    {
       public static DataFields g_data; // data structure holding edge mappings and PageRanks
       public static bool g_dataRead; // true if a valid data set is currently available
       public static bool g_dataSim; // true if valid PageRankings are currently available
       public static TimeSpan g_simTime; //elapsed time of last PageRank simulation
       public static int g_iterations; //number of iterations on last PageRank simulation
    }
}
