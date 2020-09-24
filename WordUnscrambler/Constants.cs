using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Constants
    {
        //Lists of constants to replace literal strings
        public const string ManualOrFileOption = "Enter scrambled word(s) manually or as a file: F - File / M - Manual";
        public const string ManualOrFileOptionError = "The entered option was not recognized, enter a valid option: F - File / M - Manual";
        public const string EnterFilePath = "Enter the full path including the file name: ";
        public const string ManuallyEnteredWords = "Enter word(s) manually (separated by commas/space if there are multiple words)";
        public const string FileExceptionError = "The program will be terminated. ";
        public const string ContinueLoop = "Would you like to continue? (Y/N)";
        public const string FilePath = "wordlist.txt";
        public const string MatchFound = "MATCH FOUND FOR ";
        public const string NoMatchFound = "NO MATCH FOUND";
        public const string Matrix = "If this appears in the console, then you're either cheating or you're in the matrix ;)";

    }
}
