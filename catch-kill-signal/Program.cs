using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace catch_kill_signal
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{DateTime.Now} Start");
            var s = new WinExitSignal();
            while (true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
