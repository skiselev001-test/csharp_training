using System;
using System.Collections;
using System.Collections.Generic;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.WindowsAPI;

namespace addressbook_tests_white
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string GROUPWINDELTITLE = "Delete group";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public void Add(GroupData newGroup)
        {
            Window dialogue = OpenGroupDialog();
            dialogue.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox = (TextBox) dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
           // aux.Send(newGroup.Name);
           // aux.Send("{ENTER}");
            CloseGroupDialog(dialogue);
        }

  /*      public void Del(string groupIndex)
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
  */
  /*
        public void CheckGroupList()
        {
            while (GetGroupList().Count < 2)
            {
                Add(new GroupData() { Name = "test0_1" });
            }
            
        }
  */
        private void CloseGroupDialog(Window dialog)
        {
            dialog.Get<Button>("uxCloseAddressButton").Click();
        }

        private Window OpenGroupDialog()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData>  list = new List<GroupData>();
            Window dialogue = OpenGroupDialog();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach (TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                });
            }

            CloseGroupDialog(dialogue);
            return list;
        }

       
    }
}