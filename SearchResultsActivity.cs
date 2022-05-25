using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hejkal
{
	[Activity(Label = "Výsledek hledání")]
	[Obsolete]
	public class SearchResultsActivity : ListActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			var searchResults = Intent.Extras.GetStringArrayList("searchResults");
			ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, searchResults);

			ListView.ItemClick += ItemClick;
		}

		void ItemClick(object sender, AdapterView.ItemClickEventArgs args)
		{
			var item = ((TextView)args.View).Text;
			var songNumber = item.Split(':')[0];

			var intent = new Intent(this, typeof(SongViewActivity));
			intent.PutExtra("songFile", songNumber + ".html");
			StartActivity(intent);
		}
	}
}