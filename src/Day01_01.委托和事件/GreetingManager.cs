using System;
using System.Collections.Generic;
using System.Text;

namespace Day01_01.委托和事件
{
    class GreetingManager
    {
        //直接在GreetingManager类的内部声明greetingDelegate变量
        public GreetingDelegate greetingDelegate;
        public void GreetPeople(string name)
        {
            if (greetingDelegate != null)   //如果有方法注册委托变量
                greetingDelegate(name);     //通过委托调用方法
        }
    }
}
