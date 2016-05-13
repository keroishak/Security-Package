using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class Monoalphabetic : ICryptographicTechnique<string, string>
    {
        char[] charsToCharsMap = new char[26];

        char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };


        public string Analyse(string plainText, string cipherText)
        {
            //throw new NotImplementedException();          
           /*
            plainText = plainText.ToUpper();
            cipherText = cipherText.ToUpper();

            int deff = Math.Abs(plainText[0] - cipherText[0]);

            char[] key = ShiftList(deff);

            string res_key = null;
            for (int i = 0; i < key.Length; ++i)
            {
                res_key = string.Concat(res_key, key[i]);
            }
            
            return res_key;*/
            HashSet<char> NotUsedChars = new HashSet<char>(alphabet);

            char []key = new char[26];
            char tmp;
            for (int i = 0; i < plainText.Length; ++i)
            {
                tmp=char.ToLower(cipherText[i]);
                key[plainText[i] - 'a'] = tmp;
                NotUsedChars.Remove(tmp);
            }
           // int tmp;
            char lastchar = 'a';
            for (int i = 0; i < 26; ++i)
            {
                if (key[i] == 0)
                {
                    //tmp=key[i]-'a';
                    while (!NotUsedChars.Contains(lastchar))
                    {
                        ++lastchar;
                        if(lastchar>'z')
                        lastchar = 'a';
                    }
                        NotUsedChars.Remove(lastchar);
                    key[i] = lastchar;                  
                }
                lastchar = key[i];
            }
            string res="";
            for (int i = 0; i < 26; ++i)
                res += key[i];

                return res;
        }

        char[] ShiftList(int num_shift)
        {
            int k = num_shift;
            char[] ar1 = alphabet.Skip(k).Concat(alphabet.Take(k)).ToArray();

            return ar1;
        }

        public string Decrypt(string cipherText, string key)
        {
            // throw new NotImplementedException();

            string output = "";


            StringBuilder tmp = new StringBuilder(cipherText);
            for (int i = 0; i < tmp.Length; i++)
            {
                if ((int)tmp[i] > 64 && (int)tmp[i] < 91)
                    tmp[i] += (char)32;
            }
            cipherText = tmp.ToString();


            for (int i = 0; i < cipherText.Length; i++)
            {
                char res = 'a';
                for (int j = 0; j < 26; j++)
                {
                    if (cipherText[i] == key[j])
                        break;
                    res++;
                }
                output += res;
            }

            return output;
        }

        public string Encrypt(string plainText, string key)
        {
            //throw new NotImplementedException();

            string output = "";


            for (int i = 0; i < 26; i++)
                charsToCharsMap[i] = key[i];

            StringBuilder tmp = new StringBuilder(plainText);

            for (int i = 0; i < tmp.Length; i++)
            {
                if ((int)tmp[i] > 64 && (int)tmp[i] < 91)
                    tmp[i] += (char)32;
            }
            plainText = tmp.ToString();


            for (int i = 0; i < plainText.Length; i++)
            {
                output += charsToCharsMap[(int)plainText[i] - 97];
            }

            return output;
        }

        /// <summary>
        /// Frequency Information:
        /// E   12.51%/
        /// T	9.25/
        /// A	8.04/
        /// O	7.60/
        /// I	7.26/
        /// N	7.09/
        /// S	6.54/
        /// R	6.12/
        /// H	5.49/
        /// L	4.14/
        /// D	3.99/
        /// C	3.06/
        /// U	2.71/
        /// M	2.53/
        /// F	2.30/
        /// P	2.00/
        /// G	1.96/
        /// W	1.92/
        /// Y	1.73/
        /// B	1.54/
        /// V	0.99/
        /// K	0.67/
        /// X	0.19/
        /// J	0.16/
        /// Q	0.11/
        /// Z	0.09
        /// </summary>
        /// <param name="cipher"></param>
        /// <returns>Plain text</returns>
        public string AnalyseUsingCharFrequency(string cipher)
        {

            double[] frqInfo = { 8.04, 1.54, 3.06, 3.99, 12.51, 2.30, 1.96, 5.49, 7.26, 0.16, 0.67, 4.14, 
                2.53,7.09,7.60,2.00,0.11,6.12,6.54,9.25,2.71,0.99,1.92,0.19,1.73,0.09};
            List<Tuple< char, double>> freq = new List<Tuple< char, double>>();
            List<Tuple< char, double>> cipherfreq = new List<Tuple< char, double>>();
            
            double []distribution=new double[26];
            cipher = cipher.ToLower();
            for (int i = 0; i < cipher.Length; ++i)
                ++distribution[cipher[i]-'a'];

            for (int i = 0; i < 26; ++i)
                distribution[i] =(distribution[i]/ cipher.Length)*100.0;
            for (int i = 0; i < 26; ++i)
            {
                freq.Add(Tuple.Create( Convert.ToChar('a' + i),frqInfo[i]));
                cipherfreq.Add(Tuple.Create(Convert.ToChar('a' + i),Math.Round(distribution[i],2)));
            }
            freq.Sort((x,y)=>x.Item2.CompareTo(y.Item2));
            cipherfreq.Sort((x, y) => x.Item2.CompareTo(y.Item2));
            Dictionary<char, char> pair = new Dictionary<char, char>();
            
            for (int i=0;i<26;++i)
            {
                pair.Add(cipherfreq[i].Item1, freq[i].Item1);
            }
            string res = "";
            for (int i = 0; i < cipher.Length; ++i)
                res += pair[cipher[i]];
           
            return res;
        }
    }
}
