using System.ComponentModel.Composition;

namespace Server.Utils
{
    [Export(typeof(IMessageRandomizer))]
    public class MessageRandomizer : IMessageRandomizer
    {
        public string GetNewMessage()
        {
            // TODO: Implement string randomizer and return randomized string
            return "random string";
        }
    }
}