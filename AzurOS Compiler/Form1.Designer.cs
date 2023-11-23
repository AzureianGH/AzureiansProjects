namespace AzurOS_Compiler
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            compsettings = new TabControl();
            General = new TabPage();
            browsefolder = new Button();
            label3 = new Label();
            othercompilables = new Button();
            compilableslistbox = new ListBox();
            label2 = new Label();
            browseforkernelC = new Button();
            mainkernelC = new TextBox();
            label1 = new Label();
            browsefile = new Button();
            mainassemnly = new TextBox();
            Platform = new TabPage();
            groupBox2 = new GroupBox();
            checkBox4 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            groupBox1 = new GroupBox();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            tabPage1 = new TabPage();
            textBox1 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            textBox2 = new TextBox();
            compsettings.SuspendLayout();
            General.SuspendLayout();
            Platform.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // compsettings
            // 
            compsettings.Controls.Add(General);
            compsettings.Controls.Add(Platform);
            compsettings.Controls.Add(tabPage1);
            compsettings.Dock = DockStyle.Fill;
            compsettings.Location = new Point(0, 0);
            compsettings.Name = "compsettings";
            compsettings.SelectedIndex = 0;
            compsettings.Size = new Size(555, 450);
            compsettings.TabIndex = 0;
            // 
            // General
            // 
            General.BackColor = Color.FromArgb(23, 23, 23);
            General.Controls.Add(browsefolder);
            General.Controls.Add(label3);
            General.Controls.Add(othercompilables);
            General.Controls.Add(compilableslistbox);
            General.Controls.Add(label2);
            General.Controls.Add(browseforkernelC);
            General.Controls.Add(mainkernelC);
            General.Controls.Add(label1);
            General.Controls.Add(browsefile);
            General.Controls.Add(mainassemnly);
            General.Location = new Point(4, 24);
            General.Name = "General";
            General.Padding = new Padding(3);
            General.Size = new Size(547, 422);
            General.TabIndex = 0;
            General.Text = "General";
            // 
            // browsefolder
            // 
            browsefolder.Location = new Point(231, 250);
            browsefolder.Name = "browsefolder";
            browsefolder.Size = new Size(107, 23);
            browsefolder.TabIndex = 9;
            browsefolder.Text = "Browse Folder";
            browsefolder.UseVisualStyleBackColor = true;
            browsefolder.Click += browsefolder_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(3, 127);
            label3.Name = "label3";
            label3.Size = new Size(109, 15);
            label3.TabIndex = 8;
            label3.Text = "Other Compilables:";
            // 
            // othercompilables
            // 
            othercompilables.Location = new Point(246, 221);
            othercompilables.Name = "othercompilables";
            othercompilables.Size = new Size(75, 23);
            othercompilables.TabIndex = 7;
            othercompilables.Text = "Browse";
            othercompilables.UseVisualStyleBackColor = true;
            othercompilables.Click += othercompilables_Click;
            // 
            // compilableslistbox
            // 
            compilableslistbox.FormattingEnabled = true;
            compilableslistbox.ItemHeight = 15;
            compilableslistbox.Location = new Point(3, 145);
            compilableslistbox.Name = "compilableslistbox";
            compilableslistbox.Size = new Size(222, 184);
            compilableslistbox.TabIndex = 6;
            compilableslistbox.DoubleClick += compilableslistbox_DoubleClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(0, 56);
            label2.Name = "label2";
            label2.Size = new Size(94, 15);
            label2.TabIndex = 5;
            label2.Text = "Main Kernel File:";
            // 
            // browseforkernelC
            // 
            browseforkernelC.Location = new Point(291, 73);
            browseforkernelC.Name = "browseforkernelC";
            browseforkernelC.Size = new Size(75, 23);
            browseforkernelC.TabIndex = 4;
            browseforkernelC.Text = "Browse";
            browseforkernelC.UseVisualStyleBackColor = true;
            browseforkernelC.Click += browseforkernelC_Click;
            // 
            // mainkernelC
            // 
            mainkernelC.Location = new Point(3, 74);
            mainkernelC.Name = "mainkernelC";
            mainkernelC.Size = new Size(282, 23);
            mainkernelC.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(0, 4);
            label1.Name = "label1";
            label1.Size = new Size(112, 15);
            label1.TabIndex = 2;
            label1.Text = "Main Assembly File:";
            // 
            // browsefile
            // 
            browsefile.Location = new Point(291, 21);
            browsefile.Name = "browsefile";
            browsefile.Size = new Size(75, 23);
            browsefile.TabIndex = 1;
            browsefile.Text = "Browse";
            browsefile.UseVisualStyleBackColor = true;
            browsefile.Click += browsefile_Click;
            // 
            // mainassemnly
            // 
            mainassemnly.Location = new Point(3, 22);
            mainassemnly.Name = "mainassemnly";
            mainassemnly.Size = new Size(282, 23);
            mainassemnly.TabIndex = 0;
            // 
            // Platform
            // 
            Platform.BackColor = Color.FromArgb(23, 23, 23);
            Platform.Controls.Add(groupBox2);
            Platform.Controls.Add(groupBox1);
            Platform.Location = new Point(4, 24);
            Platform.Name = "Platform";
            Platform.Padding = new Padding(3);
            Platform.Size = new Size(547, 422);
            Platform.TabIndex = 1;
            Platform.Text = "Platform";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(checkBox4);
            groupBox2.Controls.Add(checkBox3);
            groupBox2.Controls.Add(checkBox2);
            groupBox2.Controls.Add(checkBox1);
            groupBox2.ForeColor = SystemColors.ControlLightLight;
            groupBox2.Location = new Point(114, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(147, 116);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Format";
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(6, 90);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(136, 19);
            checkBox4.TabIndex = 3;
            checkBox4.Text = "VIRTUAL DISK IMAGE";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(6, 65);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(62, 19);
            checkBox3.TabIndex = 2;
            checkBox3.Text = "IMAGE";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(6, 40);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(44, 19);
            checkBox2.TabIndex = 1;
            checkBox2.Text = "ISO";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(6, 15);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(59, 19);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Binary";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton4);
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.ForeColor = SystemColors.ControlLightLight;
            groupBox1.Location = new Point(8, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(88, 116);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Architecture";
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(6, 90);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(44, 19);
            radioButton4.TabIndex = 5;
            radioButton4.TabStop = true;
            radioButton4.Text = "X64";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(6, 15);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(38, 19);
            radioButton3.TabIndex = 4;
            radioButton3.TabStop = true;
            radioButton3.Text = "X8";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(6, 65);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(44, 19);
            radioButton2.TabIndex = 3;
            radioButton2.TabStop = true;
            radioButton2.Text = "X32";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(6, 40);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(44, 19);
            radioButton1.TabIndex = 2;
            radioButton1.TabStop = true;
            radioButton1.Text = "X16";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(23, 23, 23);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(textBox2);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(547, 422);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Arguments";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(8, 38);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(443, 23);
            textBox1.TabIndex = 0;
            textBox1.Text = "nasm -f {platformtype} {asmkernel} -o {asmkernel}.bin";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(8, 20);
            label4.Name = "label4";
            label4.Size = new Size(135, 15);
            label4.TabIndex = 1;
            label4.Text = "Main ASM Compile Line";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(8, 88);
            label5.Name = "label5";
            label5.Size = new Size(143, 15);
            label5.TabIndex = 3;
            label5.Text = "Main Kernel Compile Line";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(8, 106);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(443, 23);
            textBox2.TabIndex = 2;
            textBox2.Text = "gcc -ffreestanding -c {kernelC/C++}  {}";
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(23, 23, 23);
            ClientSize = new Size(555, 450);
            Controls.Add(compsettings);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Zephyr";
            Load += Form1_Load;
            compsettings.ResumeLayout(false);
            General.ResumeLayout(false);
            General.PerformLayout();
            Platform.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl compsettings;
        private TabPage General;
        private TabPage Platform;
        private TextBox mainassemnly;
        private TabPage tabPage1;
        private Button browsefile;
        private Label label1;
        private Label label2;
        private Button browseforkernelC;
        private TextBox mainkernelC;
        private Label label3;
        private Button othercompilables;
        private ListBox compilableslistbox;
        private Button browsefolder;
        private RadioButton radioButton1;
        private GroupBox groupBox1;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private GroupBox groupBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private CheckBox checkBox4;
        private RadioButton radioButton4;
        private Label label4;
        private TextBox textBox1;
        private Label label5;
        private TextBox textBox2;
    }
}