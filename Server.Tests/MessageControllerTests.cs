using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Controllers;
using Server.Utils;
using System.Linq;

namespace Server.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetShouldCallMessageServiceGetNewMessage()
        {
            // Arrange
            var messageRandomizer = A.Fake<IMessageRandomizer>();
            var messageController = new MessageController(messageRandomizer);

            // Act
            messageController.Get();

            // Assert
            A.CallTo(() => messageRandomizer.GetNewMessage()).MustHaveHappened();
        }

        [TestMethod]
        public void GetShouldReturnMessageFromRandomizer()
        {
            // Arrange
            var messageRandomizer = A.Fake<IMessageRandomizer>();
            var expectedMessage = "testString";

            A.CallTo(() => messageRandomizer.GetNewMessage()).Returns(expectedMessage);

            var messageController = new MessageController(messageRandomizer);

            // Act
            var actualMessage = messageController.Get().First();

            // Assert
            Assert.AreEqual(actualMessage, expectedMessage);
        }
    }
}
