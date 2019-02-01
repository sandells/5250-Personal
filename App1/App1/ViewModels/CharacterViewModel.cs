using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
//using System.Collections.Generic;
using Xamarin.Forms;

using App1.Models;
using App1.Views;
using System.Linq;

//using App1.Views.Character;

namespace App1.ViewModels
{
    public class CharacterViewModel : BaseViewModel
    {
        public ObservableCollection<Character> Characters { get; set; }
        public Command LoadCharactersCommand { get; set; }
        private bool _NeedsRefresh;

        public CharacterViewModel()
        {
            Title = "Browse";
            Characters = new ObservableCollection<Character>();
            LoadCharactersCommand = new Command(async () => await ExecuteLoadCharactersCommand());

            MessagingCenter.Subscribe<NewCharacterPage, Character>(this, "AddCharacter", async (obj, character) =>
            {
                var newCharacter = character as Character;
                Characters.Add(newCharacter);
                await DataStore.AddCharacterAsync(newCharacter);
            });

            MessagingCenter.Subscribe<EditCharacterPage, Character>(this, "EditCharacter", async (obj, character) =>
            {
                var newCharacter = character as Character;

                var ch = Characters.FirstOrDefault( arg => arg.Id == newCharacter.Id);
                if (ch == null)
                {
                    return;
                }

                ch.Update(newCharacter);
                await DataStore.UpdateCharacterAsync(ch);

                _NeedsRefresh = true;
            });

            MessagingCenter.Subscribe<DeleteCharacterPage, Character>(this, "DeleteCharacter", async (obj, character) =>
            {
                var newCharacter = character as Character;
                Characters.Remove(newCharacter);
                await DataStore.DeleteCharacterAsync(newCharacter.Id);
            });
        }

        public bool NeedsRefresh()
        {
            if (_NeedsRefresh)
            {
                _NeedsRefresh = false;
                return true;
            }
            return false;
        }

        async Task ExecuteLoadCharactersCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Characters.Clear();
                var characters = await DataStore.GetCharactersAsync(true);
                foreach (var character in characters)
                {
                    Characters.Add(character);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}