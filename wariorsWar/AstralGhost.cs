using System;
using System.Collections.Generic;

namespace WariorsWar
{
    internal class AstralGhost : Warior
    {
        private readonly int _incomingDamageDownScale;
        private readonly int _outgoingDamageDownScale;
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
            _incomingDamageDownScale = 2;
            _outgoingDamageDownScale = 4;
            _downscaleChanse = 3;
        }

        protected override int ChangeAttack(int damage)
        {
            if (TryDownScale())
            {
                return damage / _outgoingDamageDownScale;
            }

            return damage;
        }

        protected override int ChangeDefence(int damage)
        {
            return damage / _incomingDamageDownScale;
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
