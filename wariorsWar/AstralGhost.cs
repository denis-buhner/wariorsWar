using System;
using System.Collections.Generic;

namespace WariorsWar
{
    internal class AstralGhost : Warior
    {
        private int _incomingDamageDownScale;
        private int _outgoingDamageDownScale;
        private int _downscaleChanse;

        public AstralGhost(int health, int damage)
            : base(health, damage)
        {
            TakeDamageReactions = new List<string>()
            {
                "ьырлп!",
                "брьльп!",
                "льып!",
            };
            MakeDamageReactions = new List<string>()
            {
                "бпрююю!",
                "дрылб!",
                "шмть!",
            };
            _incomingDamageDownScale = 2;
            _outgoingDamageDownScale = 4;
            _downscaleChanse = 3;
        }

        public override string ToString()
        {
            return $"Астральный призрак. {base.ToString()}";
        }

        protected override int ChangeOutgoingDamage(int damage)
        {
            if (TryDownScale())
            {
                return damage / _outgoingDamageDownScale;
            }

            return damage;
        }

        protected override int ChangeIncomingDamage(int damage)
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
