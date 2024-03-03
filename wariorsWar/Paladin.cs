namespace WariorsWar
{
    internal class Paladin : Warior
    {
        private readonly int _armor;
        private readonly int _minimalIncomingDamage;

        public Paladin(int health, int damage, string description, string name)
            : base(health, damage, description, name)
        {
            AddDefenceReactions(new[]
            {
                "Тебе не пробить мою броню!",
                "Моя защита все так же крепка!",
                "Это был хороший удар!",
            });
            AddAttackReactions(new[]
            {
                "Боги на моей стороне!",
                "Злу не выстоять в битве со мной!",
                "Я наступаю!",
            });
            _armor = 5;
            _minimalIncomingDamage = 1;
        }

        protected override int ChangeDefence(int damage)
        {
            if (damage - _armor <= 0)
            {
                return _minimalIncomingDamage;
            }
            else
            {
                return damage - _armor;
            }
        }
    }
}
