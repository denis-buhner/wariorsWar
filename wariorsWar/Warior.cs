using System;
using System.Collections.Generic;

namespace WariorsWar
{
    internal abstract class Warior
    {
        private int _health;
        private int _damage;

        protected Warior(int health, int damage)
        {
            _health = health;
            _damage = damage;

            MakeDamageReactions = new List<string>()
            {
                { "Съешь это!" },
                { "Получай!" },
            };
            TakeDamageReactions = new List<string>()
            {
                { "Ай!" },
                { "Было больно!" },
                { "Черт!" },
            };

            IsDead = false;
        }

        public List<string> MakeDamageReactions { get; protected set; }

        public List<string> TakeDamageReactions { get; protected set; }

        public bool IsDead { get; private set; }

        public void MakeDamage(Warior warior)
        {
            Console.WriteLine($"{this} нападает");
            Console.WriteLine($"    - {MakeDamageReactions[Utility.GetRandomNumber(MakeDamageReactions.Count)]}");

            int changedOutgoingDamage = ChangeOutgoingDamage(_damage);

            Console.WriteLine($"попытка нанести {changedOutgoingDamage} урона\n");
            Console.WriteLine($"{warior} защищается");
            warior.TakeDamage(changedOutgoingDamage);
        }

        public override string ToString()
        {
            return $"Очки здоровья = {_health}";
        }

        protected virtual int ChangeIncomingDamage(int damage)
        {
            return damage;
        }

        protected virtual int ChangeOutgoingDamage(int damage)
        {
            return damage;
        }

        private void TakeDamage(int damage)
        {
            int changedIncomingDamage = ChangeIncomingDamage(damage);
            _health -= changedIncomingDamage;

            Console.WriteLine($"    - {TakeDamageReactions[Utility.GetRandomNumber(TakeDamageReactions.Count)]}");

            if (_health <= 0)
            {
                _health = 0;
                IsDead = true;
            }

            Console.WriteLine($"Впиталось {changedIncomingDamage} урона\n");
        }
    }
}
