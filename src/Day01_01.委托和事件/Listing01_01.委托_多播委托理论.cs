/* ==============================================================================
 * 创 建 者：Fowindy
 * 创建日期：2020年5月30日 星期六 06:57:32
 * ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace Fowindy.Day01_01.委托和事件.Listing01_01
{
    public class Listing01_01
    {
        /// <summary>
        /// 自定义声明一个无参数无返回值的委托
        /// </summary>
        public delegate void MyDelegate();
        /// <summary>
        /// 定义一个方法_没有参数没有返回值_静态方法
        /// </summary>
        public static void Test_static()
        {
            Console.WriteLine("测试自定义委托的使用_无参数无返回值_静态方法");
        }
        /// <summary>
        /// 定义另一个方法_测试多播委托的使用
        /// </summary>
        public static void Test_static2()
        {
            Console.WriteLine("测试自定义多播委托的使用_无参数无返回值_静态方法");
        }
        /// <summary>
        /// 定义一个方法_没有参数没有返回值_实例方法
        /// </summary>
        public void Test()
        {
            Console.WriteLine("测试自定义委托的使用_无参数无返回值_实例方法");
        }
        /// <summary>
        /// 定义一个方法_有参数有返回值_静态方法
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int Test3(int num)
        {
            return num;
        }

        public int Test4(int num)
        {
            return num;
        }
        public static void Main()
        {
            #region 自定义委托_静态方法(被委托)
            Console.WriteLine("******自定义委托_静态方法(被委托)******");
            //实例化委托的第一种方法_标准方法
            MyDelegate myDelegate1 = new MyDelegate(Test_static);
            //实例化委托的第二种方法_简写方法
            MyDelegate myDelegate2 = Test_static;
            //自定义委托的调用
            myDelegate1.Invoke();
            Console.WriteLine();
            #endregion

            #region 自定义委托_实例方法(被委托)
            Console.WriteLine("******自定义委托_实例方法(被委托)******");
            Listing01_01 program = new Listing01_01();
            MyDelegate myDelegate3 = program.Test;
            myDelegate3.Invoke();
            Console.WriteLine();
            #endregion

            #region 自定义多播委托+=的使用_静态方法(被委托)
            Console.WriteLine("******自定义多播委托+=的使用_静态方法(被委托)******");
            myDelegate1 += Test_static2;
            myDelegate1.Invoke();
            Console.WriteLine();
            #endregion

            #region 自定义多播委托-=的使用_静态方法(被委托)
            Console.WriteLine("******自定义多播委托-=的使用_静态方法(被委托)******");
            myDelegate1 -= Test_static;
            myDelegate1.Invoke();
            Console.WriteLine();
            #endregion

            #region 系统委托的使用_静态方法(被委托)
            Console.WriteLine("******系统委托的使用_静态方法(被委托)******");
            //实例化委托的第一种方法_标准方法
            Action action1 = new Action(Test_static);
            //实例化委托的第二种方法_简写方法
            Action action2 = Test_static;
            //系统委托的调用
            action1.Invoke();
            Console.WriteLine();
            #endregion

            #region 系统委托的使用_实例方法(被委托)
            Console.WriteLine("******系统委托的使用_实例方法(被委托)******");
            Action action3 = new Action(program.Test);
            //系统委托的调用
            action3.Invoke();
            Console.WriteLine();
            #endregion

            #region 系统委托的使用_调用有参数有返回值的静态方法(被委托)
            Console.WriteLine("******系统委托的使用_调用有参数有返回值的静态方法(被委托)******");
            //系统委托的调用
            Func<int, int> func = Test3;
            int i = func.Invoke(3);
            Console.WriteLine(i);
            Console.WriteLine();
            #endregion

            #region 系统委托的使用_调用有参数有返回值的实例方法(被委托)
            Console.WriteLine("******系统委托的使用_调用有参数有返回值的实例方法(被委托)******");
            //系统委托的调用
            Func<int, int> func1 = program.Test4;
            int j = func.Invoke(4);
            Console.WriteLine(j);
            Console.WriteLine();
            #endregion

            Console.ReadKey();
        }
    }
}
