using System;
using System.Text.RegularExpressions;

namespace Learning.RegularExpressions
{
    public class MyRegularExpression
    {
        public void Process()
        {
            String text = "C#   Java    Ruby   Elixir    Javascript";


            var replaced = Regex.Replace(text, " +", ",");

            Console.WriteLine(replaced);

            String text2 = "123: O exterminador do futuro:1984:107";

            //var pattern = "\\d+:[\\w ]+:[0-9]{4}:[0-9]+";
            //var pattern = "\\d+:[a-zA-Z]+:[0-9]{4}:[0-9]+";
            var pattern = "^\\d+:[a-zA-Z ]+:[0-9]{4}:[0-9]+$";

            var replaced2 = Regex.IsMatch(text2, pattern);

            Console.WriteLine(replaced2);
        }


    }
}
