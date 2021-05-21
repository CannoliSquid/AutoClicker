using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SkillerAgent.Properties;

namespace SkillerAgent.Helpers
{
    #region Thread Helper Class

    internal class ThreadHelper
    {
        #region Fields, DLL Imports and Constants

        public List<Point> Points { get; set; } //Hold the list of points in the queue
        public int Iterations { get; set; } //Hold the number of iterations/repeats
        public List<string> ClickType { get; set; } //Is each point right click or left click
        public List<int> Times { get; set; } //Holds sleep times for after each click
        public int[] PointVariance { get; set; } //Holds variance for pixel variants for click points
        public int TimeVariance { get; set; } //Holds variance for pixel variants for click points
                                              //public delegate void InvokeDelegate(int num);
        Label iterCount = Application.OpenForms["MainForm"].Controls["StartingOptionsGroupBox"].Controls["IterationLabel"] as Label;

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
                    iterCount.BeginInvoke(new Action(() => UpdateLabel(i)));

                    //Iterate through all queued clicks
                    for (int j = 0; j <= Points.Count - 1; j++)
                    {
                        PointVariance = PointRNGVariance();
                        Point modPoint = new Point(Points[j].X + PointVariance[0], Points[j].Y + PointVariance[1]);

                        if (j >= 1)
                        {
                            LinearSmoothMove(Points[j - 1], modPoint, 100, 1);
                        }
                        else
                        {
                            LinearSmoothMove(Cursor.Position, modPoint, 100, 1);
                            //SetCursorPosition(modPoint); //Set cursor position onto modded position before clicking
                        }

                        TimeVariance = TimeRNGVariance();
                        Thread.Sleep(Times[j] + TimeVariance); //Add in rng time variance

                        if (ClickType[j].Equals("R"))
                        {
                            ClickRightMouseButtonSendInput();
                        }
                        else
                        {
                            ClickLeftMouseButtonSendInput();
                        }
                    }

                    i++;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Update Label
        public void UpdateLabel(int arg)
        {
            iterCount.Text = arg.ToString();
        }

        //Move cursor along in a straight line.
        public void LinearSmoothMove(Point startingPosition, Point newPosition, int steps, int sleepTime)
        {
            //Point start = GetCursorPosition();
            PointF iterPoint = startingPosition;

            // Find the slope of the line segment defined by start and newPosition
            PointF slope = new PointF(newPosition.X - startingPosition.X, newPosition.Y - startingPosition.Y);

            // Divide by the number of steps
            slope.X = slope.X / steps;
            slope.Y = slope.Y / steps;

            // Move the mouse to each iterative point.
            for (int i = 0; i < steps; i++)
            {
                iterPoint = new PointF(iterPoint.X + slope.X, iterPoint.Y + slope.Y);
                SetCursorPosition(Point.Round(iterPoint));
                Thread.Sleep(sleepTime);
            }

            // Move the mouse to the final destination.
            SetCursorPosition(newPosition);
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
            string xValue = ConfigurationManager.AppSettings["xVariance"];
            string yValue = ConfigurationManager.AppSettings["xVariance"];
            Random pointxrng = new Random();
            Random pointyrng = new Random();
            Random pointxcoin = new Random();
            Random pointycoin = new Random();
            int[] pointVar = new int[2];
            int[] genRNG = new int[4];

            //use 7 for x/5 for y for actual clicking around, 1 x/1 y for ha'ing
            genRNG[0] = pointxrng.Next(0, Convert.ToInt32(xValue));
            genRNG[1] = pointxcoin.Next(1, 2);
            genRNG[2] = pointyrng.Next(0, Convert.ToInt32(yValue));
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
            string timeValue = ConfigurationManager.AppSettings["timeVariance"];

            Random timerng = new Random();
            int timeVar;

            timeVar = timerng.Next(0, Convert.ToInt32(timeValue));

            return timeVar;
        }

        #endregion
    }


    #endregion
}
