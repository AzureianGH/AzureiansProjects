// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.My.Resources.Resources
// Assembly: WindowsApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4CBD7ACE-B776-4CE5-9290-598D4272DF24
// Assembly location: C:\Program Files (x86)\Etroxian 2.0 Beta 2\Etroxian 2.0.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace WindowsApplication1.My.Resources
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [HideModuleName]
  [CompilerGenerated]
  [DebuggerNonUserCode]
  [StandardModule]
  internal sealed class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) WindowsApplication1.My.Resources.Resources.resourceMan, (object) null))
          WindowsApplication1.My.Resources.Resources.resourceMan = new ResourceManager("WindowsApplication1.Resources", typeof (WindowsApplication1.My.Resources.Resources).Assembly);
        return WindowsApplication1.My.Resources.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => WindowsApplication1.My.Resources.Resources.resourceCulture;
      set => WindowsApplication1.My.Resources.Resources.resourceCulture = value;
    }
  }
}
