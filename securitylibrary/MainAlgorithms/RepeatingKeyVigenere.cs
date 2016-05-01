using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class RepeatingkeyVigenere : ICryptographicTechnique<string, string>
    {
        private char[,] Table;

        public RepeatingkeyVigenere()
        {
            Table = new char[26,26];
            int start = 65;
            for (int i = 0; i < 26; i++)
            {
                start = 65 + i;
                for (int j = 0; j < 26; j++)
                {
                    Table[i, j] = (char) start;
                    ++start;
                    if (start > 90)
                    {
                        start = 65;
                    }
                }
            }
        }

        private string FitKey(string PT, string Key)
        {
            int diff = PT.Length - Key.Length;
            for (int i = 0; i < diff; i++)
            {
                Key += Key[i];
            }
            return Key;
        }

        public string Analyse(string plainText, string cipherText)
        {
            string key = "";
            for (int i = 0; i < plainText.Length; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (cipherText[i] == Table[j, plainText[i] - 97])
                    {
                        key += (char)(j + 97);
                        break;
                    }
                }
            }
            string res = "";
            for (int i = 1; i <= key.Length; i++)
            {
                if (key.Substring(i, i) == key.Substring(0, i))
                {
                    res = key.Substring(0, i);
                    break;
                }
            }
            return res;
        }

        public string Decrypt(string cipherText, string key)
        {
            string res = "";
            for (int i = 0; i < cipherText.Length; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (cipherText[i] == Table[j, key[i] - 97])
                    {
                        res += (char)(j + 97);
                        key += key[i];
                        break;
                    }
                }
            }
            return res;
        }

        public string Encrypt(string plainText, string key)
        {
            if (key.Length < plainText.Length)
            {
                key = FitKey(plainText, key);
            }
            string res = "";
            for (int i = 0; i < plainText.Length; i++)
            {
                res += Table[plainText[i] - 97, key[i] - 97];
            }
            return res;
        }
    }
}