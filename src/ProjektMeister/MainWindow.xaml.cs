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
            var umlTypes = DatenMeister.Entities.AsObject.Uml.Types.Init();
            var fieldInfoTypes = DatenMeister.Entities.AsObject.FieldInfo.Types.Init();

            // Initializes the database itself
            database.Init();

            // Create some persons
            var person = database.ProjectExtent.CreateObject(Database.Types.Person);
            person.set("name", "Martin Brenn");
            person.set("email", "brenn@depon.net");
            person.set("phone", "0151/560");
            person.set("title", "Project Lead");

            person = database.ProjectExtent.CreateObject(Database.Types.Person);
            person.set("name", "Martina Brenn");
            person.set("email", "brenna@depon.net");
            person.set("phone", "0151/650");
            person.set("title", "Project Support");

            // Initializes the views            
            this.tablePersons.Extent = database.ProjectExtent;
            this.tablePersons.TableViewInfo = Database.Views.PersonTable;
            this.tablePersons.DetailViewInfo = Database.Views.PersonDetail;
            this.tablePersons.ElementFactory = () => database.ProjectExtent.CreateObject(Database.Types.Person);
            this.tableTasks.Extent = database.ProjectExtent;
            this.tableTasks.TableViewInfo = Database.Views.TaskTable;
            this.tableTasks.DetailViewInfo = Database.Views.TaskDetail;
            this.tableTasks.ElementFactory = () => database.ProjectExtent.CreateObject(Database.Types.Task);
        }
    }
}
