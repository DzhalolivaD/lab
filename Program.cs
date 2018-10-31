using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Management;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using System.Management.Instrumentation;
using System.Threading;



namespace ConsoleApp2
{
    class Program

    {
        static void f1()
        {
            ManagementObjectSearcher ramMonitor = new ManagementObjectSearcher("SELECT TotalVisibleMemorySize,FreePhysicalMemory FROM Win32_OperatingSystem");

            foreach (ManagementObject objram in ramMonitor.Get())
            {
                ulong totalRam = Convert.ToUInt64(objram["TotalVisibleMemorySize"]);    //общая память ОЗУ
                ulong busyRam = totalRam - Convert.ToUInt64(objram["FreePhysicalMemory"]);        
                Console.WriteLine("Занятая память в МБ: " + busyRam/1024);
                Console.WriteLine("Cвободная память в МБ: " + (totalRam-busyRam )/1024);      
            }
        }
        static void t()
        {
            Console.Write("GitHab");
        }

        public static void th1(object obj)
        {
            for (int i = 1; i < 2; i++)
            {
                f1();
                  
            }
        }
        static void f3()
        {
            int num = 0;
            // устанавливаем метод обратного вызова
            TimerCallback tm = new TimerCallback(th1);
            // создаем таймер
            Timer timer = new Timer(tm, num, 0, 5000);
        }

        static void th2()
        {
            f3();
        }
        static void f4()
        {
            Thread thread1 = new Thread(th2);
            thread1.Start();
            for(int j=1000;j>1;j--)
            {
                   Thread.Sleep(4000);
                   Console.Clear();

            }
            

        }
        
        static void Main(string[] args)
        {
            //f1();
            //f3();
           f4();
            t();
            Console.ReadLine();
        }
    }
}
