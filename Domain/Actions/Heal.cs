namespace Domain.Action
{
    public class Heal : IAction
    {
        protected readonly ILogger _logger;
        public Heal(ILogger logger)
        {
            _logger = logger;
        }
        public void Execute(Character character)
        {
            character.Health += 20;
            if (character.Health > 100) character.Health = 100;
            _logger.Log($"{character.Name} used Heal and restored health!");
        }
    }
}