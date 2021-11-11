using System;
using System.Threading;

namespace CVConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main Thread";

            var thread = new Thread(ThreadMethod);
            thread.Name = "Other thread";
            thread.IsBackground = true;

            thread.Start();

            CheckThread();

            Console.ReadLine();
        }

        private static void ThreadMethod()
        {
            CheckThread();
        }

        private static void CheckThread()
        {
            var thread = Thread.CurrentThread;
            Console.WriteLine("id:{0} - {1}", thread.ManagedThreadId, thread.Name);
        }
}
}
