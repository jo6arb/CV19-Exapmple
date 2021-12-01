using System.Security.Permissions;
using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace CV19.Infrastructure.Behaviours
{
    class WindowTitleBarBehavior : Behavior<UIElement>
    {
        private Window _window;
        protected override void OnAttached()
        {
            _window = AssociatedObject as Window ?? AssociatedObject
        }

        protected override void OnDetaching()
        {

        }
    }
}