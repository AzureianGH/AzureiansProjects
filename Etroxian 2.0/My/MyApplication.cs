﻿// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.My.MyApplication
// Assembly: WindowsApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4CBD7ACE-B776-4CE5-9290-598D4272DF24
// Assembly location: C:\Program Files (x86)\Etroxian 2.0 Beta 2\Etroxian 2.0.exe

using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WindowsApplication1.My
{
  [EditorBrowsable(EditorBrowsableState.Never)]
  [GeneratedCode("MyTemplate", "11.0.0.0")]
  internal class MyApplication : WindowsFormsApplicationBase
  {
    private static List<WeakReference> __ENCList = new List<WeakReference>();

    [DebuggerNonUserCode]
    static MyApplication()
    {
    }

    [DebuggerNonUserCode]
    private static void __ENCAddToList(object value)
    {
      lock (MyApplication.__ENCList)
      {
        if (MyApplication.__ENCList.Count == MyApplication.__ENCList.Capacity)
        {
          int index1 = 0;
          int num = checked (MyApplication.__ENCList.Count - 1);
          int index2 = 0;
          while (index2 <= num)
          {
            if (MyApplication.__ENCList[index2].IsAlive)
            {
              if (index2 != index1)
                MyApplication.__ENCList[index1] = MyApplication.__ENCList[index2];
              checked { ++index1; }
            }
            checked { ++index2; }
          }
          MyApplication.__ENCList.RemoveRange(index1, checked (MyApplication.__ENCList.Count - index1));
          MyApplication.__ENCList.Capacity = MyApplication.__ENCList.Count;
        }
        MyApplication.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [STAThread]
    [DebuggerHidden]
    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    internal static void Main(string[] Args)
    {
      try
      {
        Application.SetCompatibleTextRenderingDefault(WindowsFormsApplicationBase.UseCompatibleTextRendering);
      }
      finally
      {
      }
      MyProject.Application.Run(Args);
    }

    [DebuggerStepThrough]
    public MyApplication()
      : base(AuthenticationMode.Windows)
    {
      MyApplication.__ENCAddToList((object) this);
      this.IsSingleInstance = false;
      this.EnableVisualStyles = true;
      this.SaveMySettingsOnExit = true;
      this.ShutdownStyle = ShutdownMode.AfterMainFormCloses;
    }

    [DebuggerStepThrough]
    protected override void OnCreateMainForm() => this.MainForm = (Form) MyProject.Forms.Form1;
  }
}
