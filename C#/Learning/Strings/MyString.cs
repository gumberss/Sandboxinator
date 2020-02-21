using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Strings
{
    public class MyString
    {
        public async void Process()
        {
            var texto1 = "a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a ";
            var texto2 = "                                                                                                    ";
            var texto = "aaaaaaaaaaaa aaaaaaaaaaaa aaaaaa aaaaaaaaaaaaaaa aaaaa aaaaaaaaa aaaa aaaaaaaaaaa aaaaa aaaaa aaaaaaa aaaaaa aaaaaaa";
            var texto4 = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            var texts = new String[] { texto1, texto2, texto, texto, texto4 };

            Stopwatch s = new Stopwatch();

            foreach (var item in texts)
            {
                s.Restart();
                for (int i = 0; i < 10_000_000; i++)
                {
                    int espacos1 = Method1(texto);
                }

                s.Stop();
                Console.WriteLine(s.ElapsedMilliseconds);
                s.Restart();
                for (int i = 0; i < 10_000_000; i++)
                {
                    var espacos2 = Method2(texto);
                }
                s.Stop();
                Console.WriteLine(s.ElapsedMilliseconds);

                Console.WriteLine();

            }

            return;

            Console.OutputEncoding = Encoding.UTF8;

            var ingredients = GetIngredients();

            var text = await WriteAndReadAsync(ingredients);

            PrettyPresentation(text);
        }

        private static int Method2(string texto)
        {
            int espacos = 0;

            foreach (var c in texto)
            {
                if (c == ' ') espacos++;
            }

            return espacos;
        }

        private static int Method1(string text)
        {
            int indice = -1;
            int espacos = 0;

            while (true)
            {
                indice = text.IndexOf(' ', indice + 1);

                if (indice == -1)
                    break;

                espacos++;
            }

            return espacos;
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
