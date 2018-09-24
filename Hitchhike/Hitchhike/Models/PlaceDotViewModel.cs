using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hitchhike.Models
{
	public class PlaceDotViewModel
	{
		public int Id { get; set; }
		public float Lat { get; set;}
		public float Lon { get; set; }
		public float Rating { get; set; }
	}
}