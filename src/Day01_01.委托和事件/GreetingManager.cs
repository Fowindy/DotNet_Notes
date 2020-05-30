using System;
using System.Collections.Generic;
using System.Text;

namespace Day01_01.委托和事件
{
    class GreetingManager
    {
        //直接在GreetingManager类的内部声明greetingDelegate变量
        //public GreetingDelegate greetingDelegate;
        /************************************************************************/
        /* 委托的修饰符的矛盾点:
            1.声明委托的目的就是为了把它暴露在类的客户端进行方法的注册,因此不能使用private
            2.声明成public又会导致在客户端可以对它进行随意的赋值等操作，严重破坏对象的封装性
            */
        /************************************************************************/
        /************************************************************************/
        /* 声明Event事件来解决上述矛盾:
         * 1.在类的内部，不管你声明它是public还是protected，它总是private的;
           2.在类的外部，注册“+=”和注销“-=”的访问限定符与你在声明事件时使用的访问符相同*/
        /************************************************************************/

        /************************************************************************/
        /* 声明一个事件类似于声明一个进行了封装的委托类型的变量而已                                                                     */
        /************************************************************************/
        public event GreetingDelegate greetingDelegate;
        public void GreetPeople(string name)
        {
            if (greetingDelegate != null)   //如果有方法注册委托变量
                greetingDelegate(name);     //通过委托调用方法
        }
    }
}
