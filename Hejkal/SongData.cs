namespace Hejkal
{
	public class SongData
	{
		string number;
		string title;

		public SongData(string _n, string _t)
		{
			number = _n;
			title = _t;
		}

		public string GetNumber() => number;

		public string GetFileName()
		{
			if (number == "test")
				return "Songs/test.png";

			return "Songs/" + number + ".html";
		}

		public bool Match(string key)
		{
			if (number == key)
				return true;

			// TODO: add disregarding diacritics
			if (title.IndexOf(key, System.StringComparison.OrdinalIgnoreCase) >= 0)
				return true;

			return false;
		}

		public override string ToString()
		{
			return number + ": " + title;
		}
	}
}
