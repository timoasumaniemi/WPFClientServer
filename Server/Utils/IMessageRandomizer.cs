namespace Server.Utils
{
    /// <summary>
    /// Helper to create a random message between 8 to 32 characters
    /// </summary>
    public interface IMessageRandomizer
    {
        /// <summary>
        /// Get new randomized message
        /// </summary>
        /// <returns></returns>
        string GetNewMessage();
    }
}