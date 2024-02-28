using System;
using System.Collections.Generic;

namespace WariorsWar
{
    internal class Game
    {
        private UnitFactory _unitFactory;
        private List<Warior> _wariorsList;

        public Game()
        {
            _wariorsList = new List<Warior>();
            _unitFactory = new UnitFactory();
            _unitFactory.RegisterClass(1, () => new Paladin(100, 10));
            _unitFactory.RegisterClass(2, () => new AstralGhost(100, 10));
            _unitFactory.RegisterClass(3, () => new King(100, 1));
            _unitFactory.RegisterClass(4, () => new Wizard(75, 15));
            _unitFactory.RegisterClass(5, () => new Spike(100, 10));
        }

        public void Play()
        {
            const string PlayCommand = "1";
            const string ExitCommand = "2";

            bool isPlay = true;

            Console.WriteLine("После нажатия любой клавиши начнётся игра. Краткое описание:\n" +
                "Сначала выбирите 2 бойцов, дополнительно ничего вводить не надо, все бойцы автоматически настроятся.\n" +
                "Наблюдайте за битвой.\n" +
                "Эксперементируйте с сочитанием бойцов, чтобы узнать, кто сильнее.\n" +
                "Описание бойцов:\n" +
                "   Паладин - обладает внушительной броней и большим запасом здоровья, стабильно наносит небольшой урон.\n" +
                "   Астральный призрак - Способен игнорировать часть урона, но с некоторым шансом его урон также будет снижен\n" +
                "   Король - не серьезный противник. Получает и наносит 1 еденицу урона. Хихихиха\n" +
                "   Волшебник - имеет скромный запас здоровья, но большой урон. способен увеличивать свой урон за счет манны.\n" +
                "   Колючка - нанесенный ему урон частично добавляется к его основному.");

            Console.ReadKey(true);
            Console.Clear();

            while (isPlay)
            {
                Console.WriteLine($"{PlayCommand} - играть.\n" +
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
            const string DeleteWariorCommand = "1";
            const string DontDeleteWariorCommand = "2";

            int firstWighterIndex = 0;
            int secondWighterIndex = 1;

            while (_wariorsList.Count < 2)
            {
                Warior warior = TryChoseWarior();
                _wariorsList.Add(warior);
            }

            Warior losingWarior = TryGetLosingWarior(_wariorsList[firstWighterIndex], _wariorsList[secondWighterIndex]);
            _wariorsList.Remove(losingWarior);

            Console.WriteLine("Мертвый персонаж удалён. Удалить живого?\n" +
                $"{DeleteWariorCommand} - да\n" +
                $"{DontDeleteWariorCommand} - нет");

            switch (Console.ReadLine())
            {
                case DeleteWariorCommand:
                    _wariorsList.Clear();
                    break;
                case DontDeleteWariorCommand:
                    break;
                default:
                    Console.WriteLine("Нет такой опции.");
                    break;
            }
        }

        private Warior TryChoseWarior()
        {
            const string ChosePaladinCommand = "1";
            const string ChoseAstralGhostCommand = "2";
            const string ChoseKingCommand = "3";
            const string ChoseWizardCommand = "4";
            const string ChoseSpikeCommand = "5";

            int paladinIndex = 1;
            int astralGhostIndex = 2;
            int kingIndex = 3;
            int wizardIndex = 4;
            int spikeIndex = 5;
            Warior chosenWarior = null;

            while (chosenWarior == null)
            {
                Console.WriteLine("Выберите бойца\n" +
                $"{ChosePaladinCommand} - Паладин\n" +
                $"{ChoseAstralGhostCommand} - Астральный призрак\n" +
                $"{ChoseKingCommand} - Король\n" +
                $"{ChoseWizardCommand} - Волшебник\n" +
                $"{ChoseSpikeCommand} - Колючка");
                switch (Console.ReadLine())
                {
                    case ChosePaladinCommand:
                        chosenWarior = _unitFactory.CreateWarior(paladinIndex);
                        break;
                    case ChoseAstralGhostCommand:
                        chosenWarior = _unitFactory.CreateWarior(astralGhostIndex);
                        break;
                    case ChoseKingCommand:
                        chosenWarior = _unitFactory.CreateWarior(kingIndex);
                        break;
                    case ChoseWizardCommand:
                        chosenWarior = _unitFactory.CreateWarior(wizardIndex);
                        break;
                    case ChoseSpikeCommand:
                        chosenWarior = _unitFactory.CreateWarior(spikeIndex);
                        break;
                    default:
                        Console.WriteLine("не верный индекс");
                        break;
                }
            }

            return chosenWarior;
        }

        private Warior TryGetLosingWarior(Warior firstWarior, Warior secondWarior)
        {
            while (firstWarior.IsDead == false && secondWarior.IsDead == false)
            {
                firstWarior.MakeDamage(secondWarior);
                if (secondWarior.IsDead == false)
                {
                    secondWarior.MakeDamage(firstWarior);
                }
            }

            if (firstWarior.IsDead == true)
            {
                Console.WriteLine($"победа за {secondWarior} (2 боец)");
                return firstWarior;
            }
            else
            {
                Console.WriteLine($"победа за {firstWarior} (1 боец)");
                return secondWarior;
            }
        }
    }
}
