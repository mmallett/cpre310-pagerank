using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

namespace CprE_310_PageRank
{
    /// <summary>
    /// Provides the data structure of the edge mappings.
    /// Data is held in a list of 'Nodes' where each Node
    /// has a list of all outbound and inbound links, and
    /// holds a value for its PageRank.
    /// 
    /// This class also does the parsing of the input file
    /// </summary>
    class DataFields
    {
        public ArrayList nodeList;// List of all Nodes on the map
        private string filePath; // filepath for the input file

        /// <summary>
        /// Constructs a new mapping based on the
        /// specified input file
        /// </summary>
        /// <param name="filePath">Input file containing edge pairs</param>
        public DataFields(string filePath)
        {
            nodeList = new ArrayList();
            this.filePath = filePath;
            readFile();
        }

        /// <summary>
        /// Resets all PageRanks in the map back to default
        /// value of 1, allowing you to resimulate and check
        /// for consistent results
        /// </summary>
        public void resetPageRanks()
        {
            foreach (Node n in nodeList)
            {
                n.LastPageRank = n.PageRank = 1;
            }
            GlobalVariables.g_dataSim = false;
        }

        /// <summary>
        /// Helper method called within the constructor that parses the input
        /// file and initializes the data structure with the parsed data
        /// </summary>
        private void readFile()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);

            string line;
            string[] split;

            int src, dest;

            while ((line = file.ReadLine()) != null)
            {
                split = line.Split('\t'); //split the current line in half at the tab
                src = Convert.ToInt32(split[0]);
                dest = Convert.ToInt32(split[1]);

                bool containsSrc = false;
                bool containsDest = false;
                Node srcNode= null, destNode = null;
                // now need to see if new nodes are contained in map
                // if not, we need to add them
                foreach (Node n in nodeList)
                {
                    if (n.Tag == src)
                    {
                        srcNode = n;
                        containsSrc = true;
                    }
                    else if(n.Tag == dest)
                    {
                        destNode = n;
                        containsDest = true;
                    }
                }
                    /**
                    {
                        srcNode = new Node(src,dest);
                        destNode = new Node(dest);
                    }**/
                /**if (!(containsSrc || containsDest))
                {
                    srcNode = new Node(src, dest);
                    destNode = new Node(dest);
                }**/
                if (!containsDest)
                {
                    destNode = new Node(dest);
                    nodeList.Add(destNode);
                }

                if (!containsSrc)
                {
                    srcNode = new Node(src);//, dest);
                    nodeList.Add(srcNode);
                }
                destNode.InboundList.Add(srcNode);
                srcNode.OutboundList.Add(destNode);
            }
            file.Close();
        }
    }

    /// <summary>
    /// Basic unit of the map, the Node contains lists of both inbound and outbound edges, as
    /// well as a PageRank value for the node, that is updated frequently during simulation, until
    /// the change in the value is within the target range.
    /// </summary>
    class Node
    {
        int tag; // the 'name' or numerical value of the page
        ArrayList inboundList;// all elements in this list link to this node
        ArrayList outboundList;//this node links to all elements in this list
        double pageRank; //PageRank value for this node, updated frequently during simulation
        double lastPageRank;

        /// <summary>
        /// Constructs a new Node with the given tag, and no 
        /// edges
        /// </summary>
        /// <param name="tag">Name of the node</param>
        public Node(int tag)
        {
            this.tag = tag;
            inboundList = new ArrayList();
            outboundList = new ArrayList();
            pageRank = lastPageRank = 1;
        }

       /// <summary>
        /// Constructs a new Node with the given tag, and
        /// adds one edge linked to the destination node argument
        /// </summary>
        /// <param name="tag">Name of the node</param>
        /// <param name="dest">Edge from new node to this destination</param>
       /** public Node(int tag, int dest)
        {
            this.tag = tag;
            inboundList = new ArrayList();
            inboundList.Add(dest);
            outboundList = new ArrayList();
            pageRank = lastPageRank = 1;
        }**/

        /**Properties replace the getter/setter methods of Java, they allow you to declare
         * a public element with access to the private backing variable,
         * and control what values the user can set the backing private to.
         **/
        /// <summary>
        /// Property of the Node class which represents
        /// its name, or numerical value
        /// </summary>
        public int Tag
        {
            get
            {
                return tag;
            }
            set
            {
                tag = value;
            }
        }

        /// <summary>
        /// Every node in this list has an edge going from that node
        /// to this node.
        /// In other words, a list of inbound links.
        /// </summary>
        public ArrayList InboundList
        {
            get
            {
                return inboundList;
            }
        }

        /// <summary>
        /// Every node in this list has an edge going from this node to the
        /// listed node.
        /// This is a list of all outbound links.
        /// </summary>
        public ArrayList OutboundList
        {
            get
            {
                return outboundList;
            }
        }

        /// <summary>
        /// The page rank value from the last iteration
        /// in the iterative power algorithm. Binding it to
        /// each node allows easy access and comparison to
        /// new page ranks.
        /// </summary>
        public double LastPageRank
        {
            get
            {
                return lastPageRank;
            }
            set
            {
                lastPageRank = value;
            }
        }

        /// <summary>
        /// The current value of the PageRank of this node.
        /// This value is updated frequently while inside the
        /// PageRank algorithm, but after the algorithm is complete,
        /// this is an accurate reflection of the nodes PageRank.
        /// </summary>
        public double PageRank
        {
            get
            {
                return pageRank;
            }
            set
            {
                pageRank = value;
            }
        }
    }
}
