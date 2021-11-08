using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace CV19
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] Agrs)
        {
            var hostBuilder = Host.CreateDefaultBuilder(Agrs);

            hostBuilder.UseContentRoot(Environment.CurrentDirectory);
            hostBuilder.ConfigureAppConfiguration((host, cfg) =>
            {
                cfg.SetBasePath(Environment.CurrentDirectory);
                cfg.AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            });

            hostBuilder.ConfigureServices(App.ConfigureServices);

            return hostBuilder;
        }
    }
}