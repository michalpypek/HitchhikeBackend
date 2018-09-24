using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hitchhike.Models
{
	public class PlaceHitchWikiModel
	{
		public int Id { get; set; }
		public float Lat { get; set; }
		public float Lon { get; set; }
		public float Elevation { get; set; }
		public float Rating { get; set; }
		public int RatingCount { get; set; }
		public string PlaceName { get; set; }
		public Location Location { get; set; }
		public Dictionary<string, Dictionary<string, string>> description { get; set; }
		public int CommentsCount { get; set; }
		public PlaceComment[] Comments { get; set; }
	}

	public class PlaceComment
	{
		public string Comment { get; set; }
	}
}