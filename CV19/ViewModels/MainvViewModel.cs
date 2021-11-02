using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using CV19.Infrastructure.Commands;
using CV19.Models.Decanat;
using CV19.ViewModels.Base;
using OxyPlot;

namespace CV19.ViewModels
{
    internal class MainvViewModel : ViewModel
    {

        public  ObservableCollection<Group> Groups { get; }

        public object[] CompositeCollection { get; }

        #region SelectedCompositeValue - object - Выбранный непонятный элемент

        /// <summary>
        /// Выбранный непонятный элемент
        /// </summary>
        private object _selectedCompositeValue;

        /// <summary>
        /// Выбранный непонятный элемент
        /// </summary>
        public object SelectedCompositeValue
        {
            get => _selectedCompositeValue; set => Set(ref _selectedCompositeValue, value);
        }

        #endregion

        #region SelectedGroup : Group - Выбранная группа

        /// <summary>
        /// Выбранная группа
        /// </summary>
        private Group _selectedGroup;

        /// <summary>
        /// Выбранная группа
        /// </summary>
        public Group SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                if(!Set(ref _selectedGroup, value)) return;

                _selectedGroupStudent.Source = value?.Students;
                OnPropertyChanged(nameof(SelectedGroupStudent));
            }
        }

        #endregion

        #region StudentFilterText : string - Текст фильтра студента

        /// <summary>
        /// Текст фильтра студента
        /// </summary>
        private string _studentFilterText;

        /// <summary>
        /// Текст фильтра студента
        /// </summary>
        public string StudentFilterText
        {
            get => _studentFilterText;
            set
            {
                if(!Set(ref _studentFilterText, value)) return;
                _selectedGroupStudent.View.Refresh();
            }
        }

        #endregion

        #region SelectedGroupStudents

        private readonly CollectionViewSource _selectedGroupStudent = new CollectionViewSource();

        public ICollectionView SelectedGroupStudent => _selectedGroupStudent?.View;
        
        private void OnStudentFiltred(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Student student ))
            {
                e.Accepted = false;
                return;
            }

            var filterText = _studentFilterText;
            if (string.IsNullOrWhiteSpace(filterText)) return;

            if (student.Name is null || student.Surname is null || student.Patronymic is null)
            {
                e.Accepted = false;
                return;
            }
            if (student.Name.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;
            if (student.Surname.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;
            if (student.Patronymic.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;

            e.Accepted = false;
        }

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

        public IEnumerable<Student> TeStudents => 
            Enumerable.Range(1, App.IsDesignMode ? 10 : 100_000)
            .Select(i => new Student
            {
                Name = $" Имя {i}",
                Surname = $"Фамилия {i}"
            });
        
        #region CloseApplicationCommand - команда закрытия приложения

        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
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


        public MainvViewModel()
        {
            #region Команды

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            CreateNewGroupCommand = new LambdaCommand(OnCreateNewGroupCommandExecuted, CanCreateNewGroupCommandExecute);
            DeleteGroupCommand = new LambdaCommand(OnDeleteGroupCommandExecuted, CanDeleteGroupCommandExecute);

            #endregion

            var studentIndex = 1;

            var students = Enumerable.Range(1, 10).Select(i => new Student
            {
                Name = $"Name {studentIndex}",
                Surname = $" Surname {studentIndex}",
                Patronymic = $"Pathromyc {studentIndex++}",
                Birthday = DateTime.Now,
                Rating = 0
            });
            var grosups = Enumerable.Range(1, 20).Select(i => new Group
            {
                Name = $"Группа {i}",
                Students = new ObservableCollection<Student>(students)
            }); 
            
            Groups = new ObservableCollection<Group>(grosups);


            var dataList = new List<object>();

            dataList.Add("Hello");
            dataList.Add(42);
            var group = Groups[1];
            dataList.Add(group);
            dataList.Add(group.Students[0]);

            CompositeCollection = dataList.ToArray();

            _selectedGroupStudent.Filter+= OnStudentFiltred;

           //_selectedGroupStudent.SortDescriptions.Add(new SortDescription());
            //_selectedGroupStudent.GroupDescriptions.Add(new PropertyGroupDescription("Name"));
        }

        
    }
}