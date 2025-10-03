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
    public ClassType ClassType { get; set; }
    public List<IAction> Actions { get; set; } = new();

    //TODO: potionObserver pattern implementation OR Use Composition to include a PotionSubject instance in the Character class
    // private readonly PotionSubject _potionSubject = new();
    // private readonly List<IPotionObserver> _potionObservers = new List<IPotionObserver>();
    //
    protected readonly ILogger _logger;

    public Character(int id, string name, string characterClass, string weapon, int level = 0, ClassType classType, ILogger logger)
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
        if (string.IsNullOrWhiteSpace(classType.ToString()))
        {
            throw new ArgumentException("Weapon cannot be null or empty.", nameof(weapon));
        }

        Id = id;
        Name = name;
        Level = level;
        CharacterClass = characterClass;
        Weapon = weapon;
        ClassType = classType;
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
    
    //Since I am using a list of actions, I don't need to override this method in each character class just if I want to add specific behavior
    // HERE we have an adventage since actions are separated from characters, we could execute infinite actions without modifying the character class
    protected virtual void performAction(IAction action)
    {
        action.Execute(this);
    }

    public virtual void showActions()
    {
        foreach (var action in Actions)
        {
            _logger.Log($"{Name} can perform the action: {action.Name}");
        }
    }

    // This would be cool to implement in the future
    public void LearnSkill(IActivity skill)
    {
        Skills.Add(skill);
        _logger.Log($"{Name} has learned a new skill: {skill.Name}");
    }
}