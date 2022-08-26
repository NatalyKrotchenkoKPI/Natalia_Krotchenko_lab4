using System;
using System.Collections.Generic;

namespace ЛР4
{
    //суперклас птах
    abstract class Bird
    {
        //поля класу
        public int Age { get; set; }
        public int FlightHeight { get; set; }

        //конструктор, в якому задається вік
        public Bird(int age, int flightHeight)
        {
            Age = age;
            FlightHeight = flightHeight;
        }

        //абстрактні методи SayHi і Feature
        abstract public void SayHi();

        abstract public void Feature();
    }

    //клас наслідник Eagle
    class Eagle : Bird
    {
        //конструктор, в якому вказується вік і висота польоту
        public Eagle(int age, int flightHeight) : base(age, flightHeight)
        {
            Age = age;
            FlightHeight = flightHeight;
        }

        //перевизначений метод, який виводить максимальну висоту польоту
        public override void Feature()
        {
            Console.WriteLine($"Моя максимальна висота польоту {Age * FlightHeight * 3} м");
        }

        //перевизначений метод, який виводить інформацію про птаха
        public override void SayHi()
        {
            Console.WriteLine($"Всiм привiт! Я орел! Менi {Age}");
        }

        //метод класу Eagle, в якому виводиться здатність орла
        public void Hunting()
        {
            int eyesight = Age * 100 - 33;
            int flightSpeed = Age * 10;

            Console.WriteLine($"Я можу знайти здобич за {eyesight * 5} м вiд мене " +
                $"та вполювати її за {flightSpeed / 2} c");
        }
    }

    //клас наслідник Parrot
    class Parrot : Bird
    {
        //конструктор, в якому вказується вік і висота польоту
        public Parrot(int age, int flightHeight) : base(age, flightHeight)
        {
            Age = age;
            FlightHeight = flightHeight;
        }

        //перевизначений метод, який виводить максимальну висоту польоту
        public override void Feature()
        {
            Console.WriteLine($"Моя максимальна висота польоту {Age * FlightHeight} м");
        }

        //перевизначений метод, який виводить інформацію про птаха
        public override void SayHi()
        {
            Console.WriteLine($"Всiм привiт! Я папуга! Менi {Age}");
        }

        //метод класу Parrot, в якому виводиться кількість вивчених папугою слів, в залежності від його віку
        public void AmountOfWords(List<string> words)
        {
            Console.WriteLine("Зараз я назву слова, якi вже вивчив");

            try
            {
                for (int i = 0; i < Age * 2; i++)
                {
                    Console.Write(words[i] + " ");
                }
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("\nСкоро вивчу новi!");
            }
        }
    }

    //абстрактний клас FlightlessBird, який наслідується від суперкласу Bird
    abstract class FlightlessBird : Bird
    {
        public int RunningSpeed { get; set; } //швидкість бігу

        //конструктор, в якому вказується вік і швидкість бігу
        public FlightlessBird(int age, int runningSpeed) : base(age, 0)
        {
            Age = age;
            RunningSpeed = runningSpeed;
        }

        //абстрактні методи
        abstract public override void SayHi();

        abstract public override void Feature();

        abstract public void Pride();
    }

    //клас наслідник Ostrich
    class Ostrich : FlightlessBird
    {
        //конструктор, в якому вказується вік і швидкість бігу
        public Ostrich(int age, int runningSpeed) : base(age, runningSpeed)
        {
            Age = age;
            RunningSpeed = runningSpeed;
        }

        //перевизначений метод, який виводить максимальну швидкість бігу
        public override void Feature()
        {
            Console.WriteLine($"Моя максимальна швидкiсть бiгу {Age * RunningSpeed * 0.1} км/год\nАле якщо мене покормити, " +
                $"то я зможу бiгти швидше!\nЯ люблю bounty, snickers, twix та mars");
        }

        //перевизначений метод, який виводить інформацію про птаха
        public override void SayHi()
        {
            Console.WriteLine($"Всiм привiт! Я страус! Менi {Age}");
        }

