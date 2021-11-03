using System.Linq;
using System.Windows;
using CV19.Services;

namespace CV19
{

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceTest = new DataService();

            var countries = serviceTest.GetData().ToArray();
        }
    }
}
