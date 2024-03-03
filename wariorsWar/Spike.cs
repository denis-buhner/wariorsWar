namespace WariorsWar
{
    internal class Spike : Warior
    {
        private readonly int _chargeDownscale;
        private int _chargedDamage;

        public Spike(int health, int damage, string description, string name)
            : base(health, damage, description, name)
        {
            AddDefenceReactions(new[]
            {
                "Я колючий, не так ли?",
                "Это вернётся тебе десятикратно!",
                "Посмотрим, кто будет смеяться последним",
            });
            AddAttackReactions(new[]
            {
                "Шипастый удар!",
                "Возвращаю!",
                "Думал уйдёшь безнаказанным?",
            });

            _chargeDownscale = 2;
        }

        protected override int ChangeAttack(int damage)
        {
            return damage + (_chargedDamage / _chargeDownscale);
        }

        protected override int ChangeDefence(int damage)
        {
            _chargedDamage = damage;
            return base.ChangeDefence(damage);
        }
    }
}
