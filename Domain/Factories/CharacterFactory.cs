public class CharacterFactory
{
    public Character CreateCharacter(int id, string name, string characterClass, string weapon)
    {
        switch (characterType.ToLower())
        {
            case "warrior":
                return new Warrior { Id = id, Name = name, Weapon = weapon, Level = level, CharacterClass = "Warrior", Health = 150 };
            case "mage":
                return new Mage { Id = id, Name = name, Weapon = weapon, Level = level, CharacterClass = "Mage"};
            case "healer":
                return new Healer { Id = id, Name = name, Weapon = weapon, Level = level, CharacterClass = "Archer", Mana = 80 };
            default:
                throw new ArgumentException("Invalid character type");
        }
    }
}