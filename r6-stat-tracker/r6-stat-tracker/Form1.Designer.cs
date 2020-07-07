namespace r6_stat_tracker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDetectScore = new System.Windows.Forms.Button();
            this.txtScores = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnDetectScore
            // 
            this.btnDetectScore.Location = new System.Drawing.Point(12, 12);
            this.btnDetectScore.Name = "btnDetectScore";
            this.btnDetectScore.Size = new System.Drawing.Size(108, 23);
            this.btnDetectScore.TabIndex = 3;
            this.btnDetectScore.Text = "Detect Score";
            this.btnDetectScore.UseVisualStyleBackColor = true;
            this.btnDetectScore.Click += new System.EventHandler(this.btnDetectScore_Click);
            // 
            // txtScores
            // 
            this.txtScores.Location = new System.Drawing.Point(12, 56);
            this.txtScores.Multiline = true;
            this.txtScores.Name = "txtScores";
            this.txtScores.Size = new System.Drawing.Size(358, 189);
            this.txtScores.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 326);
            this.Controls.Add(this.txtScores);
            this.Controls.Add(this.btnDetectScore);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDetectScore;
        private System.Windows.Forms.TextBox txtScores;
    }
}

