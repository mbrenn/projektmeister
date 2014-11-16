using BurnSystems.ObjectActivation;
using DatenMeister.AddOns;
using DatenMeister.AddOns.Export.Excel;
using DatenMeister.AddOns.Export.Report.Simple;
using DatenMeister.AddOns.Views;
using DatenMeister.Logic;
using DatenMeister.WPF.Helper;
using DatenMeister.WPF.Modules.RecentFiles;
using DatenMeister.WPF.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProjektMeister
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        private ApplicationCore core;

        protected override void OnStartup(StartupEventArgs e)
        {
            BurnSystems.Logging.Log.TheLog.FilterLevel = BurnSystems.Logging.LogLevel.Everything;
            BurnSystems.Logging.Log.TheLog.AddLogProvider(new BurnSystems.Logging.DebugProvider());

            var result = DefaultModules.DefaultStartWith<ProjectMeisterConfiguration>(this);
            this.core = result.Core;
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }
}
