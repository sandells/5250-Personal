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
	public partial class DeleteCharacterPage : ContentPage
	{
        CharacterDetailViewModel viewModel;
        public Character Character { get; set; }

        public DeleteCharacterPage ()
		{
			InitializeComponent ();
		}

        public DeleteCharacterPage(CharacterDetailViewModel viewModel)
        {
            Character = viewModel.Character;

            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public async void DeleteCharacterForReal_Clicked(object sender, EventArgs e)
        {

            MessagingCenter.Send(this, "DeleteCharacter", Character);
            await Navigation.PopToRootAsync();
        }
    }
}