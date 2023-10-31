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
                      
            comboBox1.Text = Properties.Settings.Default.Language;
            textBox1.Text = Properties.Settings.Default.APIKey;


        }

        private void powrot_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Properties.Settings.Default.Language = comboBox1.Text;
            Properties.Settings.Default.APIKey = textBox1.Text;
            Properties.Settings.Default.Save();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
