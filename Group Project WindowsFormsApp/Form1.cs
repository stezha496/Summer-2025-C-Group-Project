using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Group_Project_Class_Library;

namespace Group_Project_WindowsFormsApp
{
    public partial class Form1 : Form
    {
        GameLogic game = new GameLogic();
        Timer tick = new Timer();
        int[] dims;            
        int startHumans;
        int startZombies;
        int maxIters;

        public Form1()
        {
            InitializeComponent();
            btnWrite.Click += btnWrite_Click;
            tick.Interval = 300;
            tick.Tick += Tick_Tick;
            cmbFloor.Enabled = false;
            pnlGrid.Paint += pnlGrid_Paint;
            pnlGrid.Resize += (s, e) => pnlGrid.Invalidate();
            pnlGrid.BackColor = Color.White;   
            pnlGrid.BringToFront();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // read user inputs
            startHumans = Convert.ToInt32(txtHumans.Text);
            startZombies = Convert.ToInt32(txtZombies.Text);
            maxIters = Convert.ToInt32(txtMaxIter.Text);

            int numDims = Convert.ToInt32(txtNumDims.Text);   
            if (numDims < 1) numDims = 1;
            if (numDims > 5) numDims = 5;

            string[] raw = txtDims.Text.Split(new char[] { ',', ' ', 'x', 'X' });
            List<string> tokens = new List<string>();
            for (int i = 0; i < raw.Length; i++)
            {
                if (raw[i] != null)
                {
                    string t = raw[i].Trim();
                    if (t != "") tokens.Add(t);   
                }
            }

            if (tokens.Count != numDims)
            {
                MessageBox.Show("Enter exactly " + numDims + " dimension sizes in the Dimensions box.");
                return;
            }

            // build dims[]
            dims = new int[numDims];
            for (int i = 0; i < numDims; i++)
                dims[i] = Convert.ToInt32(tokens[i]);

            // Start game
            game.ClearAll();
            game.InitializeFromUI(maxIters, startHumans, startZombies, dims);

            // SetupFloors Dimension for 3,4,5;
            SetupSliceSelectors();

            // start timer & refresh
            tick.Start();
            rtbLog.AppendText("Simulation started.\n");
            UpdateStats();
            pnlGrid.Invalidate();

        }

        

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (tick.Enabled)
            {
                tick.Stop();
                rtbLog.AppendText("Paused.\n");
            }
            else
            {
                tick.Start();
                rtbLog.AppendText("Resumed.\n");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tick.Stop();
            game.ClearAll();
            pnlGrid.Invalidate();
            lblIteration.Text = "Iteration: 0";
            lblHumansLeft.Text = "Humans Left: 0";
            lblZombies.Text = "Zombies: 0";
            lblPercent.Text = "% Remaining: 0";
            rtbLog.AppendText("Reset.\n");

        }

        private void Tick_Tick(object sender, EventArgs e)
        {
            bool end = game.StepOnce();   
            UpdateStats();
            pnlGrid.Invalidate();

            if (end)
            {
                tick.Stop();
                rtbLog.AppendText("Simulation ended.\n");
            }
        }

        private void UpdateStats()
        {
            lblIteration.Text = "Iteration: " + game.getIterations();
            lblHumansLeft.Text = "Humans Left: " + game.getNumOfHumans();
            lblZombies.Text = "Zombies: " + game.getNumOfZombies();

            // avoid divide by zero
            int startTotal = startHumans;
            int left = game.getNumOfHumans();
            int pct = 0;
            if (startTotal > 0) pct = (left * 100) / startTotal;
            lblPercent.Text = "% Remaining: " + pct;
        }

        private void SetupSliceSelectors()
        {
            // reset all
            cmbFloor.Items.Clear(); cmbFloor.Enabled = false;
            cmbDim4.Items.Clear(); cmbDim4.Enabled = false;
            cmbDim5.Items.Clear(); cmbDim5.Enabled = false;

            // if 3rd dimension exists
            if (dims.Length >= 3)
            {
                for (int i = 0; i < dims[2]; i++) cmbFloor.Items.Add(i);
                cmbFloor.SelectedIndex = 0;
                cmbFloor.Enabled = true;
            }
            // if 4th dimension exists
            if (dims.Length >= 4)
            {
                for (int i = 0; i < dims[3]; i++) cmbDim4.Items.Add(i);
                cmbDim4.SelectedIndex = 0;
                cmbDim4.Enabled = true;
            }
            // if 5th dimension exists
            if (dims.Length == 5)
            {
                for (int i = 0; i < dims[4]; i++) cmbDim5.Items.Add(i);
                cmbDim5.SelectedIndex = 0;
                cmbDim5.Enabled = true;
            }
        }

