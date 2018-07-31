using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionPrePlaner.Algorithm
{
    class Alphabet
    {
        public const string Letters = "abcdefghijklmnopqrstuvwxyz";

        public static string GetLettersTillTheEndOfAlphabet(String startingFrom)
        {
            int count = Letters.Length - Letters.IndexOf(startingFrom);
            return Letters.Substring(Letters.IndexOf(startingFrom), count);
        }

        internal static char GetNextAlphabetLetter(char after)
        {
            return (char)(after + 1);
        }

        public static char FirstUpperLetter { get { return char.ToUpper(Letters.First()); } }
    }
}
