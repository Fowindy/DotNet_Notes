/* ==============================================================================
 * 创 建 者：Fowindy
 * 创建日期：2020年5月30日 星期六 15:02:25
 * ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace Fowindy.Day01_01.委托和事件.Listing01_04
{
    public class Listing01_04
    {
        /// <summary>
        /// 水温字段
        /// </summary>
        private int temperature;
        /// <summary>
        /// 烧水的方法
        /// </summary>
        public void BoilWater()
        {
            //实时记录当前水温
            for (int i = 0; i <= 100; i++)
                temperature = i;
            //当水温大于95度
            if (temperature > 95)
            {
                //开始报警
                MarkAlert(temperature);
                //并显示当前水温
                ShowTemperature(temperature);
            }
        }
        /// <summary>
        /// 发出语音报警
        /// </summary>
        /// <param name="temperature">水温</param>
        private void ShowTemperature(int temperature)
        {
            Console.WriteLine("Alarm:滴滴滴,水已经{0}度了;",temperature);
        }
        /// <summary>
        /// 显示水温
        /// </summary>
        /// <param name="temperature">水温</param>
        private void MarkAlert(int temperature)
        {
            Console.WriteLine("Display:水快开了,当前温度:{0}度.",temperature);
        }

        public static void Main()
        {
            Listing01_04 heater = new Listing01_04();
            heater.BoilWater();
            Console.ReadKey();
        }
    }
}
