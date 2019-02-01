using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App1.Models;

namespace App1.Services
{
    public interface IDataStore
    {
        Task<bool> AddItemAsync(Item item);
        Task<bool> UpdateItemAsync(Item item);
        Task<bool> DeleteItemAsync(string id);
        Task<Item> GetItemAsync(string id);
        Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false);

        Task<bool> AddCharacterAsync(Character character);
        Task<bool> UpdateCharacterAsync(Character character);
        Task<bool> DeleteCharacterAsync(string id);
        Task<Character> GetCharacterAsync(string id);
        Task<IEnumerable<Character>> GetCharactersAsync(bool forceRefresh = false);
    }
}
