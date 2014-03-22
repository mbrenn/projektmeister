using ProjektMeister.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektMeister
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Stores the database to be used for the project
        /// </summary>
        private Database database = new Database();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            database.Init();

            this.tablePersons.TableViewInfo = Database.Views.PersonTable;
            this.tablePersons.DetailViewInfo = Database.Views.PersonDetail;
            this.tableTasks.TableViewInfo = Database.Views.TaskTable;
            this.tableTasks.DetailViewInfo = Database.Views.TaskDetail;
        }
    }
}
