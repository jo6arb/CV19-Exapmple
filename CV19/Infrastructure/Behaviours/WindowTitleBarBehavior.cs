using System.Security.Permissions;
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
           if(e.ClickCount > 1) return;
           if (!(AssociatedObject.FindVisualRoot() is Window window)) return;
           window.DragMove();
        }

        
    }
}