/// <summary>
/// Represents a warrior character in the game.
/// </summary>
public class Warrior : Character
{
    public int stamina { get; set; } = 100;

    public Warrior(int id, string name, string weapon)
        : base(id, name, "Warrior", weapon)
    {
        if (weapon == "Tree branch")
        {
            _logger.Log("A tree branch? Really? You might want to consider a real weapon for a warrior.");
        }
        else if (weapon == "Greatsword")
        {
            _logger.Log("Great choice! Greatswords are powerful but require strength to wield effectively.");
        }
        
    }

    public override void Attack()
    {
        if(stamina == 0)
        {
            _logger.Log($"{Name} the warrior is too tired to attack!");
            return;
        }
        _logger.Log($"{Name} the warrior attacks with: {Weapon}!");
        stamina -= 10;
    }
    
}