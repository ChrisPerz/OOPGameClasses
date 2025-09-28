// momentary method to aprox observer pattern for potion use
public class DrinkPotionObserver() : IPotionObserver
{
    ILogger _logger;
    public void OnDrinkPotion(Character character, ILogger logger)
    {
        _logger = logger;
        character.numberOfPotionsUsed++;
        _logger.Log($"{character.Name} has used a potion. Total potions used: {character.numberOfPotionsUsed}");
    }
}

// multiple observers: UI potion counter, log potion use, cooldown manager