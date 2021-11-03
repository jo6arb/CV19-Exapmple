using CV19.Services;
using CV19.ViewModels.Base;

namespace CV19.ViewModels
{
    internal class CountryStatisticViewModel : ViewModel
    {

        private DataService _dataService;

        private  MainvViewModel MainVm { get; }

        public CountryStatisticViewModel(MainvViewModel mainVM)
        {
            MainVm = mainVM;
            _dataService = new DataService();
        }
    }
}