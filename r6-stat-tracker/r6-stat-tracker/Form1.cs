using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Tesseract;


namespace r6_stat_tracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDetectScore_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var img = new Bitmap(fileDialog.FileName);
                var ocr = new TesseractEngine(@"C:\Users\Stef\Documents\GitHub Projects\Personal\R6-Stat-Tracker\r6-stat-tracker\tessdata", "eng", EngineMode.Default);
                var page = ocr.Process(img);
                txtScores.Text = page.GetText();
            }
        }
    }
}
