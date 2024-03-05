using System;

namespace WariorsWar
{
    internal class AstralGhost : Warior
    {
        private readonly int _defenceScale;
        private readonly int _attackScale;
        private readonly double _downscaleChanse;

        public AstralGhost(int health, int damage, string description, string name)
            : base(health, damage, description, name)
        {
            AddDefenceReactions(new[]
            {
                "ьырлп!",
                "брьльп!",
                "льып!",
            });
            AddAttackReactions(new[]
            {
                "бпрююю!",
                "дрылб!",
                "шмть!",
            });
            _defenceScale = 2;
            _attackScale = 4;
            _downscaleChanse = 0.3;
        }

        protected override int ComputeOutgoingDamage(int damage)
        {
            if (Utility.CalculateChanse(_downscaleChanse))
            {
                return damage / _attackScale;
            }

            return damage;
        }

        protected override int ComputeIncomingDamage(int damage)
        {
            return damage / _defenceScale;
        }
    }
}
