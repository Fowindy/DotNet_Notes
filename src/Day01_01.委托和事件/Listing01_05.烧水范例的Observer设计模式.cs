/* ==============================================================================
 * 创 建 者：Fowindy
 * 创建日期：2020年5月30日 星期六 15:18:58
 * ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace Fowindy.Day01_01.委托和事件.Listing01_05
{
    /************************************************************************/
    /* 热水器由三部分组成:
     *  1.热水器:负责烧水(面向对象为抽出类)
        2.警报器:负责警报(面向对象抽出类)
        3.显示器:负责显示温度(面向对象抽出类)*/
    /************************************************************************/
    /// <summary>
    /// 热水器类
    /// </summary>
    public class Heater
    {
        /// <summary>
        /// 温度变量
        /// </summary>
        private int temperature;
        /// <summary>
        /// 烧水方法
        /// </summary>
        private void BoilWater()
        {
            for (int i = 0; i <= 100; i++)
                temperature = i;
        }
    }
    /// <summary>
    /// 警报器类
    /// </summary>
    public class Alarm
    {
        /// <summary>
        /// 报警的方法
        /// </summary>
        /// <param name="temperature">温度</param>
        private void MarkAlert(int temperature)
        {
            Console.WriteLine("Alarm:滴滴滴,水已经{0}度了;",temperature);
        }
    }
    /// <summary>
    /// 显示器类
    /// </summary>
    public class Display
    {
        /// <summary>
        /// 显示温度的方法
        /// </summary>
        /// <param name="temperature">水温</param>
        private void ShowTemperature(int temperature)
        {
            Console.WriteLine("Display:水快烧开了,当前温度:{0}.",temperature);
        }
    }
    /************************************************************************/
    /* 思考1:如何在水烧开的时候通知报警器和显示器？
     * 引出:Observer设计模式
        1.Subject：监视对象，它往往包含着其他对象所感兴趣的内容;热水器就是一个监视对象;
        2.Observer：监视者，它监视Subject，当Subject中的某件事发生的时候，会告知Observer，而Observer则会采取相应的行动。在本范例中，Observer有警报器和显示器，它们采取的行动分别是发出警报和显示水温。
        范例分析:
        1.警报器和显示器告诉热水器，它对它的温度比较感兴趣(注册)。
        2.热水器知道后保留对警报器和显示器的引用。
        3.热水器进行烧水这一动作，当水温超过95度时，通过对警报器和显示器的引用，自动调用警报器的MakeAlert()方法、显示器的ShowTemperature()方法。
        总结:
        Observer设计模式是为了定义对象间的一种一对多的依赖关系，以便于当一个对象的状态改变时，其他依赖于它的对象会被自动告知并更新。Observer模式是一种松耦合的设计模式。*/
    /************************************************************************/
    public class Listing01_05
    {
        public static void Main()
        {
        }
    }
}
