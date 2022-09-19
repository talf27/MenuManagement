using System;
using Menus.Interfaces;

namespace Menus.Test
{
    public class ShowDate : IChoiceObserver
    {
        public void DoFunction()
        {
            Console.WriteLine("Today's date is: {0}{1}", DateTime.Now.ToString("d"), Environment.NewLine);
        }
    }
}
