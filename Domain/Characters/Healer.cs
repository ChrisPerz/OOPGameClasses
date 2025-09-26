public class Healer : Character
{
    private string _evolutionJob = "";
    private int _mana;
    private bool isNewHealer = true;
    public int numberOfPotionsUsed = 0;

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
                Console.WriteLine($"{Name} has used too many potions and cannot recover more mana.");
            }
            else
            {
                _mana = value;
                Console.WriteLine($"{Name} now has {Mana} mana.");
            }
        }
    }

    public Healer(int id, string name, string weapon, int mana)
        : base(id, name, "Healer", weapon)
    {
        if (weapon == "Spellbook")
        {
            Console.WriteLine("A spellbook is an excellent choice for a healer, you begin with better spells but they are limited to your book.");
        }
        if (weapon == "Staff")
        {
            Console.WriteLine("A staff is a solid choice for a healer, offering both support and defensive capabilities.");
        }
        _mana = mana;
    }  

    //HERE we use polymorphism to override the Attack method for the Healer class -> A healer attacks with a debuff spell
    public override void Attack()
    {
        if (mana == 0)
        {
            Console.WriteLine($"{Name} the healer has no mana left to cast healing spells!");
            return;
        }
        Console.WriteLine($"{Name} the healer casts a debuff spell with: {Weapon}!");
    } 
}