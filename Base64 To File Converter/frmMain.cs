using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Base24_To_File_Converter
{
    public partial class frmMain : Form
    {

        private string fileName;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Show();
            frmMain_Resize(this, null);
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            txtData.Width = this.Width - 72;
            txtData.Height = this.Height - 274
;
            txtFileName.Width = this.Width - 120;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "All Files *.*|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = dlg.FileName;
                fileName = dlg.FileName;
            }


        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFileName.Text))
            {
                fileName = Data.GetNewFile(Application.StartupPath);
                txtFileName.Text = fileName;
            }
            else
            {
                fileName = txtFileName.Text;
            }

            using (Data data = new Data())
            {
                if (data.SaveFile(fileName,txtData.Text))
                {
                    OpenFile(fileName);
                }
                else
                {
                    MessageBox.Show("Error creating the file", "Error ...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }

        private void OpenFile(string fileName)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process()
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo("Explorer.exe")
                {
                    Arguments = fileName

                }
            };

            p.Start();

        }
    }
}
