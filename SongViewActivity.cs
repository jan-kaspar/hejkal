using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hejkal
{
	[Activity(Label = "SongViewActivity")]
	public class SongViewActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.SongViewLayout);
			
			string songFile = Intent.Extras.GetString("songFile");
			WebView textView = FindViewById<WebView>(Resource.Id.webView);
			textView.LoadUrl("file:///android_asset/Songs/" + songFile);
		}
	}
}