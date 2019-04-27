using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Displaying tweets.\n");
            TweetManager.ShowAll();

            Console.WriteLine("Hashtags present in above tweets:\n" +
                "> Ford\n" +
                "> Invalid\n" +
                "> Jays\n" +
                "> Leaf\n" +
                "> Raptors\n" +
                "> Taxes\n" +
                "> WeTheNorth\n");

            Console.Write("Enter a hashtag found within the list of above tweets: ");
            string input = Console.ReadLine();
            Console.WriteLine($"\nThe following tweets have the hashtag value: {input}\n");
            TweetManager.ShowAll(input);

            TweetManager.ConvertToJson();
            Console.WriteLine("tweets.json has been created.");
            Console.WriteLine(@"> Filepath: ..\sec006-5_COMP123_03\Program\bin\Debug\tweets.json");

            Console.ReadKey(); // Prevent immediate exit.
        }
    }
}
