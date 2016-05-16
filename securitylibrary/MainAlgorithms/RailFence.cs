using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class RailFence : ICryptographicTechnique<string, int>
    {
        public int Analyse(string plainText, string cipherText)
        {
            //throw new NotImplementedException();
            plainText = plainText.ToUpper();
            cipherText = cipherText.ToUpper();

            int key = 0;
            for (int i = 2; i < 10; ++i)
            {
                string res = Decrypt(cipherText, i);
                res = removeX(res);

                if (res.Equals(plainText))
                {
                    key = i;
                    break;
                }
            }

            return key;
        }

        string removeX(string str)
        {
            string res = null;

            for (int i = 0; i < str.Length; ++i)
            {
                if (str[i] == 'X' || str[i] == 'x')
                {
                    continue;
                }
                res = String.Concat(res, str[i]);
            }



            return res;
        }

        public string Decrypt(string cipherText, int key)
        {
            // throw new NotImplementedException();

            int numCols = (cipherText.Length / key);

            if (cipherText.Length % key != 0)
                numCols++;

            char[,] arr = new char[key, numCols];
            int index = 0;

            for (int j = 0; j < arr.GetLength(0); j++)
            {
                for (int i = 0; i < arr.GetLength(1); i++)
                {
                    if (index == cipherText.Length)
                        break;
                    else
                        arr[j, i] = cipherText[index++];
                }
                if (index == cipherText.Length)
                    break;
            }


            string enc = "";
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[j, i] != '\0')
                        enc += arr[j, i];
                }
            }

            return enc;
        }

        public string Encrypt(string plainText, int key)
        {
            // throw new NotImplementedException();

            int numCols = (plainText.Length / key);
            if (plainText.Length % key != 0)
                numCols++;
            char[,] arr = new char[key, numCols];

            int index = 0;
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    if (index == plainText.Length)
                        break;
                    else
                        arr[i, j] = plainText[index++];
                }
                if (index == plainText.Length)
                    break;
            }


            string enc = "";
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] != '\0')
                        enc += arr[i, j];
                }
            }
            return enc;
        }
    }
}
