using Hitchhike.Models;
using Hitchhike.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace Hitchhike.Services
{

	public class PlacesRepository
	{
		public const string hitchWikiURI = "http://hitchwiki.org/maps/api/";

		public async Task<string> GetTestPlace()
		{
			Task<string> getPlaceTask = HttpHelper.GetAsync(hitchWikiURI + "?place=1770");
			try
			{
				string result = await getPlaceTask;
				return result;
			}

			catch (WebException error)
			{

				return "An error has occured " + error.Status;
			}
		}

		public async Task<PlaceViewModel> GetPlace(int id)
		{
			Task<string> getPlaceTask = HttpHelper.GetAsync(hitchWikiURI + "?place=" + id);
			string result = await getPlaceTask;

			PlaceViewModel toReturn = null;

			if(!string.IsNullOrEmpty(result))
				toReturn = Newtonsoft.Json.JsonConvert.DeserializeObject<PlaceViewModel>(result);
			return toReturn;
		}

		public async Task<PlaceViewModel> GetPlaceDot(int id)
		{
			Task<string> getPlaceTask = HttpHelper.GetAsync(string.Format("{0}?place={1}&dot", hitchWikiURI, id));
			string result = await getPlaceTask;

			PlaceViewModel toReturn = null;

			if (!string.IsNullOrEmpty(result))
				toReturn = Newtonsoft.Json.JsonConvert.DeserializeObject<PlaceViewModel>(result);
			return toReturn;
		}

		public async Task<IEnumerable<PlaceViewModel>> GetPlacesFromArea(float lat, float lon, float range)
		{
			string url = BoundsHelper.GetBounds(lat, lon, range);

			Task<string> getPlaceTask = HttpHelper.GetAsync(hitchWikiURI + url);
			string result = await getPlaceTask;

			IEnumerable<PlaceViewModel> toReturn = new List<PlaceViewModel>();

			if (!string.IsNullOrEmpty(result))
				toReturn = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<PlaceViewModel>>(result);
			return toReturn;
		}

		public async Task<IEnumerable<PlaceViewModel>> GetPlacesFromCity(string cityName)
		{
			Task<string> getPlaceTask = HttpHelper.GetAsync(string.Format("{0}?city={1}", hitchWikiURI, cityName));
			string result = await getPlaceTask;

			IEnumerable<PlaceViewModel> toReturn = new List<PlaceViewModel>();

			if (!string.IsNullOrEmpty(result))
				toReturn = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<PlaceViewModel>>(result);
			return toReturn;
		}

		public async Task<IEnumerable<PlaceViewModel>> GetPlacesFromCountry(string countryCode)
		{
			Task<string> getPlaceTask = HttpHelper.GetAsync(string.Format("{0}?country={1}", hitchWikiURI, countryCode));
			string result = await getPlaceTask;

			IEnumerable<PlaceViewModel> toReturn = new List<PlaceViewModel>();

			if (!string.IsNullOrEmpty(result))
				toReturn = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<PlaceViewModel>>(result);
			return toReturn;
		}

		public async Task<IEnumerable<PlaceViewModel>> GetPlacesFromContinent(string continentCode)
		{
			Task<string> getPlaceTask = HttpHelper.GetAsync(string.Format("{0}?continent={1}", hitchWikiURI, continentCode));
			string result = await getPlaceTask;

			IEnumerable<PlaceViewModel> toReturn = new List<PlaceViewModel>();

			if (!string.IsNullOrEmpty(result))
				toReturn = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<PlaceViewModel>>(result);
			return toReturn;
		}
	}
}