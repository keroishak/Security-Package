using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class Columnar : ICryptographicTechnique<string, List<int>>
    {
        private List<string> PlaintoList(string pt, int key)
        {
            int rows = pt.Length / key + (pt.Length % key == 0 ? 0 : 1);
            int columns = key;
            string input = pt;
            int rem = (key - (pt.Length % key)) % key;
            for (int i = 0; i < rem; i++)
            {
                input += 'x';
            }
            input = input.ToUpper();
            char[,] PT = new char[rows, columns];
            List<string> PTlist = new List<string>();
            int ind = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    PT[i, j] = input[ind++];
                }
            }
            for (int i = 0; i < columns; i++)
            {
                string s = "";
                for (int j = 0; j < rows; j++)
                {
                    s += PT[j, i];
                }
                PTlist.Add(s);
            }
            
            return PTlist;
        }

        private List<string> ciphertoList(string ct, int key)
        {
            int rows = ct.Length / key + (ct.Length % key == 0 ? 0 : 1);
            int columns = key;
            int height = rows;
            rows = columns;
            columns = height;
            string input = ct;
            int rem = (key - (ct.Length % key)) % key;
            for (int i = 0; i < rem; i++)
            {
                input += 'X';
            }
            input = input.ToUpper();
            char[,] PT = new char[rows, columns];
            List<string> CTlist = new List<string>();
            int ind = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    PT[i, j] = input[ind++];
                }
            }
            for (int i = 0; i < rows; i++)
            {
                string s = "";
                for (int j = 0; j < columns; j++)
                {
                    s += PT[i, j];
                }
                CTlist.Add(s);
            }

            return CTlist;
        }

        private bool firstisfound(List<string> PTlist, List<string> CTlist)
        {
            for (int i = 0; i < CTlist.Count; i++)
            {
                if (PTlist[0] == CTlist[i])
                {
                    return true;
                }
            }
            return false;
        }
        
        public List<int> Analyse(string plainText, string cipherText)
        {
            bool hasx = true;
            plainText = plainText.ToUpper();
            if (plainText.Length < cipherText.Length)
            {
                while (plainText.Length != cipherText.Length)
                {
                    plainText += 'X';
                    hasx = true;
                }
            }
            else if (plainText.Length > cipherText.Length)
            {
                while (plainText.Length != cipherText.Length)
                {
                    plainText = plainText.Remove(plainText.Length - 1);
                    hasx = false;
                }
            }
            List<string> PTlist = new List<string>();
            List<string> CTlist = new List<string>();
            List<int> keys = new List<int>();
            bool start = false;
            for (int key = 2; key < plainText.Length; key++)
            {
                PTlist = PlaintoList(plainText, key);
                CTlist = ciphertoList(cipherText, key);
                keys = new List<int>();

                bool compelete = true;
                if (firstisfound(PTlist,CTlist))
                {
                    start = true;
                    for (int i = 0; i < PTlist.Count; i++)
                    {
                        bool found = false;
                        for (int j = 0; j < CTlist.Count; j++)
                        {
                            if (CTlist[j] == PTlist[i])
                            {
                                keys.Add(j+1);
                                found = true;
                            }
                        }
                        if (found == false)
                        {
                            compelete = false;
                            break;
                        }
                    }
                }
                if (compelete && start)
                {
                    break;
                }
            }
            return keys;
            
        }

        public string Decrypt(string cipherText, List<int> key)
        {
            int rows = cipherText.Length / key.Count + (cipherText.Length % key.Count == 0 ? 0 : 1);
            int columns = key.Count;
            int rem = (key.Count - (cipherText.Length % key.Count)) % key.Count;
            string input = cipherText;
            for (int i = 0; i < rem; i++)
            {
                input += 'X';
            }
            string [] vertical = new string[columns];
            int ind = 0;
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                vertical[ind] += input[i];
                count++;
                if (count % rows == 0)
                {
                    ind++;
                    count = 0;
                }
            }

            string PT = "";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    PT += vertical[key[j] - 1][i];
                }
            }
            if(rem == 0 && PT[PT.Length-1] == 'X')
                for (int i = PT.Length - 1; i > -1 && PT[PT.Length - 1] == 'X'; i--)
                {
                    if (PT[i] == 'X')
                        PT = PT.Remove(i);
                }
            return PT.ToLower();
        }

        public string Encrypt(string plainText, List<int> key)
        {
            int rows = plainText.Length / key.Count + (plainText.Length % key.Count == 0 ? 0 : 1);
            int columns = key.Count;
            string input = plainText;
            int rem = (key.Count - (plainText.Length % key.Count)) % key.Count;
            for (int i = 0; i < rem; i++)
            {
                input += 'x';
            }
            input = input.ToUpper();
            char[,] PT = new char[rows,columns];
            int ind = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    PT[i, j] = input[ind++];
                }
            }
            string []results = new string[columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    results[key[j]-1] += PT[i,j];
                }
            }
            string res = "";
            for (int i = 0; i < columns; i++)
            {
                res += results[i];
            }

            return res;
        }
    }
}
