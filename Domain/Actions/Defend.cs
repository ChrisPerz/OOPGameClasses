namespace Domain.Action
{
    public class Defend : IAction
    {
        private readonly ILogger _logger;
        public Defend(ILogger logger)
        {
            _logger = logger;
        }
        public void Execute(Character character)
        {
            character.shield += 10;
            _logger.Log($"{character.Name} used shield and defend!");
        }
    }
}
