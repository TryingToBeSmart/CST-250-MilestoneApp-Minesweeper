namespace CST_250_MilstoneApp
{
    partial class MenuForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DifficultyGroupBox = new GroupBox();
            HardRadioButton = new RadioButton();
            ModerateRadioButton = new RadioButton();
            EasyRadioButton = new RadioButton();
            SizeGroupBox = new GroupBox();
            LargeRadioButton = new RadioButton();
            MediumRadioButton = new RadioButton();
            SmallRadioButton = new RadioButton();
            StartButton = new Button();
            ScoreBoardButton = new Button();
            DifficultyGroupBox.SuspendLayout();
            SizeGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // DifficultyGroupBox
            // 
            DifficultyGroupBox.BackColor = SystemColors.ActiveCaptionText;
            DifficultyGroupBox.Controls.Add(HardRadioButton);
            DifficultyGroupBox.Controls.Add(ModerateRadioButton);
            DifficultyGroupBox.Controls.Add(EasyRadioButton);
            DifficultyGroupBox.ForeColor = Color.Lime;
            DifficultyGroupBox.Location = new Point(12, 12);
            DifficultyGroupBox.Name = "DifficultyGroupBox";
            DifficultyGroupBox.Size = new Size(200, 200);
            DifficultyGroupBox.TabIndex = 0;
            DifficultyGroupBox.TabStop = false;
            DifficultyGroupBox.Text = "Difficulty";
            // 
            // HardRadioButton
            // 
            HardRadioButton.AutoSize = true;
            HardRadioButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            HardRadioButton.Location = new Point(40, 134);
            HardRadioButton.Name = "HardRadioButton";
            HardRadioButton.Size = new Size(76, 34);
            HardRadioButton.TabIndex = 2;
            HardRadioButton.Text = "Hard";
            HardRadioButton.UseVisualStyleBackColor = true;
            // 
            // ModerateRadioButton
            // 
            ModerateRadioButton.AutoSize = true;
            ModerateRadioButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            ModerateRadioButton.Location = new Point(40, 94);
            ModerateRadioButton.Name = "ModerateRadioButton";
            ModerateRadioButton.Size = new Size(121, 34);
            ModerateRadioButton.TabIndex = 1;
            ModerateRadioButton.Text = "Moderate";
            ModerateRadioButton.UseVisualStyleBackColor = true;
            // 
            // EasyRadioButton
            // 
            EasyRadioButton.AutoSize = true;
            EasyRadioButton.Checked = true;
            EasyRadioButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            EasyRadioButton.Location = new Point(40, 54);
            EasyRadioButton.Name = "EasyRadioButton";
            EasyRadioButton.Size = new Size(72, 34);
            EasyRadioButton.TabIndex = 0;
            EasyRadioButton.TabStop = true;
            EasyRadioButton.Text = "Easy";
            EasyRadioButton.UseVisualStyleBackColor = true;
            // 
            // SizeGroupBox
            // 
            SizeGroupBox.BackColor = SystemColors.ActiveCaptionText;
            SizeGroupBox.Controls.Add(LargeRadioButton);
            SizeGroupBox.Controls.Add(MediumRadioButton);
            SizeGroupBox.Controls.Add(SmallRadioButton);
            SizeGroupBox.ForeColor = Color.Lime;
            SizeGroupBox.Location = new Point(222, 12);
            SizeGroupBox.Name = "SizeGroupBox";
            SizeGroupBox.Size = new Size(200, 200);
            SizeGroupBox.TabIndex = 1;
            SizeGroupBox.TabStop = false;
            SizeGroupBox.Text = "Size";
            // 
            // LargeRadioButton
            // 
            LargeRadioButton.AutoSize = true;
            LargeRadioButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            LargeRadioButton.Location = new Point(45, 134);
            LargeRadioButton.Name = "LargeRadioButton";
            LargeRadioButton.Size = new Size(82, 34);
            LargeRadioButton.TabIndex = 5;
            LargeRadioButton.Text = "Large";
            LargeRadioButton.UseVisualStyleBackColor = true;
            // 
            // MediumRadioButton
            // 
            MediumRadioButton.AutoSize = true;
            MediumRadioButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            MediumRadioButton.Location = new Point(45, 94);
            MediumRadioButton.Name = "MediumRadioButton";
            MediumRadioButton.Size = new Size(108, 34);
            MediumRadioButton.TabIndex = 4;
            MediumRadioButton.Text = "Medium";
            MediumRadioButton.UseVisualStyleBackColor = true;
            // 
            // SmallRadioButton
            // 
            SmallRadioButton.AutoSize = true;
            SmallRadioButton.Checked = true;
            SmallRadioButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            SmallRadioButton.Location = new Point(45, 54);
            SmallRadioButton.Name = "SmallRadioButton";
            SmallRadioButton.Size = new Size(81, 34);
            SmallRadioButton.TabIndex = 3;
            SmallRadioButton.TabStop = true;
            SmallRadioButton.Text = "Small";
            SmallRadioButton.UseVisualStyleBackColor = true;
            // 
            // StartButton
            // 
            StartButton.BackColor = SystemColors.MenuText;
            StartButton.FlatAppearance.BorderColor = Color.Lime;
            StartButton.FlatAppearance.MouseDownBackColor = Color.Lime;
            StartButton.FlatStyle = FlatStyle.Flat;
            StartButton.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            StartButton.Location = new Point(12, 218);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(200, 65);
            StartButton.TabIndex = 0;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = false;
            StartButton.Click += StartButton_Click;
            // 
            // ScoreBoardButton
            // 
            ScoreBoardButton.BackColor = SystemColors.MenuText;
            ScoreBoardButton.FlatAppearance.BorderColor = Color.Lime;
            ScoreBoardButton.FlatAppearance.MouseDownBackColor = Color.Lime;
            ScoreBoardButton.FlatStyle = FlatStyle.Flat;
            ScoreBoardButton.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            ScoreBoardButton.Location = new Point(222, 218);
            ScoreBoardButton.Name = "ScoreBoardButton";
            ScoreBoardButton.Size = new Size(200, 65);
            ScoreBoardButton.TabIndex = 2;
            ScoreBoardButton.Text = "Scores";
            ScoreBoardButton.UseVisualStyleBackColor = false;
            ScoreBoardButton.Click += ScoreBoardButton_Click;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(434, 292);
            Controls.Add(ScoreBoardButton);
            Controls.Add(StartButton);
            Controls.Add(SizeGroupBox);
            Controls.Add(DifficultyGroupBox);
            Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.Lime;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(6, 7, 6, 7);
            Name = "MenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Minesweeper";
            DifficultyGroupBox.ResumeLayout(false);
            DifficultyGroupBox.PerformLayout();
            SizeGroupBox.ResumeLayout(false);
            SizeGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox DifficultyGroupBox;
        private GroupBox SizeGroupBox;
        private Button StartButton;
        private RadioButton HardRadioButton;
        private RadioButton ModerateRadioButton;
        private RadioButton EasyRadioButton;
        private RadioButton LargeRadioButton;
        private RadioButton MediumRadioButton;
        private RadioButton SmallRadioButton;
        private Button ScoreBoardButton;
    }
}