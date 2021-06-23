using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackMe.Net_Task1
{
    class Caesar_Cipher
    {


        public static char cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {

                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);


        }


        public static string Encipher(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += cipher(ch, key);

            return output;
        }

        public static string Decipher(string input, int key)
        {
            return Encipher(input, 26 - key);
        }


        public static string LetterNumbersMap(int input)
        {
            List<int> inputList = new();
            List<char> outList = new();
            string output = string.Empty;

            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            while (input > 0)
            {
                inputList.Add(input % 10);
                input /= 10;
            }

            inputList.Reverse();
            inputList.ForEach(ins =>
            {
                for (int i = 0; i <= 9; i++)
                {
                    if (ins == i)
                    {
                        outList.Add(alphabet[i]);
                    }
                }
            });

            output = new String(outList.ToArray());
            return output;
        }
    }
}