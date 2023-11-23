using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using HydrixOS.Stack;
namespace HydrixOS
{
    public class Kernel : Sys.Kernel
    {
        public static Stack.Stack stack = new Stack.Stack();
        public static uint tasksruncount = 0;
        protected override void BeforeRun()
        {
            //init stack
            stack.init();
            stack.push(new Action(print));
        }

        protected override void Run()
        {
            if (tasksruncount > 5)
            {
                stack.pop();
                Console.ReadLine();
            }
            tasksruncount++;
        }
        public static void print()
        {
            Console.WriteLine("Har");
        }
    }
}
