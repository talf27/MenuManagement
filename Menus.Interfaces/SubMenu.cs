using System.Collections.Generic;

namespace Menus.Interfaces
{
    public class SubMenu : MenuItem
    {
        internal List<MenuItem> SubItems { get; }

        internal SubMenu(string i_Name, SubMenu i_Parent)
            : base(i_Name, i_Parent)
        {
            this.SubItems = new List<MenuItem>{ i_Parent };
        }

        internal void AddFunctionItems(params string[] i_ItemNames)
        {
            foreach (string itemName in i_ItemNames)
            {
                this.SubItems.Add(new FunctionItem(itemName, this));
            }
        }

        internal void AddSubMenuItems(params string[] i_ItemNames)
        {
            foreach (string itemName in i_ItemNames)
            {
                this.SubItems.Add(new SubMenu(itemName, this));
            }
        }
    }
}
