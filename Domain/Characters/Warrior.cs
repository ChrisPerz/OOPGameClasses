/// <summary>
/// Represents a warrior character in the game.
/// </summary>
public class Warrior : Character
{
    public int stamina { get; set; } = 100;
    public int shield { get; set; } = 0;
    public ClassType ClassType { get; set; } = ClassType.StaminaUser;

    //THIS is a mistake, this is not overriding but hiding and this could lead to confusion and bugs - I left the comment here to remember why
    // public List<IAction> Actions { get; set; } = new()
    // {
    //     new Attack(),
    //     new Defend(),
    //     new UsePotionAction()
    // };

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
        Actions.Add(new Attack());
        Actions.Add(new Defend());
    }


}