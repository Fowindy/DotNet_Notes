/* ==============================================================================
 * 创 建 者：Fowindy
 * 创建日期：2020年5月30日 星期六 06:01:13
 * ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace Fowindy.Day01_02.委托和事件2.Listing01_01
{
    /************************************************************************/
    /* 思考1:为什么要使用事件而不是委托变量
     *  1.从封装性和易用性上去考虑
        2.事件应该由事件发布者触发，而不应该由客户端（客户程序）来触发
        3.对应关系:
            发布者(publisher)、订阅者(subscriber)、客户端(client)
            主题(subject)、观察者(observer)、Main()方法的Program类
        */
    /************************************************************************/
    /// <summary>
    /// 定义委托
    /// </summary>
    /// <param name="count"></param>
    public delegate void NumberChangedEventHandler(int count);
    /// <summary>
    /// 定义事件发布者
    /// </summary>
    public class Publisher
    {
        private int count;
        /// <summary>
        /// 声明委托变量
        /// </summary>
        //public NumberChangedEventHandler NumberChanged;

        /// <summary>
        /// 声明事件
        /// </summary>
        public event NumberChangedEventHandler NumberChanged;
        public void DoSomething(int count)
        {
            if (NumberChanged != null)
            {
                count++;
                NumberChanged(count);
            }
        }
    }
    /// <summary>
    /// 定义事件订阅者
    /// </summary>
    public class Subscriber
    {
        public void OnNumberChanged(int count)
        {
            Console.WriteLine("Subscriber notified:count = {0}",count);
        }
    }
    public class Listing01_01
    {
        public static void Main()
        {
            Publisher publisher = new Publisher();
            Subscriber subscriber = new Subscriber();

            publisher.NumberChanged += new NumberChangedEventHandler(subscriber.OnNumberChanged);
            publisher.DoSomething(100);    // 应该通过DoSomething()来触发事件
            publisher.DoSomething(103);    // 应该通过DoSomething()来触发事件
            /************************************************************************/
            /* 客户端直接通过委托变量触发事件,将会影响到所有注册了该委托的订阅者
             * 事件的本意应该为在事件发布者在其本身的某个行为中触发,比如说在方法DoSomething()中满足某个条件后触发
               添加event关键字来发布事件，事件发布者的封装性会更好
               事件仅仅是供其他类型订阅，而客户端不能直接触发事件
               事件只能在事件发布者Publisher类的内部触发
               订阅事件的方法的命名，通常为“On事件名”*/
            /************************************************************************/
            //publisher.NumberChanged(100);   // 但可以被这样直接调用，对委托变量的不恰当使用
            //publisher.NumberChanged(98);
        }
    }
}
