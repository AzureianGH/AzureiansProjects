// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.Browser
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

namespace WindowsApplication1
{
  [DesignerGenerated]
  public class Browser : Form
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();
    private IContainer components;
    [AccessedThroughProperty("TabControl1")]
    private TabControl _TabControl1;

    [DebuggerNonUserCode]
    static Browser()
    {
    }

    [DebuggerNonUserCode]
    public Browser()
    {
      this.Load += new EventHandler(this.Browser_Load);
      Browser.__ENCAddToList((object) this);
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
    private static void __ENCAddToList(object value)
    {
      lock (Browser.__ENCList)
      {
        if (Browser.__ENCList.Count == Browser.__ENCList.Capacity)
        {
          int index1 = 0;
          int num = checked (Browser.__ENCList.Count - 1);
          int index2 = 0;
          while (index2 <= num)
          {
            if (Browser.__ENCList[index2].IsAlive)
            {
              if (index2 != index1)
                Browser.__ENCList[index1] = Browser.__ENCList[index2];
              checked { ++index1; }
            }
            checked { ++index2; }
          }
          Browser.__ENCList.RemoveRange(index1, checked (Browser.__ENCList.Count - index1));
          Browser.__ENCList.Capacity = Browser.__ENCList.Count;
        }
        Browser.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
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
      this.TabControl1 = new TabControl();
      this.SuspendLayout();
      this.TabControl1.Dock = DockStyle.Fill;
      this.TabControl1.Location = new Point(0, 0);
      this.TabControl1.Name = "TabControl1";
      this.TabControl1.SelectedIndex = 0;
      TabControl tabControl1 = this.TabControl1;
      Size size1 = new Size(792, 689);
      Size size2 = size1;
      tabControl1.Size = size2;
      this.TabControl1.TabIndex = 0;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      size1 = new Size(792, 689);
      this.ClientSize = size1;
      this.Controls.Add((Control) this.TabControl1);
      this.Name = nameof (Browser);
      this.Text = nameof (Browser);
      this.ResumeLayout(false);
    }

    internal virtual TabControl TabControl1
    {
      [DebuggerNonUserCode] get => this._TabControl1;
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.TabControl1_SelectedIndexChanged);
        if (this._TabControl1 != null)
          this._TabControl1.SelectedIndexChanged -= eventHandler;
        this._TabControl1 = value;
        if (this._TabControl1 == null)
          return;
        this._TabControl1.SelectedIndexChanged += eventHandler;
      }
    }

    private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void Browser_Load(object sender, EventArgs e)
    {
      TabPage tabPage = new TabPage();
      Form1 form1 = new Form1();
      form1.Show();
      form1.Dock = DockStyle.Fill;
      form1.TopLevel = false;
      tabPage.Controls.Add((Control) form1);
      this.TabControl1.TabPages.Add(tabPage);
      this.TabControl1.SelectTab(tabPage);
      form1.WebBrowser1.Navigate("www.google.com");
    }
  }
}
