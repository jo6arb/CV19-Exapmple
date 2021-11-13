using System;
using System.Collections.Generic;
using System.Text;
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

        public bool _Enabled;

        public bool Enabled
        {
            get => _Enabled;
            set => Set(ref _Enabled, value);
        }

        #endregion

        #region StartCommand

        private ICommand _startCommand;

        public ICommand StartCommand => _startCommand
                                        ?? new LambdaCommand(OnStartCommandExecuted, CanStartCommandExecute);

        private void OnStartCommandExecuted(object p)
        {
            Enabled = true;
        }

        private bool CanStartCommandExecute(object p) => !_Enabled;

        #endregion

        #region StopCommand

        private ICommand _stopCommand;

        public ICommand StopCommand => _stopCommand
                                       ?? new LambdaCommand(OnStopCommandExecute, CanStopCommandExecute);

        private  bool CanStopCommandExecute(object p) => _Enabled;

        private void OnStopCommandExecute(object p)
        {
            Enabled = false;
        }

        #endregion

        public WebServerViewModel(IWebServerService server) => _server = server;
    }
}
