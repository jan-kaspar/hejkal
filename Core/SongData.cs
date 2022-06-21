namespace Hejkal
{
	public class SongData
	{
		string number;
		string title;
		string author;
		string source;

		public SongData(string _n, string _t, string _a, string _s)
		{
			number = _n;
			title = _t;
			author = _a;
			source = _s;
		}

		public string GetNumber() => number;
		public string GetTitle() => title;
		public string GetAuthor() => author;
		public string GetSource() => source;

		public string GetFileName()
		{
			if (number == "test")
				return "Songs/test.png";

			return "Songs/" + number + ".html";
		}

		private static bool IsMatch(string whereToSearch, string whatToSearch)
		{
			// TODO: ignore diacritics
			return whereToSearch.IndexOf(whatToSearch, StringComparison.OrdinalIgnoreCase) >= 0;
		}

		// TODO: move to search ??
		public bool Match(string key)
		{
			if (number == key)
				return true;

			if (IsMatch(title, key))
				return true;

			if (IsMatch(author, key))
				return true;

			if (IsMatch(source, key))
				return true;

			return false;
		}

		public override string ToString()
		{
			string s = number + ": " + title;
			if (author != "")
				s += $" ({author})";
			if (source != "")
				s += $" [{source}]";

			return s;
		}
	}
}
