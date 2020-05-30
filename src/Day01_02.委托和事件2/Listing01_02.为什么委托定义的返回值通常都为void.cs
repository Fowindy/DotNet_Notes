/* ==============================================================================
 * 创 建 者：Fowindy
 * 创建日期：2020年5月30日 星期六 18:11:32
 * ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace Fowindy.Day01_02.委托和事件2.Listing01_02
{
    /************************************************************************/
    /*  思考1:为什么委托定义的返回值通常都为void
     *  解答:
     *  1.因为委托变量可以供多个订阅者注册,如果定义了返回值，那么多个订阅者的方法都会向发布者返回数值，结果就是后面一个返回的方法值将前面的返回值覆盖掉了，因此，实际上只能获得最后一个方法调用的返回值。
        2.发布者和订阅者是松耦合的，发布者根本不关心谁订阅了它的事件、为什么要订阅，更别说订阅者的返回值了，所以返回订阅者的方法返回值大多数情况下根本没有必要。*/
    /************************************************************************/

    /// <summary>
    /// 定义无参带返回值的委托
    /// </summary>
    /// <returns></returns>
    public delegate string GeneralEventHandler();
    /// <summary>
    /// 定义事件发布者
    /// </summary>
    public class Publisher
    {
        /// <summary>
        /// 声明一个事件
        /// </summary>
        public event GeneralEventHandler NumberChanged;
        public void DoSomething()
        {
            if (NumberChanged != null)      //触发事件
            {
                string rtn = NumberChanged();
                Console.WriteLine(rtn);     //打印返回的字符串,输出为:Subscriber3
            }
        }
    }
    /// <summary>
    /// 定义事件订阅者Subscriber1
    /// </summary>
    public class Subscriber1
    {
        public static string OnNumberChanged()
        {
            return "Subscriber1";
        }
    }
    /// <summary>
    /// 定义事件订阅者Subscriber1
    /// </summary>
    public class Subscriber2
    {
        public static string OnNumberChanged()
        {
            return "Subscriber2";
        }
    }
    /// <summary>
    /// 定义事件订阅者Subscriber1
    /// </summary>
    public class Subscriber3
    {
        public static string OnNumberChanged()
        {
            return "Subscriber3";
        }
    }
    public class Listing01_02
    {
        public static void Main()
        {
            Publisher publisher = new Publisher();
            publisher.NumberChanged += Subscriber1.OnNumberChanged;
            publisher.NumberChanged += Subscriber2.OnNumberChanged;
            publisher.NumberChanged += Subscriber3.OnNumberChanged;
            publisher.DoSomething();
        }
    }
}
