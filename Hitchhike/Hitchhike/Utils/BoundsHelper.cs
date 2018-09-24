using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Hitchhike.Utils
{
	public static class BoundsHelper
	{
		public const float METER = 0.00001f;


		public static string GetBounds(float lat, float lon, float range)
		{
			CheckLatitude(ref lat);
			CheckLongitude(ref lon);

			float radius = range * METER;

			float minLatitude = lat - radius;
			float maxLatitude = lat + radius;
			CheckLatitude(ref minLatitude);
			CheckLatitude(ref maxLatitude);

			float minLongitude = lon - radius;
			float maxLongitude = lon + radius;

			CheckLongitude(ref minLongitude);
			CheckLongitude(ref maxLongitude);

			return string.Format("?bounds={0},{1},{2},{3}", minLatitude.ToString(CultureInfo.InvariantCulture), maxLatitude.ToString(CultureInfo.InvariantCulture), minLongitude.ToString(CultureInfo.InvariantCulture), maxLongitude.ToString(CultureInfo.InvariantCulture));
		}


		public static void CheckLatitude (ref float lat)
		{
			if( lat < -90f)
			{
				lat = 90f + (lat + 90f);
			}

			else if (lat > 90f)
			{
				lat = -90f - (90f - lat);
			}
		}

		public static void CheckLongitude (ref float lon)
		{
			if (lon < -180f)
			{
				lon = 180f + (lon + 180f);
			}

			else if (lon > 180f)
			{
				lon = -180f - (180f - lon);
			}
		}
	}
}