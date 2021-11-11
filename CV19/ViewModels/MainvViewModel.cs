using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using CV19.Infrastructure.Commands;
using CV19.Models.Decanat;
using CV19.Services.Interfaces;
using CV19.ViewModels.Base;

namespace CV19.ViewModels
{
    [MarkupExtensionReturnType(typeof(MainvViewModel))]
    internal class MainvViewModel : ViewModel
    {
        private readonly IAsyngDataService _asyngData;
        public CountryStatisticViewModel CountryStatistic { get; }

        public  ObservableCollection<Group> Groups { get; }
        
        #region SelectedGroup : Group - Выбранная группа

        /// <summary>
        /// Выбранная группа
        /// </summary>
        private Group _selectedGroup;

        /// <summary>
        /// Выбранная группа
        /// </summary>
        public Group SelectedGroup { get => _selectedGroup; set => Set(ref _selectedGroup, value);}

        #endregion

        #region Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _title = "Анализ статистики CV19";

        /// <summary>Заголовок окна</summary>
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        #endregion

        #region Status : string  - Статус программы

        /// <summary>Статус программы</summary>
        private string _status = "Готов!";

        /// <summary>Статус программы</summary>
        public string Status { get => _status ; set => Set(ref _status, value);}

        #endregion

        #region DataValue : string - Результат длительной асинхнонной операции

        /// <summary>Результат длительной асинхнонной операции</summary>
        private string _DataValue;

        /// <summary>Результат длительной асинхнонной операции</summary>
        public string DataValue
        {
            get => _DataValue;
            private set => Set(ref _DataValue, value);
        }

        #endregion

        #region CloseApplicationCommand - команда закрытия приложения

        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p)
        {
            (RootObject as Window)?.Close();
        }

        #endregion

        #region CreateNewGroupCommand

        public ICommand CreateNewGroupCommand { get; }

        private bool CanCreateNewGroupCommandExecute(object p) => true;

        private void OnCreateNewGroupCommandExecuted(object p)
        {
            var groupMaxIndex = Groups.Count + 1;
            var newGroup = new Group
            {
                Name = $"Группа {groupMaxIndex}",
                Students = new ObservableCollection<Student>()
            };

            Groups.Add(newGroup);
        }

        #endregion

        #region DeleteGroupCommand

        public ICommand DeleteGroupCommand { get; }

        private bool CanDeleteGroupCommandExecute(object p) => p is Group group && Groups.Contains(group);

        private void OnDeleteGroupCommandExecuted(object p)
        {
            if(!(p is Group group)) return;
            var groupIndex = Groups.IndexOf(group);
            Groups.Remove(group);
            if (groupIndex < Groups.Count)
                SelectedGroup = Groups[groupIndex];
        }

        #endregion

        #region Command StartProccessCommand - Запуск процесса

        /// <summary>Запуск процесса</summary>
        private ICommand _StartProccessCommand;

        /// <summary>Запуск процесса</summary>
        public ICommand StartProccessCommand => _StartProccessCommand
            ??= new LambdaCommand(OnStartProcessCommandExecuted, CanStartProcessCommandExecute);

        /// <summary>Проверка возможности выполнения - Запуск процесса</summary>
        private static bool CanStartProcessCommandExecute(object p) => true;

        /// <summary>Логика выполнения - Запуск процесса</summary>
        private void OnStartProcessCommandExecuted(object p)
        {
            DataValue = _asyngData.GetResult(DateTime.Now);
        }

        #endregion

        #region Command StopProcessCommand - Остановка процесса

        /// <summary>Остановка процесса</summary>
        private ICommand _StopProcessCommand;

        /// <summary>Остановка процесса</summary>
        public ICommand StopProcessCommand => _StopProcessCommand
            ??= new LambdaCommand(OnStopProcessCommandExecuted, CanStopProcessCommandExecute);

        /// <summary>Проверка возможности выполнения - Остановка процесса</summary>
        private static bool CanStopProcessCommandExecute(object p) => true;

        /// <summary>Логика выполнения - Остановка процесса</summary>
        private void OnStopProcessCommandExecuted(object p)
        {
            
        }

        #endregion

        public MainvViewModel(CountryStatisticViewModel statistic, IAsyngDataService asyngData)
        {
            _asyngData = asyngData;
            CountryStatistic = statistic;
            statistic.MainVm = this;
            /*CountryStatistic = new CountryStatisticViewModel(this);*/
            #region Команды

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            CreateNewGroupCommand = new LambdaCommand(OnCreateNewGroupCommandExecuted, CanCreateNewGroupCommandExecute);
            DeleteGroupCommand = new LambdaCommand(OnDeleteGroupCommandExecuted, CanDeleteGroupCommandExecute);

            #endregion

        }
    }
}