        //метод класу Ostrich, в якому можна присокрити страуса
        public void SpeedBoost(int amount, string sweet)
        {
            int speedBoost = (int)(Age * RunningSpeed * 0.1 + amount);

            //в залежності від введеної кількості і виду корму страус буде бігти швидше
            if (sweet == "bounty" && amount < 5 && amount > 1)
            {
                Console.WriteLine($"Вооуу! Тепер моя максимальна швидкiсть {speedBoost * 2} км/год! " +
                    $"Дякую за {sweet}");
            }
            else if (sweet == "snickers" && amount < 5 && amount > 1)
            {
                Console.WriteLine($"Ого! Тепер моя максимальна швидкiсть {Math.Round(speedBoost * 1.8, 1)} км/год! " +
                    $"Дякую за {sweet}");
            }
            else if (sweet == "twix" && amount < 5 && amount > 1)
            {
                Console.WriteLine($"Вжуух! Тепер моя максимальна швидкiсть {Math.Round(speedBoost * 1.6, 1)} км/год! " +
                    $"Дякую за {sweet}");
            }
            else if (sweet == "mars" && amount < 5 && amount > 1)
            {
                Console.WriteLine($"Уух! Тепер моя максимальна швидкiсть {MathF.Round((float)(speedBoost * 1.4), 1)} км/год! " +
                    $"Дякую за {sweet}");
            }
            else if (sweet != "bounty" && sweet != "snickers" && sweet != "twix" && sweet != "mars")
            {
                Console.WriteLine("Нi! Менi це не подобається!");
            }
            else if (amount > 4)
            {
                Console.WriteLine($"Ой-йой! Трохи переїв. Тепер моя максимальна швидкiсть {(speedBoost - amount) * 0.5} " +
                    $"км/год");
            }
            else if (amount < 1)
            {
                Console.WriteLine($"Еее! Ви менi нiчого не дали! Моя максимальна швидкiсть {speedBoost - amount} км/год");
            }
        }

        //перевизначений метод Pride
        public override void Pride()
        {
            Console.WriteLine("Не лiтаю, зате швидко бiгаю!");
        }
    }

    //клас наслідник Penguin
    class Penguin : FlightlessBird
    {
        //конструктор, в якому вказується вік і швидкість бігу
        public Penguin(int age, int runningSpeed) : base(age, runningSpeed)
        {
            Age = age;
            RunningSpeed = runningSpeed;
        }

        //перевизначений метод, який виводить максимальну швидкість бігу
        public override void Feature()
        {
            Console.WriteLine($"Моя максимальна швидкiсть бiгу {Age * RunningSpeed * 0.1} км/год");
        }

        //перевизначений метод, який виводить інформацію про птаха
        public override void SayHi()
        {
            Console.WriteLine($"Всiм привiт! Я пiнгвiн! Менi {Age}");
        }

        //метод класу Penguin, в якому виводиться к-сть їжі і вид риби, яку наловив пінгвін, в залежності від його віку
        public void Fishing(int durability, List<string> fish)
        {
            Console.WriteLine("Сьогоднi я наловив чимало риби!");
            Random rnd = new Random();
            int amount = 0;
            for (int i = 0; i < rnd.Next(1, fish.Count); i++)
            {
                int k, j; //змінні для збереження даних, k - рандомна к-сть риби, j - рандомний вид риби
                Console.WriteLine($"{k = rnd.Next((int)(Age * 1.2), Age + durability)} {fish[j = rnd.Next(0, fish.Count)]}");
                fish.RemoveAt(j);
                amount += k; //додаємо кількість риби
            }
            Console.WriteLine($"Загалом {amount} риби");
        }

        //перевизначений метод Pride
        public override void Pride()
        {
            Console.WriteLine("Не лiтаю, зате швидко плаваю!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //змінні для кожного класу
            Eagle eagle = new Eagle(5, 100);
            Parrot parrot = new Parrot(10, 70);

            //викликаємо методи
            eagle.SayHi();
            eagle.Feature();
            eagle.Hunting();
            Console.WriteLine();

            //список слів для папуги
            List<string> words = new List<string>
            {
                "hello", "key", "home", "dog", "candle", "basic", "lake", "walk", "replace", "remember", "behave", "wind",
                "liberty", "neck", "reaction", "portrait", "plant", "find", "cinema", "happen", "member", "develop"
            };

            //викликаємо методи
            parrot.SayHi();
            parrot.Feature();
            parrot.AmountOfWords(words);
            Console.WriteLine();

            //змінні для кожного класу
            Ostrich ostrich = new Ostrich(12, 30);
            Penguin penguin = new Penguin(17, 5);

            //викликаємо методи
            ostrich.SayHi();
            ostrich.Pride();
            ostrich.Feature();
            ostrich.SpeedBoost(3, "mars");
            Console.WriteLine();

            //список риби, яку їсть пінгвін
            List<string> fish = new List<string>
            {
                "кальмари", "криль", "краби", "креветки", "сардини", "анчоус"
            };

            //викликаємо методи
            penguin.SayHi();
            penguin.Feature();
            penguin.Pride();
            penguin.Fishing(30, fish);
            Console.WriteLine();
        }
    }
}
