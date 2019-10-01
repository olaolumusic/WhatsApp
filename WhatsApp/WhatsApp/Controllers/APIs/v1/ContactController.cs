using System.Collections.Generic;
using System.Web.Http;

namespace WhatsApp.Controllers.APIs.v1
{
    public class ContactController : ApiController
    {
        // GET: api/Payments
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Payments/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Payments
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Payments/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Payments/5
        public void Delete(int id)
        {
        }
    }
}
