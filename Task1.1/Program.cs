using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager();
        }

        static void Manager()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Чтобы вы хотели сделать?");
                Console.WriteLine("Нажмите F1, чтобы открыть список стран");
                Console.WriteLine("Нажмите F2, чтобы узнать количество заполненных и незаполненных стран");
                Console.WriteLine("Нажмите F3, чтобы найти столицу по названию страны");
                Console.WriteLine("Нажмите F4, чтобы найти страну по названию столицы");
                Console.WriteLine("Нажмите F5, чтобы добавить страну");
                Console.WriteLine("Нажмите F6, чтобы удалить страну");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.F1: PrintAll(); break;
                    case ConsoleKey.F2: FilledCountries(); break;
                    case ConsoleKey.F3: CountrySearch(); break;
                    case ConsoleKey.F4: CapitalSearch(); break;
                    case ConsoleKey.F5: AddCapital(); break;
                    case ConsoleKey.F6: RemoveCountry(); break;
                }
                Console.WriteLine();
                Console.WriteLine("Нажмите Escape, чтобы закончить или любую другую кнопку, чтобы продолжить");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        static Dictionary<string, string> Сountries = new Dictionary<string, string>() {
            { "Россия", "" },
            { "Исландия", "Рейкьявик" },
            { "Норвегия", "Осло" },
            { "Швеция", "Стокгольм" },
            { "Финляндия", "" },
            { "Дания", "Копенгаген" },
            { "Ирландия", "Дублин" },
            { "Великобритания", "Лондон" },
            { "Франция", "Париж" },
            { "Бельгия", "Брюссель" },
            { "Нидерланды", "Амстердам" },
            { "Германия", "Берлин" },
            { "Польша", "Варшава" },
            { "Словакия", "Братислава" },
            { "Швейцария", "Берн" },
            { "Италия", "Рим" },
            { "Испания", "Мадрид" },
            { "Португалия", "Лиссабон" },
            { "Греция", "Афины" },
            { "Узбекистан", "Ташкент" },
            { "Украина", "Киев" },
        };

        static void PrintAll()
        {
            Console.Clear();
            foreach (KeyValuePair<string, string> kvp in Сountries)
            {
                Console.WriteLine("Страна: {0}\nСтолица: {1}", kvp.Key, kvp.Value);
                Console.WriteLine();
            }
        }

        static void PrintCountryAndCapital(string input)
        {
            if(Сountries.ContainsKey(input))
            {
                Console.WriteLine("Страна: " + Сountries.Where(country => country.Key == input).FirstOrDefault().Key);
                Console.WriteLine("Столица: " + Сountries[input]);
            }
            else
            {
                Console.WriteLine("Страна: " + Сountries.Where(country => country.Value == input).FirstOrDefault().Key);
                Console.WriteLine("Столица: " + Сountries.Where(country => country.Value == input).FirstOrDefault().Value);
            }
        }

        static void FilledCountries()
        {
            Console.Clear();
            var withCapital = Сountries.Where(country => country.Value != "").ToArray().Length;
            var withoutCapital = Сountries.Where(country => country.Value == "").ToArray().Length;
            Console.WriteLine("Заполненных стран: {0}", withCapital);
            Console.WriteLine("Незаполненных стран: {0}", withoutCapital);
            if (withoutCapital != 0)
            {
                Console.WriteLine("Не заполнены:");
                foreach (KeyValuePair<string, string> kvp in Сountries)
                {
                    if (kvp.Value == "")
                    {
                        Console.Write(kvp.Key + "  ");
                    }
                }
                Console.WriteLine();
            }
        }

        static void CountrySearch()
        {
            Console.Clear();
            Console.WriteLine("Введите страну, чтобы найти ее столицу");
            string input = CapitalizedWord();
            if (Сountries.ContainsKey(input)) 
            {
                PrintCountryAndCapital(input);
            }
            else
            {
                Console.WriteLine("К сожалению, такой страны в списке нет");
            }
        }

        static void CapitalSearch()
        {
            Console.Clear();
            Console.WriteLine("Введите столицу, чтобы найти ее страну");
            string input = CapitalizedWord();
            if (Сountries.ContainsValue(input))
            {
                PrintCountryAndCapital(input);
            }
            else
            {
                Console.WriteLine("К сожалению, такой столицы в списке нет");
            }
        }

        static void AddCapital()
        {
            Console.Clear();
            Console.WriteLine("Введите страну, которую хотите добавить");
            string country = CapitalizedWord();
            if (Сountries.ContainsKey(country) && Сountries[country] != "")
            {
                Console.WriteLine("Такая страна уже имеется и нее уже есть столица.");
                ChangeCapital(country);
            }
            else if (Сountries.ContainsKey(country) && Сountries[country] == "")
            {
                Console.WriteLine("Такая страна уже имеется, но у нее нет столицы.");
                Console.WriteLine("Введите для нее столицу");
                Сountries[country] = CapitalizedWord();
            }
            else
            {
                Console.WriteLine("Введите столицу для своей страны");
                Сountries.Add(country, CapitalizedWord());
            }
        }

        static void ChangeCapital(string country)
        {
            Console.WriteLine("Хотите изменить ее?\nНажмите Enter, чтобы изменить или любую другую кнопку, чтобы вернуться в главное меню");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.WriteLine("Введите новую столицу");
                Сountries[country] = CapitalizedWord();
            }
            else
            {
                return;
            }
        }

        static void RemoveCountry()
        {
            Console.Clear();
            Console.WriteLine("Введите страну, которую хотите удалить");
            string country = CapitalizedWord();
            if (Сountries.ContainsKey(country))
            {
                Сountries.Remove(country);
                Console.WriteLine("{0} успешно удалена", country);
            }
            else
            {
                Console.WriteLine("К сожалению, такой страны в списке нет");
            }
        }

        static string CapitalizedWord()
        {
            string str = Console.ReadLine().ToLower();
            string l = str.Substring(0, 1).ToUpper();
            return l + str[1..];
        }
    }
}
