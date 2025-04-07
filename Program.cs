using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace задание_1_2__Федоров_ПР_23
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите имя файла (****.txt):");
                string filePath = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    Console.WriteLine("Имя файла не может быть пустым.");
                    return;
                }
                Console.WriteLine("Введите текст для вывода из него гласных в обратном порядке:");
                string text = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(text))
                {
                    Console.WriteLine("Текст не может быть пустым.");
                    return;
                }
                File.WriteAllText(filePath, text);
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Файл не найден.");
                    return;
                }
                string fileContent = File.ReadAllText(filePath);
                if (string.IsNullOrWhiteSpace(fileContent))
                {
                    Console.WriteLine("Файл пустой.");
                    return;
                }
                Stack<char> charStack = new Stack<char>();
                string chars = "аеёиоуыэюяАЕЁИОУЫЭЮЯ";
                foreach (char c in fileContent)
                {
                    if (chars.Contains(c))
                    {
                        charStack.Push(c);
                    }
                }
                if (charStack.Count == 0)
                {
                    Console.WriteLine("В файле нет гласных букв.");
                    return;
                }
                Console.WriteLine("Гласные буквы в обратном порядке:");
                while (charStack.Count > 0)
                {
                    Console.Write(charStack.Pop() + " ");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Произошла ошибка: {exception.Message}");
            }
        }
    }
}
