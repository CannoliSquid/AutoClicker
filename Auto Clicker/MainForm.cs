﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Runtime.InteropServices;


/// <summary>
/// Credit goes to Ryan Harrison (raharrison on GitHub) for starting this project.
/// I'm introducing my own spin on it with some changes that hopefully help with games that are less auto-click friendly.
/// </summary>
namespace Auto_Clicker
{
    public partial class MainForm : Form
    {
        #region Global Variables and Properties

        private Thread ClickThread; //Thread to take care of clicking the mouse
                                    //so UI is not made unresponsive

        private Point CurrentPosition { get; set; } //The current position of the mouse cursor

        #endregion

        #region Constructor

        /// <summary>
        /// Construct the form object and initialise all form components
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Component Events

        /// <summary>
        /// Start the timer to update the cursor position and clear all items in the list view
        /// when the form loads
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            CurrentPositionTimer.Start();
            PositionsGridView.Rows.Clear();
            //PositionsGridView.SelectedCells.
            //PositionsListView.Items.Clear();
        }

        /// <summary>
        /// Handle keyboard shortcuts from the user
        /// </summary>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                CopyToAddButton_Click(null, null);
            }
            else if (e.KeyCode == Keys.F2)
            {
                AddPositionButton_Click(null, null);
            }
            else if (e.KeyCode == Keys.F2)
            {
                StartClickingButton_Click(null, null);
            }
            else if (e.KeyCode == Keys.F2)
            {
                StopClickingButton_Click(null, null);
            }
        }

        /// <summary>
        /// Set the CurrentPosition property to the current position of the mouse cursor
        /// on screen on each interval of the timer
        /// </summary>
        private void CurrentPositionTimer_Tick(object sender, EventArgs e)
        {
            CurrentPosition = Cursor.Position;
            UpdateCurrentPositionTextBoxes();
        }

        /// <summary>
        /// Copy current position of the cursor to alternate textboxes so they are ready to 
        /// be queued by the user
        /// </summary>
        private void CopyToAddButton_Click(object sender, EventArgs e)
        {
            QueuedXPositionTextBox.Text = CurrentPosition.X.ToString();
            QueuedYPositionTextBox.Text = CurrentPosition.Y.ToString();
        }

        /// <summary>
        /// Add the point held in the queued textboxes to the listview so ready to be executed
        /// </summary>
        private void AddPositionButton_Click(object sender, EventArgs e)
        {
            if (CurrentPositionIsValid(QueuedXPositionTextBox.Text, QueuedYPositionTextBox.Text))
            {
                if (IsValidNumericalInput(SleepTimeTextBox.Text))
                {
                    //Add item holding coordinates, right/left click and sleep time to list view
                    //holding all queued clicks
                    //ListViewItem item = new ListViewItem(QueuedXPositionTextBox.Text);
                    //item.SubItems.Add(QueuedYPositionTextBox.Text);
                    string clickType = (RightClickCheckBox.Checked) == true ? "R" : "L";

                    int sleepTime = Convert.ToInt32(SleepTimeTextBox.Text);
                    //item.SubItems.Add(clickType);
                    //item.SubItems.Add(sleepTime.ToString());
                    //PositionsListView.Items.Add(item);
                    PositionsGridView.Rows.Add(QueuedXPositionTextBox.Text, QueuedYPositionTextBox.Text, clickType, sleepTime.ToString());
                }
                else
                {
                    MessageBox.Show("Sleep time is not a valid positive integer", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Current Coordinates are not valid", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Assign all points in the queue to the ClickHelper and start the thread
        /// </summary>
        private void StartClickingButton_Click(object sender, EventArgs e)
        {
            if (IsValidNumericalInput(NumRepeatsTextBox.Text))
            {
                int iterations = Convert.ToInt32(NumRepeatsTextBox.Text);
                List<Point> points = new List<Point>();
                List<string> clickType = new List<string>();
                List<int> times = new List<int>();

                foreach (DataGridViewRow row in PositionsGridView.Rows)//ListViewItem item in PositionsListView.Items)
                {
                    if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                    {
                        //Add data in queued clicks to corresponding List collection
                        int x = Convert.ToInt32(row.Cells[0].Value); //x coordinate
                        int y = Convert.ToInt32(row.Cells[1].Value); //y coordinate
                        clickType.Add(row.Cells[2].Value.ToString()); //click type
                        times.Add(Convert.ToInt32(row.Cells[3].Value)); //sleep time

                        points.Add(new Point(x, y));
                    }
                }

                try
                {
                    //Create a ClickHelper passing Lists of click information
                    ClickThreadHelper helper = new ClickThreadHelper() { Points = points, ClickType = clickType, Iterations = iterations, Times = times };
                    //Create the thread passing the Run method
                    ClickThread = new Thread(new ThreadStart(helper.Run));
                    //Start the thread, thus starting the clicks
                    ClickThread.Start();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Number of repeats is not a valid positive integer", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Abort the clicking thread and so stop all simulated clicks
        /// </summary>
        private void StopClickingButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClickThread.IsAlive)
                {
                    ClickThread.Abort(); //Attempt to stop the thread
                    ClickThread.Join(); //Wait for thread to stop
                    MessageBox.Show("Clicking successfully stopped", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ThreadAbortException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Remove all items from the list view holding queued positions
        /// </summary>
        private void RemoveAllMenuItem_Click(object sender, EventArgs e)
        {
            //PositionsListView.Items.Clear();
            PositionsGridView.Rows.Clear();
        }

        private void PositionsGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = PositionsGridView.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    ListViewContextMenu.Show(Cursor.Position);
                }

                //ContextMenu m = new ContextMenu();
                //m.MenuItems.Add(new MenuItem("Cut"));
                //m.MenuItems.Add(new MenuItem("Copy"));
                //m.MenuItems.Add(new MenuItem("Paste"));

                //int currentMouseOverRow = PositionsGridView.HitTest(e.X, e.Y).RowIndex;

                //if (currentMouseOverRow >= 0)
                //{
                //    m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                //}

                //m.Show(PositionsGridView, new Point(e.X, e.Y));

            }
        }

        /// <summary>
        /// Remove only the selected item from the list view holding all queued positions
        /// </summary>
        private void RemoveSelectedMenuItem_Click(object sender, EventArgs e)
        {
            //PositionsListView.SelectedItems[0].Remove();
            foreach (DataGridViewRow item in this.PositionsGridView.SelectedRows)
            {
                PositionsGridView.Rows.RemoveAt(item.Index);
            }
        }

        //Not exactly what I had in mind
        private void PositionsGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //works for one cell at a time
            //PositionsGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Clipboard.GetText();

            //This is perfect but need to be careful with doubleclick
            string s = Clipboard.GetText();
            string[] lines = s.Split('\n');
            int row = PositionsGridView.CurrentCell.RowIndex;
            int col = PositionsGridView.CurrentCell.ColumnIndex;
            foreach (string line in lines)
            {
                string[] cells = line.Split('\t');
                int cellsSelected = cells.Length;
                if (row < PositionsGridView.Rows.Count)
                {
                    for (int i = 0; i < cellsSelected; i++)
                    {
                        if (col + i < PositionsGridView.Columns.Count)
                            PositionsGridView[col + i, row].Value = cells[i];
                        else
                            break;
                    }
                    row++;
                }
                else
                {
                    break;
                }
            }
        }

        //Import from Excel
        private void ImportButton_Click(object sender, EventArgs e)
        {

        }

        //Save as Excel? CSV?
        private void SaveButton_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Update current position textboxes to reflect the current position of the cursor
        /// </summary>
        private void UpdateCurrentPositionTextBoxes()
        {
            CurrentXCoordTextBox.Text = this.CurrentPosition.X.ToString();
            CurrentYCoordTextBox.Text = this.CurrentPosition.Y.ToString();
        }

        /// <summary>
        /// Check whether the input string consists of a valid positive integer
        /// </summary>
        /// <param name="input">The string to check</param>
        /// <returns>True if input is a valid positive integer, otherwise false</returns>
        private bool IsValidNumericalInput(string input)
        {
            int temp = 0;
            return (int.TryParse(input, out temp)) && temp >= 0;
        }

        /// <summary>
        /// Check if the coordinates are valid positive integers and also fit
        /// inside the bounds of the monitor
        /// </summary>
        /// <param name="xCoord">The X coordinate to check</param>
        /// <param name="yCoord">The Y coordinate to check</param>
        /// <returns>True if coordinates are valid, otherwise false</returns>
        private bool CurrentPositionIsValid(string xCoord, string yCoord)
        {
            int x, y, width, height = 0;

            if (int.TryParse(xCoord, out x) && int.TryParse(yCoord, out y))
            {
                width = System.Windows.Forms.SystemInformation.VirtualScreen.Width;
                height = System.Windows.Forms.SystemInformation.VirtualScreen.Height;

                if (x <= width && x >= 0 && y <= height && y >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Thread Helper Class

        internal class ClickThreadHelper
        {
            #region Fields, DLL Imports and Constants

            public List<Point> Points { get; set; } //Hold the list of points in the queue
            public int Iterations { get; set; } //Hold the number of iterations/repeats
            public List<string> ClickType { get; set; } //Is each point right click or left click
            public List<int> Times { get; set; } //Holds sleep times for after each click
            public int[] PointVariance { get; set; } //Holds variance for pixel variants for click points
            public int TimeVariance { get; set; } //Holds variance for pixel variants for click points

            //Import unmanaged functions from DLL library
            [DllImport("user32.dll")]
            public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

            [DllImport("user32.dll", SetLastError = true)]
            public static extern int SendInput(int nInputs, ref INPUT pInputs, int cbSize);

            /// <summary>
            /// Structure for SendInput function holding relevant mouse coordinates and information
            /// </summary>
            public struct INPUT
            {
                public uint type;
                public MOUSEINPUT mi;

            };

            /// <summary>
            /// Structure for SendInput function holding coordinates of the click and other information
            /// </summary>
            public struct MOUSEINPUT
            {
                public int dx;
                public int dy;
                public int mouseData;
                public int dwFlags;
                public int time;
                public IntPtr dwExtraInfo;
            };

            //Constants for use in SendInput and mouse_event
            public const int INPUT_MOUSE = 0x0000;
            public const int MOUSEEVENTF_LEFTDOWN = 0x0002;
            public const int MOUSEEVENTF_LEFTUP = 0x0004;
            public const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
            public const int MOUSEEVENTF_RIGHTUP = 0x0010;
            public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
            public const int MOUSEEVENTF_MIDDLEUP = 0x0040;

            #endregion

            #region Mouse_Event Methods

            /// <summary>
            /// Click the left mouse button at the current cursor position using
            /// the imported mouse_event function
            /// </summary>
            private void ClickLeftMouseButtonMouseEvent()
            {
                //Send a left click down followed by a left click up to simulate a 
                //full left click
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            }

            /// <summary>
            /// Click the right mouse button at the current cursor position using
            /// the imported mouse_event function
            /// </summary>
            private void ClickRightMouseButtonMouseEvent()
            {
                //Send a left click down followed by a right click up to simulate a 
                //full right click
                mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
            }

            #endregion

            #region SendInput Methods

            /// <summary>
            /// Click the left mouse button at the current cursor position using
            /// the imported SendInput function
            /// </summary>
            public void ClickLeftMouseButtonSendInput()
            {
                //Initialise INPUT object with corresponding values for a left click
                INPUT input = new INPUT();
                input.type = INPUT_MOUSE;
                input.mi.dx = 0;
                input.mi.dy = 0;
                input.mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
                input.mi.dwExtraInfo = IntPtr.Zero;
                input.mi.mouseData = 0;
                input.mi.time = 0;

                //Send a left click down followed by a left click up to simulate a 
                //full left click
                SendInput(1, ref input, Marshal.SizeOf(input));
                input.mi.dwFlags = MOUSEEVENTF_LEFTUP;
                SendInput(1, ref input, Marshal.SizeOf(input));

            }

            /// <summary>
            /// Click the left mouse button at the current cursor position using
            /// the imported SendInput function
            /// </summary>
            public void ClickRightMouseButtonSendInput()
            {
                //Initialise INPUT object with corresponding values for a right click
                INPUT input = new INPUT();
                input.type = INPUT_MOUSE;
                input.mi.dx = 0;
                input.mi.dy = 0;
                input.mi.dwFlags = MOUSEEVENTF_RIGHTDOWN;
                input.mi.dwExtraInfo = IntPtr.Zero;
                input.mi.mouseData = 0;
                input.mi.time = 0;

                //Send a right click down followed by a right click up to simulate a 
                //full right click
                SendInput(1, ref input, Marshal.SizeOf(input));
                input.mi.dwFlags = MOUSEEVENTF_RIGHTUP;
                SendInput(1, ref input, Marshal.SizeOf(input));
            }

            #endregion

            #region Methods

            /// <summary>
            /// Iterate through all queued clicks, for each deciding which mouse button
            /// to press and how long to sleep afterwards
            /// 
            /// This method is assigned to the ClickThread and is the only place where
            /// the mouse buttons are pressed
            /// </summary>
            public void Run()
            {
                try
                {
                    int i = 1;

                    while (i <= Iterations)
                    {
                        //Iterate through all queued clicks
                        for (int j = 0; j <= Points.Count - 1; j++)
                        {
                            PointVariance = PointRNGVariance();
                            Point modPoint = new Point(Points[j].X + PointVariance[0], Points[j].Y + PointVariance[1]);

                            SetCursorPosition(modPoint); //Set cursor position onto modded position before clicking
                            if (ClickType[j].Equals("R"))
                            {
                                ClickRightMouseButtonSendInput();
                            }
                            else
                            {
                                ClickLeftMouseButtonSendInput();
                            }
                            TimeVariance = TimeRNGVariance();
                            Thread.Sleep(Times[j] + TimeVariance); //Add in rng time variance
                        }
                        i++;
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            /// <summary>
            /// Set the current position of the cursor to the coordinates held in point
            /// </summary>
            /// <param name="point">Coordinates to set the cursor to</param>
            private void SetCursorPosition(Point point)
            {
                Cursor.Position = point;
            }

            /// <summary>
            /// Include pixel variance based on RNG and an acceptable range.
            /// </summary>
            /// <returns></returns>
            private int[] PointRNGVariance()
            {
                Random pointxrng = new Random();
                Random pointyrng = new Random();
                Random pointxcoin = new Random();
                Random pointycoin = new Random();
                int[] pointVar = new int[2];
                int[] genRNG = new int[4];

                genRNG[0] = pointxrng.Next(0, 15);
                genRNG[1] = pointxcoin.Next(1, 2);
                genRNG[2] = pointyrng.Next(0, 10);
                genRNG[3] = pointycoin.Next(1, 2);

                if (genRNG[1] == 2)
                {
                    genRNG[0] = genRNG[0] * -1;
                }

                if (genRNG[3] == 2)
                {
                    genRNG[2] = genRNG[2] * -1;
                }

                pointVar[0] = genRNG[0];
                pointVar[1] = genRNG[2];

                return pointVar;
            }

            /// <summary>
            /// Include time variance based on RNG and an acceptable range.
            /// </summary>
            /// <returns></returns>
            private int TimeRNGVariance()
            {

                Random timerng = new Random();
                int timeVar;

                timeVar = timerng.Next(0, 500);

                return timeVar;
            }

            #endregion
        }


        #endregion
    }
}
