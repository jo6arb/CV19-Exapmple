using System.Collections.Generic;
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

        public StudentManagementViewModel(StudentsManager studentsManager) => _studentsManager = studentsManager;
    }
}