        private void cmbFloor_SelectedIndexChanged(object sender, EventArgs e) { pnlGrid.Invalidate(); }
        private void cmbDim4_SelectedIndexChanged(object sender, EventArgs e) { pnlGrid.Invalidate(); }
        private void cmbDim5_SelectedIndexChanged(object sender, EventArgs e) { pnlGrid.Invalidate(); }

        private void pnlGrid_Paint(object sender, PaintEventArgs e)
        {
            Array area = game.GetArea();
            if (area == null) return;

            int rank = area.Rank;

            // figure out X/Y sizes (if 1D, Y=1)
            int sizeX = area.GetLength(0);
            int sizeY = (rank >= 2) ? area.GetLength(1) : 1;

            // which slice indices are we using for dims 2..4?
            int idx2 = 0, idx3 = 0, idx4 = 0;
            if (rank >= 3 && cmbFloor.Enabled) idx2 = cmbFloor.SelectedIndex;
            if (rank >= 4 && cmbDim4.Enabled) idx3 = cmbDim4.SelectedIndex;
            if (rank >= 5 && cmbDim5.Enabled) idx4 = cmbDim5.SelectedIndex;

            // scale cells to panel
            int pad = 4;
            int cellW = (pnlGrid.ClientSize.Width - pad * 2) / Math.Max(1, sizeX);
            int cellH = (pnlGrid.ClientSize.Height - pad * 2) / Math.Max(1, sizeY);
            int cell = Math.Max(6, Math.Min(cellW, cellH));
            Graphics g = e.Graphics;

            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    int px = pad + x * cell;
                    int py = pad + y * cell;
                    g.DrawRectangle(Pens.Black, px, py, cell, cell);

                    // get the entity list at (x,y,idx2,idx3,idx4) 
                    List<Entity> list;
                    if (rank == 1)
                        list = (List<Entity>)area.GetValue(x);
                    else if (rank == 2)
                        list = (List<Entity>)area.GetValue(x, y);
                    else if (rank == 3)
                        list = (List<Entity>)area.GetValue(x, y, idx2);
                    else if (rank == 4)
                        list = (List<Entity>)area.GetValue(x, y, idx2, idx3);
                    else // rank == 5
                        list = (List<Entity>)area.GetValue(x, y, idx2, idx3, idx4);

                    // mark cell: H / Z / HZ (converted humans count as Z)
                    bool hasZ = false, hasH = false;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] is Zombie) hasZ = true;
                        else if (list[i] is Human)
                        {
                            Human h = (Human)list[i];
                            if (h.getConvertedToZombie()) hasZ = true; else hasH = true;
                        }
                    }
                    string mark = hasZ && hasH ? "HZ" : hasZ ? "Z" : hasH ? "H" : "";
                    if (mark != "") g.DrawString(mark, this.Font, Brushes.Black, px + 3, py + 3);
                }
            }
        }


        private void btnWrite_Click(object sender, EventArgs e)
        {
            using (StreamWriter w = new StreamWriter("simulation_log.txt"))
            {
                w.WriteLine("Humans:{0}", txtHumans.Text);
                w.WriteLine("Zombies:{0}", txtZombies.Text);
                w.WriteLine("MaxIterations:{0}", txtMaxIter.Text);

                //Get Dimensions 
                string dimsOut = "";
                if (dims != null && dims.Length > 0)
                {
                    for (int i = 0; i < dims.Length; i++)
                    {
                        if (i > 0) dimsOut += ",";
                        dimsOut += dims[i].ToString();
                    }
                }

                w.WriteLine("NumDims:{0}", txtNumDims.Text);
                w.WriteLine("Dims:{0}", dimsOut);

                w.WriteLine("--- Event Log ---");
                w.WriteLine(rtbLog.Text);
            }
            MessageBox.Show("Saved to simulation_log.txt");
        }


    }
}
