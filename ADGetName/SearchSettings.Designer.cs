﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ADGetName {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.3.0.0")]
    internal sealed partial class SearchSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static SearchSettings defaultInstance = ((SearchSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new SearchSettings())));
        
        public static SearchSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ComputerName {
            get {
                return ((string)(this["ComputerName"]));
            }
            set {
                this["ComputerName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public decimal StartingNumber {
            get {
                return ((decimal)(this["StartingNumber"]));
            }
            set {
                this["StartingNumber"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public decimal NumberLength {
            get {
                return ((decimal)(this["NumberLength"]));
            }
            set {
                this["NumberLength"] = value;
            }
        }
    }
}
