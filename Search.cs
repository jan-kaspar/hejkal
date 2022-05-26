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

		public override string ToString()
		{
			return number + ": " + title;
		}

		public bool Match(string key)
		{
			if (number == key)
				return true;

			if (title.IndexOf(key, System.StringComparison.OrdinalIgnoreCase) >= 0)
				return true;

			return false;
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
					results.Add(song.ToString());
			}

			return results.ToArray();
		}
	}
}
