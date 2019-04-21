using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers
{
    public class MessageController : ApiController
    {
        private Message _message = new Message { Content = "default message" };

        public string Message => _message.Content;

        // GET: api/Message
        public IEnumerable<string> Get()
        {
            return new string[] { Message };
        }

        // GET: api/Message/5
        public string Get(int id)
        {
            return Message;
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
