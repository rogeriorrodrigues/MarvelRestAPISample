using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MarvelApp
{
	public partial class MarvelAppPage : ContentPage
	{
		public MarvelAppPage()
		{
			InitializeComponent();
			carregar();
		}

		async Task carregar()
		{
			string sURL = "https://gateway.marvel.com/v1/public/characters?ts={0}&apikey={1}&hash={2}";

			HttpClient client = new HttpClient();

			var uri = new Uri(string.Format(sURL, new object[] { Settings.timestamp , Settings.publicKey, Settings.hash }));

			var response = await client.GetAsync(uri);

			MarvelChars chars = new MarvelChars();

			if (response.IsSuccessStatusCode)
			{
				var contet = await response.Content.ReadAsStringAsync();

				 chars = JsonConvert.DeserializeObject<MarvelChars>(contet);
				lstMarvel.ItemsSource = chars.data.results;


			}
	
		}

		void MarvelItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			if (e == null) return;
			Debug.WriteLine("Persongem: " + e.Item);
			((ListView)sender).SelectedItem = null;

			Navigation.PushModalAsync(new NavigationPage(new PersonagemDetailsPage(((MarvelChars)e.Item).data.results[0])));
		}
	}
}
