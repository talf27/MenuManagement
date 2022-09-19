using System;
using System.Linq;

namespace Menus.Interfaces
{
    public enum eItemType
    {
        SubMenu,
        FunctionItem
    }
    
    public class MainMenu
    {
        private readonly SubMenu r_MainItem;

        public MainMenu(string i_Title)
        {
            this.r_MainItem = new SubMenu(i_Title, null);
        }

        public void AddMenuItems(int[] i_Path, eItemType i_ItemType, params string[] i_ItemNames)
        {
            SubMenu subMenuToAddTo = FindMenuItem(i_Path) as SubMenu;

            if(subMenuToAddTo == null)
            {
                throw new ArgumentException("The given path to add items to is not a sub-menu");
            }

            if(i_ItemType == eItemType.SubMenu)
            {
                subMenuToAddTo.AddSubMenuItems(i_ItemNames);
            }
            else if(i_ItemType == eItemType.FunctionItem)
            {
                subMenuToAddTo.AddFunctionItems(i_ItemNames);
            }
        }

        public void RemoveMenuItem(int[] i_Path)
        {
            MenuItem itemToRemove = FindMenuItem(i_Path);
            itemToRemove.RemoveItem();
        }

        public MenuItem FindMenuItem(int[] i_Path)
        {
            MenuItem itemToFind = this.r_MainItem;
            SubMenu itemToFindAsSubMenu;

            if(i_Path != null)
            {
                foreach(int subItemIndex in i_Path)
                {
                    itemToFindAsSubMenu = itemToFind as SubMenu;
                    if(itemToFindAsSubMenu == null || subItemIndex <= 0 || subItemIndex >= itemToFindAsSubMenu.SubItems.Count)
                    {
                        throw new ArgumentException("there is no item corresponding to the given indexes");
                    }

                    itemToFind = itemToFindAsSubMenu.SubItems.ElementAt(subItemIndex);
                }
            }

            return itemToFind;
        }

        public void Show()
        {
            bool show = true;
            MenuItem itemChosen;
            SubMenu parent, currentItem = this.r_MainItem;
            int itemChosenIndex, currentLevel = 1;

            while(show)
            {
                parent = currentItem.SubItems.ElementAt(0) as SubMenu;
                Console.WriteLine("** Menu level: {0} **", currentLevel);
                if(parent == null)
                {
                    Console.WriteLine("** {0} **", currentItem.Name);
                }
                else
                {
                    Console.WriteLine("** {0}. {1} **", parent.SubItems.IndexOf(currentItem), currentItem.Name);
                }

                Console.WriteLine("===============");
                for (int i = 1; i < currentItem.SubItems.Count; i++)
                { 
                    Console.WriteLine("{0}: {1}", i, currentItem.SubItems.ElementAt(i).Name);
                }

                Console.WriteLine(parent == null ? "0: exit" : "0: back");
                Console.Write("Please enter your choice (1-{0} or 0 to exit): ", currentItem.SubItems.Count - 1);
                getValidIndex(currentItem.SubItems.Count - 1, out itemChosenIndex);
                Console.Clear();
                if(itemChosenIndex == 0 && parent == null)
                {
                    Console.WriteLine("Goodbye from interfaces menu! {0}", Environment.NewLine);
                    show = false;
                }
                
                itemChosen = currentItem.SubItems.ElementAt(itemChosenIndex);
                if(itemChosen is FunctionItem)
                {
                    (itemChosen as FunctionItem).NotifyFunctionItemItWasChosen();
                }
                else if(itemChosen is SubMenu)
                {
                    if(itemChosenIndex == 0)
                    {
                        currentLevel--;
                    }
                    else
                    {
                        currentLevel++;
                    }

                    currentItem = itemChosen as SubMenu;
                }
            }
        }

        private static void getValidIndex(int i_RangeOfItemIndexes, out int o_ItemIndex)
        {
            string input = Console.ReadLine();

            while(!int.TryParse(input, out o_ItemIndex) || o_ItemIndex < 0 || o_ItemIndex > i_RangeOfItemIndexes)
            {
                Console.Write("Please provide a legal choice number (1-{0} or 0 to exit): ", i_RangeOfItemIndexes);
                input = Console.ReadLine();
            }
        }
    }
}