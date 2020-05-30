/* ==============================================================================
 * 创 建 者：Fowindy
 * 创建日期：2020年5月30日 星期六 10:22:19
 * ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using Day01_01.委托和事件;

namespace Fowindy.Day01_01.委托和事件.Listing01_03
{
    public class Listing01_03
    {
        public static void EnglishGreeting(string name)
        {
            Console.WriteLine("Good Morning,"+ name);
        }
        public static void ChineseGreeting(string name)
        {
            Console.WriteLine("早上好,"+name);
        }
        public static void Main()
        {
            GreetingManager gm= new GreetingManager();
            gm.greetingDelegate = ChineseGreeting;
            gm.GreetPeople("王岳");
            Console.ReadKey();
        }
    }
}
