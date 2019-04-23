using Client.Service;
using Prism.Commands;
using System;
using System.ComponentModel;
using System.ComponentModel.Composition;

namespace Client.UI
{
    [Export(typeof(IWpfClient))]
    public class WpfClient : IWpfClient, INotifyPropertyChanged
    {
        private readonly IConnectionService _connectionService;

        private readonly IMessageEncrypter _messageEncrypter;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Status { get; private set; }

        public DelegateCommand ReceiveMessage { get; private set; }

        [ImportingConstructor]
        public WpfClient(IConnectionService connectionService, IMessageEncrypter messageEncrypter)
        {
            _connectionService = connectionService;
            _messageEncrypter = messageEncrypter;
            ReceiveMessage = new DelegateCommand(OnReceiveMessage);
        }

        private async void OnReceiveMessage()
        {
            try
            {
                var message = await _connectionService.GetString();

                var encryptedMessage = _messageEncrypter.EncryptMessage(message);

                var response = await _connectionService.SendMessage(encryptedMessage);

                Status = response;
                OnPropertyChanged("Status");
            }
            catch ( Exception ex )
            {
                Console.Write($"Receive Message failed: { ex.Message }");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}