using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace StoryboardTables
{
    public partial class ChoreBoardTableController : UITableViewController
    {
        List<Chore> chores;
        
        public ChoreBoardTableController (IntPtr handle) : base (handle)
        {
            chores = new List<Chore> {
                new Chore {Name="Groceries", Notes="Buy bread, cheese, apples", Done=false},
                new Chore {Name="Devices", Notes="Buy Nexus, Galaxy, Droid", Done=false}
            };
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            TableView.Source = new RootTableSource(chores.ToArray());
        }

        public override void ViewDidLoad()
        {
            AddButton.Clicked += (sender, e) => CreateTask();
        }
    

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "TaskSegue")
            { // set in Storyboard
                var detailController = segue.DestinationViewController as TaskDetailViewController;
                if (detailController != null)
                {
                    var source = TableView.Source as RootTableSource;
                    var rowPath = TableView.IndexPathForSelectedRow;
                    var item = source.GetItem(rowPath.Row);
                    detailController.SetTask(this, item); // to be defined on the TaskDetailViewController
                }

            }
        }

        public void SaveTask(Chore chore)
        {
            var oldTask = chores.Find(t => t.Id == chore.Id);
            NavigationController.PopViewController(true);
        }

        public void DeleteTask(Chore chore)
        {
            var oldTask = chores.Find(t => t.Id == chore.Id);
            chores.Remove(oldTask);
            NavigationController.PopViewController(true);
        }

        public void CreateTask()
        {
            // first, add the task to the underlying data
            var newId = chores[chores.Count - 1].Id + 1;
            var newChore = new Chore { Id = newId };
            chores.Add(newChore);

            // then open the detail view to edit it
            var detail = Storyboard.InstantiateViewController("detail") as TaskDetailViewController;
            detail.SetTask(this, newChore);
            NavigationController.PushViewController(detail, true);
        }

        public override 
    }
}