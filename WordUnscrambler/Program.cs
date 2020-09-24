using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();

        static void Main(string[] args)
        {
            String userInput = "Y";

            while (true)
            {
                if (userInput.ToUpper() == "Y")
                {
                    try
                    {
                        Console.WriteLine("Enter scrambled word(s) manually or as a file: F - File / M - Manual");

                        string option = Console.ReadLine();

                        switch (option.ToUpper())
                        {
                            case "F":
                                Console.WriteLine("Enter the full path including the file name: ");
                                ExecuteScrambledWordsInFileScenario();
                                break;
                            case "M":
                                Console.WriteLine("Enter word(s) manually (separated by commas if there are multiple words)");
                                ExecuteScrambledWordsManualEntryScenario();
                                break;
                            default:
                                Console.WriteLine("The entered option was not recognized");
                                break;
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("The program will be terminated" + ex.Message);
                    }

                    Console.WriteLine("Would you like to continue? (Y/N)");
                    userInput = Console.ReadLine();
                }

                else if (userInput.ToUpper() == "N")
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Would you like to continue? (Y/N)");
                    userInput = Console.ReadLine();
                }
            }

        }
        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            //Read the user's input - manually entered words separated by commas
            string manualInput;
            manualInput = Console.ReadLine();
            //extract the words into a string[] - use Split()
            char[] separators = { ',', ' ' };
            string[] scrambledWords = manualInput.Split(separators);

            //display the matched words
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            //Read the user's input - file with scrambled words
            string fileName = Console.ReadLine();

            //Read words from file and store in string[] scrambledWords
            string[] scrambledWords = _fileReader.Read(fileName);

            //Display the matched words
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            //Read the list of words in the wordlist.txt (unscrambled words)
            string[] wordList = _fileReader.Read("wordlist.txt");

            //Call a word matched method, to get a list of MatchedWord structs
            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);
            //Display the match - print to console
            if (matchedWords.Any())
            {
                //loop through matchedWords and print to console the contents of the structs
                //foreach
                foreach (var matchedWord in matchedWords)
                {
                    //write to console
                    //output -> MATCH FOUND FOR act: cat
                    Console.WriteLine("MATCH FOUND FOR " + matchedWord.ScrambledWord + " : " + matchedWord.Word);
                }

            } else
            {
                //NO MATCHED HAVE BEEN FOUND
                Console.WriteLine("NO MATCH FOUND");
            }
        }
    }
}