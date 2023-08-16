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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LingoSub
{
    public partial class Form2 : Form
    {
        public string filepath = Application.StartupPath;
        public Form2()
        {
            InitializeComponent();
            if (File.Exists(filepath + "\\settings.txt"))
            {
                StreamReader streamReader = new StreamReader(filepath + "\\settings.txt");
                try
                {
                    comboBox1.Text = streamReader.ReadLine().ToString();
                    textBox1.Text = streamReader.ReadLine().ToString();
                    streamReader.Close();
                }
                catch (Exception ee)
                {
                    Console.WriteLine("Exception: " + ee.Message);
                }
            }
            else
            {
                string path = filepath + "\\settings.txt";
                using (File.CreateText(path)) ;
                
            }
            
        }

        private void powrot_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(filepath + "\\settings.txt");
            try
            {
                sw.WriteLine(comboBox1.Text.ToString());
                sw.WriteLine(textBox1.Text.ToString());
                sw.Close();
            }
            catch (Exception ee)
            {
                Console.WriteLine("Exception: " + ee.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
