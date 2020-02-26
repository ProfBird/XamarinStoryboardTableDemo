using Foundation;
using System;
using UIKit;

namespace StoryboardTables
{
    public partial class TaskDetailViewController : UITableViewController
    {
        public TaskDetailViewController (IntPtr handle) : base (handle)
        {
        }

        Chore CurrentTask { get; set; }
        public ChoreBoardTableController Delegate { get; set; } // will be used to Save, Delete later

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            TitleText.Text = CurrentTask.Name;
            NotesText.Text = CurrentTask.Notes;
            DoneSwitch.On = CurrentTask.Done;
        }

        // this will be called before the view is displayed
        public void SetTask(ChoreBoardTableController d, Chore task)
        {
            Delegate = d;
            CurrentTask = task;
        }

        public override void ViewDidLoad()
        {
            SaveButton.TouchUpInside += (sender, e) => {
                CurrentTask.Name = TitleText.Text;
                CurrentTask.Notes = NotesText.Text;
                CurrentTask.Done = DoneSwitch.On;
                Delegate.SaveTask(CurrentTask);
            };

            DeleteButton.TouchUpInside += (sender, e) => Delegate.DeleteTask(CurrentTask);
        }
    }
}