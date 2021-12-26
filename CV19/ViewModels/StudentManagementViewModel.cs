using System.Collections.Generic;
using System.IO.Packaging;
using System.Windows.Input;
using CV19.Infrastructure.Commands;
using CV19.Models.Decanat;
using CV19.Services;
using CV19.ViewModels.Base;

namespace CV19.ViewModels
{
    class StudentManagementViewModel : ViewModel
    {
        private readonly StudentsManager _studentsManager;

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
            var student = (Student)p;


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
            var group = (Group)p;
        }

        #endregion

        #endregion

        public StudentManagementViewModel(StudentsManager studentsManager) => _studentsManager = studentsManager;
    }
}