// Decompiled with JetBrains decompiler
// Type: Reports.Properties.Resources
// Assembly: Reports, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6EABA3FB-B96C-4D63-9763-B5503E139195
// Assembly location: C:\Program\Exell\ColiberDLLs\Reports.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Reports.Properties
{
  [CompilerGenerated]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) Reports.Properties.Resources.resourceMan, (object) null))
          Reports.Properties.Resources.resourceMan = new ResourceManager("Reports.Properties.Resources", typeof (Reports.Properties.Resources).Assembly);
        return Reports.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return Reports.Properties.Resources.resourceCulture;
      }
      set
      {
        Reports.Properties.Resources.resourceCulture = value;
      }
    }

    internal static Bitmap wykres
    {
      get
      {
        return (Bitmap) Reports.Properties.Resources.ResourceManager.GetObject(nameof (wykres), Reports.Properties.Resources.resourceCulture);
      }
    }
  }
}
