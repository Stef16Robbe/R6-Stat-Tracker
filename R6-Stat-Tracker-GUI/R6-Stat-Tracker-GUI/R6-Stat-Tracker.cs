using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R6_Stat_Tracker_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                // dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|.png| All Files(*.*)|*.*";
                dialog.Filter = "All Files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string filetype = System.IO.Path.GetExtension(dialog.FileName);
                    if (filetype == ".png" || filetype == ".jpg" || filetype == ".jpeg")
                    {
                        imageLocation = dialog.FileName;

                        // do something with img location to PY ...
                        ExecPyProcess(imageLocation);
                    } else
                    {
                        throw new Exception();
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Ocurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExecPyProcess(string imageLocation)
        {
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Users\Stef Robbe\AppData\Local\Programs\Python\Python38-32\python.exe";

            var script = @"C:\Users\Stef Robbe\Documents\GitHub projects\Personal\R6-Stat-Tracker\stat-tracker\stat-tracker.py";
            
            psi.Arguments = $"\"{script}\" \"{imageLocation}\"";

            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            var errors = "";
            var result = "";

            using(var process = Process.Start(psi))
            {
                errors = process.StandardError.ReadToEnd();
                result = process.StandardOutput.ReadToEnd();
            }

            if (errors != "")
            {
                lblError.Text = errors;
            }
            if (result != "")
            {
                lblResult.Text = result;
            }
        }
    }
}
