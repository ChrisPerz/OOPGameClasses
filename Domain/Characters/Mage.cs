/// <summary>
/// Represents a Mage character in the game.
/// </summary>
public class Mage : Character
{
    private string _evolutionJob = "";

    // HERE we use encapsulation to control access to the EvolutionJob property
    public string EvolutionJob 
    { 
        get => _evolutionJob; 
        set 
        {
            if (Level <= 20)
            {
                 console.WriteLine($"{Name} needs to be at least level 20 to evolve. Current level: {Level}");
                throw new InvalidOperationException("Cannot set EvolutionJob unless Level is greater than 20.");
            }
            _evolutionJob = value;
            Console.WriteLine($"{Name} has evolved into a {EvolutionJob}!");
        }; 
        
    }

    public Mage(int id, string name, string weapon)
        : base(id, name, "Mage", weapon)
    {
        if (weapon == "Grimoire")
        {
            Console.WriteLine("A grimoire is an excellent choice for a mage, enhancing spellcasting abilities.");
        }
        if (weapon == "Staff")
        {
            Console.WriteLine("A staff is a solid choice for a mage, offering both offensive and defensive capabilities.");
        }
        else if (weapon == "Dagger")
        {
            Console.WriteLine("A dagger? Mages typically rely on their spells rather than close combat.");
        }
    }
    public override void Attack()
    {
        if (Weapon == "Dagger")
        {
            Console.WriteLine($"{Name} the mage tries to attack with a dagger, but it's not very effective!");
            return;
        } 
        Console.WriteLine($"{Name} the mage casts a spell with: {Weapon}!");

    }
}