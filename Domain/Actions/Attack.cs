namespace Domain.Actions
{
    public class Attack : IAction
    {
        private readonly ILogger _logger;
        public Attack(ILogger logger)
        {
            _logger = logger;
        } 
        public void Execute(Character character)
        {
            if(character.classType == EnumClassType.ManaUser)
            {
                character.Mana -= 15;
                if (character.Mana < 0) character.Mana = 0;
                _logger.Log($"{character.Name} used Attack and lost mana!");
                return;
            }
            character.stamina -= 10;
            if (character.stamina < 0) character.stamina = 0;
            _logger.Log($"{character.Name} used Attack and lost stamina!");
        }
    }
}