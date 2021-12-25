using CV19.ViewModels.Base;

namespace CV19.ViewModels
{
    class StudentManagementViewModel : ViewModel
    {
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

    }
}