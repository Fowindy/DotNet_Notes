using System;
using System.Collections.Generic;
using System.Text;

namespace Day01_01.委托和事件
{
    class GreetingManager
    {
        public void GreetPeople(string name, GreetingDelegate greetingDelegate)
        {
            greetingDelegate(name);
        }
    }
}
