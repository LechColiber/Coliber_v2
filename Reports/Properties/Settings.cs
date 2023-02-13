// Decompiled with JetBrains decompiler
// Type: Reports.Properties.Settings
// Assembly: Reports, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6EABA3FB-B96C-4D63-9763-B5503E139195
// Assembly location: C:\Program\Exell\ColiberDLLs\Reports.dll

using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Reports.Properties
{
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
  [CompilerGenerated]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default
    {
      get
      {
        return Settings.defaultInstance;
      }
    }
  }
}
