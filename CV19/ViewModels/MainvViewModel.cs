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

        #region Status : string  - Статус программы

        /// <summary>Статус программы</summary>
        private string _status = "Готов!";

        /// <summary>Статус программы</summary>
        public string Status { get => _status ; set => Set(ref _status, value);}

        #endregion
    }
}