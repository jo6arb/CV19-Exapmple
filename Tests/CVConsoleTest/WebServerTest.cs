using System;
using System.IO;
using CV19.Web;

namespace CVConsoleTest
{
    internal static class WebServerTest
    {
        public static void Run()
        {
            var server = new WebServer(8080);
            server.RequestReceived += OnRequestReceive;

            server.Start();
            Console.WriteLine("Сервер запущен");

            Console.ReadLine();
        }

        private static void OnRequestReceive(object? sender, RequestReceiverEventArgs e)
        {
            var context = e.Context;
            Console.WriteLine($"Connection {context.Request.UserHostAddress}");

            using var writer = new StreamWriter(context.Response.OutputStream);
            writer.Write("Hello from test Web Server");
        }
    }
}
