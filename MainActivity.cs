using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System.Collections.Generic;

namespace Hejkal
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
		Search search = new Search();

		static readonly List<string> searchResults = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

			EditText selectionText = FindViewById<EditText>(Resource.Id.SelectionText);
			Button searchButton = FindViewById<Button>(Resource.Id.SearchButton);

			searchButton.Click += (sender, e) =>
			{
				var pattern = selectionText.Text;

				if (pattern == "")
				{
					Toast.MakeText(Application, "Hledaný výraz nesmí být prázdný.", ToastLength.Long).Show();
					return;
				}

				var intent = new Intent(this, typeof(SearchResultsActivity));
				intent.PutStringArrayListExtra("searchResults", search.FindSongs(selectionText.Text));
				StartActivity(intent);

				// reset text before next search
				selectionText.Text = "";
			};
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}