using System.Collections.Generic;

namespace Menus.Interfaces
{
    public interface IChoiceObserver
    {
        void DoFunction();
    }

    public class FunctionItem : MenuItem
    {
        private readonly LinkedList<IChoiceObserver> r_ChoiceObservers;

        public FunctionItem(string i_Name, SubMenu i_Parent)
            : base(i_Name, i_Parent)
        {
            this.r_ChoiceObservers = new LinkedList<IChoiceObserver>();
        }

        public void AddObserver(IChoiceObserver i_ChoiceObserver)
        {
            r_ChoiceObservers.AddLast(i_ChoiceObserver);
        }

        public void RemoveObserver(IChoiceObserver i_ChoiceObserver)
        {
            r_ChoiceObservers.Remove(i_ChoiceObserver);
        }

        internal void NotifyFunctionItemItWasChosen()
        {
            DoWhenFunctionItemChosen();
        }

        protected virtual void DoWhenFunctionItemChosen()
        {
            foreach (IChoiceObserver observer in r_ChoiceObservers)
            {
                observer.DoFunction();
            }
        }
    }
}
