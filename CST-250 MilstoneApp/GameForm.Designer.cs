namespace CST_250_MilstoneApp
{
    partial class GameForm
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
            components = new System.ComponentModel.Container();
            MenuButton = new Button();
            panel1 = new Panel();
            TimerLabel = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // MenuButton
            // 
            MenuButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MenuButton.BackColor = SystemColors.WindowText;
            MenuButton.DialogResult = DialogResult.Cancel;
            MenuButton.FlatAppearance.BorderColor = Color.Lime;
            MenuButton.FlatAppearance.MouseDownBackColor = Color.Lime;
            MenuButton.FlatAppearance.MouseOverBackColor = Color.DarkSlateGray;
            MenuButton.FlatStyle = FlatStyle.Flat;
            MenuButton.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            MenuButton.ForeColor = Color.Lime;
            MenuButton.Location = new Point(212, 430);
            MenuButton.Name = "MenuButton";
            MenuButton.Size = new Size(178, 68);
            MenuButton.TabIndex = 0;
            MenuButton.Text = "Menu";
            MenuButton.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Location = new Point(0, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(420, 420);
            panel1.TabIndex = 1;
            // 
            // TimerLabel
            // 
            TimerLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            TimerLabel.AutoSize = true;
            TimerLabel.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            TimerLabel.ForeColor = Color.LimeGreen;
            TimerLabel.Location = new Point(0, 444);
            TimerLabel.Name = "TimerLabel";
            TimerLabel.Size = new Size(33, 40);
            TimerLabel.TabIndex = 2;
            TimerLabel.Text = "0";
            TimerLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(419, 510);
            Controls.Add(TimerLabel);
            Controls.Add(panel1);
            Controls.Add(MenuButton);
            ForeColor = SystemColors.ButtonFace;
            Name = "GameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Minesweeper";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button MenuButton;
        private Panel panel1;
        private Label TimerLabel;
        private System.Windows.Forms.Timer timer1;
    }
}