//TODO: Use serialization to save/load game state in JSON or Binary format
// Implement logger to log save/load operations and errors  

using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Models;

namespace Services
{
    public class SaveGame
    {
        private string saveFileJson = "savegame.json";
        private string saveFileBinary = "savegame.dat";

        public async Task<bool> SaveGameStateInJson(GameState state)
        {
            if (state == null)
            {
                Console.WriteLine("Game state is null. Cannot save.");
                return false;
            }
        
            try
            {
                state.LastSaved = DateTime.Now;
                string jsonGameState = JsonSerializer.Serialize(state);
                await File.WriteAllTextAsync(saveFileJson, jsonGameState);
                Console.WriteLine($"Game state saved successfully to {path}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving game state in JSON: {ex.Message}");
                return false
            }
        }
        
    }
}

