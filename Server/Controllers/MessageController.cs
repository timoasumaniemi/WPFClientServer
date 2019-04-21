using Server.Models;
using Server.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        // GET: api/Message
        public IEnumerable<string> Get()
        {
            var messageToReturn = _messageRandomizer.GetNewMessage();

            return new string[] { messageToReturn };
        }

        // GET: api/Message/5
        public string Get(int id)
        {
            return _messageRandomizer.GetNewMessage();
        }

        // POST: api/Message
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Message/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Message/5
        public void Delete(int id)
        {
        }
    }
}
