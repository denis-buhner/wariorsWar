using System;
using System.Collections.Generic;

namespace WariorsWar
{
    internal class Game
    {
        private List<UnitFactory> _unitFactorys;

        public Game()
        {
            _unitFactorys = new List<UnitFactory>()
            {
                new PaladinFactory(),
                new AstralGhostFactory(),
                new KingFactory(),
                new WizardFactory(),
                new SpikeFactory(),
            };
        }

        public void Play()
        {
            const string PlayCommand = "1";
            const string ExitCommand = "2";

            bool isPlay = true;

            Console.WriteLine(
                "После нажатия любой клавиши начнётся игра. Краткое описание:\n" +
                "Сначала выбирите 2 бойцов, дополнительно ничего вводить не надо, все бойцы автоматически настроятся.\n" +
                "Наблюдайте за битвой.\n" +
                "Эксперементируйте с сочитанием бойцов, чтобы узнать, кто сильнее.\n");

            Console.Clear();

            while (isPlay)
            {
                Console.WriteLine(
                    $"{PlayCommand} - играть.\n" +
                    $"{ExitCommand} - выйти.");
                switch (Console.ReadLine())
                {
                    case PlayCommand:
                        ManageFight();
                        break;
                    case ExitCommand:
                        isPlay = false;
                        break;
                    default:
                        Console.WriteLine("Не верная комманда");
                        break;
                }
            }
        }

        private void ManageFight()
        {
            Warior warior1 = ChoseWarior();
            Warior warior2 = ChoseWarior();

            Fight(warior1, warior2);
            GetLosingWarior(warior1, warior2);
        }

        private Warior ChoseWarior()
        {
            Warior warior = null;

            while (warior == null)
            {
                for (int i = 0; i < _unitFactorys.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {_unitFactorys[i].UnitName}");
                }

                if (int.TryParse(Console.ReadLine(), out int chosenCommand))
                {
                    if (_unitFactorys.Count > chosenCommand - 1 && chosenCommand - 1 >= 0)
                    {
                        warior = _unitFactorys[chosenCommand - 1].CreateWarior();
                    }
                }
            }

            return warior;
        }

        private void Fight(Warior firstWarior, Warior secondWarior)
        {
            while (firstWarior.IsDead == false && secondWarior.IsDead == false)
            {
                firstWarior.MakeDamage(secondWarior);
                if (secondWarior.IsDead == false)
                {
                    secondWarior.MakeDamage(firstWarior);
                }
            }
        }

        private void GetLosingWarior(Warior firstWarior, Warior secondWarior)
        {
            if (firstWarior.IsDead)
            {
                Console.WriteLine($"победа за {secondWarior} (2 боец)");
            }
            else
            {
                Console.WriteLine($"победа за {firstWarior} (1 боец)");
            }
        }
    }
}
