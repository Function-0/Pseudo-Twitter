using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Script.Serialization;

namespace Program
{
    class TweetManager
    {
        private static Tweet[] tweets;

        // ..\sec006-5_COMP123_03\Program\bin\Debug\tweets.txt
        private static string fileName = "tweets.txt";

        static TweetManager()
        {
            int NUM_TWEETS = File.ReadLines(fileName).Count();
            tweets = new Tweet[NUM_TWEETS];

            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);

            int i = 0;
            string currLine = streamReader.ReadLine();
            while (currLine != null)
            {
                tweets[i] = Tweet.Parse(currLine);
                currLine = streamReader.ReadLine();
                i++;
            }

            streamReader.Close();
            fileStream.Close();
        }

        public static void ShowAll()
        {
            for (int i = 0; i < tweets.Length; i++)
            {
                Console.WriteLine(tweets[i].ToString());
            }
        }

        public static void ShowAll(string hashtag)
        {
            for (int i = 0; i < tweets.Length; i++)
            {
                if (tweets[i].Hashtag == hashtag)
                {
                    Console.WriteLine(tweets[i].ToString());
                }
            }
        }

        public static void ConvertToJson()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            // ..\sec006-5_COMP123_03\Program\bin\Debug\tweets.json
            FileStream fileStream = new FileStream("tweets.json", FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);

            streamWriter.Write(serializer.Serialize(tweets));

            streamWriter.Close();
            fileStream.Close();
        }
    }
}
