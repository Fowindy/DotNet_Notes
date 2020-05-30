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
            GreetPeople("Mark", EnglishGreeting);
            GreetPeople("马云", ChineseGreeting);
            Console.ReadKey();
        }
    }
}
