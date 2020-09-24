using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();

            foreach (var scrambledWord in scrambledWords)
            {
                foreach (var word in wordList)
                {
                    //scrambledWord already matches word
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                    } else
                    {
                        //Convert strings into character arrays
                        char[] scrambledWordArray = scrambledWord.ToCharArray();
                           
                        //act sort -> act
                        //cat sort -> act

                        //Sort both character arrays (Array.sort())
                        //Convert character array back to a string
                        //Compare the two strings
                    }


                }
            }

            MatchedWord BuildMatchedWord(string scrambledWord, string word)
            {
                MatchedWord matchedWord = new MatchedWord
                {
                    ScrambledWord = scrambledWord,
                    Word = word
                };

                return matchedWord;
            }

            return matchedWords;
        }
    }
}
