using System;
using System.Linq;

namespace FusionPrePlaner.Algorithm
{
    public static class Alphabet
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

