using System.Collections.Generic;
using System.IO.Packaging;
using System.Windows;
using System.Windows.Input;
using CV19.Infrastructure.Commands;
using CV19.Models.Decanat;
using CV19.Services;
using CV19.Services.Interfaces;
using CV19.ViewModels.Base;
using CV19.Views.Windows;

namespace CV19.ViewModels
{
    class StudentManagementViewModel : ViewModel
    {
        private readonly StudentsManager _studentsManager;
        private readonly IUserDialogService _UserDialog;

        public IEnumerable<Student> Students => _studentsManager.Students;

        public IEnumerable<Group> Groups => _studentsManager.Groups;


        #region Title : String - Заголовок окна

        /// <summary>
        ///Заголовок окна
        /// </summary>
        private string _Title = "Редактирование студентов";

        /// <summary>
        ///Заголовок окна
        /// </summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }

        #endregion

        #region SelectedGroup : Group - Выбранная группа студентов

        /// <summary>Выбранная группа студентов</summary>
        private Group _SelectedGroup;

        /// <summary>Выбранная группа студентов</summary>
        public Group SelectedGroup { get => _SelectedGroup; set => Set(ref _SelectedGroup, value); }

        #endregion

        #region SelectedStudent : Student - Выбранный студент

        /// <summary>Выбранный студент</summary>
        private Student _SelectedStudent;

        /// <summary>Выбранный студент</summary>
        public Student SelectedStudent { get => _SelectedStudent; set => Set(ref _SelectedStudent, value); }

        #endregion

        #region Команды

        #region EditStudentCommand - Команда редактирование студента

        private ICommand _EditStudentCommand;

        /// <summary>Команда редактирование студента</summary>
        public ICommand EditStudentCommand => _EditStudentCommand ??= new LambdaCommand(OnEditStudentCommandExecuted, CanEditStudentCommandExecute);

        private static bool CanEditStudentCommandExecute(object p) => p is Student;

        private void OnEditStudentCommandExecuted(object p)
        {
            if (_UserDialog.Edit(p))
            {
                _studentsManager.Update((Student) p);
                _UserDialog.ShowInfo("Студент отредактирован", "Менеджер студентов");
            }
            else
            {
                _UserDialog.ShowWarning("Отказ редактирования", "Менеджер студентов");
            }

        }

        #endregion

        #region Command CreateNewStudentCommand - Создание нового студента

        /// <summaryСоздание нового студента</summary>
        private ICommand _CreateNewStudentCommand;

        /// <summary>Создание нового студента</summary>
        public ICommand CreateNewStudentCommand => _CreateNewStudentCommand
            ??= new LambdaCommand(OnCreateNewStudentCommandExecuted, CanCreateNewStudentCommandExecute);

        /// <summary>Проверка возможности выполнения - Создание нового студента</summary>
        private static bool CanCreateNewStudentCommandExecute(object p) => p is Group;

        /// <summary>Логика выполнения - Создание нового студента</summary>
        private void OnCreateNewStudentCommandExecuted(object p)
        {
            var group = (Group) p;

            var student = new Student();

            if (!_UserDialog.Edit(student) || _studentsManager.Create(student, group.Name))
            {
                OnPropertyChanged(nameof(Students));
                return;
            }

            if(_UserDialog.Confirm("Не удалось создать студента, повторить?", "Менеджер студентов"))
                        OnCreateNewStudentCommandExecuted(p);
            
        }

        #endregion

        #endregion

        public StudentManagementViewModel(StudentsManager studentsManager, IUserDialogService UserDialog)
        {
            _studentsManager = studentsManager;
            _UserDialog = UserDialog;
        }
    }
}