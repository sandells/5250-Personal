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
	public partial class CharacterPage : ContentPage
	{
        CharacterViewModel viewModel;

		public CharacterPage ()
		{
			InitializeComponent ();

            BindingContext = this.viewModel = new CharacterViewModel();
		}

        async void OnCharacterSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var ch = args.SelectedItem as Character;
            if (ch == null)
                return;

            await Navigation.PushAsync(new CharacterDetailPage(new CharacterDetailViewModel(ch)));

            CharactersListView.SelectedItem = null;
        }

        async void AddCharacter_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewCharacterPage());
        }

        protected override void OnAppearing()
        {
            //base.OnAppearing();

            //if (viewModel.Characters.Count == 0)
              //  viewModel.LoadCharactersCommand.Execute(null);

          
            base.OnAppearing();

            BindingContext = null;

            if (ToolbarItems.Count > 0)
            {
                ToolbarItems.RemoveAt(0);
            }

            InitializeComponent();

            if (viewModel.Characters.Count == 0)
            {
                viewModel.LoadCharactersCommand.Execute(null);
            }
            else if (viewModel.NeedsRefresh())
            {
                viewModel.LoadCharactersCommand.Execute(null);
            }

            BindingContext = viewModel;

        }
    }
    
}