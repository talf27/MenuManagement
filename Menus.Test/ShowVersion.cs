using System;
using Menus.Interfaces;

namespace Menus.Test
{
    public class ShowVersion : IChoiceObserver
    {
        public void DoFunction()
        {
            Console.WriteLine("Version: 22.2.4.8950 {0}",Environment.NewLine);
        }
    }
}
