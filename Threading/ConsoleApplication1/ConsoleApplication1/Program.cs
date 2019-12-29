using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
           // Task t = Task.Factory.StartNew(Go);
            //Thread.Sleep(100);
            //Thread t = new Thread(Go);
            //t.Start();
            //t.Join();
            //t.Wait(1);
            Console.WriteLine("Not Finishing Main");
            //Thread.Sleep(1);
            //NoGo();
            Task<string> t = Task.Factory.StartNew(() => DownloadString("http://www.google.com"));
            Console.WriteLine("back...");
            Go();
            Console.WriteLine(t.Result.Length);
            Console.WriteLine("Finishing Main");
        }

        private static string DownloadString(string v)
        {
            using (var wc = new System.Net.WebClient())
                return wc.DownloadString(v);
        }

        private static void Go()
        {
            Console.WriteLine("Inside Go");
            //throw new Exception();
        }

        private static void NoGo()
        {
            Console.WriteLine("Inside NoGo");
        }
    }
}
