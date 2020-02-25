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
    }
}