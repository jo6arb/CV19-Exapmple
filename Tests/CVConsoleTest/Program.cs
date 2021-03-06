using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Channels;

namespace CVConsoleTest
{
    internal class Program
    {
        private static bool _threadUp = true;
        static void Main(string[] args)
        {

            WebServerTest.Run();
            return;

            //Thread.CurrentThread.Name = "Main Thread";

            //var clockThread = new Thread(ThreadMethod);
            //clockThread.Name = "Other thread";
            //clockThread.IsBackground = true;
            //clockThread.Priority = ThreadPriority.AboveNormal;
            //clockThread.Start(42);

            ///*  var count = 5;
            //  var msg = "Gbie";
            //  var timeout = 150;

            //  new Thread(() => PrintMethod(msg,count , timeout)) { IsBackground = true}.Start();



            //  CheckThread();*/

            //var values = new List<int>();

            //var threads = new Thread[10];
            //object lock_object = new object();
            //for (var i = 0; i < threads.Length; i++)
            //{
            //    threads[i] = new Thread(() =>
            //    {
            //        for (var j = 0; j < 10; j++)
            //            lock (lock_object)
            //                values.Add(Thread.CurrentThread.ManagedThreadId);
            //    });
            //}



            //foreach (var thread in threads)
            //   thread.Start();


            //if (clockThread.Join(100))
            //{
            //    clockThread.Abort();
            //    clockThread.Interrupt();
            //}

            //Mutex mutex = new Mutex();
            //Semaphore semaphore = new Semaphore(0,10);
            //semaphore.WaitOne();

            //semaphore.Release();

            ManualResetEvent manual = new ManualResetEvent(false);
            AutoResetEvent auto = new AutoResetEvent(false);

            EventWaitHandle threadHandle = manual;

            var testThreads = new Thread[10];
            for (var i = 0; i < testThreads.Length; i++)
            {
                testThreads[i] = new Thread(() =>
                {
                    var localI = i;
                    Console.WriteLine($"Поток id:{Thread.CurrentThread.ManagedThreadId} - стартовал");

                    threadHandle.WaitOne();

                    Console.WriteLine($"Value: {localI}");
                    Console.WriteLine($"Поток id:{Thread.CurrentThread.ManagedThreadId} - завершился");
                    threadHandle.Set();
                });
                testThreads[i].Start();
            }

            Console.WriteLine("Готов к запуску потоков!");
            Console.ReadLine();

            threadHandle.Set();

            Console.ReadLine();
            /*Console.WriteLine(String.Join(",", values));
            Console.ReadLine();*/
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void PrintMethod(string Message, int Count, int Timeout)
        {
            for (var i = 0; i < Count; i++)
            {
                Console.WriteLine(Message);
                Thread.Sleep(Timeout);
            }

        }

        private static void ThreadMethod(object parametr)
        {
            var value = (int) parametr;
            Console.WriteLine(value);

            while (_threadUp)
            {
                Thread.Sleep(100);
                Console.Title = DateTime.Now.ToString();
            }
                

        }

        private static void CheckThread()
        {
            var thread = Thread.CurrentThread;
            Console.WriteLine("id:{0} - {1}", thread.ManagedThreadId, thread.Name);
        }
}
}
