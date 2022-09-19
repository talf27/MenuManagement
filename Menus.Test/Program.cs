namespace Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            InterfacesTestMenu interfacesMenu = new InterfacesTestMenu();
            interfacesMenu.m_MainMenu.Show();

            DelegatesTestMenu delegatesMenu = new DelegatesTestMenu();
            delegatesMenu.m_MainMenu.Show();
        }
    }
}
