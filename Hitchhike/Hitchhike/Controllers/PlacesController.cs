using Hitchhike.Models;
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
        public async Task<IHttpActionResult> Get()
        {
			string result = await _placesRepository.GetTestPlace();
            return Json(result);
        }

        // GET: api/Places/5

        public async Task<IHttpActionResult> Get(int id)
        {
			var result = await _placesRepository.GetPlace(id);
            return Json(result);
        }

		[HttpGet]
		public async Task<IHttpActionResult> GetByLocation(float lat, float lon, float range = 3000)
		{
			var result = await _placesRepository.GetPlacesFromArea(lat, lon, range);

			return Json(result);
		}

    }
}
