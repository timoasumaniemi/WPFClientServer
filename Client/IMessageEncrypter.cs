namespace Client
{
    public interface IMessageEncrypter
    {
        /// <summary>
        /// Returns given message encrypted
        /// </summary>
        /// <returns></returns>
        string EncryptMessage();
    }
}