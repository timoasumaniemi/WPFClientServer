using System.ComponentModel.Composition;

using DevOne.Security.Cryptography.BCrypt;

namespace Client
{
    [Export(typeof(IMessageEncrypter))]
    public class MessageEncrypter : IMessageEncrypter
    {
        public string EncryptMessage(string messageToEncrypt)
        {
            var encryptedMessage = BCryptHelper.HashPassword(messageToEncrypt, BCryptHelper.GenerateSalt());
            return encryptedMessage;
        }
    }
}