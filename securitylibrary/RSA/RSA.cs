using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSA_GUI;

namespace SecurityLibrary.RSA
{
    public class RSA
    {
        /* 
         * modulo inverse of an integer (a%m) = x such that a^-1 = x % m
         * => a * x = a * (a^-1) = 1 % m
         * modulo inverse exists iff a & m is coprime => gcd(a, m) = 1
         * 
         * Bezout's identity:
         * let a and b be nonzero integers and let d be their gcd then there
         * exist integers x and y such that
         * => a*x + b*y = d
         * 
         * Extended Euclidean Algorithm:
         * an extension to Euclid algorithm it doesn't find only gcd for two numbers
         * but also the Bezout coffeicients (x, y)
         * 
         */

        //Brute-force Method: tries every possible value for x
        private static int BFmodInv(int a, int m)
        {
            a %= m;
            for(int x = 1; x < m; ++x)
                if ((a*x)%m == 1)
                    return x;
            return 0;
        }

        /* 
         * Recursive Extended Euclidan
         * a*x + b*y = d
         * if a = 0:
         * then the gcd is b and there will be nothing of a and exactly one of b
         * else:
         * b/a = q and r where q is quotient and r is reminder
         * recursivly find s, t such that
         * => r*t + b*s = number that divides both b and r
         * so
         * y = t and x = s - qt
         */
        private static int exEuclid(int a, int b, ref int x, ref int y)
        {
            if (a == 0)
            {
                x = 0;
                y = 1;
                return b;
            }
            //      t                 s
            int recursive_x = -1, recursive_y = -1;
            int gcd = exEuclid(b%a, a, ref recursive_x, ref recursive_y);

            x = recursive_y - recursive_x*(b/a);
            y = recursive_x;
            return gcd;
        }

        /*
         * ModInverse using exEuclid
         */
        int EXmodInv(int a, int m)
        {
            int x = 0, y = 0;
            exEuclid(a, m, ref x, ref y);
            return (x + m) % m;
        }

        private static long powMod(long num, long power, long n)
        {
            if (power == 0)
                return 1;
            if (power == 1)
                return num % n;

            long answer = 0;
            if (power % 2 == 0)
            {
                answer = powMod(num, power / 2, n);
                answer = answer * answer;
            }
            else
            {
                answer = powMod(num, (power - 1) / 2, n);
                answer = (answer * answer * num) % n;
            }
            return answer % n;
        }

        public string Encrypt(int p, int q, string M, int e)
        {
            var n = p * q;
            string msgChunckStr = "";
            string result = "";
            for (int i = 0; i < M.Length; i++)
            {
                msgChunckStr += M[i];
                var msgChunckCheck = BigInt.text(msgChunckStr);
                if (msgChunckCheck >= BigInt.parse(q.ToString()))
                {
                    if (msgChunckStr.Length > 1)
                    {
                        i--;
                        result += RSA_GUI.BigInt.powMod(
                            BigInt.text(msgChunckStr.Substring(0, msgChunckStr.Length - 1)), BigInt.parse(e.ToString()),
                            BigInt.parse(n.ToString())) + " ";
                    }
                    else
                        result += RSA_GUI.BigInt.powMod(BigInt.text(msgChunckStr.Substring(0, msgChunckStr.Length)),
                            BigInt.parse(e.ToString()), BigInt.parse(n.ToString())) + " ";
                    msgChunckStr = "";
                }
            }
            if(msgChunckStr.Length != 0)
                result += RSA_GUI.BigInt.powMod(BigInt.text(msgChunckStr), BigInt.parse(e.ToString()), BigInt.parse(n.ToString()));
            return result;
        }

        public byte[] Decrypt(int p, int q, string C, int e)
        {
            var n = p * q;
            var phin = (p - 1) * (q - 1);
            var d = EXmodInv(e, phin);

//            string msgChunckStr = "";
//            for (int i = 0; i < C.Length; i++)
//            {
//                msgChunckStr += C[i];
//                var msgChunckCheck = BigInt.parse(msgChunckStr);
//                if (msgChunckCheck >= BigInt.parse(q.ToString()))
//                {
//                    i--;
//                    result += RSA_GUI.BigInt.powMod(BigInt.text(msgChunckStr.Substring(0, msgChunckStr.Length - 1)), BigInt.parse(d.ToString()), BigInt.parse(n.ToString()));
//                    msgChunckStr = "";
//                }
//            }
//            if (msgChunckStr.Length != 0)
            var result = RSA_GUI.BigInt.powMod(BigInt.parse(C), BigInt.parse(d.ToString()), BigInt.parse(n.ToString()));
            return result.toArray();
        }

        public int Encrypt(int p, int q, int M, int e)
        {
            var n = p * q;
//            var res = RSA_GUI.BigInt.powMod(BigInt.parse(M.ToString()), BigInt.parse(e.ToString()),
//                BigInt.parse(n.ToString()));
//            return int.Parse(res.ToString());
            return (int)powMod((long)M, (long)e, (long)n);
        }

        public int Decrypt(int p, int q, int C, int e)
        {
            var n = p * q;
            var phin = (p - 1) * (q - 1);
            var d = EXmodInv(e, phin);
//            var res = RSA_GUI.BigInt.powMod(BigInt.parse(C.ToString()), BigInt.parse(d.ToString()),
//                BigInt.parse(n.ToString()));
//            return int.Parse(res.ToString());
            return (int)powMod((long)C, (long)d, (long)n);
        }
    }
}
