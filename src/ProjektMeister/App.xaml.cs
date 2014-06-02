using BurnSystems.ObjectActivation;
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
        /// <summary>
        /// Stores the window for the application
        /// </summary>
        private MainWindow window;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            this.window = new MainWindow();
            this.window.Start();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            if (this.window != null)
            {
                this.window.Stop();
            }

            base.OnExit(e);
        }
    }
}
