namespace WariorsWar
{
    internal class Wizard : Warior
    {
        private int _manna;
        private int _maxMannaPerRound;

        public Wizard(int health, int damage)
            : base(health, damage)
        {
            TakeDamageReactions.AddRange(new[]
            {
                "Дрянные маглы!",
                "Не трогайте меня!",
                "О нет, моя манна утекает!",
            });
            MakeDamageReactions.AddRange(new[]
            {
                "Получите моей магии!",
                "Your soul is mine!",
                "Получайте маглы!",
            });
            _manna = 100;
            _maxMannaPerRound = 20;
        }

        public override string ToString()
        {
            return $"Маг. {base.ToString()}";
        }

        protected override int ChangeOutgoingDamage(int damage)
        {
            return damage + TryUpscaleDamageByAvaliableManna();
        }

        private int TryUpscaleDamageByAvaliableManna()
        {
            int usedManna = Utility.GetRandomNumber(_maxMannaPerRound);
            int avaliableManna;

            if (_manna - usedManna > 0)
            {
                avaliableManna = usedManna;
            }
            else
            {
                avaliableManna = _manna;
            }

            return avaliableManna;
        }
    }
}
