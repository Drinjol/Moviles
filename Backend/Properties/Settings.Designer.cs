﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Backend.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.9.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=SQL5113.site4now.net;Persist Security Info=True;User ID=db_aa7784_bde" +
            "mprende_admin;TrustServerCertificate=True")]
        public string DataSourceConnectionString {
            get {
                return ((string)(this["DataSourceConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=SQL5113.site4now.net;Persist Security Info=True;User ID=db_aa7784_bde" +
            "mprende_admin;Password=una123456;TrustServerCertificate=True")]
        public string DataSourceConnectionString1 {
            get {
                return ((string)(this["DataSourceConnectionString1"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=DESKTOP-GS5ITPH\\FERNANDO;Initial Catalog=SarapiquiEmprende;Integrated" +
            " Security=True;TrustServerCertificate=True")]
        public string SarapiquiEmprendeConnectionString {
            get {
                return ((string)(this["SarapiquiEmprendeConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=SQL5113.site4now.net;Persist Security Info=True;User ID=db_aa7784_bde" +
            "mprende_admin;Password=una123456;Encrypt=True;TrustServerCertificate=True")]
        public string db_aa7784_bdemprendeConnectionString {
            get {
                return ((string)(this["db_aa7784_bdemprendeConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=SQL5113.site4now.net;Persist Security Info=True;User ID=db_aa7784_bde" +
            "mprende_admin;Encrypt=True;TrustServerCertificate=True")]
        public string DataSourceConnectionString2 {
            get {
                return ((string)(this["DataSourceConnectionString2"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=SQL5113.site4now.net;Initial Catalog=db_aa7784_bdemprende;Persist Sec" +
            "urity Info=True;User ID=db_aa7784_bdemprende_admin;Encrypt=True;TrustServerCerti" +
            "ficate=True")]
        public string db_aa7784_bdemprendeConnectionString1 {
            get {
                return ((string)(this["db_aa7784_bdemprendeConnectionString1"]));
            }
        }
    }
}
