using System;
using System.Collections.Generic;

namespace WariorsWar
{
    internal abstract class Warior
    {
        private int _health;
        private int _damage;
        private List<string> _reactionsToOutgoingDamage;
        private List<string> _reactionsToIncomingDamage;

        protected Warior(int health, int damage, string description, string name)
        {
            _health = health;
            _damage = damage;
            _reactionsToIncomingDamage = new List<string>();
            _reactionsToOutgoingDamage = new List<string>();
            IsDead = false;
            Description = description;
            Name = name;
        }

        public bool IsDead { get; private set; }

        public string Description { get; }

        public string Name { get; }

        public void MakeDamage(Warior warior)
        {
            Console.WriteLine($"{this} нападает");
            Console.WriteLine($"    - {_reactionsToOutgoingDamage[Utility.GetRandomNumber(_reactionsToOutgoingDamage.Count)]}");

            int changedOutgoingDamage = ChangeAttack(_damage);

            Console.WriteLine($"попытка нанести {changedOutgoingDamage} урона\n");
            Console.WriteLine($"{warior} защищается");
            warior.TakeDamage(changedOutgoingDamage);
        }

        public override string ToString()
        {
            return $"{Name}. Очки здоровья = {_health}";
        }

        protected void AddAttackReactions(string[] reactions)
        {
            _reactionsToOutgoingDamage.AddRange(reactions);
        }

        protected virtual void AddDefenceReactions(string[] reactions)
        {
            _reactionsToIncomingDamage.AddRange(reactions);
        }

        protected virtual int ChangeDefence(int damage)
        {
            return damage;
        }

        protected virtual int ChangeAttack(int damage)
        {
            return damage;
        }

        private void TakeDamage(int damage)
        {
            int changedIncomingDamage = ChangeDefence(damage);
            _health -= changedIncomingDamage;

            Console.WriteLine($"    - {_reactionsToIncomingDamage[Utility.GetRandomNumber(_reactionsToIncomingDamage.Count)]}");

            if (_health <= 0)
            {
                _health = 0;
                IsDead = true;
            }

            Console.WriteLine($"Впиталось {changedIncomingDamage} урона\n");
        }
    }
}
