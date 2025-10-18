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

        public async Task<GameState> LoadGameStateFromJson()
        {
            
        }
        
        public async Task<bool> SaveGameStateInBinary(GameState state)
        {
            using( FileStream fs = new Filestream(saveFileBinary, FileMode.Create))
            {
                try
                {
                    state.LastSaved = DateTime.Now;
                    BinaryWriter writer = new BinaryWriter(fs);
                    writer.Write(state.PlayerName);
                    writer.Write(state.CharacterLevel);
                    writer.Write(state.health);
                    writer.Write(state.Energy);
                    writer.Write(state.LevelScenario);
                    writer.Write(state.ExperiencePoints);
                    writer.Write(state.LastSaved.ToBinary());
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving game state in Binary: {ex.Message}");
                    return false;
                }
            }
        }
    }
}

