using System.Collections.Generic;

namespace Hejkal
{
	partial class Search
	{
		private List<SongData> allSongs;

		public List<SongData> FindSongs(string pattern)
		{
			List<SongData> results = new List<SongData>();

			foreach (var song in allSongs)
			{
				if (song.Match(pattern))
					results.Add(song);
			}

			// TODO: remove when testing over
			if (pattern == "test")
				results.Add(new SongData("test", "test", "", ""));

			return results;
		}

		public List<SongData> GetAllSongs() => allSongs;
	}
}
