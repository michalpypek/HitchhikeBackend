using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hitchhike.Models
{
	public class PlaceViewModel
	{
		public int Id { get; set;}
		public float Lat { get; set; }
		public float Lon { get; set; }
		public float Elevation { get;set;}
		public float Rating { get; set; }
		public int RatingCount { get; set; }
		public Location Location { get; set; }
		public Dictionary<string, string> LanguageToDescription { get; set; }
		public PlaceComment[] Comments { get; set; }

		public PlaceViewModel(PlaceHitchWikiModel wikiModel)
		{
			Id = wikiModel.Id;
			Lat = wikiModel.Lat;
			Lon = wikiModel.Lon;
			Elevation = wikiModel.Elevation;
			Rating = wikiModel.Rating;
			RatingCount = wikiModel.RatingCount;
			Location = wikiModel.Location;

			LanguageToDescription = new Dictionary<string, string>();
			if (wikiModel.description != null)
			{
				foreach (var kvPair in wikiModel.description)
				{
					LanguageToDescription[kvPair.Key] = kvPair.Value["description"];
				}
			}

			Comments = wikiModel.Comments;

		}


	}
}