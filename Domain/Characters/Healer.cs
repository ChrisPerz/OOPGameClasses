public class Healer : Character
{
    private string _evolutionJob = "";
    private int _mana;
    private bool isNewHealer = true;
    public int numberOfPotionsUsed = 0;
    public ClassType ClassType { get; set; } = ClassType.Mana;

    public int Mana
    {
        get => _mana;
        private set
        {
            if (isNewHealer) 
            {
                _mana = value;
                isNewHealer = false;
            }
            //TODO: Add logic to change the value of numberOfPotionsUsed when a potion is used in the game
            if (numberOfPotionsUsed > 4)
            {
                _logger.Log($"{Name} has used too many potions and cannot recover more mana.");
            }
            else
            {
                _mana = value;
                _logger.Log($"{Name} now has {Mana} mana.");
            }
        }
    }

    public Healer(int id, string name, string weapon, int mana)
        : base(id, name, "Healer", weapon)
    {
        if (weapon == "Spellbook")
        {
            _logger.Log("A spellbook is an excellent choice for a healer, you begin with better spells but they are limited to your book.");
        }
        if (weapon == "Staff")
        {
            _logger.Log("A staff is a solid choice for a healer, offering both support and defensive capabilities.");
        }
        _mana = mana;
        Actions.Add(new Attack());
        Actions.Add(new Heal());
        Actions.Add(new Defend());
    }  

    // <summary> Deprecated method, now using IAction interface for actions </summary>
    
    //HERE we use polymorphism to override the Attack method for the Healer class -> A healer attacks with a debuff spell
    // public override void Attack()
    // {
    //     if (mana == 0)
    //     {
    //         _logger.Log($"{Name} the healer has no mana left to cast healing spells!");
    //         return;
    //     }
    //     _logger.Log($"{Name} the healer casts a debuff spell with: {Weapon}!");
    // } 
}