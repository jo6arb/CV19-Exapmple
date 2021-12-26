using System;
using CV19.Infrastructure.Commands.Base;

namespace CV19.Infrastructure.Commands
{
    public class LambdaCommand : Command
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public LambdaCommand(Action<object> Execute, Func<Object, bool> CanExecute = null)
        {
            _execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _canExecute = CanExecute;
        }

        public override bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        public override void Execute(object parameter)
        {
            if(!CanExecute(parameter)) return;
            _execute(parameter);
        }
    }
}