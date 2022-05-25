﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace Hejkal
{
    [Activity(Label = "@string/app_name", Icon = "@drawable/icon", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
		EditText selectionText;
		Button searchButton;
		TextView versionTextView;
		
		Search search = new Search();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

			selectionText = FindViewById<EditText>(Resource.Id.SelectionText);
			searchButton = FindViewById<Button>(Resource.Id.SearchButton);
			versionTextView = FindViewById<TextView>(Resource.Id.VersionTextView);

			searchButton.Click += SearchButton_Click;

			versionTextView.Text = "verze " + GetString(Resource.String.version);
        }
		
		private void SearchButton_Click(object sender, object e)
		{
			var pattern = new string(selectionText.Text);

			// reset text before next search
			selectionText.Text = "";

			if (pattern == "")
			{
				Toast.MakeText(Application, "Hledaný výraz nesmí být prázdný.", ToastLength.Long).Show();
				return;
			}

			var results = search.FindSongs(pattern);
			if (results.Length == 0)
			{
				Toast.MakeText(Application, "Nic nebylo nalezeno.", ToastLength.Long).Show();
				return;
			}

			var intent = new Intent(this, typeof(SearchResultsActivity));
			intent.PutStringArrayListExtra("searchResults", results);
			StartActivity(intent);
		}

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}