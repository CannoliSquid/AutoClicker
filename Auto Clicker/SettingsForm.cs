using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkillerAgent
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            ReadAllSettings();
        }

        //Test to make sure settings are valid.
        private void ReadAllSettings()
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

                        switch (key)
                        {
                            case "xVariance":
                                xVarTextBox.Text = appSettings["xVariance"].ToString();
                                break;
                            case "yVariance":
                                yVarTextBox.Text = appSettings["yVariance"].ToString();
                                break;
                            case "timeVariance":
                                timeVarTextBox.Text = appSettings["timeVariance"].ToString();
                                break;
                        }
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var appSettings = ConfigurationManager.AppSettings;

            //Check X Variance
            try
            {
                int xVal;

                if (int.TryParse(xVarTextBox.Text, out xVal))
                {
                    appSettings["xVariance"] = xVal.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Error", "Please enter a valid integer.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            //Check Y Variance
            try
            {
                int yVal;

                if (int.TryParse(yVarTextBox.Text, out yVal))
                {
                    appSettings["yVariance"] = yVal.ToString();
                }
            }
            catch
                {
                MessageBox.Show("Error", "Please enter a valid integer.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            //Check Time Variance
            try
            {
                int timeVal; 

                if (int.TryParse(timeVarTextBox.Text, out timeVal))
                {
                    appSettings["timeVariance"] = timeVal.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Error", "Please enter a valid integer.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
