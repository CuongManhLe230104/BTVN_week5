﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int size = 14;
        string font = "Tahoma";
        private void dinhDangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if(fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.ForeColor = fontDlg.Color;
                richTextBox1.Font = fontDlg.Font;
            }    
        }

        private void AddFontInCMB()
        {
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                cbmFont.Items.Add(font.Name);
            }
        }
        private void AddSizeInCMB()
        {
            int[] sizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 50, 72 };

            foreach (int size in sizes)
            {
                cmbSize.Items.Add(size);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddFontInCMB();
            AddSizeInCMB();
            lamMoiRich();
        }

        private void cbmFont_Click(object sender, EventArgs e)
        {
                    }

        private void lamMoiRich()
        {
            richTextBox1.Clear();
            richTextBox1.Font = new Font("Tahoma", 14, FontStyle.Regular);
            cbmFont.SelectedItem = "Tahoma";
            cmbSize.SelectedItem = 14;
        }

        private void cmbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            size = Int32.Parse(cmbSize.Text);
            richTextBox1.Font = new Font(font, size, FontStyle.Regular);
        }

        private void cbmFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            font = cbmFont.Text;
            richTextBox1.Font = new Font(font, size);
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newFile_Click(object sender, EventArgs e)
        {
            lamMoiRich();
        }

        private void taoMoVanBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lamMoiRich();
        }

        private void openFile_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                lamMoiRich();
                e.Handled = true;
                return;
            }
            if (e.Control && e.KeyCode == Keys.O)
            {
                openFile_Click(this, e);
                e.Handled = true;
                return;
            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                toolStripButton2_click(this, e);
                e.Handled = true;
                return;
            }
        }

        private void toolStripButton2_click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.Title = "Lưu tập tin văn bản";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "Text files|*.txt";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = saveFileDialog.FileName;
                try
                {
                    richTextBox1.SaveFile(selectedFileName, RichTextBoxStreamType.UnicodePlainText);
                    MessageBox.Show("Tập tin đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình lưu tập tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void luuNoiDungVanBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.Title = "Lưu tập tin văn bản";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "Text files|*.txt";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = saveFileDialog.FileName;
                try
                {
                    richTextBox1.SaveFile(selectedFileName, RichTextBoxStreamType.UnicodePlainText);
                    MessageBox.Show("Tập tin đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình lưu tập tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Bold)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & ~FontStyle.Bold);

            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Bold);

            }   
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Italic)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & ~FontStyle.Italic);

            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Italic);

            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Underline)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & ~FontStyle.Underline);

            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Underline);

            }
        }

        private void moTapTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (*.txt) |*.txt|all Files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                try
                {
                    richTextBox1.Text = File.ReadAllText(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening file : ", ex.Message);
                }
            }           
        }
    }
}
