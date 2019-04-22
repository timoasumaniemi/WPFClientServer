using System.Threading.Tasks;

namespace Client.Service
{
    /// <summary>
    /// Delegates send and receive commands to server.
    /// </summary>
    public interface IConnectionService
    {
        // Gets message from server
        Task<string> GetString();

        // Sends encrypted message to server and receives response
        Task<string> SendMessage(string message);
    }
}