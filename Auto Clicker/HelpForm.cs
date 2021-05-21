using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkillerAgent
{
    public partial class HelpForm : Form
    {
        string[] files = Directory.GetFiles("HelpTopics", "*.txt", SearchOption.TopDirectoryOnly);

        public HelpForm()
        {
            InitializeComponent();
        }

        //Load file list on load, populate textbox with "Welcome" message.
        private void HelpForm_Load(object sender, EventArgs e)
        {
            LoadFileList();
            LoadFileData("Welcome");
        }

        //Read from text file.
        private void LoadFileData(string fileName)
        {
            foreach(string filePath in files)
            {
                if (filePath.Contains(fileName))
                {
                    contentTextBox.Text = File.ReadAllText(filePath);
                    break;
                }
            }
        }

        //Populate listbox with filenames.
        private void LoadFileList()
        {
            topicListBox.Items.Clear();
            DirectoryInfo dinfo = new DirectoryInfo(@"HelpTopics");
            FileInfo[] smFiles = dinfo.GetFiles("*.txt");
            foreach (FileInfo fi in smFiles)
            {
                topicListBox.Items.Add(Path.GetFileNameWithoutExtension(fi.Name));
            }
        }

        //When Listbox selected item changed, load file data.
        private void topicListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFileData(topicListBox.SelectedItem.ToString());
        }
    }
}
