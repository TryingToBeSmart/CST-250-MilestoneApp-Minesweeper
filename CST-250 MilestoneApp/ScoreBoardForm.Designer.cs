namespace CST_250_MilstoneApp
{
    partial class ScoreBoardForm
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
            SmallGroupBox = new GroupBox();
            SmallLabel = new Label();
            LargGroupBox = new GroupBox();
            LargeLabel = new Label();
            MediumGroupBox = new GroupBox();
            MediumLabel = new Label();
            SmallGroupBox.SuspendLayout();
            LargGroupBox.SuspendLayout();
            MediumGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // SmallGroupBox
            // 
            SmallGroupBox.Controls.Add(SmallLabel);
            SmallGroupBox.ForeColor = Color.Lime;
            SmallGroupBox.Location = new Point(12, 12);
            SmallGroupBox.Name = "SmallGroupBox";
            SmallGroupBox.Size = new Size(453, 239);
            SmallGroupBox.TabIndex = 0;
            SmallGroupBox.TabStop = false;
            SmallGroupBox.Text = "Small";
            // 
            // SmallLabel
            // 
            SmallLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            SmallLabel.Location = new Point(6, 56);
            SmallLabel.Name = "SmallLabel";
            SmallLabel.Size = new Size(441, 171);
            SmallLabel.TabIndex = 0;
            // 
            // LargGroupBox
            // 
            LargGroupBox.Controls.Add(LargeLabel);
            LargGroupBox.ForeColor = Color.Lime;
            LargGroupBox.Location = new Point(969, 12);
            LargGroupBox.Name = "LargGroupBox";
            LargGroupBox.Size = new Size(453, 239);
            LargGroupBox.TabIndex = 1;
            LargGroupBox.TabStop = false;
            LargGroupBox.Text = "Large";
            // 
            // LargeLabel
            // 
            LargeLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            LargeLabel.Location = new Point(6, 56);
            LargeLabel.Name = "LargeLabel";
            LargeLabel.Size = new Size(441, 171);
            LargeLabel.TabIndex = 2;
            // 
            // MediumGroupBox
            // 
            MediumGroupBox.Controls.Add(MediumLabel);
            MediumGroupBox.ForeColor = Color.Lime;
            MediumGroupBox.Location = new Point(493, 12);
            MediumGroupBox.Name = "MediumGroupBox";
            MediumGroupBox.Size = new Size(453, 239);
            MediumGroupBox.TabIndex = 1;
            MediumGroupBox.TabStop = false;
            MediumGroupBox.Text = "Medium";
            // 
            // MediumLabel
            // 
            MediumLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            MediumLabel.Location = new Point(6, 56);
            MediumLabel.Name = "MediumLabel";
            MediumLabel.Size = new Size(441, 171);
            MediumLabel.TabIndex = 1;
            // 
            // ScoreBoardForm
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1437, 268);
            Controls.Add(LargGroupBox);
            Controls.Add(MediumGroupBox);
            Controls.Add(SmallGroupBox);
            Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.Lime;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(6, 7, 6, 7);
            Name = "ScoreBoardForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Score Board";
            SmallGroupBox.ResumeLayout(false);
            LargGroupBox.ResumeLayout(false);
            MediumGroupBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox SmallGroupBox;
        private GroupBox LargGroupBox;
        private GroupBox MediumGroupBox;
        private Label SmallLabel;
        private Label LargeLabel;
        private Label MediumLabel;
    }
}