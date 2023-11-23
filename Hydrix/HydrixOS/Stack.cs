using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydrixOS.Stack
{
    public class Stack
    {
        public List<Action> actions;

        public void push(Action action)
        {
            actions.Add(action);
        }
        public void pop()
        {
              actions.RemoveAt(actions.Count - 1);
        }
        public void loop()
        {
            //run action at top of stack
            actions[actions.Count - 1].Invoke();
        }
        public void init()
        {
            actions = new List<Action>();
        }
        public void clear()
        {
            actions.Clear();
        }
    }
}
