using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace LingoSub
{
    public partial class Form3 : Form

    {
        public string file_input { get; private set; }

        public string file_output { get; private set; }

        public string filepath = Application.StartupPath;
        public Form3()
        {
            InitializeComponent();
        }

       

        private void powrot_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Srt Files (*.srt)|*.srt";
            openFileDialog.DefaultExt = "srt";
            openFileDialog.AddExtension = true;
            openFileDialog.ShowDialog(this);
            file_input = openFileDialog.FileName;
            file.Text = openFileDialog.FileName;
        }

        private void openDestination_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Srt Files (*.srt)|*.srt";
            saveFileDialog.DefaultExt = "srt";
            saveFileDialog.AddExtension = true;
            saveFileDialog.ShowDialog(this);
            

            file_output = saveFileDialog.FileName;
            destination.Text = saveFileDialog.FileName;
        }

        private void translate_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(filepath + "\\info.txt");
            try
            {
                sw.WriteLine(file_input);
                sw.WriteLine(file_output);
                sw.Close();
            }
            catch (Exception ee)
            {
                Console.WriteLine("Exception: " + ee.Message);
            }

            run_python();


        }

        private void run_python()
        {
            //Process myProcess = new Process();
            //myProcess.StartInfo.UseShellExecute = false;
            //myProcess.StartInfo.FileName = @"C:\Users\rumca\source\repos\LingoSub\LingoSub\bin\Debug\shortcut.lnk";
            //myProcess.Start();

            Process.Start(@"C:\Users\rumca\source\repos\LingoSub\LingoSub\bin\Debug\shortcut.exe.lnk");



        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
