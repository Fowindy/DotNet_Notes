using System;
using System.Collections.Generic;
using System.Text;

namespace Day01_01.委托和事件
{
    class GreetingManager
    {
        //直接在GreetingManager类的内部声明greetingDelegate变量
        public GreetingDelegate greetingDelegate;
        /************************************************************************/
        /* 委托的修饰符的矛盾点:
            1.声明委托的目的就是为了把它暴露在类的客户端进行方法的注册,因此不能使用private
            2.声明成public又会导致在客户端可以对它进行随意的赋值等操作，严重破坏对象的封装性
            */
        /************************************************************************/
        public void GreetPeople(string name)
        {
            if (greetingDelegate != null)   //如果有方法注册委托变量
                greetingDelegate(name);     //通过委托调用方法
        }
    }
}
