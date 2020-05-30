/* ==============================================================================
 * 创 建 者：Fowindy
 * 创建日期：2020年5月30日 星期六 16:01:49
 * ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace Fowindy.Day01_01.委托和事件.Listing01_06
{
    /************************************************************************/
    /* 思考1: 为什么.Net Framework 中的事件模型和上面的不同？为什么有很多的EventArgs参数？
     * 引出: .Net Framework的编码规范：
        1.委托类型的名称都应该以EventHandler结束
        2.委托的原型定义：有一个void返回值，并接受两个输入参数：一个Object 类型，一个 EventArgs类型(或继承自EventArgs)
        3.事件的命名为 委托去掉 EventHandler之后剩余的部分
        4.继承自EventArgs的类型应该以EventArgs结尾
        再做一下说明：
        1.委托声明原型中的Object类型的参数代表了Subject，也就是监视对象，在本例中是 Heater(热水器)。回调函数(比如Alarm的MakeAlert)可以通过它访问触发事件的对象(Heater)
        2.EventArgs 对象包含了Observer所感兴趣的数据，在本例中是temperature*/
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
        /// 添加型号作为演示
        /// </summary>
        public string type = "Haier 001";
        /// <summary>
        /// 添加产地作为演示
        /// </summary>
        public string area = "China SuZhou";
        /// <summary>
        /// 声明委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void BoiledEventHandler(Object sender, BoiledEventArgs e);
        /// <summary>
        /// 声明事件
        /// </summary>
        public event BoiledEventHandler Boiled;
        /// <summary>
        /// 定义BoiledEventArgs子类,传递Observer监视者所感兴趣的信息,本例为温度
        /// </summary>
        public class BoiledEventArgs : EventArgs
        {
            /// <summary>
            /// 定义传递变量temperature
            /// </summary>
            public readonly int temperature;
            /// <summary>
            /// 使用构造函数传递监视者所感兴趣的信息
            /// </summary>
            /// <param name="temperature"></param>
            public BoiledEventArgs(int temperature)
            {
                this.temperature = temperature;
            }
        }
        /// <summary>
        /// 可以供继承自Heater的类的重写,以便继承类拒绝其他对象对它的监视
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnBoiled(BoiledEventArgs e)
        {
            if (Boiled != null)     //如果有对象注册
            {
                Boiled(this, e);    //调用所有注册对象的方法
            }
        }
        public void BoilWater()
        {
            for (int i = 0; i <= 100; i++)
            {
                temperature = i;
                if (temperature > 95)
                {
                    //建立BoiledEventArgs对象
                    BoiledEventArgs e = new BoiledEventArgs(temperature);
                    //调用OnBoiled方法
                    OnBoiled(e);
                }
            }
        }
    }
    /// <summary>
    /// 报警器类
    /// </summary>
    public class Alarm
    {
        /// <summary>
        /// 报警方法
        /// </summary>
        /// <param name="sender">触发对象</param>
        /// <param name="e">触发参数</param>
        public void MakeAlert(Object sender,Heater.BoiledEventArgs e)
        {
            //将sender强转为触发对象
            Heater heater = (Heater)sender;
            //显示产地和品牌
            Console.WriteLine("Alarm:{0} - {1};",heater.type,heater.area);
            //报警
            Console.WriteLine("Alarm:滴滴滴,水已经{0}度了;",e.temperature);
            Console.WriteLine();
        }
    }
    /// <summary>
    /// 显示器类
    /// </summary>
    public class Display
    {
        /// <summary>
        /// 显示温度方法
        /// </summary>
        /// <param name="sender">触发对象</param>
        /// <param name="e">触发参数</param>
        public static void ShowTemperature(Object sender,Heater.BoiledEventArgs e)
        {
            //将sender强转为触发对象
            Heater heater = (Heater)sender;
            //显示产地和品牌
            Console.WriteLine("Display:{0}-{1};",heater.area,heater.type);
            //显示当前温度
            Console.WriteLine("Display:水快烧开了,当前温度{0}度",e.temperature);
            Console.WriteLine();
        }
    }
    public class Listing01_06
    {
        public static void Main()
        {
            Heater heater = new Heater();
            Alarm alarm = new Alarm();
            heater.Boiled += alarm.MakeAlert;
            heater.Boiled += Display.ShowTemperature;
            heater.BoilWater();
            Console.ReadKey();
        }
    }
}
