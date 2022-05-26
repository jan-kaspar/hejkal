using System.Collections.Generic;

namespace Hejkal
{
	struct SongData
	{
		string number;
		string title;

		public SongData(string _n, string _t)
		{
			number = _n;
			title = _t;
		}

		public bool Match(string key)
		{
			if (number == key)
				return true;

			if (title.IndexOf(key, System.StringComparison.OrdinalIgnoreCase) >= 0)
				return true;

			return false;
		}

		public string PackToString()
		{
			return number + ": " + title;
		}

		public static string PackedStringToFileName(string packedString)
		{
			return packedString.Split(':')[0];
		}
	}

	partial class Search
	{
		private List<SongData> allSongs;

		public string[] FindSongs(string pattern)
		{
			List<string> results = new List<string>();

			foreach (var song in allSongs)
			{
				if (song.Match(pattern))
					results.Add(song.PackToString());
			}

			return results.ToArray();
		}
	}
}
