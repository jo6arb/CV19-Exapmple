using System.Windows;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace CV19.Infrastructure.Behaviours
{
    class WindowTitleBarBehavior : Behavior<UIElement>
    {
        private Window _window;
        protected override void OnAttached()
        {
            _window = AssociatedObject as Window ?? AssociatedObject.FindLogicalParent<Window>();
            AssociatedObject.MouseLeftButtonDown += OnMouseDown;
        }

        protected override void OnDetaching() => AssociatedObject.MouseLeftButtonDown -= OnMouseDown;

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            switch (e.ClickCount)
            {
                case 1:
                    DragMode();
                    break;
                case 2:
                    Maximize();
                    break;
            }
           
        }

        private void DragMode()
        {
            if (!(AssociatedObject.FindVisualRoot() is Window window)) return;
            window.DragMove();
        }

        private void Maximize()
        {
            if (!(AssociatedObject.FindVisualRoot() is Window window)) return;
            window.WindowState = window.WindowState switch
            {
                WindowState.Normal => WindowState.Maximized,
                WindowState.Maximized => WindowState.Normal,
                _ => window.WindowState
            };
        }

        
    }
}