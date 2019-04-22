using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Controllers;
using Server.Utils;
using System.Linq;
using System.Web.Http.Results;

namespace Server.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private MessageController _messageController;
        private IMessageRandomizer _messageRandomizer;

        [TestInitialize]
        public void setup()
        {
            _messageRandomizer = A.Fake<IMessageRandomizer>();
            _messageController = new MessageController(_messageRandomizer);

        }

        [TestMethod]
        public void GetShouldCallMessageServiceGetNewMessage()
        {
            // Act
            _messageController.Get();

            // Assert
            A.CallTo(() => _messageRandomizer.GetNewMessage()).MustHaveHappened();
        }

        [TestMethod]
        public void GetShouldReturnMessageFromRandomizer()
        {
            // Arrange
            var expectedMessage = "test";
            A.CallTo(() => _messageRandomizer.GetNewMessage()).Returns(expectedMessage);

            // Act
            var actualMessage = _messageController.Get().First();

            // Assert
            Assert.AreEqual(actualMessage, expectedMessage);
        }

        [TestMethod]
        public void PostShouldReturnGivenStringWithOkResponse()
        {
            // Act
            NegotiatedContentResult<string> response = _messageController.Post("test") as NegotiatedContentResult<string>;

            // Assert
            Assert.AreEqual(response.Content, "test");
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }
    }
}
