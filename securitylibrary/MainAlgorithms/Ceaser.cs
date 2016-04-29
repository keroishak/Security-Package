using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class Ceaser : ICryptographicTechnique<string, int>
    {
        public string Encrypt(string plainText, int key)
        {
            //throw new NotImplementedException();
            plainText = plainText.ToUpper();
            string s = "";
            for (int i = 0; i < plainText.Length; i++)
            {
                int ch = (plainText[i] + key);
                if (ch > 90)
                {
                    ch %= 90;
                    ch += 64;
                }
                s += (char)ch;
            }
            return s;
        }

        public string Decrypt(string cipherText, int key)
        {
            //throw new NotImplementedException();
            string s = "";
            for (int i = 0; i < cipherText.Length; i++)
            {
                int ch = (cipherText[i] - key);
                if (ch < 65)
                {
                    ch = 65 - ch;
                    ch = 91 - ch;
                }
                s += (char)ch;
            }

            s = s.ToLower();
            return s;
        }

        public int Analyse(string plainText, string cipherText)
        {
            //throw new NotImplementedException();
            plainText = plainText.ToUpper();
            int key = cipherText[0] - plainText[0];
            if (key < 0)
            {
                key += 26;
            }
            return key;
        }
    }
}
