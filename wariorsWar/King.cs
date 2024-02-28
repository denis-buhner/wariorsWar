namespace WariorsWar
{
    internal class King : Warior
    {
        private int _incomingDamage;
        private int _outgoingDamage;

        public King(int health, int damage)
            : base(health, damage)
        {
            TakeDamageReactions.AddRange(new[]
            {
                "Гарррр!",
                "Плак, плак",
                "Хнык...",
            });
            MakeDamageReactions.AddRange(new[]
            {
                "Хихихиха",
                "Хаха",
                "Хохохо",
            });
            _incomingDamage = 1;
            _outgoingDamage = 1;
        }

        public override string ToString()
        {
            return $"Король. {base.ToString()}";
        }

        protected override int ChangeIncomingDamage(int damage)
        {
            return _incomingDamage;
        }

        protected override int ChangeOutgoingDamage(int damage)
        {
            return _outgoingDamage;
        }
    }
}
