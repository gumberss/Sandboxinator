using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Strings
{
    public class MyString
    {
        public async void Process()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var ingredients = GetIngredients();

            var text = await WriteAndReadAsync(ingredients);

            PrettyPresentation(text);
        }

        private void PrettyPresentation(string text)
        {
            foreach (var letter in text)
            {
                if (char.IsDigit(letter))
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                else if (char.IsUpper(letter))
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (char.IsWhiteSpace(letter))
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else if (char.IsLetter(letter))
                {
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }

                Console.Write(letter);
            }

            Console.ResetColor();
        }

        private static async Task<String> WriteAndReadAsync(string ingredients)
        {
            using (StringReader reader = new StringReader(ingredients))
            using (StringWriter writer = new StringWriter())
            {
                String line = String.Empty;

                while ((line = await reader.ReadLineAsync()) != null)
                {
                    await writer.WriteLineAsync($"• {line}");
                }

                return writer.ToString();
            }
        }

        private static string GetIngredients()
        {
            return
@"3 Cenouras médias raspadas e picadas
3 Ovos
1 Xícara de óleo
2 Xícaras de açúcar
2 Xícaras de farinha de trigo
1 Colher(sopa) de fermento em pó
1 Pitada de sal";
        }

    }
}
