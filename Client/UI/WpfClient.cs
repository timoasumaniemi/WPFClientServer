using Client.Service;
using System;

namespace Client.UI
{
    public class WpfClient
    {
        private readonly IConnectionService _connectionService;
        private readonly IMessageEncrypter _messageEncrypter;

        public WpfClient(IConnectionService connectionService, IMessageEncrypter messageEncrypter)
        {
            _connectionService = connectionService;
            _messageEncrypter = messageEncrypter;
        }

        public void ReceiveMessage()
        {
            var encryptedMessage = _messageEncrypter.EncryptMessage();
            _connectionService.GetString("");
        }
    }
}