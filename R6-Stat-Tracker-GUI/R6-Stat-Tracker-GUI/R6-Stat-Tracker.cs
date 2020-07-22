using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
                dialog.Filter = "All Files(*.*)|*.*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string filetype = System.IO.Path.GetExtension(dialog.FileName);
                    if (filetype == ".png" || filetype == ".jpg" || filetype == ".jpeg")
                    {
                        imageLocation = dialog.FileName;

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
            // psi.FileName = @"C:\Users\Stef Robbe\AppData\Local\Programs\Python\Python38-32\python.exe";
            // string script = @"C:\Users\Stef Robbe\Documents\GitHub projects\Personal\R6-Stat-Tracker\stat-tracker\stat-tracker.py";
            
            var psi = new ProcessStartInfo();
            psi.FileName = GetPythonPath();

            string script = @"..\..\..\..\stat-tracker\stat-tracker.py";

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
                //lblError.Text = errors;
            }
            if (result != "")
            {
                ShowScores(result);
            }
        }

        // Get python path from environtment variable
        string GetPythonPath()
        {
            System.Collections.IDictionary environmentVariables = Environment.GetEnvironmentVariables();
            string pathVariable = environmentVariables["Path"] as string;
            if (pathVariable != null)
            {
                string[] allPaths = pathVariable.Split(';');
                foreach (var path in allPaths)
                {
                    string pythonPathFromEnv = path + "\\python.exe";
                    if (File.Exists(pythonPathFromEnv))
                        return pythonPathFromEnv;
                }
            }
            return "";
        }

        void ShowScores(string result)
        {
            result = result.Replace(System.Environment.NewLine, ",");
            result = result.Remove(result.Length - 1);
            string[] scores = result.Split(',');
            List<Player> players = new List<Player>();

            int count = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                if (count == 5)
                {
                    players.Add(new Player() { Name = scores[i - 5], Score = int.Parse(scores[i - 4]), Kills = int.Parse(scores[i - 3]), Assists = int.Parse(scores[i - 2]), Deaths = int.Parse(scores[i - 1])});
                    count = 0;
                }
                count++;
            }
            dataGridView1.DataSource = players;
        }

        private void lblUpload_Click(object sender, EventArgs e)
        {

        }
    }
}
