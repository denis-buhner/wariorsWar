namespace WariorsWar
{
    internal class King : Warior
    {
        private readonly int _incomingDamage;
        private readonly int _outgoingDamage;

        public King(int health, int damage, string description, string name)
            : base(health, damage, description, name)
        {
            AddDefenceReactions(new[]
            {
                "Гарррр!",
                "Плак, плак",
                "Хнык...",
            });
            AddAttackReactions(new[]
            {
                "Хихихиха",
                "Хаха",
                "Хохохо",
            });
            _incomingDamage = 1;
            _outgoingDamage = 1;
        }

        protected override int ChangeDefence(int damage)
        {
            return _incomingDamage;
        }

        protected override int ChangeAttack(int damage)
        {
            return _outgoingDamage;
        }
    }
}
