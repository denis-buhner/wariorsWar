namespace WariorsWar
{
    internal class Paladin : Warior
    {
        private int _armor;
        private int _minimalIncomingDamage;

        public Paladin(int health, int damage)
            : base(health, damage)
        {
            TakeDamageReactions.AddRange(new[]
            {
                "Тебе не пробить мою броню!",
                "Моя защита все так же крепка!",
                "Это был хороший удар!",
            });
            MakeDamageReactions.AddRange(new[]
            {
                "Боги на моей стороне!",
                "Злу не выстоять в битве со мной!",
                "Я наступаю!",
            });
            _armor = 5;
            _minimalIncomingDamage = 1;
        }

        public override string ToString()
        {
            return $"Паладин. {base.ToString()}";
        }

        protected override int ChangeIncomingDamage(int damage)
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
