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
        public void ClickReceiveMessageShouldCallGetStringFromServer()
        {
            // Act
            _client.ReceiveMessage.Execute();

            // Assert
            A.CallTo(() => _connectionService.GetString()).MustHaveHappened();
        }

        [Test]
        public void ClickReceiveMessageShouldCallEncryptMessage()
        {
            // Act
            _client.ReceiveMessage.Execute();

            // Assert
            A.CallTo(() => _messageEncrypter.EncryptMessage(A<string>.Ignored)).MustHaveHappened();
        }

        [Test]
        public void ClickReceiveMessageShouldCallSendMessageWithStringReceivedFromEncrypter()
        {
            // Arrange
            var expectedMessage = "encrypted";
            A.CallTo(() => _messageEncrypter.EncryptMessage(A<string>.Ignored)).Returns(expectedMessage);

            // Act
            _client.ReceiveMessage.Execute();

            // Assert
            A.CallTo(() => _connectionService.SendMessage(expectedMessage)).MustHaveHappened();
        }
    }
}