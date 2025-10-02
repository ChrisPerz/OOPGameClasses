namespace Domain.Activities
{
    public class Defend : IActivity
    {
        public void Execute(Character character)
        {
            Console.WriteLine($"{character.Name} use shield and defend!");
        }
    }
}
