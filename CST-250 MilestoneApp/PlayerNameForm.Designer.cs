namespace CST_250_MilstoneApp
{
    partial class PlayerNameForm
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
            PlayerNameTextBox = new TextBox();
            label1 = new Label();
            EnterButton = new Button();
            SuspendLayout();
            // 
            // PlayerNameTextBox
            // 
            PlayerNameTextBox.BackColor = SystemColors.InactiveCaptionText;
            PlayerNameTextBox.ForeColor = Color.Lime;
            PlayerNameTextBox.Location = new Point(12, 52);
            PlayerNameTextBox.MaxLength = 8;
            PlayerNameTextBox.Name = "PlayerNameTextBox";
            PlayerNameTextBox.Size = new Size(321, 46);
            PlayerNameTextBox.TabIndex = 0;
            PlayerNameTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 9);
            label1.Name = "label1";
            label1.Size = new Size(232, 40);
            label1.TabIndex = 1;
            label1.Text = "Enter Your Name";
            // 
            // EnterButton
            // 
            EnterButton.DialogResult = DialogResult.OK;
            EnterButton.FlatAppearance.BorderColor = Color.Lime;
            EnterButton.FlatAppearance.MouseDownBackColor = Color.Lime;
            EnterButton.FlatStyle = FlatStyle.Flat;
            EnterButton.Location = new Point(78, 104);
            EnterButton.Name = "EnterButton";
            EnterButton.Size = new Size(193, 58);
            EnterButton.TabIndex = 2;
            EnterButton.Text = "Enter";
            EnterButton.UseVisualStyleBackColor = true;
            EnterButton.Click += EnterButton_Click;
            // 
            // PlayerNameForm
            // 
            AcceptButton = EnterButton;
            AutoScaleDimensions = new SizeF(16F, 40F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(345, 181);
            Controls.Add(EnterButton);
            Controls.Add(label1);
            Controls.Add(PlayerNameTextBox);
            Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.Lime;
            Margin = new Padding(7, 8, 7, 8);
            Name = "PlayerNameForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Player Name";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button EnterButton;
        public TextBox PlayerNameTextBox;
    }
}