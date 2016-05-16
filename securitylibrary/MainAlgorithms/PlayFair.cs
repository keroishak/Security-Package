using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class PlayFair : ICryptographicTechnique<string, string>
    {
        private char[,] matrix;
        private Dictionary<char, int> myDictionary;
        private char[] Letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        public PlayFair()
        {
            matrix = new char[5, 5];
            myDictionary = new Dictionary<char, int>();
        }

        private string RemoveDuplicatedinKey(string key)
        {
            string res = "";
            foreach (char c in key)
            {
                if (res.IndexOf(c) == -1)
                    res += c;
            }
            return res;
        }

        public string Analyse(string plainText, string cipherText)
        {
            throw new NotSupportedException();
        }
        public string Analyse(string plainText)
        {
            throw new NotImplementedException();
        }

        public string Decrypt(string cipherText, string key)
        {
            cipherText = cipherText.ToLower();
            for (int i = 0; i < 26; i++)
            {
                myDictionary.Add(Letters[i], 0);
            }
            key = RemoveDuplicatedinKey(key);
            int ind = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (ind < key.Length)
                    {
                        if (myDictionary[key[ind]] == 0)
                        {
                            matrix[i, j] = key[ind];
                            myDictionary[key[ind]] = 1;
                            if (key[ind] == 'i')
                                myDictionary['j'] = 1;
                            else if (key[ind] == 'j')
                                myDictionary['i'] = 1;
                            ind++;
                        }
                        else
                        {
                            ind++;
                            continue;
                        }
                    }
                    else
                    {
                        for (int k = 0; k < myDictionary.Count; k++)
                        {
                            var item = myDictionary.ElementAt(k);
                            if (item.Value == 0)
                            {
                                if (item.Key == 'i')
                                {
                                    myDictionary['j'] = 1;
                                }
                                matrix[i, j] = item.Key;
                                myDictionary[item.Key] = 1;
                                break;
                            }
                        }
                    }

                }

            }
            string first, second;
            int firstrow = 0, secondrow = 0;
            int firstcol = 0, secondcol = 0;
            string res = "";

            for (int i = 0; i < cipherText.Length; i += 2)
            {
                if (cipherText[i] == cipherText[i + 1])
                {
                    first = new string(cipherText.Take(i + 1).ToArray());
                    second = new string(cipherText.Skip(i + 1).ToArray());
                    cipherText = first + 'x' + second;
                }
                if (cipherText.Length % 2 != 0 && cipherText.Length - 1 - i == 2)
                {
                    cipherText += 'x';
                }
                for (int k = 0; k < 5; k++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (cipherText[i] == matrix[k, j])
                        {
                            firstrow = k;
                            firstcol = j;
                        }
                        if (cipherText[i + 1] == matrix[k, j])
                        {
                            secondrow = k;
                            secondcol = j;
                        }
                    }
                }
                if (firstrow == secondrow)
                {
                    firstcol--;
                    secondcol--;
                    if (firstcol < 0) firstcol += 5;
                    if (secondcol < 0) secondcol += 5;

                    res += matrix[firstrow, firstcol];
                    res += matrix[secondrow, secondcol];
                }
                else if (firstcol == secondcol)
                {
                    firstrow--;
                    secondrow--;
                    if (firstrow < 0) firstrow += 5;
                    if (secondrow < 0) secondrow += 5;

                    res += matrix[firstrow, firstcol];
                    res += matrix[secondrow, secondcol];
                }
                else
                {
                    res += matrix[firstrow, secondcol];
                    res += matrix[secondrow, firstcol];
                }
            }
            char[] tmp = res.ToArray();
            res="";
            for (int i = 0; i < tmp.Length - 2; ++i)
                if (tmp[i] == tmp[i + 2] && tmp[i + 1] == 'x'&&i%2==0)
                {
                    tmp[i + 1] = '0';
                }
            for (int i = 0; i < tmp.Length; ++i)
                if (tmp[i] != '0')
                    res += tmp[i];
                if (res[res.Length - 1] == 'x')
                    return res.Substring(0, res.Length - 1).ToLower();
            return res.ToLower();
        }

        public string Encrypt(string plainText, string key)
        {
            for (int i = 0; i < 26; i++)
            {
                myDictionary.Add(Letters[i], 0);
            }
            key = RemoveDuplicatedinKey(key);
            int ind = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (ind < key.Length)
                    {
                        if (myDictionary[key[ind]] == 0)
                        {
                            matrix[i, j] = key[ind];
                            myDictionary[key[ind]] = 1;
                            if (key[ind] == 'i')
                                myDictionary['j'] = 1;
                            else if (key[ind] == 'j')
                                myDictionary['i'] = 1;
                            ind++;
                        }
                        else
                        {
                            ind++;
                            continue;
                        }
                    }
                    else
                    {
                        for (int k = 0; k < myDictionary.Count; k++)
                        {
                            var item = myDictionary.ElementAt(k);
                            if (item.Value == 0)
                            {
                                if (item.Key == 'i')
                                {
                                    myDictionary['j'] = 1;
                                }
                                matrix[i, j] = item.Key;
                                myDictionary[item.Key] = 1;
                                break;
                            }
                        }
                    }

                }

            }
            string first, second;
            int firstrow = 0, secondrow = 0;
            int firstcol = 0, secondcol = 0;
            string res = "";

            for (int i = 0; i < plainText.Length; i += 2)
            {
                if (plainText[i] == plainText[i + 1])
                {
                    first = new string(plainText.Take(i + 1).ToArray());
                    second = new string(plainText.Skip(i + 1).ToArray());
                    plainText = first + 'x' + second;
                }
                if (plainText.Length % 2 != 0 && plainText.Length - 1 - i == 2)
                {
                    plainText += 'x';
                }
                for (int k = 0; k < 5; k++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (plainText[i] == matrix[k, j])
                        {
                            firstrow = k;
                            firstcol = j;
                        }
                        if (plainText[i + 1] == matrix[k, j])
                        {
                            secondrow = k;
                            secondcol = j;
                        }
                    }
                }
                if (firstrow == secondrow)
                {
                    res += matrix[firstrow, (firstcol + 1) % 5];
                    res += matrix[secondrow, (secondcol + 1) % 5];
                }
                else if (firstcol == secondcol)
                {
                    res += matrix[(firstrow + 1) % 5, firstcol];
                    res += matrix[(secondrow + 1) % 5, secondcol];
                }
                else
                {
                    res += matrix[firstrow, secondcol];
                    res += matrix[secondrow, firstcol];
                }
            }

            return res.ToUpper();
        }

    }
}
