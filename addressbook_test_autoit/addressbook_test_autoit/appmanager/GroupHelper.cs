using System;
using System.Collections.Generic;

namespace addressbook_test_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string GROUPWINDELTITLE = "Delete group";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public void Add(GroupData newGroup)
        {
            OpenGroupDialog();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            CloseGroupDialog();
        }

        public void Del(string groupIndex)
        {
            
            OpenGroupDialog();
            aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "Select", groupIndex, "");

            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.WinWait(GROUPWINDELTITLE);
            aux.ControlClick(GROUPWINDELTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.ControlClick(GROUPWINDELTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
           

            CloseGroupDialog();
        }

        public void CheckGroupList()
        {
            while (GetGroupList().Count < 2)
            {
                Add(new GroupData() { Name = "test0_1" });
            }
            
        }

        private void CloseGroupDialog()
        {
            aux.WinWait(GROUPWINTITLE);
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        private void OpenGroupDialog()
        {
            aux.WinWait(WINTITLE);
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData>  list = new List<GroupData>();
            OpenGroupDialog();
            string count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetText", "#0|#"+i, "");
                list.Add(new GroupData()
                {
                    Name = item
                });
            }

            CloseGroupDialog();
            return list;
        }

       
    }
}