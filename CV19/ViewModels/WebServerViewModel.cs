using System.Windows.Input;
using CV19.Infrastructure.Commands;
using CV19.Services.Interfaces;
using CV19.ViewModels.Base;

namespace CV19.ViewModels
{
    internal class WebServerViewModel : ViewModel
    {
        private readonly IWebServerService _server;

        #region Enabled
        
        public bool Enabled
        {
            get => _server.Enabled;
            set
            {
                _server.Enabled = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region StartCommand

        private ICommand _startCommand;

        public ICommand StartCommand => _startCommand
                                        ?? new LambdaCommand(OnStartCommandExecuted, CanStartCommandExecute);

        private void OnStartCommandExecuted(object p)
        {
            _server.Start();
            OnPropertyChanged(nameof(Enabled));
        }

        private bool CanStartCommandExecute(object p) => !Enabled;

        #endregion

        #region StopCommand

        private ICommand _stopCommand;

        public ICommand StopCommand => _stopCommand
                                       ?? new LambdaCommand(OnStopCommandExecute, CanStopCommandExecute);

        private  bool CanStopCommandExecute(object p) => Enabled;

        private void OnStopCommandExecute(object p)
        {
            _server.Stop();
            OnPropertyChanged(nameof(Enabled));
        }

        #endregion

        public WebServerViewModel(IWebServerService server) => _server = server;
    }
}
