using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPIDemo.Controllers
{
    [RoutePrefix("api/v1")]
    public class ValuesController : ApiController
    {
        /// <summary>
        /// Gets some Guid values
        /// </summary>
        /// <returns>The Guid values</returns>
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, 
            Type = typeof(IEnumerable<string>))]
        [Route("values")]
        public async Task<IEnumerable<string>> Get()
        {
            var values = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                values.Add(Guid.NewGuid().ToString());
            }

            return values;
        }

        /// <summary>
        /// Get a specific Guid value
        /// </summary>
        /// <param name="id">Identifier for the Guid values</param>
        /// <returns>The requested Guid value</returns>
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, 
            Description = "OK", 
            Type = typeof(IEnumerable<string>))]
        [SwaggerResponse(HttpStatusCode.NotFound, 
            Description = "Guid not found", 
            Type = typeof(IEnumerable<string>))]
        [Route("values/{id}")]
        public async Task<string> Get([FromUri]int id)
        {
            if (id != 2)
            {
                return Guid.NewGuid().ToString();
            }

            return null;   
            
        }

        /// <summary>
        /// Insert a specific Guid value
        /// </summary>
        /// <param name="value">Guid value on string</param>
        /// <returns>The saved Guid value</returns>
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.Created, 
            Description = "Created", 
            Type = typeof(string))]
        [Route("values")]
        public async Task<HttpStatusCode> Post([FromBody]string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                return HttpStatusCode.BadRequest;
            }

            return HttpStatusCode.Created;
        }

        [Obsolete]
        public void Put(int id, [FromBody]string value)
        {
        }

        [Obsolete]
        public void Delete(int id)
        {
        }
    }
}
