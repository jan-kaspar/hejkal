using System.Diagnostics;

namespace Hejkal;

public partial class MainPage : ContentPage
{
	Search search = new Search();

	public MainPage()
	{
		InitializeComponent();

		Title = "Hejkal";
		VersionLabel.Text = $"version: {AppInfo.Version} ({AppInfo.BuildString})";
	}

	private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
	{
		// run search
		var results = search.FindSongs(SearchBar.Text.Trim());

		// show placeholder/tip again
		SearchBar.Text = "";

		// nothing found
		if (results.Count == 0)
		{
			await DisplayAlert("Chyba", "Žádná píseň nebyla nalezena", "OK");
			return;
		}

		// found exactly one song -> display it directly
		if (results.Count == 1)
		{
			await Navigation.PushAsync(new SongViewPage(results[0]));
			return;
		}

		// multiple results, show list
		await Navigation.PushAsync(new SearchResultsPage(results));
	}

	private async void ShowAllButton_Clicked(object sender, EventArgs e)
	{
		var results = search.GetAllSongs();

		await Navigation.PushAsync(new SearchResultsPage(results));
	}
}

