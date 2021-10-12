using CV19.ViewModels.Base;

namespace CV19.ViewModels
{
    internal class MainvViewModel : ViewModel
    {
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
    }
}