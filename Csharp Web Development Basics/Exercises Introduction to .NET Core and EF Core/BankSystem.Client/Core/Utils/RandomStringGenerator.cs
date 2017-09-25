using System;
using System.Text;

namespace BankSystem.Client.Core.Utils
{
    public static class RandomStringGenerator
    {
        private const string ALPHABET = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static Random rnd = new Random();

        public static string GenerateString(int length)
        {
            var result = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                result.Append(ALPHABET[rnd.Next(0, ALPHABET.Length)]);
            }

            return result.ToString();
        }
    }
}