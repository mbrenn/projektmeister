using BurnSystems.ObjectActivation;
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

            base.OnStartup(e);

            this.core = new ApplicationCore();
            this.core.Start<ProjectMeisterConfiguration>();

            var wnd = WindowFactory.CreateWindow(this.core);
            
            // Other menu helpers
            RecentFileIntegration.AddSupport(wnd);
            MenuHelper.AddExtentView(wnd);

            // Exports the entry to an excel item
            ExcelExportGui.AddMenu(wnd);
            TypeManager.Integrate(wnd);
            ViewSetManager.Integrate(wnd);
            SimpleReportGui.Integrate(wnd);
            //DatenMeister.AddOns.ComplianceSuite.WPF.Plugin.Integrate(wnd);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            if (this.core.Settings != null)
            {
                this.core.StoreViewSet();
            }

            base.OnExit(e);
        }
    }
}
