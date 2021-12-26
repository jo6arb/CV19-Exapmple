using System;
using System.ComponentModel;
using System.Windows;

namespace CV19.Views.Windows
{

    public partial class StudentEditorWindow : Window
    {

        #region FirstName : String - Имя

        /// <summary>Имя</summary>
        public static readonly DependencyProperty FirstNameProperty =
            DependencyProperty.Register(
                nameof(FirstName),
                typeof(String),
                typeof(StudentEditorWindow),
                new PropertyMetadata(default(String)));

        /// <summary>Имя</summary>
        //[Category("")]
        [Description("$summary$")]
        public String FirstName { get => (String) GetValue(FirstNameProperty); set => SetValue(FirstNameProperty, value); }

        #endregion


        #region LastName : String - Фамилия

        /// <summary>Фамилия</summary>
        public static readonly DependencyProperty LastNameProperty =
            DependencyProperty.Register(
                nameof(LastName),
                typeof(String),
                typeof(StudentEditorWindow),
                new PropertyMetadata(default(String)));

        /// <summary>Фамилия</summary>
        //[Category("")]
        [Description("$summary$")]
        public String LastName { get => (String) GetValue(LastNameProperty); set => SetValue(LastNameProperty, value); }

        #endregion

        #region Patronymic : String - Отчество

        /// <summary>$summary$</summary>
        public static readonly DependencyProperty PatronymicProperty =
            DependencyProperty.Register(
                nameof(Patronymic),
                typeof(String),
                typeof(StudentEditorWindow),
                new PropertyMetadata(default(String)));

        /// <summary>Отчество</summary>
        //[Category("")]
        [Description("Отчество")]
        public String Patronymic { get => (String) GetValue(PatronymicProperty); set => SetValue(PatronymicProperty, value); }

        #endregion

        #region Rating : Double - Рейтинг

        /// <summary>$summary$</summary>
        public static readonly DependencyProperty RatingProperty =
            DependencyProperty.Register(
                nameof(Rating),
                typeof(Double),
                typeof(StudentEditorWindow),
                new PropertyMetadata(default(Double)));

        /// <summary>Рейтинг</summary>
        //[Category("")]
        [Description("Рейтинг")]
        public Double Rating { get => (Double) GetValue(RatingProperty); set => SetValue(RatingProperty, value); }

        #endregion

        #region Birthday : DateTime - Дата рождения

        /// <summary>Дата рождения</summary>
        public static readonly DependencyProperty BirthdayProperty =
            DependencyProperty.Register(
                nameof(Birthday),
                typeof(DateTime),
                typeof(StudentEditorWindow),
                new PropertyMetadata(default(DateTime)));

        /// <summary>Дата рождения</summary>
        //[Category("")]
        [Description("$summary$")]
        public DateTime Birthday { get => (DateTime) GetValue(BirthdayProperty); set => SetValue(BirthdayProperty, value); }

        #endregion
        public StudentEditorWindow()
        {
            InitializeComponent();
        }
    }
}
