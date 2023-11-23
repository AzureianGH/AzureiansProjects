// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.Form1
// Assembly: WindowsApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4CBD7ACE-B776-4CE5-9290-598D4272DF24
// Assembly location: C:\Program Files (x86)\Etroxian 2.0 Beta 2\Etroxian 2.0.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using WindowsApplication1.My;

namespace WindowsApplication1
{
  [DesignerGenerated]
  public class Form1 : Form
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    private IContainer components;
    [AccessedThroughProperty("WebBrowser1")]
    private WebBrowser _WebBrowser1;
    [AccessedThroughProperty("Button1")]
    private Button _Button1;
    [AccessedThroughProperty("Button2")]
    private Button _Button2;
    [AccessedThroughProperty("Button3")]
    private Button _Button3;
    [AccessedThroughProperty("Button4")]
    private Button _Button4;
    [AccessedThroughProperty("Button5")]
    private Button _Button5;
    [AccessedThroughProperty("TextBox1")]
    private TextBox _TextBox1;

    [DebuggerNonUserCode]
    static Form1()
    {
    }

    [DebuggerNonUserCode]
    public Form1()
    {
      Form1.__ENCAddToList((object) this);
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
    private static void __ENCAddToList(object value)
    {
      lock (Form1.__ENCList)
      {
        if (Form1.__ENCList.Count == Form1.__ENCList.Capacity)
        {
          int index1 = 0;
          int num = checked (Form1.__ENCList.Count - 1);
          int index2 = 0;
          while (index2 <= num)
          {
            if (Form1.__ENCList[index2].IsAlive)
            {
              if (index2 != index1)
                Form1.__ENCList[index1] = Form1.__ENCList[index2];
              checked { ++index1; }
            }
            checked { ++index2; }
          }
          Form1.__ENCList.RemoveRange(index1, checked (Form1.__ENCList.Count - index1));
          Form1.__ENCList.Capacity = Form1.__ENCList.Count;
        }
        Form1.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
      }
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.WebBrowser1 = new WebBrowser();
      this.Button1 = new Button();
      this.Button2 = new Button();
      this.Button3 = new Button();
      this.Button4 = new Button();
      this.Button5 = new Button();
      this.TextBox1 = new TextBox();
      this.SuspendLayout();
      this.WebBrowser1.Dock = DockStyle.Fill;
      WebBrowser webBrowser1_1 = this.WebBrowser1;
      Point point1 = new Point(0, 0);
      Point point2 = point1;
      webBrowser1_1.Location = point2;
      WebBrowser webBrowser1_2 = this.WebBrowser1;
      Size size1 = new Size(20, 20);
      Size size2 = size1;
      webBrowser1_2.MinimumSize = size2;
      this.WebBrowser1.Name = "WebBrowser1";
      WebBrowser webBrowser1_3 = this.WebBrowser1;
      size1 = new Size(1057, 922);
      Size size3 = size1;
      webBrowser1_3.Size = size3;
      this.WebBrowser1.TabIndex = 0;
      this.WebBrowser1.Url = new Uri("http://google.com", UriKind.Absolute);
      Button button1_1 = this.Button1;
      point1 = new Point(183, 0);
      Point point3 = point1;
      button1_1.Location = point3;
      this.Button1.Name = "Button1";
      Button button1_2 = this.Button1;
      size1 = new Size(39, 20);
      Size size4 = size1;
      button1_2.Size = size4;
      this.Button1.TabIndex = 1;
      this.Button1.Text = "←";
      this.Button1.UseVisualStyleBackColor = true;
      Button button2_1 = this.Button2;
      point1 = new Point(228, 0);
      Point point4 = point1;
      button2_1.Location = point4;
      this.Button2.Name = "Button2";
      Button button2_2 = this.Button2;
      size1 = new Size(39, 20);
      Size size5 = size1;
      button2_2.Size = size5;
      this.Button2.TabIndex = 2;
      this.Button2.Text = "→";
      this.Button2.UseVisualStyleBackColor = true;
      Button button3_1 = this.Button3;
      point1 = new Point(759, 0);
      Point point5 = point1;
      button3_1.Location = point5;
      this.Button3.Name = "Button3";
      Button button3_2 = this.Button3;
      size1 = new Size(49, 20);
      Size size6 = size1;
      button3_2.Size = size6;
      this.Button3.TabIndex = 3;
      this.Button3.Text = "Search";
      this.Button3.UseVisualStyleBackColor = true;
      Button button4_1 = this.Button4;
      point1 = new Point(814, 0);
      Point point6 = point1;
      button4_1.Location = point6;
      this.Button4.Name = "Button4";
      Button button4_2 = this.Button4;
      size1 = new Size(39, 20);
      Size size7 = size1;
      button4_2.Size = size7;
      this.Button4.TabIndex = 4;
      this.Button4.Text = "↻";
      this.Button4.UseVisualStyleBackColor = true;
      Button button5_1 = this.Button5;
      point1 = new Point(859, 0);
      Point point7 = point1;
      button5_1.Location = point7;
      this.Button5.Name = "Button5";
      Button button5_2 = this.Button5;
      size1 = new Size(63, 20);
      Size size8 = size1;
      button5_2.Size = size8;
      this.Button5.TabIndex = 5;
      this.Button5.Text = "Home";
      this.Button5.UseVisualStyleBackColor = true;
      TextBox textBox1_1 = this.TextBox1;
      point1 = new Point(273, 0);
      Point point8 = point1;
      textBox1_1.Location = point8;
      this.TextBox1.Name = "TextBox1";
      TextBox textBox1_2 = this.TextBox1;
      size1 = new Size(480, 20);
      Size size9 = size1;
      textBox1_2.Size = size9;
      this.TextBox1.TabIndex = 6;
      this.TextBox1.Text = " ";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Maroon;
      size1 = new Size(1057, 922);
      this.ClientSize = size1;
      this.Controls.Add((Control) this.TextBox1);
      this.Controls.Add((Control) this.Button5);
      this.Controls.Add((Control) this.Button4);
      this.Controls.Add((Control) this.Button3);
      this.Controls.Add((Control) this.Button2);
      this.Controls.Add((Control) this.Button1);
      this.Controls.Add((Control) this.WebBrowser1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (Form1);
      this.Text = "Etrox 2.0 Test Branch 2";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    internal virtual WebBrowser WebBrowser1
    {
      [DebuggerNonUserCode] get => this._WebBrowser1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set => this._WebBrowser1 = value;
    }

    internal virtual Button Button1
    {
      [DebuggerNonUserCode] get => this._Button1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button1_Click);
        if (this._Button1 != null)
          this._Button1.Click -= eventHandler;
        this._Button1 = value;
        if (this._Button1 == null)
          return;
        this._Button1.Click += eventHandler;
      }
    }

    internal virtual Button Button2
    {
      [DebuggerNonUserCode] get => this._Button2;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button2_Click);
        if (this._Button2 != null)
          this._Button2.Click -= eventHandler;
        this._Button2 = value;
        if (this._Button2 == null)
          return;
        this._Button2.Click += eventHandler;
      }
    }

    internal virtual Button Button3
    {
      [DebuggerNonUserCode] get => this._Button3;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button3_Click);
        if (this._Button3 != null)
          this._Button3.Click -= eventHandler;
        this._Button3 = value;
        if (this._Button3 == null)
          return;
        this._Button3.Click += eventHandler;
      }
    }

    internal virtual Button Button4
    {
      [DebuggerNonUserCode] get => this._Button4;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button4_Click);
        if (this._Button4 != null)
          this._Button4.Click -= eventHandler;
        this._Button4 = value;
        if (this._Button4 == null)
          return;
        this._Button4.Click += eventHandler;
      }
    }

    internal virtual Button Button5
    {
      [DebuggerNonUserCode] get => this._Button5;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button5_Click);
        if (this._Button5 != null)
          this._Button5.Click -= eventHandler;
        this._Button5 = value;
        if (this._Button5 == null)
          return;
        this._Button5.Click += eventHandler;
      }
    }

    internal virtual TextBox TextBox1
    {
      [DebuggerNonUserCode] get => this._TextBox1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.TextBox1_TextChanged);
        if (this._TextBox1 != null)
          this._TextBox1.TextChanged -= eventHandler;
        this._TextBox1 = value;
        if (this._TextBox1 == null)
          return;
        this._TextBox1.TextChanged += eventHandler;
      }
    }

    private void TextBox1_TextChanged(object sender, EventArgs e)
    {
    }

    private void Button1_Click(object sender, EventArgs e) => this.WebBrowser1.GoBack();

    private void Button2_Click(object sender, EventArgs e) => this.WebBrowser1.GoForward();

    private void Button3_Click(object sender, EventArgs e) => this.WebBrowser1.Navigate(this.TextBox1.Text);

    private void Button4_Click(object sender, EventArgs e) => this.WebBrowser1.Refresh();

    private void Button5_Click(object sender, EventArgs e) => this.WebBrowser1.Navigate("www.google.com");

    private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void Button6_Click(object sender, EventArgs e)
    {
      TabPage tabPage = new TabPage();
      Form1 form1 = new Form1();
      form1.Show();
      form1.Dock = DockStyle.Fill;
      form1.TopLevel = false;
      tabPage.Controls.Add((Control) form1);
      MyProject.Forms.Browser.TabControl1.TabPages.Add(tabPage);
      MyProject.Forms.Browser.TabControl1.SelectTab(tabPage);
      form1.WebBrowser1.Navigate("www.google.com");
    }

    private void Button7_Click(object sender, EventArgs e)
    {
      MyProject.Forms.Browser.TabControl1.TabPages.Remove(MyProject.Forms.Browser.TabControl1.SelectedTab);
      this.Close();
    }
  }
}
