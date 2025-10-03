/// <summary>
/// Represents a Mage character in the game.
/// </summary>
public class Mage : Character
{
    private string _evolutionJob = "";
    private int _mana;
    public int Mana;

    // HERE we use encapsulation to control access to the EvolutionJob property
    public string EvolutionJob 
    { 
        get => _evolutionJob; 
        set 
        {
            if (Level <= 20)
            {
                _logger.Log($"{Name} needs to be at least level 20 to evolve. Current level: {Level}");
                throw new InvalidOperationException("Cannot set EvolutionJob unless Level is greater than 20.");
            }
            _evolutionJob = value;
            _logger.Log($"{Name} has evolved into a {EvolutionJob}!");
        }; 
        
    }

    public Mage(int id, string name, string weapon)
        : base(id, name, "Mage", weapon)
    {
        if (weapon == "Grimoire")
        {
            _logger.Log("A grimoire is an excellent choice for a mage, enhancing spellcasting abilities.");
        }
        if (weapon == "Staff")
        {
            _logger.Log("A staff is a solid choice for a mage, offering both offensive and defensive capabilities.");
        }
        else if (weapon == "Dagger")
        {
            _logger.Log("A dagger? Mages typically rely on their spells rather than close combat.");
        }

        Actions.Add(new Attack());
    }

    // <summary> Deprecated method, now using IAction interface for actions </summary>
    // public override void Attack()
    // {
    //     if (Weapon == "Dagger")
    //     {
    //         _logger.Log($"{Name} the mage tries to attack with a dagger, but it's not very effective!");
    //         return;
    //     } 
    //     if (_mana == 0)
    //     {
    //         _logger.Log($"{Name} the mage has no mana left to cast spells!");
    //         return;
    //     }
    //     _logger.Log($"{Name} the mage casts a spell with: {Weapon}!");
    //     mana -= 10;

    // }
}