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

namespace App1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditCharacterPage : ContentPage
	{

        CharacterDetailViewModel viewModel;
        public Character Character { get; set; }

		public EditCharacterPage (CharacterDetailViewModel viewModel)
		{

            Character = viewModel.Character;

			InitializeComponent ();

            BindingContext = this.viewModel = viewModel;
		}

        public async void EditCharacter_Clicked(object sender, EventArgs e)
        {
            
            MessagingCenter.Send(this, "EditCharacter", Character);
            //await Navigation.PopAsync();
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            await Navigation.PushAsync(new CharacterDetailPage(new CharacterDetailViewModel(Character)));
            Navigation.RemovePage(this);
            //await Navigation.PopAsync();
        }
    }
}