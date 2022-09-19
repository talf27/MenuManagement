namespace Menus.Interfaces
{
    public abstract class MenuItem
    {
        public string Name { get; }
        public SubMenu Parent { get; }

        protected internal MenuItem(string i_Name, SubMenu i_Parent)
        {
            this.Name = i_Name;
            this.Parent = i_Parent;
        }

        internal void RemoveItem()
        {
            this.Parent.SubItems.Remove(this);
        }
    }
}