using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CprE_310_PageRank
{
    /// <summary>
    /// The Viewer window is used to display information and instructions, and acts as a supplement to
    /// the Main window. In this window you can view edge mappings, PageRanks, performance statistics, help,
    /// and general information about this program.
    /// </summary>
    public partial class TextViewer : Form
    {
        //this string is showed whenever a default Viewer is opened
        string init = "Getting Started\n\nThis program has 2 main windows, Main, and Viewer.\n\n" +
                "The Main window lets you perform tasks such as reading input files, and running page rank simulations.\n" +
                "The Main window is automatically opened at the start of the program\n\n" +
                "The Viewer window lets you view various information, such as PageRank values, mappings, and simulation analyses.\n" +
                "To open a new Viewer window, go to Viewer, Open New in the Main window. A Viewer is automatically opened after every PageRank simulation, too\n\n" +
                "Running a PageRank simulation can be done in up to 3 easy steps\n" +
                "1)If you do not have an input file ready, click Generate File on the Main window, provide inputs that are prompted for.\n" +
                "2)Click on Read Input on the Main window, and specify a file with the explorer window\n" +
                "3)Click on Simulate on the Main window. You will now be able to view results in the Viewer window\n\n\n" +
                "For more detailed instructions, see the README.txt file contained in the packaged folder";
            
        /// <summary>
        /// Constructs a new Viewer window with default (Getting Started) text
        /// </summary>
        public TextViewer()
        {
            InitializeComponent();
            rtbViewer.AppendText(init);
        }

        /// <summary>
        /// Constructs a new Viewer window with text specified by argument
        /// </summary>
        /// <param name="text">This text will be displayed in the Viewer window</param>
        public TextViewer(string text)
        {
            InitializeComponent();
            if (text.Equals("_viewPageRanks"))
            {

                rtbViewer.AppendText("---------Iteration Pageranks--------\nNode\tPageRank");
                foreach (Node n in GlobalVariables.g_data.nodeList)
                {
                    rtbViewer.AppendText("\n" + n.Tag + "\t" + n.PageRank);
                }
            }
            else
            {
                rtbViewer.AppendText(text);
            }
        }

        /// <summary>
        /// Displays the edge mappings of nodes as read from an input file.
        /// A small notice will display if no input has been given.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mappingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbViewer.Clear();
            if (GlobalVariables.g_dataRead)
            {
                rtbViewer.AppendText("--------Node Mappings--------\nSource\tDestination");
                foreach (Node x in GlobalVariables.g_data.nodeList)
                {
                    foreach (Node y in x.OutboundList)
                    {
                          rtbViewer.AppendText("\n" + x.Tag + "\t" + y.Tag);
                    }
                }
            }
            else
            {
                rtbViewer.AppendText("You have not read an input file yet, so there are no mappings to display. Read an input file and then return here to view the mappings");
            }

        }

        /// <summary>
        /// Displays PageRanks after a simulation has been run.
        /// If PageRanks haven't been calculated yet, a small notice will appear inside
        /// notifying the user of this.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pageRanksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbViewer.Clear();
            if (GlobalVariables.g_dataSim)
            {

                rtbViewer.AppendText("---------Iteration Pageranks--------\nNode\tPageRank");
                foreach (Node n in GlobalVariables.g_data.nodeList)
                {
                    rtbViewer.AppendText("\n" + n.Tag + "\t" + n.PageRank);
                }
            }
            else
            {
                rtbViewer.AppendText("You have not run a simulation yet. Run a simulation, then you will be able to see results here.");
            }
        }

        /// <summary>
        /// Closes the Viewer window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Displays the default text in the Viewer window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gettingStartedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbViewer.Clear();
            rtbViewer.AppendText(init);
        }

        /// <summary>
        /// Displays a short summary of the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = "Author: Matt Mallett\nDate: 11/2/2011\nPurpose: To provide an accurate simulation of Google's PageRank algorithm"
                + " \n\nThis project was written and developed entirely" +
                " in C# with Microsoft Visual C# 2010 Express. It approximates PageRanks using the power iteration method" +
                " of simulation. My implementation of of the PageRank simulation offers a fully developed GUI powered by the .NET"
                + " framework, which means it will run on virtually any up to date Windows machine, no installation required.";
              
            rtbViewer.Clear();
            rtbViewer.AppendText(text);
        }

        /// <summary>
        /// Saves the text currently appearing on the Viewer window to a 
        /// file specified/created by a Save File dialog window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFD.ShowDialog();

            try
            {
                StreamWriter write = new StreamWriter(saveFD.FileName);
                foreach (string line in rtbViewer.Lines)
                {
                    write.WriteLine(line);
                }
                write.Close();
            }
            catch (IOException)
            {
                MessageBox.Show("The file " + saveFD.FileName + " was not found", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Allows the user to view size of the data structure, as well
        /// as number of iterations, and time elapsed while calculating the PageRanks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void performanceAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbViewer.Clear();
            if (GlobalVariables.g_dataSim)
            {
                rtbViewer.AppendText("---Performance Analysis of PageRank simulation---\n");
                rtbViewer.AppendText("--Mapping data--\n");
                rtbViewer.AppendText("Total nodes in map\t" + GlobalVariables.g_data.nodeList.Count + "\n");
                int c = 0;
                foreach (Node n in GlobalVariables.g_data.nodeList)
                {
                    c += n.OutboundList.Count;
                }
                rtbViewer.AppendText("Total edges in map\t" + c + "\n");
                if (GlobalVariables.g_dataSim)
                {
                    rtbViewer.AppendText("\n--Simulation Performance\n");
                    rtbViewer.AppendText("Number of iterations\t" + GlobalVariables.g_iterations + "\n");
                    rtbViewer.AppendText("Elapsed time\t" + GlobalVariables.g_simTime.TotalMilliseconds + " ms\n");
                }
            }
            else
            {
                rtbViewer.AppendText("No data to show, input has been run");
            }
        }
    }
}
