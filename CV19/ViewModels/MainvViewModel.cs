using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Input;
using CV19.Infrastructure.Commands;
using CV19.Models.Decanat;
using CV19.ViewModels.Base;

namespace CV19.ViewModels
{
    internal class MainvViewModel : ViewModel
    {

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

        #region CloseApplicationCommand - команда закрытия приложения

        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        #endregion

        public MainvViewModel()
        {
            CloseApplicationCommand =
                new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            var studentIndex = 1;

            var students = Enumerable.Range(1, 20).Select(i => new Student
            {
                Name = $"Name {studentIndex}",
                Surname = $" Surname {studentIndex}",
                Patronymic = $"Pathromyc {studentIndex++}",
                Birthday = DateTime.Now,
                Rating = 0
            });
            var grosups = Enumerable.Range(1, 10).Select(i => new Group
            {
                Name = $"Группа {i}",
                Students = new ObservableCollection<Student>(students)
            }); 
            
            Groups = new ObservableCollection<Group>(grosups);
        }
    }
}