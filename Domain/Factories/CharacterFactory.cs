public class CharacterFactory
{
    // This factory let me add new characters and new fields easily without modifying each character class ej: adding a new field "ClassType" to differentiate between ManaUser and StaminaUser
    // All centralized in one place
    public Character CreateCharacter(int id, string name, string characterClass, string weapon, ClassType classType)
    {
        switch (characterType.ToLower())
        {
            case "warrior":
                return new Warrior { Id = id, Name = name, Weapon = weapon, Level = level, CharacterClass = "Warrior", Health = 150, classType = ClassType.StaminaUser };
            case "mage":
                return new Mage { Id = id, Name = name, Weapon = weapon, Level = level, CharacterClass = "Mage", classType = ClassType.ManaUser};
            case "healer":
                return new Healer { Id = id, Name = name, Weapon = weapon, Level = level, CharacterClass = "Archer", Mana = 80, , classType = ClassType.ManaUser };
            default:
                throw new ArgumentException("Invalid character type");
        }
    }
}