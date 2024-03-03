using System;
using System.Collections.Generic;

namespace WariorsWar
{
    internal abstract class Warior
    {
        private readonly string _name;
        private readonly string _description;
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
            _description = description;
            _name = name;
        }

        public bool IsDead { get; private set; }

        public void MakeDamage(Warior warior)
        {
            Console.WriteLine($"{this} нападает");
            Console.WriteLine($"    - {_reactionsToOutgoingDamage[Utility.GetRandomNumber(_reactionsToOutgoingDamage.Count)]}");

            int changedAttack = ChangeAttack(_damage);

            Console.WriteLine($"попытка нанести {changedAttack} урона\n");
            Console.WriteLine($"{warior} защищается");
            warior.TakeDamage(changedAttack);
        }

        public override string ToString()
        {
            return $"{_name}. Очки здоровья = {_health}";
        }

        protected void AddAttackReactions(string[] reactions)
        {
            _reactionsToOutgoingDamage.AddRange(reactions);
        }

        protected virtual void AddDefenceReactions(string[] reactions)
        {
            _reactionsToIncomingDamage.AddRange(reactions);
        }

        protected virtual int ComputeIncomingDamage(int damage)
        {
            return damage;
        }

        protected virtual int ChangeAttack(int damage)
        {
            return damage;
        }

        private void TakeDamage(int damage)
        {
            int changedDamage = ComputeIncomingDamage(damage);
            _health -= changedDamage;

            Console.WriteLine($"    - {_reactionsToIncomingDamage[Utility.GetRandomNumber(_reactionsToIncomingDamage.Count)]}");

            if (_health <= 0)
            {
                _health = 0;
                IsDead = true;
            }

            Console.WriteLine($"Впиталось {changedDamage} урона\n");
        }
    }
}
