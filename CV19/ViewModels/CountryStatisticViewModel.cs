using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using CV19.Infrastructure.Commands;
using CV19.Models;
using CV19.Services;
using CV19.ViewModels.Base;

namespace CV19.ViewModels
{
    internal class CountryStatisticViewModel : ViewModel
    {

        private DataService _dataService;

        private  MainvViewModel MainVm { get; }

        #region Countries : IEnumerable<CounryInfo> - Статистика по странам

        /// <summary>Статистика по странам</summary>
        private IEnumerable<CountryInfo> _countries;

        /// <summary>Статистика по странам</summary>
        public IEnumerable<CountryInfo> Countries
        {
            get => _countries;
            private set => Set(ref _countries, value);
        }

        #endregion

        #region Команды

        public ICommand RefreshDataCommand { get; }

        private void OnRefreshDataCommandExecuted(object p)
        {
            Countries = _dataService.GetData();
        }

        #endregion

        /// <summary> Отладочный конструктор, используемый в процессе разработки в визуальном дизайнере </summary>
        public CountryStatisticViewModel() : this(null)
        {
            _countries = Enumerable.Range(1, 10)
                .Select(i => new CountryInfo
            {
                    Name = $"Country {i}",
                    ProvinceCounts = Enumerable.Range(1,10).Select(j => new PlaceInfo
                    {
                        Name = $"Province {i}",
                        Location = new Point(i, j),
                        Counts = Enumerable.Range(1,10).Select(k => new ConfirmedCount
                        {
                            Date = DateTime.Now.Subtract(TimeSpan.FromDays(100-k)),
                            Count = k
                        })
                    })
                    
            });
        }

        public CountryStatisticViewModel(MainvViewModel mainVM)
        {
            MainVm = mainVM;
            _dataService = new DataService();

            #region Команды

            RefreshDataCommand = new LambdaCommand(OnRefreshDataCommandExecuted);

            #endregion
        }
    }
}