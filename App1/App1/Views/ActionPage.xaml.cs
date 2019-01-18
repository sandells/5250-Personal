using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ActionPage : ContentPage
	{
		public ActionPage ()
		{
			InitializeComponent ();
		}

        //Button handler for character page button
        async void OnCharClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CharacterPage());
        }

        //Button handler for score page button
        async void OnScoreClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ScorePage());
        }

        //Button handler for items page button
        async void OnItemsClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ItemsPage());
        }
    }
}