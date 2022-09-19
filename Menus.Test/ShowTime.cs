using System;
using Menus.Interfaces;

namespace Menus.Test
{
    public class ShowTime : IChoiceObserver
    {
        public void DoFunction()
        {
            Console.WriteLine("Time of the day is: {0}{1}", DateTime.Now.ToString("T"), Environment.NewLine);
        }
    }
}
