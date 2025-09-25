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

    public Character(int id, string name, string characterClass, string weapon, int level = 0)
    {
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
}