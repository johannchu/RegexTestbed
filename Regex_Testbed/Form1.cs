using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Regex_Testbed
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegexMatching(richTextBox1.Text, richTextBox2.Text);
        }
                
        private void RegexMatching(string input, string identifier)
        {
            try
            {
                input = richTextBox1.Text;
                identifier = richTextBox2.Text;
                richTextBox3.Text = "";
                MatchCollection matches = Regex.Matches(input, identifier, RegexOptions.Multiline);
                foreach (Match match in matches)
                {
                    richTextBox3.AppendText(match.Value+"\n");
                }
            }
            catch
            {
                MessageBox.Show("Error in your Regex", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                richTextBox2.Text = "";
            }
        }

        private void richTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RegexMatching(richTextBox1.Text, richTextBox2.Text);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void readToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files (.txt)|*.txt";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;
            openFileDialog1.FileName = "";
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.Stream fileStream = openFileDialog1.OpenFile();
                using (System.IO.StreamReader reader = new System.IO.StreamReader(fileStream))
                {
                    richTextBox1.AppendText(reader.ReadToEnd());
                }
                fileStream.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files (.txt)|*.txt";
            saveFileDialog1.Title = "Save the result";
            saveFileDialog1.ShowDialog();
            
            if (saveFileDialog1.FileName != "")
            {
                System.IO.File.WriteAllLines(saveFileDialog1.FileName, richTextBox3.Lines);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox3.Text = "";
        }
    }
}
