using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App1.Models;
using App1.Views;
using App1.ViewModels;

//using App1.Views.Characters;

namespace App1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CharacterDetailPage : ContentPage
	{
        CharacterDetailViewModel viewModel;

		public CharacterDetailPage ()
		{
			InitializeComponent ();
		}

        public CharacterDetailPage(CharacterDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void EditCharacter_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditCharacterPage(viewModel));
        }

        async void DeleteCharacter_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteCharacterPage(viewModel));
        }

        
    }
}