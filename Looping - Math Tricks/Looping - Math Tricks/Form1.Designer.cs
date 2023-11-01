namespace Looping___Math_Tricks
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
            this.boardPanel = new System.Windows.Forms.Panel();
            this.startGameBtn = new System.Windows.Forms.Button();
            this.mInputBox = new System.Windows.Forms.TextBox();
            this.nInputBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.playerRedScore = new System.Windows.Forms.Label();
            this.playerBlueScore = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // boardPanel
            // 
            this.boardPanel.BackColor = System.Drawing.SystemColors.Control;
            this.boardPanel.Location = new System.Drawing.Point(12, 12);
            this.boardPanel.Name = "boardPanel";
            this.boardPanel.Size = new System.Drawing.Size(1327, 689);
            this.boardPanel.TabIndex = 0;
            // 
            // startGameBtn
            // 
            this.startGameBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startGameBtn.Location = new System.Drawing.Point(477, 711);
            this.startGameBtn.Name = "startGameBtn";
            this.startGameBtn.Size = new System.Drawing.Size(139, 25);
            this.startGameBtn.TabIndex = 1;
            this.startGameBtn.Text = "Start";
            this.startGameBtn.UseVisualStyleBackColor = true;
            this.startGameBtn.Click += new System.EventHandler(this.startGameBtn_Click);
            // 
            // mInputBox
            // 
            this.mInputBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mInputBox.Location = new System.Drawing.Point(323, 713);
            this.mInputBox.Name = "mInputBox";
            this.mInputBox.Size = new System.Drawing.Size(100, 22);
            this.mInputBox.TabIndex = 2;
            // 
            // nInputBox
            // 
            this.nInputBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nInputBox.Location = new System.Drawing.Point(94, 713);
            this.nInputBox.Name = "nInputBox";
            this.nInputBox.Size = new System.Drawing.Size(100, 22);
            this.nInputBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 715);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Width (<=15)";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 715);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Height (<=15)";
            // 
            // playerRedScore
            // 
            this.playerRedScore.AutoSize = true;
            this.playerRedScore.Location = new System.Drawing.Point(1002, 716);
            this.playerRedScore.Name = "playerRedScore";
            this.playerRedScore.Size = new System.Drawing.Size(88, 16);
            this.playerRedScore.TabIndex = 5;
            this.playerRedScore.Text = "Player Red: 0";
            // 
            // playerBlueScore
            // 
            this.playerBlueScore.AutoSize = true;
            this.playerBlueScore.Location = new System.Drawing.Point(1177, 716);
            this.playerBlueScore.Name = "playerBlueScore";
            this.playerBlueScore.Size = new System.Drawing.Size(89, 16);
            this.playerBlueScore.TabIndex = 5;
            this.playerBlueScore.Text = "Player Blue: 0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(869, 715);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "SCORES:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 744);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.playerBlueScore);
            this.Controls.Add(this.playerRedScore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nInputBox);
            this.Controls.Add(this.mInputBox);
            this.Controls.Add(this.startGameBtn);
            this.Controls.Add(this.boardPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Math Tricks";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel boardPanel;
        private System.Windows.Forms.Button startGameBtn;
        private System.Windows.Forms.TextBox mInputBox;
        private System.Windows.Forms.TextBox nInputBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label playerRedScore;
        private System.Windows.Forms.Label playerBlueScore;
        private System.Windows.Forms.Label label3;
    }
}

