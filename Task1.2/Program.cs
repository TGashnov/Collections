using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static List<List<string>> AllUsers = new List<List<string>>();

        static void Input()
        {
            Console.Clear();
            Console.WriteLine("Вводите свои \"любимки\" через запятую для каждого пользователя. Чтобы закончить введите пустую строку");
            int i = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "") break;
                AllUsers.Add(input.Split(' ').Select(word => word.ToLower()).ToList());
            } 
        }

        static void PrintAllUsers()
        {
            Console.Clear();
            int i = 0;
            foreach (var list in AllUsers)
            {
                i++;
                Console.Write("Пользователь #{0}:", i);
                foreach(var word in list)
                {
                    Console.Write(" " + word);
                }
                Console.WriteLine();
            }
        }

        static void PrintAnyUser()
        {
            Console.Clear();
            Random random = new Random();
            var user = random.Next(AllUsers.Count);
            Console.Write("Пользователь #{0}:", user+1);
            foreach (var word in AllUsers[user])
            {
                Console.Write("{0, 3}", word);
            }
        }

        static void UserLike()
        {
            Console.Clear();
            var foundLubimki = new Dictionary<int, List<string>>();
            int i = 0;
            foreach(var list in AllUsers)
            {
                i++;
                var neLubimki = new List<string>();
                foreach(var word in list)
                {
                    if (!AllUsers.Where(lst => lst != list).Any(lst => lst.Contains(word)))
                    {
                        neLubimki.Add(word);
                    }
                }
                foundLubimki.Add(i, neLubimki);
            }
            i = 0;
            foreach(KeyValuePair<int, List<string>> kvp in foundLubimki)
            {
                i++;
                if(kvp.Value.Count != 0)
                {
                    Console.Write("У пользователя #{0} любимки:", i);
                    foreach(var word in kvp.Value)
                    {
                        Console.Write(" " + word);
                    }
                    Console.Write(", которых больше ни у кого нет!");
                }
                Console.WriteLine();
            }
        }

        static void CountLubimok()
        {
            Console.Clear();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach(var list in AllUsers)
            {
                foreach(var word in list)
                {
                    if (dict.ContainsKey(word))
                    {
                        dict[word]++;
                    }
                    else
                    {
                        dict.Add(word, 1);
                    }
                }
            }
            foreach(KeyValuePair<string, int> kvp in dict)
            {
                var str = "раз";
                var remain = kvp.Value % 10;
                if (remain >= 2 && remain <= 4 &&
                    kvp.Value != 12 && kvp.Value != 13 && kvp.Value != 14) str = "раза";

                Console.WriteLine("Любимка \"{0}\" встречается {1} {2}", kvp.Key, kvp.Value, str);
            }
        }

        static void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("Нажмите F1, чтобы добавить пользователя и его любимки");
                Console.WriteLine("Нажмите F2, чтобы вывести любимки всех пользователей");
                Console.WriteLine("Нажмите F3, чтобы вывести любимки рандомного пользователя");
                Console.WriteLine("Нажмите F4, чтобы вывести изысканные предпочтения каждого пользователя");
                Console.WriteLine("Нажмите F5, чтобы каждую любимку и ее количество");
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.F1: Input(); break;
                    case ConsoleKey.F2: PrintAllUsers(); break;
                    case ConsoleKey.F3: PrintAnyUser(); break;
                    case ConsoleKey.F4: UserLike(); break;
                    case ConsoleKey.F5: CountLubimok(); break;
                    default: Console.WriteLine("Команда не распознана"); break;
                }
                Console.WriteLine();
                Console.WriteLine("Нажмите Escape, чтобы закончить или любую другую кнопку, чтобы продолжить");
            } while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }
    }
}
