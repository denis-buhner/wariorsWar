namespace WariorsWar
{
    internal class Spike : Warior
    {
        private int _chargedDamage;
        private int _chargeDownscale;

        public Spike(int health, int damage)
            : base(health, damage)
        {
            TakeDamageReactions.AddRange(new[]
            {
                "Я колючий, не так ли?",
                "Это вернётся тебе десятикратно!",
                "Посмотрим, кто будет смеяться последним",
            });
            MakeDamageReactions.AddRange(new[]
            {
                "Шипастый удар!",
                "Возвращаю!",
                "Думал уйдёшь безнаказанным?",
            });

            _chargeDownscale = 2;
        }

        public override string ToString()
        {
            return $"Колючка. {base.ToString()}";
        }

        protected override int ChangeOutgoingDamage(int damage)
        {

            return damage + (_chargedDamage / _chargeDownscale);
        }

        protected override int ChangeIncomingDamage(int damage)
        {
            _chargedDamage = damage;
            return base.ChangeIncomingDamage(damage);
        }
    }
}
