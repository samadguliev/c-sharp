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
        private string newfilename;
        private string filename;

        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFileDialog1.FileName.Length > 0)
            {
                try
                {
                    richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText);

                }
                catch (System.AggregateException)
                {
                    richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFileDialog1.FileName.Length > 0)
             {
                 richTextBox1.SaveFile(saveFileDialog1.FileName);
                 this.Text = "Файл [" + saveFileDialog1.FileName + "]";

             }*/
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Текстовые файлы | *.rtf";
            sfd.DefaultExt = ".rtf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                filename = sfd.FileName;
                richTextBox1.SaveFile(filename);
                this.Text = sfd.FileName;
                newfilename = sfd.FileName;
            }

        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void цветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }

        private void поЛевомуКраюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void поЦентруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void поПравомуКраюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename != null)
            {
                richTextBox1.SaveFile(filename);
                this.Text = newfilename;
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Текстовые файлы | *.rtf";
                sfd.DefaultExt = ".rtf";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    filename = sfd.FileName;
                    richTextBox1.SaveFile(filename);
                    this.Text = sfd.FileName;
                    newfilename = sfd.FileName;

                }
            }
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength != 0)
            {
                DialogResult res = MessageBox.Show("Тут есть текст. Сохранить?", "Внимание", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.FileName = "Без имени";
                    sfd.Filter = "Текстовый докуменет ТЕСТ|*.rtf";


                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(sfd.FileName, richTextBox1.Text);
                    }
                }
                if (res == DialogResult.Yes)
                {
                    richTextBox1.Clear();
                }
            }
        }

        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
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
    }
}
