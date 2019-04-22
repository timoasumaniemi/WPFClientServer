
using Server.Utils;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Net;
using System.Web.Http;

namespace Server.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MessageController : ApiController
    {
        private IMessageRandomizer _messageRandomizer;


        [ImportingConstructor]
        public MessageController(IMessageRandomizer messageRandomizer) : base()
        {
            _messageRandomizer = messageRandomizer;
        }

        // GET: api/message
        [Route("api/message")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var messageToReturn = _messageRandomizer.GetNewMessage();

            return new string[] { messageToReturn };
        }


        // POST: sendmessage
        [Route("sendmessage")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] string message)
        {
            //TODO: Implement message encryption check, if ok return it, if not ok return error code
            return Content(HttpStatusCode.OK, message);
        }
    }
}
