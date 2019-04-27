using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Tweet
    {
        private static int currentId = 1;

        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Message { get; set; }
        public string Hashtag { get; set; }

        public Tweet(string from, string to, string message, string hashtag)
        {
            this.From = from;
            this.To = to;
            this.Message = message;
            this.Hashtag = hashtag;
            this.Id = currentId;
            currentId++;
        }

        public override string ToString()
        {
            const int CHAR_LIMIT = 30;
            string shortMessage = this.Message;
            if (this.Message.Length > CHAR_LIMIT)
            {
                shortMessage = this.Message.Substring(0, CHAR_LIMIT);
            }

            string result = String.Format($"Tweet ID {this.Id}:\n" +
                $"> From: {this.From}\n" +
                $"> To: {this.To}\n" +
                $"> Message (First 30 characters): {shortMessage}\n" +
                $"> Hashtag: {this.Hashtag}\n");

            return result;
        }

        public static Tweet Parse(string line)
        {
            string[] parsedTweet = line.Split(new char[] { '\t' });
            Tweet newTweet;

            try
            {
                newTweet = new Tweet(parsedTweet[0], parsedTweet[1], parsedTweet[2], parsedTweet[3]);
            }
            catch (IndexOutOfRangeException)
            {
                const string INVALID = "Invalid";
                newTweet = new Tweet(INVALID, INVALID, INVALID, INVALID);
            }

            return newTweet;
        }
    }
}
