using DatenMeister;
using DatenMeister.DataProvider;
using DatenMeister.DataProvider.DotNet;
using DatenMeister.DataProvider.Views;
using DatenMeister.DataProvider.Xml;
using DatenMeister.Entities.DM.Primitives;
using DatenMeister.Entities.FieldInfos;
using DatenMeister.Logic;
using DatenMeister.Logic.MethodProvider;
using DatenMeister.Logic.Views;
using DatenMeister.Pool;
using DatenMeister.Transformations;
using Ninject;
using ProjektMeister.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjektMeister.Data
{
    /// <summary>
    /// Stores the datenmeister instance and all its properties
    /// </summary>
    public class Database
    {        
        public static void InitViews(IPool pool)
        {
            var viewExtent = pool.GetExtents(ExtentType.View).First();                

            // Creates the factory
            var factory = Factory.GetFor(viewExtent);

            ////////////////////////////////////////////
            // List view for persons
            Views.PersonTable = factory.create(DatenMeister.Entities.AsObject.FieldInfo.Types.TableView);
            viewExtent.Elements().add(Views.PersonTable);
            var asObjectPersons = new DatenMeister.Entities.AsObject.FieldInfo.TableView(Views.PersonTable);

            var personColumns = new DotNetSequence(
                ViewHelper.ViewTypes,
                new TextField("First Name", "firstname"),
                new TextField("Name", "name"),
                new HyperLinkColumn("E-Mail", "email"),
                new TextField("Phone", "phone"),
                new TextField("Job", "title"));
            asObjectPersons.setFieldInfos(personColumns);
            asObjectPersons.setName("Persons");
            asObjectPersons.setExtentUri(ProjectMeisterConfiguration.DataUri + "?type=Person");
            asObjectPersons.setAllowNew(true);
            asObjectPersons.setAllowEdit(true);
            asObjectPersons.setAllowDelete(true);
            asObjectPersons.setMainType(ProjektMeister.Data.Entities.AsObject.Types.Person);

            // Detail view for persons
            var personDetailView = new DatenMeister.Entities.FieldInfos.FormView();
            Views.PersonDetail = factory.create(DatenMeister.Entities.AsObject.FieldInfo.Types.FormView);
            viewExtent.Elements().add(Views.PersonDetail);
            Views.PersonDetail.set("name", "Person (Detail)");

            var personDetailColumns = new DotNetSequence(
                ViewHelper.ViewTypes,
                new TextField("First Name", "firstname"),
                new TextField("Name", "name"),
                new TextField("E-Mail", "email"),
                new TextField("Phone", "phone"),
                new TextField("Job", "title"),
                new TextField("Comment", "comment")
                {
                    isMultiline = true,
                    height = -1
                });
            Views.PersonDetail.set("fieldInfos", personDetailColumns);

            ////////////////////////////////////////////
            // List view for tasks
            Views.TaskTable = factory.create(DatenMeister.Entities.AsObject.FieldInfo.Types.TableView);
            viewExtent.Elements().add(Views.TaskTable);
            var asObjectTasks = new DatenMeister.Entities.AsObject.FieldInfo.TableView(Views.TaskTable);

            var taskColumns = new DotNetSequence(
                ViewHelper.ViewTypes,
                new TextField("Category", "category")
                {
                    columnWidth = 100
                },
                new TextField("Name", "name")
                {
                    columnWidth = 200
                },
                new TextField("Start", "startdate")
                {
                    isDateTime = true
                },
                new TextField("Ende", "enddate")
                {
                    isDateTime = true
                },
                new TextField("Finished", "finished"),
                new TextField("Assigned", "assignedPerson"),
                new TextField("Predecessors", "predecessors")
                {
                    columnWidth = 200
                });
            asObjectTasks.setFieldInfos(taskColumns);
            asObjectTasks.setName("Tasks");
            asObjectTasks.setExtentUri(ProjectMeisterConfiguration.DataUri + "?type=Task");
            asObjectTasks.setAllowNew(true);
            asObjectTasks.setAllowEdit(true);
            asObjectTasks.setAllowDelete(true);
            asObjectTasks.setMainType(ProjektMeister.Data.Entities.AsObject.Types.Task);

            ///////////////////////////////////////////////////
            // Short list for the tasks
            var shortTasks = factory.create(DatenMeister.Entities.AsObject.FieldInfo.Types.TableView);
            var asObjectShortTasks = new DatenMeister.Entities.AsObject.FieldInfo.TableView(shortTasks);

            var shortTaskColumns = new DotNetSequence(
                ViewHelper.ViewTypes,
                new TextField("Name", "name")
                {
                    columnWidth = 200
                },
                new TextField("Start", "startdate")
                {
                    isDateTime = true
                },
                new TextField("Ende", "enddate")
                {
                    isDateTime = true
                });
            asObjectShortTasks.setFieldInfos(shortTaskColumns);
            asObjectShortTasks.setName("Tasks (short)");
            asObjectShortTasks.setMainType(ProjektMeister.Data.Entities.AsObject.Types.Task);

            ///////////////////////////////////////////////////
            // Detail view for tasks
            Views.TaskDetail = factory.create(DatenMeister.Entities.AsObject.FieldInfo.Types.FormView);
            Views.TaskDetail.set("name", "Person (Detail)");
            viewExtent.Elements().add(Views.TaskDetail);

            var taskDetailColumns = new DotNetSequence(
                ViewHelper.ViewTypes,
                new TextField("Name", "name"),
                new ReferenceByConstant("Category", "category")
                 {
                     values = new object[] { "Milestone", "Task" }
                 },
                new DatePicker("Start", "startdate"),
                new DatePicker("End", "enddate"),
                new Checkbox("Finished", "finished"),
                new ReferenceByRef("Assigned", "assignedPerson", ProjectMeisterConfiguration.DataUri + "?type=Person", "name"),
                new MultiReferenceField("Predecessors", "predecessors", ProjectMeisterConfiguration.DataUri + "?type=Task", "name")
                {
                    tableViewInfo = shortTasks
                },
                /*new TextField("Comment", "comment")
                {
                    isMultiline = true,
                    height = -1
                },*/
                new SubElementList("Comments", "comments")
                {
                    typeForNew = ProjektMeister.Data.Entities.AsObject.Types.Remark
                });

            Views.TaskDetail.set("fieldInfos", taskDetailColumns);

            ////////////////////////////////////////////
            // List view for all the open tasks
            Views.OpenTaskTable = factory.create(DatenMeister.Entities.AsObject.FieldInfo.Types.TableView);
            viewExtent.Elements().add(Views.OpenTaskTable);
            asObjectTasks = new DatenMeister.Entities.AsObject.FieldInfo.TableView(Views.OpenTaskTable);

            asObjectTasks.setFieldInfos(taskColumns);
            asObjectTasks.setName("Open Tasks");
            asObjectTasks.setExtentUri(ProjectMeisterConfiguration.DataUri + "/OpenTasks");
            asObjectTasks.setAllowNew(true);
            asObjectTasks.setAllowEdit(true);
            asObjectTasks.setAllowDelete(true);
            asObjectTasks.setMainType(ProjektMeister.Data.Entities.AsObject.Types.Task);

            var methodProvider = Injection.Application.Get<IMethodProvider>();
            methodProvider.AddInstanceMethod(
                asObjectTasks.Value,
                "setBackgroundColor",
                new Func<IObject, Color>(
                    value =>
                    {
                        var endDate = ObjectConversion.ToDateTime(value.get("enddate").AsSingle());
                        var isFinsihed = ObjectConversion.ToBoolean(value.get("finished").AsSingle());

                        if (endDate < DateTime.Now && !isFinsihed)
                        {
                            return new Color()
                            {
                                R = 1.0,
                                G = 0.8,
                                B = 0.8,
                                A = 1.0
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }));


            // Initialize the viewManager
            var viewManager = new DefaultViewManager(viewExtent);
            viewManager.Add(
                    ProjektMeister.Data.Entities.AsObject.Types.Person,
                    Database.Views.PersonDetail,
                    true);
            viewManager.Add(
                    ProjektMeister.Data.Entities.AsObject.Types.Task,
                    Database.Views.TaskDetail,
                    true);
            viewManager.DoAutogenerateForm = true; // Allow the autogeneration of forms

            Injection.Application.Rebind<IViewManager>().ToConstant(viewManager);
        }

        public static class Views
        {
            public static IObject PersonTable
            {
                get;
                internal set;
            }

            public static IObject TaskTable
            {
                get;
                internal set;
            }

            public static IObject OpenTaskTable
            {
                get;
                internal set;
            }

            public static IObject PersonDetail
            {
                get;
                internal set;
            }

            public static IObject TaskDetail
            {
                get;
                internal set;
            }
        }
    }
}
