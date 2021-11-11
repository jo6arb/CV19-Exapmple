using System;
using System.ComponentModel;
using System.Windows;

namespace CV19.Components
{

    public partial class GaugenIndicator
    {

        #region ValueProperty

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                nameof(Value),
                typeof(double),
                typeof(GaugenIndicator),
                new PropertyMetadata(default(double),
                    OnValuePropertyChanged,
                    OnCourceValue),
                OnValidateValue
            );
        
        private static bool OnValidateValue(object o) => true;

        private static object OnCourceValue(DependencyObject d, object basevalue)
        {
            var value = (double) basevalue;
            return Math.Max(0, Math.Min(100, value));
        }

        private static void OnValuePropertyChanged(DependencyObject D, DependencyPropertyChangedEventArgs E)
        {
            /*var gaugeIndicator = (GaugenIndicator) D;
            gaugeIndicator.ArrowRotator.Angle = (double) E.NewValue;*/
        }

        public double Value
        {
            get => (double) GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        #endregion

        public GaugenIndicator() => InitializeComponent();
    }
}
