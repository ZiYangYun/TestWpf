using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine(DateTime.Now);
            Add(1,1, AddResult);
            Console.ReadLine();
        }
        public static void AddResult(int result)
        {
            Console.WriteLine(result);
            Console.WriteLine(DateTime.Now);
        }
        public static void Add(int a, int b, Action<int> callBack)
        {
            Task.Run(() =>
            {
                Thread.Sleep(10000);
                int c = a + b;
                callBack(c);
            });
        }
    }
}
