using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Controllers;
using System.Linq;

namespace Server.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetShouldReturnDefaultMessage()
        {
            // Arrange
            var messageController = new MessageController();

            // Act
            var actualMessage = messageController.Get();

            // Assert
            Assert.AreEqual(actualMessage.First(), "default message");
            
        }
    }
}
