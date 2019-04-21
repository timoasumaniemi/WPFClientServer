using Client.UI;
using Client.Service;
using FakeItEasy;
using NUnit.Framework;
using Client;

namespace Tests
{
    public class Tests
    {
        private IConnectionService _connectionService;
        private IMessageEncrypter _messageEncrypter;
        private WpfClient _client;

        [SetUp]
        public void Setup()
        {
            _connectionService = A.Fake<IConnectionService>();
            _messageEncrypter = A.Fake<IMessageEncrypter>();
            _client = new WpfClient(_connectionService, _messageEncrypter);
        }

        [Test]
        public void ClickReceiveMessageShouldCallEncryptMessage()
        {
            // Arrange
            _client.ReceiveMessage();

            // Assert
            A.CallTo(() => _messageEncrypter.EncryptMessage()).MustHaveHappened();
        }
        
        [Test]
        public void ClickReceiveMessageShouldCallGetStringFromServer()
        {
            // Arrange
            _client.ReceiveMessage();

            // Assert
            A.CallTo(() => _connectionService.GetString(A<string>.Ignored)).MustHaveHappened();
        }

    }
}