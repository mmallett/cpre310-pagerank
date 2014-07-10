using System;
using System.Collections;
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
    /// MainForm serves as the 'hub' of the program. Input can be created and read from here, and
    /// simulations and data viewing is launched from here.
    /// </summary>
    public partial class MainForm : Form
    {   
        /// <summary>
        /// Constructs a new MainForm with the default getting started message in the console
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            rtbConsole.AppendText("CprE 381 PageRank Project.\n");
            rtbConsole.AppendText("For help getting started, click on Help->Getting Started.\n\n");

            GlobalVariables.g_dataRead = GlobalVariables.g_dataSim = false; // nothing has been done, set flags as so
        }

        /// <summary>
        /// Event handler for Reading input.
        /// Opens an Open File dialog window, where the user provides a
        /// filepath for an input file, then attempts to parse the file for
        /// the edge mappings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picRead_Click(object sender, EventArgs e)
        {
            bool error = false;

            openFD.ShowDialog(); // get input filepath

            string filePath = openFD.FileName;

            rtbConsole.AppendText(">>Read Input File " + System.DateTime.Now + "\n"); 
            rtbConsole.AppendText("Attempting to read file: " + filePath + "\n");
            try
            {
                GlobalVariables.g_dataRead = false; //next line will wipe data, and no new data is guaranteed to take its place
                GlobalVariables.g_data = new DataFields(filePath);//constructing a new dataField handles all of the 'reading' inside the constructor
               
            }
            catch (Exception)
            {
                error = true;
                rtbConsole.AppendText("There was a problem with the file: " + filePath + " It was either" +
                    " not found, or not formatted properly.\n\n");
            }

            if (!error)
            {
                GlobalVariables.g_dataRead = true;
                rtbConsole.AppendText("Input file was read successfully. You may now simulate with this data set.\n\n");
            }
            
        }

        /// <summary>
        /// These event handlers make cool effects on the GUI
        /// so the user notices when they mouse over the buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picRead_MouseEnter(object sender, EventArgs e)
        {
            picRead.Image = CprE_310_PageRank.Properties.Resources.binary_inv;
        }

        private void picRead_MouseLeave(object sender, EventArgs e)
        {
            picRead.Image = CprE_310_PageRank.Properties.Resources.binary;
        }

        /// <summary>
        /// Performs a PageRank simulation on the input data previously read, using an iteration method
        /// fleshed out in Simulations.cs
        /// If no input has been successfully read, no simulation will be run.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picSim_Click(object sender, EventArgs e)
        {
            runSim();
        }

        private void picSim_MouseEnter(object sender, EventArgs e)
        {
            picSim.Image = CprE_310_PageRank.Properties.Resources.simulate_inv;
        }

        private void picSim_MouseLeave(object sender, EventArgs e)
        {
            picSim.Image = CprE_310_PageRank.Properties.Resources.simulate;
        }

        private void picGen_MouseEnter(object sender, EventArgs e)
        {
            picGen.Image = CprE_310_PageRank.Properties.Resources.generate_inv;
        }

        private void picGen_MouseLeave(object sender, EventArgs e)
        {
            picGen.Image = CprE_310_PageRank.Properties.Resources.generate;
        }

        /// <summary>
        /// Opens a new Viewer window with basic instructions on getting started
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gettingStartedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextViewer view = new TextViewer();
            view.Show();
        }

        /// <summary>
        /// Opens a new Viewer window with a short description of the program displayed
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
            TextViewer view = new TextViewer(text);
            view.Show();
        }

        /// <summary>
        /// Destroys the current set of mappings, requiring the user to read an input file again before
        /// a simulation can be run.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteDataSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbConsole.AppendText(">>Delete Data " + System.DateTime.Now + "\n");
            rtbConsole.AppendText("Data set has been deleted.\n\n");
            GlobalVariables.g_data = null;
            GlobalVariables.g_dataRead = false;
            GlobalVariables.g_dataSim = false;
        }

        /// <summary>
        /// Resets the current PageRank values to the default values of 1.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetPageRanksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbConsole.AppendText(">>Reset PageRanks " + System.DateTime.Now + "\n");
            if (GlobalVariables.g_dataSim)
            {
                rtbConsole.AppendText("Page Rankings have been reset.\n\n");
                GlobalVariables.g_data.resetPageRanks();
                GlobalVariables.g_dataSim = false;
            }
            else
            {
                rtbConsole.AppendText("Page Ranks are already in default state, no simulation has been run\n\n");
            }
        }

        /// <summary>
        /// Closes the Main window, ending the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Helper method that the simulation is actually implemented inside.
        /// </summary>
        private void runSim()
        {
            rtbConsole.AppendText(">>Simulate PageRanks " + System.DateTime.Now + "\n");
            if (GlobalVariables.g_dataRead)
            {
                rtbConsole.AppendText("Running Power Iteration Simulation on data set\n");
                Simulations.Iteration(GlobalVariables.g_data);
                GlobalVariables.g_dataSim = true;
                rtbConsole.AppendText("Power Iteration Simulation complete. See simulation analysis for details\n\n");
                TextViewer view = new TextViewer("_viewPageRanks");
                view.Show();
             
            }
            else
            {
                MessageBox.Show("Input has not been read. Read an input file before simulating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rtbConsole.AppendText("Failed: no input provided\n\n");
            }

        }

        /// <summary>
        /// Opens a new Viewer window with default text displayed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextViewer view = new TextViewer();
            view.Show();
        }

        /// <summary>
        /// Creates a randomly generated set of mappings based on user input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picGen_Click(object sender, EventArgs e)
        {
            genFile();
        }

        /// <summary>
        /// Actual implementation of file generating
        /// </summary>
        private void genFile()
        {
            rtbConsole.AppendText(">>Generating Input file " + System.DateTime.Now + "\n");

            StreamWriter write;

            saveFD.ShowDialog();   

            try
            {
                write = new StreamWriter(saveFD.FileName);

                string input = Microsoft.VisualBasic.Interaction.InputBox("How many pages in the map?", "Input");
                    
                int n = Convert.ToInt32(input);
                Random r = new Random();

                int edgeCount = r.Next(n * (n - 1)); // maximum number of edges is n*(n-1), where every node is mapped to every other node

                ArrayList map = new ArrayList();

                for (int i = 0; i < edgeCount; i++)
                {
                    int[] newEdge = new int[2];
                    newEdge[0] = r.Next(n) + 1;
                    newEdge[1] = r.Next(n) + 1;
                    bool contains = false;
                    foreach (int[] edge in map)
                    {
                        var shared = edge.Intersect(newEdge);
                        if(contains = edge.Length == newEdge.Length && shared.Count() == edge.Length) break;
                    }
                    if (!contains && (newEdge[0] != newEdge[1]))
                    {
                        map.Add(newEdge);
                    }
                }

                foreach (int[] edge in map)
                {
                    write.WriteLine(edge[0] + "\t" + edge[1]);
                }
                write.Close();

                rtbConsole.AppendText("Input file " + saveFD.FileName + " created successfully\n\n");

            }
            catch (Exception ex)
            {
                rtbConsole.AppendText("Failed to generate file due to " + ex.GetType().ToString() + "\n\n");
            }
        }
    }
}
