using System;
using System.Windows;
using CV19.Infrastructure.Commands.Base;
using CV19.Views.Windows;

namespace CV19.Infrastructure.Commands
{
    public class ManageStudentCommand : Command
    {
        private StudentManagementWindow _window;

        public override bool CanExecute(object parameter) => _window == null;

        public override void Execute(object parameter)
        {
            var window = new StudentManagementWindow
            {
                Owner = Application.Current.MainWindow
            };
            _window = window;

            window.Closed += OnWindowClosed;

            window.ShowDialog();
        }

        private void OnWindowClosed(object? sender, EventArgs e)
        {
            ((Window) sender).Closed -= OnWindowClosed;

            _window = null;
        }
    }
}