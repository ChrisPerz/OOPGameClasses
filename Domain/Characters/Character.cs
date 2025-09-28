/// <summary>
/// Represents a character in the game.
/// </summary>
public class Character
{
    public int Id {get; set; };
    public string Name { get; set; }
    public readonly int Level { get; set; }
    public string CharacterClass { get; set; }
    public string Weapon { get; set;}
    public int Health { get; set; } = 100;
    public int numberOfPotionsUsed { get; set; } = 0;
    //TODO: potionObserver pattern implementation
    private readonly List<IPotionObserver> _potionObservers = new List<IPotionObserver>();
    protected readonly ILogger _logger;

    public Character(int id, string name, string characterClass, string weapon, int level = 0, ILogger logger)
    {
        _logger = logger;
        // Added validations to ensure data integrity
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));
        }
        if (string.IsNullOrWhiteSpace(characterClass))
        {
            throw new ArgumentException("Character class cannot be null or empty.", nameof(characterClass));
        }
        if (string.IsNullOrWhiteSpace(weapon))
        {
            throw new ArgumentException("Weapon cannot be null or empty.", nameof(weapon));
        }

        Id = id;
        Name = name;
        Level = level;
        CharacterClass = characterClass;
        Weapon = weapon;
    }

    /// <summary>
    /// Executes an attack action.
    /// </summary>

    public virtual void Attack()
    {
        // TODO: Attack logic here
    }

    //HERE we use polymorphism to overload the TakeDamage method for different damage types
    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
        _logger.Log($"{Name} takes {damage} damage. Remaining health: {Health}.");
    }

    public virtual void TakeDamage(int damage, string damageType)
    {
        if (damageType == "Venom")
        {
            ApplyVenomEffect();
        }
        Health -= damage;
        _logger.Log($"{Name} takes {damage} {damageType} damage. Remaining health: {Health}.");
    }

    private void ApplyVenomEffect()
    {
        int venomDuration = 5; // Duration in seconds
        int venomDamage = 5;   // Damage per second
        int elapsedSeconds = 0;

        //TODO: Implement a proper timing mechanism for venom effect in a real game scenario
    }
}