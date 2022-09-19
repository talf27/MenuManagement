using System;
using Menus.Delegates;

namespace Menus.Test
{
    internal class DelegatesTestMenu
    {
        internal MainMenu m_MainMenu;
        internal DelegatesTestMenu()
        {
            this.m_MainMenu = buildTestMenu();
            setFunctionItemsInTestMenu(m_MainMenu);
        }

        private static MainMenu buildTestMenu()
        {
            MainMenu menu = new MainMenu("Delegates Main Menu");

            try
            {
                menu.AddMenuItems(null, eItemType.SubMenu, "Show Date/Time", "Version and Spaces");
                menu.AddMenuItems(new int[] { 1 }, eItemType.FunctionItem, "Show Time", "Show Date");
                menu.AddMenuItems(new int[] { 2 }, eItemType.FunctionItem, "Count spaces", "Show Version");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return menu;
        }

        private static void setFunctionItemsInTestMenu(MainMenu i_Menu)
        {
            try
            {
                FunctionItem functionItem = null;

                functionItem = i_Menu.FindMenuItem(new int[] { 1, 1 }) as FunctionItem;
                functionItem.FunctionBecameChosen += new Action(showTimeFunction_Chosen);
                functionItem = i_Menu.FindMenuItem(new int[] { 1, 2 }) as FunctionItem;
                functionItem.FunctionBecameChosen += new Action(showDateFunction_Chosen);
                functionItem = i_Menu.FindMenuItem(new int[] { 2, 1 }) as FunctionItem;
                functionItem.FunctionBecameChosen += new Action(countSpacesFunction_Chosen);
                functionItem = i_Menu.FindMenuItem(new int[] { 2, 2 }) as FunctionItem;
                functionItem.FunctionBecameChosen += new Action(showVersionFunction_Chosen);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void showTimeFunction_Chosen()
        {
            Console.WriteLine("Time of the day is: {0}{1}", DateTime.Now.ToString("T"), Environment.NewLine);
        }

        private static void showDateFunction_Chosen()
        {
            Console.WriteLine("Today's date is: {0}{1}", DateTime.Now.ToString("d"), Environment.NewLine);
        }

        private static void countSpacesFunction_Chosen()
        {
            Console.Write("Please write a sentence: ");
            string input = Console.ReadLine();
            Console.WriteLine("The sentence has {0} spaces {1}", input.Split(' ').Length - 1, Environment.NewLine);
        }

        private static void showVersionFunction_Chosen()
        {
            Console.WriteLine("Version: 22.2.4.8950 {0}", Environment.NewLine);
        }
    }
}
