using System;
using Menus.Interfaces;

namespace Menus.Test
{
    internal class InterfacesTestMenu
    {
        internal MainMenu m_MainMenu;

        internal InterfacesTestMenu()
        {
            this.m_MainMenu = buildTestMenu();
            setFunctionItemsInTestMenu(m_MainMenu);
        }

        private static MainMenu buildTestMenu()
        {
            MainMenu menu = new MainMenu("Interfaces Main Menu");

            try
            {
                menu.AddMenuItems(null, eItemType.SubMenu, "Show Date/Time", "Version and Spaces");
                menu.AddMenuItems(new int[] { 1 }, eItemType.FunctionItem, "Show Time", "Show Date");
                menu.AddMenuItems(new int[] { 2 }, eItemType.FunctionItem, "Count spaces", "Show Version");
            }
            catch(ArgumentException ex)
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
                functionItem.AddObserver(new ShowTime());
                functionItem = i_Menu.FindMenuItem(new int[] { 1, 2 }) as FunctionItem;
                functionItem.AddObserver(new ShowDate());
                functionItem = i_Menu.FindMenuItem(new int[] { 2, 1 }) as FunctionItem;
                functionItem.AddObserver(new CountSpaces());
                functionItem = i_Menu.FindMenuItem(new int[] { 2, 2 }) as FunctionItem;
                functionItem.AddObserver(new ShowVersion());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
