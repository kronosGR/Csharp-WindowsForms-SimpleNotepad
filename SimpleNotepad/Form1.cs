using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleNotepad
{
    public partial class frmMain : Form
    {
        string Filename;

        void DoSave(string filename)
        {
            Filename = filename;
            textBox.SaveFile(filename);
        }

        void DoSaveAs()
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DoSave(saveFileDialog1.FileName);
            }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Clear();
        }

        private bool CheckChanges()
        {
            return true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckChanges())
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox.LoadFile(openFileDialog1.FileName);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Filename))
            {
                DoSaveAs();
            } else
            {
                DoSave(Filename);
            }
        }
    }
}
