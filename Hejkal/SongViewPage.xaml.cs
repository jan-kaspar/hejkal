namespace Hejkal;

public partial class SongViewPage : ContentPage
{
	public SongViewPage(SongData song)
	{
		InitializeComponent();

		Title = @"Píseň " + song.GetNumber();

		SongWebView.Source = song.GetFileName();
	}
}