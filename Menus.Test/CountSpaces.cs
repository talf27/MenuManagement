using System;
using Menus.Interfaces;

namespace Menus.Test
{
    public class CountSpaces : IChoiceObserver
    {
        public void DoFunction()
        {
            Console.Write("Please write a sentence: ");
            string input = Console.ReadLine();
            Console.WriteLine("The sentence has {0} spaces {1}", input.Split(' ').Length - 1, Environment.NewLine);
        }
    }
}
