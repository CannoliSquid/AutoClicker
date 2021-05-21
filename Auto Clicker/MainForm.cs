using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Runtime.InteropServices;
using SkillerAgent.Helpers;
using System.IO;
using System.Data;
using System.Linq;
using System.Configuration;

/// <summary>
/// Credit goes to Ryan Harrison (raharrison on GitHub) for starting this project.
/// I'm introducing my own spin on it with some changes that hopefully help with games that are less auto-click friendly.
/// </summary>
namespace SkillerAgent
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
            ReadAllSettings();
        }

        //Test to make sure settings are valid.
        static void ReadAllSettings()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("AppSettings is empty.");
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                        Console.WriteLine("Key: {0} Value: {1}", key, appSettings[key]);
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }

        /// <summary>
        /// Handle keyboard shortcuts from the user
        /// </summary>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.F1)
            {
                CopyToAddButton_Click(null, null);
            }
            else if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.F2)
            {
                AddPositionButton_Click(null, null);
            }
            else if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.F3)
            {
                StartClickingButton_Click(null, null);
            }
            else if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.F4)
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
                    //Add coordinates, right/left click and sleep time to data grid view holding all queued clicks
                    string clickType = (RightClickCheckBox.Checked) == true ? "R" : "L";
                    int sleepTime = Convert.ToInt32(SleepTimeTextBox.Text);

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
                    ThreadHelper helper = new ThreadHelper() { Points = points, ClickType = clickType, Iterations = iterations, Times = times };
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

        //Right click to open context menu - need to fix
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

        //Import from CSV
        private void ImportButton_Click(object sender, EventArgs e)
        {
            //Open File Dialog, add filter
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV (*.csv)|*.csv";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //Get path, pass to readCSV, import into datatable
                string sFileName = ofd.FileName;
                DataTable data = readCSV(sFileName);

                //Iterate through rows, add datatable row to datagridview, < -1 to prevent extra "ghost" row from throwing error.
                for (int i = 0; i < data.Rows.Count-1; i++)
                {
                    PositionsGridView.Rows.Add(data.Rows[i].ItemArray);
                    string cellinfo = data.Rows[i].ItemArray.GetValue(0).ToString();
                    string[] cells = cellinfo.Split(',');

                    //Iterate through cells.
                    for (int j = 0; j < PositionsGridView.Rows[i].Cells.Count; j++)
                    {
                        PositionsGridView.Rows[i].Cells[j].Value = cells[j];
                    }
                }
            }
        }

        //Save as CSV
        private void SaveButton_Click(object sender, EventArgs e)
        {
            //Check for rows.
            if (PositionsGridView.Rows.Count > 0)
            {
                //Save File Dialog, add filter/file name
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "Output.csv";
                bool fileError = false;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //Check if exists, if so, overwrite.
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("An error occurred while saving the data: " + ex.Message, "Error");
                        }
                    }
                    
                    //If doesn't exist/exists and can overwrite...
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = PositionsGridView.Columns.Count;
                            string columnNames = "";
                            string[] outputCsv = new string[PositionsGridView.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += PositionsGridView.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 0; i < PositionsGridView.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCsv[i] += PositionsGridView.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }

                            File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                            MessageBox.Show("Data Exported Successfully.", "Success");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred :" + ex.Message, "Error");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("There is no data to save. Please enter data in the data grid to save it.", "Error");
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["HelpForm"];
            if (form != null)
            {
                form.Close();
            }
            else
            {
                HelpForm help = new HelpForm();

                help.Show();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["SettingsForm"];
            if (form != null)
            {
                form.Close();
            }
            else
            {
                SettingsForm settings = new SettingsForm();

                settings.Show();
            }
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

        //Use Linq to read 
        public DataTable readCSV(string filePath)
        {
            var dt = new DataTable();

            // Creating the columns
            File.ReadLines(filePath).Take(1)
                .SelectMany(x => x.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                .ToList()
                .ForEach(x => dt.Columns.Add(x.Trim()));

            // Adding the rows
            File.ReadLines(filePath).Skip(1)
                .Select(x => x.Split(';'))
                .ToList()
                .ForEach(line => dt.Rows.Add(line));

            return dt;
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
    }
}
