namespace WariorsWar
{
    internal class Wizard : Warior
    {
        private readonly int _manna;
        private readonly int _maxMannaPerRound;

        public Wizard(int health, int damage, string description, string name)
            : base(health, damage, description, name)
        {
            AddDefenceReactions(new[]
            {
                "Дрянные маглы!",
                "Не трогайте меня!",
                "О нет, моя манна утекает!",
            });
            AddAttackReactions(new[]
            {
                "Получите моей магии!",
                "Your soul is mine!",
                "Получайте маглы!",
            });
            _manna = 100;
            _maxMannaPerRound = 20;
        }

        protected override int ChangeAttack(int damage)
        {
            return damage + UpscaleDamageByManna();
        }

        private int UpscaleDamageByManna()
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
