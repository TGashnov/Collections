using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Input();
            Check();
            Output();
        }

        static readonly Stack<char> stack = new Stack<char>();
        static readonly Dictionary<char, char> brackets = new Dictionary<char, char>() {
            { '{', '}' },
            { '[', ']' },
            { '(', ')' },
            { '<', '>' }
        };
        static string Text { get; set; }
        static readonly List<int> errorIndices = new List<int>();

        static void Input()
        {
            Console.WriteLine("Введите какой-нибудь текст со скобками");
            Text = Console.ReadLine();
        }

        static void Check()
        {
            for (int i = 0; i < Text.Length; i++)
            {
                if (brackets.ContainsKey(Text[i]))
                {
                    stack.Push(Text[i]);
                }
                else if (brackets.ContainsValue(Text[i]) &&
                        (stack.Count == 0 || (brackets[stack.Pop()] != Text[i]))
                        )
                {
                    errorIndices.Add(i);
                }
            }
            if (stack.Count > 0)
            {
                int pos = Text.Length;
                while (stack.Count > 0)
                {
                    pos = Text.LastIndexOf(stack.Pop(), pos - 1);
                    errorIndices.Add(pos);
                }
            }
        }

        static void Output()
        {
            if (errorIndices.Count == 0) Console.WriteLine("Все открытые скобки закрыты");
            else
            {
                int len = 1;
                int start = 0;
                for (int i = 0; i < Text.Length; i++)
                {
                    if (i > errorIndices.Max())
                    {
                        Console.Write(Text[i..]);
                        break;
                    }
                    if (!errorIndices.Contains(i))
                    {
                        len++;
                        continue;
                    }
                    else
                    {
                        Console.Write(Text.Substring(start, len - 1));
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(Text[i]);
                        Console.ResetColor();
                        len = 1;
                        start = i + 1;
                    }
                }
            }
        }
    }
}
