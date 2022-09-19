using System;

namespace Menus.Delegates
{
    public class FunctionItem : MenuItem
    {
        public event Action FunctionBecameChosen;

        public FunctionItem(string i_Name, SubMenu i_Parent) : base(i_Name, i_Parent) { }

        internal void NotifyFunctionItemItWasChosen()
        {
            OnFunctionBecameChosen();
        }

        protected virtual void OnFunctionBecameChosen()
        {
            if(FunctionBecameChosen != null)
            {
                FunctionBecameChosen.Invoke();
            }
        }
    }
}
