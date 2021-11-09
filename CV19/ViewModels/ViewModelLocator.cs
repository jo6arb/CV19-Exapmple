using Microsoft.Extensions.DependencyInjection;

namespace CV19.ViewModels
{
    internal class ViewModelLocator
    {
        public MainvViewModel MainWindowModel => App.Host.Services.GetRequiredService<MainvViewModel>();
    }
}