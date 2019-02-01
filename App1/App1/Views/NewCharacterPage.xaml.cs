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
	public partial class NewCharacterPage : ContentPage
	{
        public Character Character { get; set; }

		public NewCharacterPage ()
		{
			InitializeComponent ();

            Character = new Character
            {
                Name = "Doug",
                Description = "Description",
                Age = 20,
                Id = Guid.NewGuid().ToString()
            };

            BindingContext = this;
		}

        public async void CreateCharacter_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddCharacter", Character);
            await Navigation.PopAsync();
        }
	}
}