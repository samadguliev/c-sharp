using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private string FilePath = "";
        private bool condition = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog.FileName)) 
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog.FileName);
                FilePath = openFileDialog.FileName;
                condition = false; 
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (condition)
            {
                SaveFileDialog saveFile1 = new SaveFileDialog();
                saveFile1.DefaultExt = "*.txt";
                saveFile1.Filter = "Text files|*.txt";
                DialogResult result = saveFile1.ShowDialog();
                condition = false;
                if (result == System.Windows.Forms.DialogResult.OK && saveFile1.FileName.Length > 0)
                {
                    FilePath = saveFile1.FileName;
                    {
                        using (StreamWriter sw = new StreamWriter(saveFile1.FileName))
                        {
                            sw.WriteLine(richTextBox1.Text);
                            sw.Close();
                        }
                    }
                }

            }

            else
            {
                DialogResult result = MessageBox.Show("Сохранить?", "Сохранить", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    File.WriteAllText(FilePath, richTextBox1.Text);
                else { }
            }
        }
        

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
            {
                richTextBox1.Cut();
            }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();
            saveFile1.DefaultExt = "*.txt";
            saveFile1.Filter = "Text files|*.txt";
            DialogResult result = saveFile1.ShowDialog();
            condition = false;
            if (result == System.Windows.Forms.DialogResult.OK && saveFile1.FileName.Length > 0)
            {
                FilePath = saveFile1.FileName;
                {
                    using (StreamWriter sw = new StreamWriter(saveFile1.FileName))
                    {
                        sw.WriteLine(richTextBox1.Text);
                        sw.Close();
                    }
                }
            }

        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
