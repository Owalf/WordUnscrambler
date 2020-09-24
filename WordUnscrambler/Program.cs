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
            //Created a string to keep the value of the user input.
            string userInput = "Y";
            //Created an infinite loop until the loop breaks.
            while (true)
            {
                //If the user input remains "Y" then run the following code
                if (userInput.ToUpper() == "Y")
                {
                    try
                    {
                        Console.WriteLine(Constants.ManualOrFileOption);

                        string option = Console.ReadLine();
                        //While loop to make sure the user entered a valid option
                        while(!(option.ToUpper() == "M" || option.ToUpper() == "F"))
                        {
                            Console.WriteLine(Constants.ManualOrFileOptionError);
                            option = Console.ReadLine();
                        }
                        switch (option.ToUpper())
                        {
                            case "F":
                                Console.WriteLine(Constants.EnterFilePath);
                                ExecuteScrambledWordsInFileScenario();
                                break;
                            case "M":
                                Console.WriteLine(Constants.ManuallyEnteredWords);
                                ExecuteScrambledWordsManualEntryScenario();
                                break;
                            default:
                                Console.WriteLine(Constants.Matrix);
                                break;
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(Constants.FileExceptionError + ex.Message);
                    }
                    //Ask the user to either continue the loop (Y) or quit the loop and program (N)
                    Console.WriteLine(Constants.ContinueLoop);
                    userInput = Console.ReadLine();
                }
                //If the userInput changes to "N", then break the loop and exit the program.
                else if (userInput.ToUpper() == "N")
                {
                    break;
                }
                //If the user enters gibberish, then we just ask the user to enter a valid option for userInput (Y/N)
                else
                {
                    Console.WriteLine(Constants.ContinueLoop);
                    userInput = Console.ReadLine();
                }
            }

        }
        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            //Read the user's input - manually entered words separated by commas
            string manualInput = Console.ReadLine();
            //Separators to separate each word if entered manually
            char[] separators = { ',', ' ' };
            string[] scrambledWords = manualInput.Split(separators);

            //Display the matched words
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
            string[] wordList = _fileReader.Read(Constants.FilePath);

            //Call a word matched method, to get a list of MatchedWord structs
            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);
            //Display the match - print to console
            if (matchedWords.Any())
            {
                //Loop through matchedWords and print to console the contents of the structs
                foreach (var matchedWord in matchedWords)
                {
                    //Write to console all the matched words
                    Console.WriteLine(Constants.MatchFound + matchedWord.ScrambledWord + " : " + matchedWord.Word);
                }

            } else
            {
                //Print "NO MATCH FOUND" if there are no matched words
                Console.WriteLine(Constants.NoMatchFound);
            }
        }
    }
}