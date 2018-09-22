using Hitchhike.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hitchhike.Controllers
{
    public class PlacesController : ApiController
    {
		private PlacesRepository _placesRepository;

		public PlacesController()
		{
			_placesRepository = new PlacesRepository();
		}

		public PlacesController(PlacesRepository placesRepository)
		{
			_placesRepository = placesRepository;
		}

        // GET: api/Places
        public async Task<string> Get()
        {
			string result = await _placesRepository.GetTestPlace();
            return result;
        }

        // GET: api/Places/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Places
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Places/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Places/5
        public void Delete(int id)
        {
        }
    }
}
