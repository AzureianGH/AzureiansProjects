namespace Azuri_Editor
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            label1 = new Label();
            label2 = new Label();
            ExceptionLabel = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightCoral;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Firebrick;
            label1.Location = new Point(2, 9);
            label1.MaximumSize = new Size(500, 0);
            label1.Name = "label1";
            label1.Size = new Size(468, 64);
            label1.TabIndex = 0;
            label1.Text = "Azuri Editor ran into a problem and has halted to prevent any further issues.";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.LightCoral;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(2, 77);
            label2.Name = "label2";
            label2.Size = new Size(137, 21);
            label2.TabIndex = 1;
            label2.Text = "What went wrong:";
            // 
            // ExceptionLabel
            // 
            ExceptionLabel.AutoSize = true;
            ExceptionLabel.Location = new Point(5, 127);
            ExceptionLabel.MaximumSize = new Size(470, 0);
            ExceptionLabel.Name = "ExceptionLabel";
            ExceptionLabel.Size = new Size(463, 405);
            ExceptionLabel.TabIndex = 2;
            ExceptionLabel.Text = resources.GetString("ExceptionLabel.Text");
            ExceptionLabel.Click += ExceptionLabel_Click;
            // 
            // button1
            // 
            button1.Location = new Point(169, 569);
            button1.Name = "button1";
            button1.Size = new Size(126, 63);
            button1.TabIndex = 3;
            button1.Text = "Exit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 644);
            Controls.Add(button1);
            Controls.Add(ExceptionLabel);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form2";
            Text = "Azuri Crash Handler";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label ExceptionLabel;
        private Button button1;
    }
}