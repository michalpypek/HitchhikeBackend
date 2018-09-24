using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hitchhike.Models
{
	public class Location
	{
		public string Locality { get; set;}
		public Country Country { get; set; }
		public Continent Continent { get; set; }
	}

	public class Country
	{
		public string Iso { get; set; }
		public string Name { get; set; }
	}

	public class Continent
	{
		public string Code { get;set;}
		public string Name { get; set; }
	}
}