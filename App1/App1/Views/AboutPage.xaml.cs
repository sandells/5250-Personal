using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        //Button handler for action page button
        async void OnButtonClick(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ActionPage());
        }
    }
}