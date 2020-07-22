namespace R6_Stat_Tracker_GUI
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
            this.btnUpload = new System.Windows.Forms.Button();
            this.lblUpload = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kills = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Assists = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deaths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(29, 73);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(86, 23);
            this.btnUpload.TabIndex = 1;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // lblUpload
            // 
            this.lblUpload.AutoSize = true;
            this.lblUpload.Location = new System.Drawing.Point(26, 32);
            this.lblUpload.Name = "lblUpload";
            this.lblUpload.Size = new System.Drawing.Size(89, 13);
            this.lblUpload.TabIndex = 2;
            this.lblUpload.Text = "Upload Game SS";
            this.lblUpload.Click += new System.EventHandler(this.lblUpload_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlayerName,
            this.Score,
            this.Kills,
            this.Assists,
            this.Deaths});
            this.dataGridView1.Location = new System.Drawing.Point(162, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(545, 400);
            this.dataGridView1.TabIndex = 3;
            // 
            // PlayerName
            // 
            this.PlayerName.HeaderText = "Player Name";
            this.PlayerName.Name = "PlayerName";
            // 
            // Score
            // 
            this.Score.HeaderText = "Score";
            this.Score.Name = "Score";
            // 
            // Kills
            // 
            this.Kills.HeaderText = "Kills";
            this.Kills.Name = "Kills";
            this.Kills.Width = 50;
            // 
            // Assists
            // 
            this.Assists.HeaderText = "Assists";
            this.Assists.Name = "Assists";
            this.Assists.Width = 50;
            // 
            // Deaths
            // 
            this.Deaths.HeaderText = "Deaths";
            this.Deaths.Name = "Deaths";
            this.Deaths.Width = 50;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 444);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblUpload);
            this.Controls.Add(this.btnUpload);
            this.Name = "Form1";
            this.Text = "R6 Stat Tracker";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label lblUpload;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kills;
        private System.Windows.Forms.DataGridViewTextBoxColumn Assists;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deaths;
    }
}

