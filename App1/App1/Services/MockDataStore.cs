using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App1.Models;

//using Character = App1.Models.Character;

namespace App1.Services
{
    public class MockDataStore : IDataStore
    {
        private static MockDataStore _instance;

        public static MockDataStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MockDataStore();
                }
                return _instance;
            }
        }

        List<Item> items;
        List<Character> characters;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Ancient Guitar", Description="Dont show it to the priests." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Cask of '43", Description="Draw another goblet." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Spaceship", Description="Perfect for black hole hunting." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Ax", Description="Keep those trees equal." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Honeydew", Description="The eternal brekfast." },
                //new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }

            characters = new List<Character>();
            var mockCharacters = new List<Character>
            {
                new Character{ Id = Guid.NewGuid().ToString(), Name = "Jonas", Description="Brave and sure", Age=40  },
                new Character{ Id = Guid.NewGuid().ToString(), Name = "Roy", Description="What an egghead", Age=30  },
                new Character{ Id = Guid.NewGuid().ToString(), Name = "Thurston", Description="The real wolf of Wall Street", Age=60  },
                new Character{ Id = Guid.NewGuid().ToString(), Name = "Mary Ann", Description="Survivor of Roomis Igloomis", Age=20  }
            };

            foreach(var data in mockCharacters)
            {
                characters.Add(data);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<bool> AddCharacterAsync(Character ch)
        {
            characters.Add(ch);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateCharacterAsync(Character ch)
        {
            var oldItem = characters.FirstOrDefault(arg => arg.Id == ch.Id);
            oldItem.Update(ch);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteCharacterAsync(string id)
        {
            var oldItem = characters.Where((Character arg) => arg.Id == id).FirstOrDefault();
            characters.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Character> GetCharacterAsync(string id)
        {
            return await Task.FromResult(characters.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Character>> GetCharactersAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(characters);
        }
    }
}