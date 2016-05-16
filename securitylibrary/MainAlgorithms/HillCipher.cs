using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    /// <summary>
    /// The List<int> is row based. Which means
    /// </summary>
    public class HillCipher : ICryptographicTechnique<string, string>, ICryptographicTechnique<List<int>, List<int>>
    {
        ////analsys...
        //public List<int> Analyse(List<int> plainText, List<int> cipherText)
        //{

        //    string _plainText = convertListTOstring(plainText);
        //    string _CipherTxt = convertListTOstring(cipherText);

        //    string res = Analyse(_plainText, _CipherTxt);

        //    List<int> l = convertstringTOlist(res);

        //    return l;
        //}

        //public string Analyse(string plainText, string cipherText)
        //{
        //    // throw new NotImplementedException();
        //    //keyMAt * PM = CM

        //    cipherText = cipherText.ToLower();

        //    string result = "";
        //    int temp = 4;

        //    int[,] PTconverted = GetKeyMatrixDouble(plainText.Substring(0, temp));
        //    int[,] CTconverted = GetKeyMatrixDouble(cipherText.Substring(0, temp));

        //    int[,] Key = new int[2, 2];
        //    int[,] res = new int[2, 2];
        //    for (int j = 0; j < 26; j++)
        //    {
        //        for (int x = 0; x < 26; x++)
        //        {
        //            for (int y = 0; y < 26; y++)
        //            {
        //                for (int z = 0; z < 26; z++)
        //                {

        //                    Key[0, 0] = j;
        //                    Key[0, 1] = x;
        //                    Key[1, 0] = y;
        //                    Key[1, 1] = z;

        //                    res = multiply(Key, PTconverted);

        //                    for (int m = 0; m < Key.GetLength(0); m++)
        //                    {
        //                        for (int w = 0; w < Key.GetLength(0); w++)
        //                        {
        //                            if (res[m, w] > 0)
        //                            {
        //                                res[m, w] %= 26;
        //                            }
        //                            else
        //                            {
        //                                while (res[m, w] < 0)
        //                                    res[m, w] += 26;
        //                            }
        //                        }
        //                    }

        //                    if (res[0, 0] == CTconverted[0, 0] && res[0, 1] == CTconverted[0, 1]
        //                        && res[1, 0] == CTconverted[1, 0]
        //                        && res[1, 1] == CTconverted[1, 1])
        //                    {
        //                        break;
        //                    }


        //                }

        //                if (res[0, 0] == CTconverted[0, 0] && res[0, 1] == CTconverted[0, 1] && res[1, 0] == CTconverted[1, 0] && res[1, 1] == CTconverted[1, 1])
        //                {
        //                    break;
        //                }
        //            }
        //            if (res[0, 0] == CTconverted[0, 0] && res[0, 1] == CTconverted[0, 1] && res[1, 0] == CTconverted[1, 0] && res[1, 1] == CTconverted[1, 1])
        //            {
        //                break;
        //            }
        //        }
        //        if (res[0, 0] == CTconverted[0, 0] && res[0, 1] == CTconverted[0, 1] && res[1, 0] == CTconverted[1, 0] && res[1, 1] == CTconverted[1, 1])
        //        {
        //            break;
        //        }
        //    }

        //    string c = ConvertMatToString(Key);


        //    string dres = Decrypt(cipherText, c);
        //    dres = dres.ToLower();
        //    if (dres == plainText)
        //    {
        //        return c;
        //    }



        //    return result;





        //    //// throw new NotImplementedException();
        //    ////keyMAt * PM = CM

        //    //cipherText =  cipherText.ToLower();

        //    //string result = "";
        //    //int temp = 4;

        //    ////int[,] PTconverted = GetKeyMatrixDouble(plainText.Substring(0, temp));

        //    ////int[,] CTconverted = GetKeyMatrixDouble(cipherText.Substring(0, temp));


        //    //int[,] PTconverted = { {15, 24 }, { 0 , 12} };

        //    //int[,] CTconverted = { {19 , 18 }, {16 , 18} };

        //    //PTconverted = keyInverse(PTconverted);

        //    //int[,] Key = multiply(CTconverted, PTconverted);

        //    //for (int j = 0; j < Key.GetLength(0); j++)
        //    //{
        //    //    for (int x = 0; x < Key.GetLength(0); x++)
        //    //    {
        //    //        if (Key[j, x] > 0)
        //    //        {
        //    //            Key[j, x] %= 26;
        //    //        }
        //    //        else
        //    //        {
        //    //            while (Key[j, x] < 0)
        //    //                Key[j, x] += 26;
        //    //        }
        //    //    }
        //    //}

        //    //string c = ConvertMatToString(Key);


        //    //string dres = Decrypt(cipherText, c);
        //    //dres = dres.ToLower();
        //    //if (dres == plainText)
        //    //{
        //    //    return c;
        //    //}



        //    //return result;
        //}

        //public List<int> Analyse3By3Key(List<int> plainText, List<int> cipherText)
        //{
        //    throw new NotImplementedException();
        //}

        //public string Analyse3By3Key(string plainText, string cipherText)
        //{
        //    throw new NotImplementedException();
        //}



        public List<int> Analyse(List<int> plainText, List<int> cipherText)
        {

            string _plainText = convertListTOstring(plainText);
            string _CipherTxt = convertListTOstring(cipherText);

            string res = Analyse(_plainText, _CipherTxt);

            List<int> l = convertstringTOlist(res);

            return l;
        }
        public string Analyse(string plainText, string cipherText)
        {

            //a b c d e f g h i j  k l  m   n  o  p q   r  s  t  u  v w   x  y  z
            //0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 

            // p a o r
            // t q y p

            //// throw new NotImplementedException();
            ////keyMAt * PM = CM

            cipherText = cipherText.ToLower();

            string result = "";
            int temp = 4;

            int[,] PTconverted = new int[2, 2];


            int[,] CTconverted = new int[2, 2];


            for (int i = 2; i < plainText.Length - 1; i++)
            {

                PTconverted[0, 0] = plainText[0] - 'a';
                PTconverted[0, 1] = plainText[1] - 'a';

                PTconverted[1, 0] = plainText[i] - 'a';
                PTconverted[1, 1] = plainText[i + 1] - 'a';

                CTconverted[0, 0] = cipherText[0] - 'a';
                CTconverted[0, 1] = cipherText[1] - 'a';
                CTconverted[1, 0] = cipherText[i] - 'a';
                CTconverted[1, 1] = cipherText[i + 1] - 'a';


                //int[,] PTconverted = { { 15, 0 }, { 14, 17 } };

                //int[,] CTconverted = { { 19, 16 }, { 24, 15 } };

                PTconverted = keyInverse(PTconverted);

                int[,] Key = multiply(PTconverted, CTconverted);

                for (int j = 0; j < Key.GetLength(0); j++)
                {
                    for (int x = 0; x < Key.GetLength(0); x++)
                    {
                        if (Key[j, x] > 0)
                        {
                            Key[j, x] %= 26;
                        }
                        else
                        {
                            while (Key[j, x] < 0)
                                Key[j, x] += 26;
                        }
                    }
                }


                Matrix.Transpose(Key);

                string c = ConvertMatToString(Key);


                string dres = Decrypt(cipherText, c);
                dres = dres.ToLower();
                if (dres == plainText)
                {
                    return c;
                }
            }

            throw new InvalidAnlysisException();

            return "";
        }
        public List<int> Analyse3By3Key(List<int> plainText, List<int> cipherText)
        {
            // throw new NotImplementedException();
            string _plainText = convertListTOstring(plainText);
            string _CipherTxt = convertListTOstring(cipherText);

            string res = Analyse3By3Key(_plainText, _CipherTxt);

            List<int> l = convertstringTOlist(res);

            return l;
        }
        public string Analyse3By3Key(string plainText, string cipherText)
        {
            //a b c d e f g h i j  k l  m   n  o  p q   r  s  t  u  v w   x  y  z
            //0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 

            // p a o r
            // t q y p

            //// throw new NotImplementedException();
            ////keyMAt * PM = CM

            cipherText = cipherText.ToLower();

            string result = "";

            int[,] PTconverted = new int[3, 3];


            int[,] CTconverted = new int[3, 3];


            PTconverted[0, 0] = plainText[0] - 'a';
            PTconverted[0, 1] = plainText[1] - 'a';
            PTconverted[0, 2] = plainText[2] - 'a';
            PTconverted[1, 0] = plainText[3] - 'a';
            PTconverted[1, 1] = plainText[4] - 'a';
            PTconverted[1, 2] = plainText[5] - 'a';
            PTconverted[2, 0] = plainText[6] - 'a';
            PTconverted[2, 1] = plainText[7] - 'a';
            PTconverted[2, 2] = plainText[8] - 'a';

            CTconverted[0, 0] = cipherText[0] - 'a';
            CTconverted[0, 1] = cipherText[1] - 'a';
            CTconverted[0, 2] = cipherText[2] - 'a';
            CTconverted[1, 0] = cipherText[3] - 'a';
            CTconverted[1, 1] = cipherText[4] - 'a';
            CTconverted[1, 2] = cipherText[5] - 'a';
            CTconverted[2, 0] = cipherText[6] - 'a';
            CTconverted[2, 1] = cipherText[7] - 'a';
            CTconverted[2, 2] = cipherText[8] - 'a';


            //int[,] PTconverted = { { 15, 0 }, { 14, 17 } };

            //int[,] CTconverted = { { 19, 16 }, { 24, 15 } };

            PTconverted = keyInverse(PTconverted);

            int[,] Key = multiply(PTconverted, CTconverted);

            for (int j = 0; j < Key.GetLength(0); j++)
            {
                for (int x = 0; x < Key.GetLength(0); x++)
                {
                    if (Key[j, x] > 0)
                    {
                        Key[j, x] %= 26;
                    }
                    else
                    {
                        while (Key[j, x] < 0)
                            Key[j, x] += 26;
                    }
                }
            }


            Matrix.Transpose(Key);

            string c = ConvertMatToString(Key);


            string dres = Decrypt(cipherText, c);
            dres = dres.ToLower();
            if (dres == plainText)
            {
                return c;
            }
            else
            {
                throw new InvalidAnlysisException();
            }

            return result;
        }

        //decreption...
        public bool ValidateDecrypt(List<int> cipherText, List<int> key)
        {
            string _cipherText = convertListTOstring(cipherText);
            string _Key = convertListTOstring(key);

            string plainRes = Decrypt(_cipherText, _Key);

            plainRes = plainRes.ToLower();
            List<int> res = convertstringTOlist(plainRes);

            string cstr = Encrypt(plainRes, _Key);
            if (cstr != _cipherText)
            {

                return true;
            }

            return false;
        }

        public List<int> Decrypt(List<int> cipherText, List<int> key)
        {

            if (!ValidateDecrypt(cipherText, key))
            {
                throw new InvalidAnlysisException();
            }

            string _cipherText = convertListTOstring(cipherText);
            string _Key = convertListTOstring(key);

            string plainRes = Decrypt(_cipherText, _Key);

            plainRes = plainRes.ToLower();
            List<int> res = convertstringTOlist(plainRes);

            return res;

        }

        public string Decrypt(string cipherText, string key)
        {

            int[,] PT = ConvertStringToVector(cipherText);
            int[,] keyMat = GetKeyMatrix(key);

            int[,] inverseMat = new int[keyMat.GetLength(0), keyMat.GetLength(1)];

            inverseMat = keyInverse(keyMat);


            int temp = keyMat.GetLength(0);


            string EncRes = "";

            for (int i = 0; i < cipherText.Length; i += temp)
            {
                int[,] PTconverted = ConvertStringToVector(cipherText.Substring(i, temp));

                int[,] cipher = multiply(inverseMat, PTconverted);

                for (int j = 0; j < cipher.GetLength(0); j++)
                {
                    if (cipher[j, 0] > 0)
                        cipher[j, 0] %= 26;
                    else while (cipher[j, 0] < 0)
                            cipher[j, 0] += 26;
                }

                int[,] c = cipher;

                EncRes = string.Concat(EncRes, ConvertVectorToString(cipher));
            }
            return EncRes;
        }


        //encreption..
        public List<int> Encrypt(List<int> plainText, List<int> key)
        {
            // throw new NotImplementedException();
            string _plainText = convertListTOstring(plainText);
            string _Key = convertListTOstring(key);


            string encres = Encrypt(_plainText, _Key);

            encres = encres.ToLower();
            List<int> res = convertstringTOlist(encres);


            return res;
        }
        public string Encrypt(string plainText, string key)
        {
            //remove spaces
            for (int i = 0; i < plainText.Length; i++)
            {
                if (plainText[i] == ' ')
                {
                    plainText = plainText.Remove(i, 1);
                    i--;
                }
            }

            int[,] PT = ConvertStringToVector(plainText);

            int[,] keyMat = GetKeyMatrix(key);
            int temp = keyMat.GetLength(0);

            string EncRes = "";

            for (int i = 0; i < plainText.Length; i += temp)
            {
                int[,] PTconverted = ConvertStringToVector(plainText.Substring(i, temp));

                int[,] cipher = multiply(keyMat, PTconverted);

                for (int j = 0; j < cipher.GetLength(0); j++)
                {
                    if (cipher[j, 0] > 0)
                        cipher[j, 0] %= 26;
                    else while (cipher[j, 0] < 0)
                            cipher[j, 0] += 26;
                }

                int[,] c = cipher;

                EncRes = string.Concat(EncRes, ConvertVectorToString(cipher));
            }
            return EncRes;
        }




        //helper functions
        int[,] ConvertStringToVector(string str)
        {

            int[,] res = new int[str.Length, 1];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                {
                    res[i, 0] = str[i] - 'A';

                }
                if (str[i] >= 'a' && str[i] <= 'z')
                {
                    res[i, 0] = str[i] - 'a';
                }
            }
            return res;
        }
        int[,] GetKeyMatrix(string str)
        {
            int wh = (int)Math.Sqrt(str.Length);

            int[,] res = new int[wh, wh];
            int index = 0;


            for (int i = 0; i < wh; ++i)
            {
                for (int j = 0; j < wh; ++j)
                {
                    if (str[index] >= 'A' && str[index] <= 'Z')
                    {
                        res[i, j] = str[index] - 'A';

                    }
                    if (str[index] >= 'a' && str[index] <= 'z')
                    {
                        res[i, j] = str[index] - 'a';
                    }
                    index++;
                }

            }
            return res;
        }
        int[,] GetKeyMatrixDouble(string str)
        {
            int wh = (int)Math.Sqrt(str.Length);

            int[,] res = new int[wh, wh];
            int index = 0;


            for (int i = 0; i < wh; ++i)
            {
                for (int j = 0; j < wh; ++j)
                {
                    if (str[index] >= 'A' && str[index] <= 'Z')
                    {
                        res[j, i] = str[index] - 'A';

                    }
                    if (str[index] >= 'a' && str[index] <= 'z')
                    {
                        res[j, i] = str[index] - 'a';
                    }
                    index++;
                }

            }
            return res;
        }



        int[,] multiply(int[,] a, int[,] b)
        {

            int[,] c = new int[a.GetLength(0), b.GetLength(1)];

            for (int i = 0; i < c.GetLength(0); i++)
            {
                for (int j = 0; j < c.GetLength(1); j++)
                {
                    for (int k = 0; k < c.GetLength(0); k++)
                    {
                        c[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return c;
        }
        int[,] multiplyD(int[,] a, int[,] b)
        {

            int[,] c = new int[a.GetLength(0), b.GetLength(1)];

            for (int i = 0; i < c.GetLength(0); i++)
            {
                for (int j = 0; j < c.GetLength(1); j++)
                {
                    for (int k = 0; k < c.GetLength(0); k++)
                    {
                        c[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return c;
        }
        string ConvertVectorToString(int[,] cipher)
        {
            string res = "";
            for (int i = 0; i < cipher.GetLength(0); i++)
            {
                cipher[i, 0] += 65;
                res = res + (char)cipher[i, 0];
            }
            return res;
        }
        string ConvertVectorToString(double[,] cipher)
        {
            string res = "";
            for (int i = 0; i < cipher.GetLength(0); i++)
            {
                cipher[i, 0] += 65;
                res = res + (char)cipher[i, 0];
            }
            return res;
        }

        string ConvertMatToString(int[,] cipher)
        {
            string res = "";
            for (int i = 0; i < cipher.GetLength(0); i++)
            {
                for (int j = 0; j < cipher.GetLength(0); j++)
                {
                    cipher[i, j] += 'a';
                    res = res + (char)cipher[i, j];
                }
            }
            return res;
        }

        char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        string convertListTOstring(List<int> l)
        {
            string res = "";


            for (int i = 0; i < l.Count; i++)
            {

                int ind = l[i];
                res += alphabet[ind];
            }

            return res;
        }

        List<int> convertstringTOlist(string str)
        {
            List<int> res = new List<int>();


            for (int i = 0; i < str.Length; i++)
            {
                int charNum = str[i];

                charNum -= 'a';
                res.Add(charNum);
            }

            return res;

        }

        //====== generate determinant for a given cell
        int getDet(int x, int y, int[,] key, int Ksz)
        {
            if (Ksz == 2)
                return key[(x + 1) % 2, (y + 1) % 2];
            int x1 = (x + 1) % 3, x2 = (x + 2) % 3, y1 = (y + 1) % 3, y2 = (y + 2) % 3;
            int xMin = Math.Min(x1, x2), xMax = Math.Max(x1, x2), yMin = Math.Min(y1, y2), yMax = Math.Max(y1, y2);
            return (key[xMin, yMin] * key[xMax, yMax]) - (key[xMin, yMax] * key[xMax, yMin]);

        }

        //==== generate multiplicative inverse of the key
        int[,] keyInverse(int[,] key)
        {
            int[,] kInv;

            int detK = 0;
            if (key.GetLength(0) == 2)
                detK = (key[0, 0] * key[1, 1]) - (key[1, 0] * key[0, 1]);
            else
                detK = key[0, 0] * getDet(0, 0, key, key.GetLength(0)) - key[0, 1] * getDet(0, 1, key, key.GetLength(0)) + key[0, 2] * getDet(0, 2, key, key.GetLength(0));
            detK = ((detK % 26) + 26) % 26;
            int b;
            bool check = false;
            for (b = 1; b < 27; b++)
            {
                if ((b * detK) % 26 == 1)
                {
                    check = true;
                    break;
                }
            }

            if (!check) //====== no multiplicative inverse found
            {
                //throw new MatrixClassException("no multiplicative inverse found");
                //throw new InvalidAnlysisException();
            }

            //===== Apply rule kij ={b x (-1)i+j * Dij mod 26} mod 26
            kInv = new int[key.GetLength(0), key.GetLength(0)];
            int[,] tempK = new int[key.GetLength(0), key.GetLength(0)];

            for (int i = 0; i < key.GetLength(0); i++)
                for (int j = 0; j < key.GetLength(0); j++)
                    tempK[i, j] = (((b * ((i + j) % 2 == 1 ? -1 : 1) * getDet(i, j, key, key.GetLength(0))) % 26) + 26) % 26;

            //==== transpose of keyInv matrix
            for (int i = 0; i < key.GetLength(0); i++)
                for (int j = 0; j < key.GetLength(0); j++)
                    kInv[i, j] = tempK[j, i];

            return kInv;
        }


    }
}
