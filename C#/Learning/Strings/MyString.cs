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

            Console.WriteLine(text);
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
@"3 cenouras médias raspadas e picadas
3 ovos
1 xícara de óleo
2 xícaras de açúcar
2 xícaras de farinha de trigo
1 colher(sopa) de fermento em pó
1 pitada de sal";
        }

    }
}
