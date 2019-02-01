using System;

using App1.Models;

namespace App1.ViewModels
{
    public class CharacterDetailViewModel : BaseViewModel
    {
        public Character Character { get; set; }
        public CharacterDetailViewModel(Character character = null)
        {
            Title = character?.Name;
            Character = character;
        }
    }
}
