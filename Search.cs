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
	}

	partial class Search
	{
		private List<SongData> allSongs;

		public string[] FindSongs(string pattern)
		{
			List<string> results = new List<string>();

			foreach (var song in allSongs)
			{
				var song_str = song.ToString();
				if (song_str.Contains(pattern))
					results.Add(song_str);
			}

			return results.ToArray();
		}
	}
}
