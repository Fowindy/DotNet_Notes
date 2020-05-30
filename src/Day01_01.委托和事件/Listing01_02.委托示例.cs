/* ==============================================================================
 * 创 建 者：Fowindy
 * 创建日期：2020年5月30日 星期六 09:15:52
 * ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace Fowindy.Day01_01.委托和事件.Listing01_02
{
    public class Listing01_02
    {
        /// <summary>
        /// 声明一个打招呼的委托函数
        /// </summary>
        /// <param name="name"></param>
        public delegate void GreetingDelegate(string name);
        /// <summary>
        /// 声明语言的枚举
        /// </summary>
        public enum Language
        {
            English,
            Chinese
        }
        /// <summary>
        /// 声明英语打招呼的方法
        /// </summary>
        /// <param name="name"></param>
        public static void EnglishGreeting(string name)
        {
            Console.WriteLine("Good Morning,"+ name);
        }
        /// <summary>
        /// 声明中文打招呼的方法
        /// </summary>
        /// <param name="name"></param>
        public static void ChineseGreeting(string name)
        {
            Console.WriteLine("早上好,"+ name);
        }
        public static void GreetPeople(string name,GreetingDelegate greetingDelegate)
        {
            greetingDelegate(name);
        }
        public static void Main()
        {
            Console.WriteLine("------委托第一种实现方式------");
            #region 委托第一种实现方式
            GreetPeople("Mark1", EnglishGreeting);
            GreetPeople("马云1", ChineseGreeting);
            #endregion
            Console.WriteLine("------委托第二种实现方式_可以节省一个GreetPeople方法------");
            #region 委托第二种实现方式_可以节省一个GreetPeople方法
            GreetingDelegate greetingDelegate1, greetingDelegate2;
            greetingDelegate1 = EnglishGreeting;
            greetingDelegate2 = ChineseGreeting;
            greetingDelegate1("Mark2");
            greetingDelegate2("马云2");
            #endregion
            Console.WriteLine("------多个方法绑定到同一个委托,依次调用其所绑定的方法------");
            #region 多个方法绑定到同一个委托,依次调用其所绑定的方法
            GreetingDelegate greetingDelegate3;
            greetingDelegate3 = EnglishGreeting;
            greetingDelegate3 += ChineseGreeting;
            greetingDelegate3("Mark3"); 
            #endregion
            Console.ReadKey();
            /************************************************************************/
            /* 委托总结:
                委托是一个类,它定义了方法的类型,使可以讲方法当作另一个方法的参数来进行传递
                这种将方法动态地赋值给参数的做法,可以避免在程序中大量使用If-Else(Switch)语句,同时使得程序具有更好的可扩展性*/
            /************************************************************************/
        }
    }
}
