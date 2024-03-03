using System;
using System.Collections.Generic;

namespace WariorsWar
{
    internal class AstralGhost : Warior
    {
        private readonly int _defenceScale;
        private readonly int _attackScale;
        private readonly int _downscaleChanse;

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
            _downscaleChanse = 3;
        }

        protected override int ChangeAttack(int damage)
        {
            if (TryDownScale())
            {
                return damage / _attackScale;
            }

            return damage;
        }

        protected override int ChangeDefence(int damage)
        {
            return damage / _defenceScale;
        }

        private bool TryDownScale()
        {
            if (Utility.GetRandomNumber(_downscaleChanse) == _downscaleChanse)
            {
                return true;
            }

            return false;
        }
    }
}
