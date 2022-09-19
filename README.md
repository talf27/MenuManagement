# Menu Management

A system that helps a programmer to display and manage an hierarchical menu for his console-based applications.
The programmer builds a menu by creating menu items in the main menu, or as sub-items for any menu item.

-----

The menu always displays its current level with a list of its menu items,
and the user is prompted to choose one of them -
By that, the user can execute an action or nevigate to sub-menus.
In each level, the user can choose to go back to the previous menu level.

-----

The test application creates a 3-level menu with that hierarchy:
1. "Show Date/Time":
    "Show Time": Displays the current time to the user
    "Show Date": Displays the current date to the user
2. "Version and Spaces":
    "Count Spaces": Counts the number of spaces in a text input from the user
    "Show Version": Displays the following text: "App Version: 22.2.4.8950"

-----

The system implements the test menu twice in both techniques:
- Interfaces
- Delegates
When the user exits the first menu, the second menu is displayed.
