using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA_GUI
{
    class BigInt
    {
        //a list of bytes to hold the integers and potential characters in the future
        List<byte> _value;

        #region GetSet
        //index operator
        public int this[int key]
        {
            get
            {
                return (int)_value[key];
            }
            set
            {
                _value[key] = (byte)value;
            }
        }
        public int Length
        {
            get
            {
                if (_value != null)
                    return _value.Count;
                return 0;
            }
        }
        #endregion

        #region constructors
        //defualt constructor to initialize a new empty instance of the class
        public BigInt()
        {
            _value = new List<byte>();
        }
        public BigInt(int size)
        {
            _value = new List<byte>();
            for (int i = 0; i < size; i++)
                _value.Add(0);
        }
        #endregion


        #region arthimitic
        public static BigInt operator +(BigInt a, uint b)
        {
            BigInt bb = BigInt.parse(b);
            return a + bb;
        }
        public static BigInt operator +(BigInt a, ulong b)
        {
            BigInt bb = BigInt.parse(b);
            return a + bb;
        }
        public static BigInt operator +(uint a, BigInt b)
        {
            BigInt aa = BigInt.parse(a);
            return aa + b;
        }
        public static BigInt operator +(ulong a, BigInt b)
        {
            BigInt aa = BigInt.parse(a);
            return aa + b;
        }
        // YOUR CODE GOES HERE
        public static BigInt operator +(BigInt a, BigInt b)
        {
            int maxS = Math.Max(a.Length, b.Length);
            BigInt res = new BigInt();
            int al = a.Length;
            int bl = b.Length;
            int carry = 0;
            int i = 0;
            for (; i < maxS || carry > 0; i++)
            {
                int newdig = carry;
                if (al - i - 1 >= 0)
                    newdig += (int)a[al - i - 1];
                if (bl - i - 1 >= 0)
                    newdig += (int)b[bl - i - 1];
                res._value.Add((byte)(newdig % 10));
                carry = newdig / 10;
            }
            res._value.Reverse();
            return res;
        }
        public static BigInt operator -(BigInt a, uint b)
        {
            BigInt bb = BigInt.parse(b);
            return a - bb;
        }
        public static BigInt operator -(BigInt a, ulong b)
        {
            BigInt bb = BigInt.parse(b);
            return a - bb;
        }
        public static BigInt operator -(uint a, BigInt b)
        {
            BigInt aa = BigInt.parse(a);
            return aa - b;
        }
        public static BigInt operator -(ulong a, BigInt b)
        {
            BigInt aa = BigInt.parse(a);
            return aa - b;
        }
        public static BigInt operator -(BigInt a, BigInt b)
        {
            //always subtract the small integer from the bigger
            if (a < b)
            {
                BigInt tmp = a;
                a = b;
                b = tmp;
            }

            BigInt res = new BigInt();
            int al = a.Length;
            int bl = b.Length;
            int carry = 0;
            for (int i = 0; i < al || carry > 0; i++)
            {
                int dig = carry;
                if (al - i - 1 >= 0)
                    dig += (int)a[al - i - 1];
                if (bl - i - 1 >= 0)
                    dig -= (int)b[bl - i - 1];
                if (dig < 0)
                {
                    res._value.Add((byte)(10 + dig));
                    carry = -1;
                }
                else
                {
                    res._value.Add((byte)dig);
                    carry = 0;
                }
            }
            if (carry != 0)
                res._value.Add((byte)(10 + carry));
            res._value.Reverse();
            return BigInt.parse(res._value.ToArray());
        }
        public static BigInt operator /(BigInt a, BigInt b)
        {
            // YOUR DIV CODE GOES HERE -> SAAD & ARAFA 
            BigInt q, r;
            ImprovedDivision(a, b, out q, out r);

            return q;
        }
        public static BigInt operator /(BigInt a, int b)
        {
            // YOUR DIV CODE GOES HERE -> SAAD & ARAFA 
            return a / BigInt.parse((uint)b);
        }
        public static BigInt operator /(int a, BigInt b)
        {
            // YOUR DIV CODE GOES HERE -> SAAD & ARAFA 
            return BigInt.parse((uint)a) / b;
        }
        public static BigInt operator %(BigInt a, BigInt b)
        {
            BigInt q, r;
            divide(a, b, out q, out r);
            return r;
        }
        public static BigInt operator %(BigInt a, int b)
        {
            BigInt q, r;
            divide(a, BigInt.parse((uint)b), out q, out r);
            return r;
        }
        public static BigInt operator %(int a, BigInt b)
        {
            BigInt q, r;
            divide(BigInt.parse((uint)a), b, out q, out r);
            return r;
        }
        public static BigInt operator *(BigInt a, BigInt b)
        {
            return karatsuba(a, b);
        }
        public static BigInt operator *(BigInt a, int b)
        {
            return karatsuba(a, BigInt.parse((uint)b));
        }
        public static BigInt operator *(BigInt a, long b)
        {
            return karatsuba(a, BigInt.parse((ulong)b));
        }
        public static BigInt operator *(int a, BigInt b)
        {
            return karatsuba(BigInt.parse((uint)a), b);
        }
        public static BigInt operator *(long a, BigInt b)
        {
            return karatsuba(b, BigInt.parse((ulong)a));
        }
        #endregion
        #region comparison
        public static bool operator <(BigInt a, uint b)
        {
            return a < BigInt.parse(b);
        }
        public static bool operator <(uint a, BigInt b)
        {
            return BigInt.parse(a) < b;
        }
        public static bool operator <(BigInt a, ulong b)
        {
            return a < BigInt.parse(b);
        }
        public static bool operator <(ulong a, BigInt b)
        {
            return BigInt.parse(a) < b;
        }
        public static bool operator <(BigInt a, BigInt b)
        {
            int al = a.Length;
            int bl = b.Length;
            if (al < bl)
                return true;
            else if (al > bl)
                return false;
            else
            {
                for (int i = 0; i < al; i++)
                    if (a[i] > b[i])
                        return false;
                    else if (a[i] < b[i])
                        return true;
            }
            return false;
        }
        public static bool operator >(BigInt a, uint b)
        {
            return a > BigInt.parse(b);
        }
        public static bool operator >(uint a, BigInt b)
        {
            return BigInt.parse(a) > b;
        }
        public static bool operator >(BigInt a, ulong b)
        {
            return a > BigInt.parse(b);
        }
        public static bool operator >(ulong a, BigInt b)
        {
            return BigInt.parse(a) > b;
        }
        public static bool operator >(BigInt a, BigInt b)
        {
            int al = a.Length;
            int bl = b.Length;
            if (al < bl)
                return false;
            else if (al > bl)
                return true;
            else
            {
                for (int i = 0; i < al; i++)
                    if (a[i] > b[i])
                        return true;
                    else if (a[i] < b[i])
                        return false;
            }
            return false;
        }
        #endregion
        #region equal_operator
        //OPERATOR ==, !=
        public static bool operator ==(uint a, BigInt b)
        {
            return BigInt.parse(a) == b;
        }
        public static bool operator !=(uint a, BigInt b)
        {
            return !(BigInt.parse(a) == b);
        }
        public static bool operator ==(ulong a, BigInt b)
        {
            return BigInt.parse(a) == b;
        }
        public static bool operator !=(ulong a, BigInt b)
        {
            return !(BigInt.parse(a) == b);
        }
        public static bool operator !=(BigInt a, uint b)
        {
            return !(a == BigInt.parse(b));
        }
        public static bool operator ==(BigInt a, uint b)
        {
            return a == BigInt.parse(b);
        }
        public static bool operator !=(BigInt a, ulong b)
        {
            return !(a == BigInt.parse(b));
        }
        public static bool operator ==(BigInt a, ulong b)
        {
            return a == BigInt.parse(b);
        }
        public static bool operator ==(BigInt a, BigInt b)
        {
            if (a.Length != b.Length)
                return false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    return false;
            }
            return true;
        }
        public static bool operator !=(BigInt a, BigInt b)
        {
            return !(a == b);
        }
        #endregion
        #region equalor
        // OPERATOR >=, <=
        public static bool operator >=(BigInt a, BigInt b)
        {
            return a == b || a > b;
        }
        public static bool operator <=(BigInt a, BigInt b)
        {
            return a == b || a < b;
        }
        public static bool operator >=(uint a, BigInt b)
        {
            return a == b || a > b;
        }
        public static bool operator <=(uint a, BigInt b)
        {
            return a == b || a < b;
        }
        public static bool operator <=(BigInt a, uint b)
        {
            return a == b || a < b;
        }
        public static bool operator >=(BigInt a, uint b)
        {
            return a == b || a > b;
        }
        public static bool operator >=(ulong a, BigInt b)
        {
            return a == b || a > b;
        }
        public static bool operator <=(ulong a, BigInt b)
        {
            return a == b || a < b;
        }
        public static bool operator <=(BigInt a, ulong b)
        {
            return a == b || a < b;
        }
        public static bool operator >=(BigInt a, ulong b)
        {
            return a == b || a > b;
        }
        #endregion
        #region shifting
        public static BigInt operator <<(BigInt a, int b)
        {
            return shiftLeft(a, b);
        }
        public static BigInt operator >>(BigInt a, int b)
        {
            //return shiftRight(a, b);
            return BigInt.parse(0);
        }
        #endregion

        #region Helper
        public static BigInt pow(BigInt num, int p)
        {
            return pow(num, BigInt.parse((uint)p));
        }
        public static BigInt powMod(BigInt num, BigInt p, BigInt n)
        {
            //return BigInt.pow(num, p) % n;
            if (p == BigInt.parse(0))
                return BigInt.parse(1) % n; //base case of dividing
            if (p == BigInt.parse(1))
                return num % n; //the division algorithm

            BigInt ans;
            if (BigInt.isEven(p))
            {
                //calculating the result of p/2 if Integer is Even
                ans = powMod(num, p / 2, n);
                ans = ans * ans;
            }
            else
            {
                //calculating the result of the odd part
                ans = powMod(num, (p - 1) / 2, n);
                ans = ans * ans * num % n;
            }
            return ans % n;
        }
        public static BigInt ImprovedPowMod(BigInt num, BigInt p, BigInt n)
        {
            BigInt res = BigInt.parse(1);
            BigInt pC = BigInt.asBytes(p.toArray());
            BigInt basi = BigInt.asBytes(num.toArray()) % n;
            while (pC > 0)
            {
                if(BigInt.isOdd(pC))
                    res = (res*basi)%n;
                basi = (basi*basi) %n;
                pC /= 2;
            }
            return res;
        }
        public static BigInt pow(BigInt num, BigInt p)
        {
            if (p == BigInt.parse(0))
                return BigInt.parse(1);
            if (p == BigInt.parse(1))
                return num;
            BigInt ans;
            if (BigInt.isEven(p))
            {
                ans = pow(num, p / 2);
                ans = ans * ans;
            }
            else
            {
                ans = pow(num, (p - 1) / 2);
                ans = ans * ans * num;
            }
            return ans;
        }
        public static BigInt DumpMultiplication(BigInt a, int b)
        {
            BigInt res = BigInt.parse(0);
            while (b > 0)
            {
                b--;
                res += a;
            }
            return res;
        }
        private static BigInt karatsuba(BigInt a, BigInt b)
        {
            int aLen = a.Length;
            int bLen = b.Length;
            if (aLen == 1 && bLen == 1)
            {
                int ans = a[0] * b[0]; // O(1)
                return BigInt.parse((uint)ans);
            }
            if (aLen == 1 || bLen == 1)
            {
                //Dump Multiplication is just adding the number N times N has a limit of 9 since it's one digit
                if (aLen == 1)
                    return DumpMultiplication(b, a[0]); //O(N)
                else if (bLen == 1)
                    return DumpMultiplication(a, b[0]);
            }

            //getting the maximum length of the two
            int MaximumLength = Math.Max(aLen, bLen);
            //setting the half to Maximum/2 and if odd add one to it
            int half = MaximumLength / 2 + (MaximumLength & 1);

            //splitting the numbers to higher and lower
            //higher = number // 10^m
            //lower = number % 10^m
            var aHigh = a.getUpper(half);
            var aLow = a.getLower(half);
            var bHigh = b.getUpper(half);
            var bLow = b.getLower(half);

            //making the three multiplcations
            var z0 = karatsuba(aLow, bLow); 
            var z2 = karatsuba(aHigh, bHigh);
            var z1 = karatsuba(aLow + aHigh, bLow + bHigh) - z2 - z0;

            //the adding equations
            //punchZeros just adding zeros to the end of the number
            var res = BigInt.punchZeros(z2, 2 * half); //O(N) where N is the number of Zeros
            res += BigInt.punchZeros(z1, half);
            res += z0;
            return BigInt.parse(res._value.ToArray());
        }
        private BigInt getLower(int n)
        {
            int len = this.Length;
            if (len <= n)
                return this;
            byte[] lower = new byte[n];
            Array.Copy(_value.ToArray(), len - n, lower, 0, n);
            return BigInt.parse(lower);
        }
        private BigInt getUpper(int n)
        {
            int len = this.Length;
            if (len <= n)
                return BigInt.parse(0);
            int upperLen = len - n;
            byte[] upperInts = new byte[upperLen];
            Array.Copy(_value.ToArray(), 0, upperInts, 0, upperLen);
            return BigInt.parse(upperInts);
        }
        private static BigInt punchZeros(BigInt a, int n)
        {
            while (n > 0)
            {
                n--;
                a._value.Add(0);
            }
            return a;
        }
        private static BigInt shiftLeft(BigInt mag, int n)
        {
            int nInts = n >> 5;
            int nBits = n & 0x1f;
            int magLen = mag.Length;
            BigInt newMag = null;
            if (nBits == 0)
            {
                byte[] newarr = new byte[magLen + nInts];
                Array.Copy(mag._value.ToArray(), 0, newarr, 0, magLen);
                newMag = BigInt.parse(newarr);
            }
            else
            {
                int i = 0;
                int nBits2 = 32 - nBits;
                int highBits = mag[0] >> nBits2;
                if (highBits != 0)
                {
                    newMag = new BigInt(magLen + nInts + 1);
                    newMag[i++] = highBits;
                }
                else
                {
                    newMag = new BigInt(magLen + nInts);
                }
                int j = 0;
                while (j < magLen - 1)
                    newMag[i++] = mag[j++] << nBits | mag[j] >> nBits2;
                newMag[i] = mag[j] << nBits;
            }
            return newMag;
        }
        public static bool isEven(BigInt v)
        {
            // YOUR EVEN/ODD CODE GOES HERE -> SAAD & ARAFA
            if (v == 0)
                return true;
            if (v._value.Count == 0)                                //If the list is empty, return false
                return false;
            byte least_significant = v._value[v._value.Count - 1];  //Least signficant digit
            if ((least_significant & (byte)1) == (byte)1)           //If LSD is odd, then the number is odd
                return false;
            return true;
        }
        public static bool isOdd(BigInt v)
        {
            // YOUR EVEN/ODD CODE GOES HERE -> SAAD & ARAFA
            if (v == 0)
                return false;
            if (v._value.Count == 0)
                return false;
            byte least_significant = v._value[v._value.Count - 1];
            if ((least_significant & (byte)1) == (byte)1)
                return true;
            return false;
        }

        //divide function
        static void divide(BigInt a, BigInt b, out BigInt q, out BigInt r)
        {
            //base case if b is > a -- O(n)
            if (a < b) //O(n)
            {
                q = BigInt.parse("0");
                r = a;
                return;
            }

            //recursion of the current algorithm with 2b -- addition = O(n)
            divide(a, b + b, out q, out r);

            //addition O(n)
            q = q + q;

            
            if (r < b) //O(n)
                return;
            else
            {
                q = q + 1; //O(n)
                r = r - b; //O(n)
                return;
            }

        }
        //improved divide function
        static void ImprovedDivision(BigInt a, BigInt b, out BigInt q, out BigInt r)
        {
            int meaw = 0;
            if (b == 0)
                meaw /= meaw;

            BigInt tmp = BigInt.parse(0);
            BigInt aC = BigInt.asBytes(a.toArray());
            //aC._value.Reverse();
            for (int i = 0; i < a.Length; i++)
            {
                tmp *= 10;
                tmp += (uint)aC[i];
                aC[i] = 0;
                while (tmp >= b)
                {
                    tmp -= b;
                    aC[i] = aC[i] + 1;
                }
            }
            q = BigInt.parse(aC.toArray());
            r = tmp;
        }
        //to cast BigInt into string for writing on screen
        public override string ToString()
        {
            string ret = "";
            for (int i = 0; i < _value.Count; i++)
            {
                ret += (char)(_value[i] + '0');
            }
            return ret;
        }
        private static int getinty(BigInt num)
        {
            return int.Parse(num.ToString());
        }
        public string asString()
        {
            string res = "";
            BigInt tmp = new BigInt();
            BigInt taste = new BigInt();
            BigInt chsz = BigInt.parse(256);
            int cursor = 0;
            while (cursor < _value.Count)
            {
                taste._value.Add(_value[cursor]);
                if (taste >= chsz)
                {
                    res += (char)BigInt.getinty(tmp);
                    tmp._value.Clear();
                    taste._value.Clear();
                    taste._value.Add(_value[cursor]);
                    tmp._value.Add(_value[cursor]);
                }
                else
                {
                    tmp._value.Add(_value[cursor]);
                }
                cursor++;
            }
            if (taste.Length != 0)
                res += (char)BigInt.getinty(taste);
            return res;
        }
        public byte[] toArray()
        {
            return _value.ToArray();
        }
        #endregion

        #region parsing
        public static BigInt text(string val)
        {
            BigInt ret = new BigInt();
            var arr = Encoding.ASCII.GetBytes(val);
            for (int i = 0; i < arr.Length; i++)
            {
                List<byte> mybit = new List<byte>();
                byte b = arr[i];
                while (b > 0)
                {
                    mybit.Add((byte)(b % 10));
                    b /= 10;
                }
                mybit.Reverse();
                ret._value.AddRange(mybit);
            }
            return ret;
        }
        public static BigInt asBytes(byte[] val)
        {
            BigInt res = new BigInt();
            res._value.AddRange(val);
            return res;
        }
        //function to try parsing the value from a string
        public static BigInt parse(string val)
        {
            BigInt ret = new BigInt();
            bool nonZero = false;
            for (int i = 0; i < val.Length; i++)
            {
                if (char.IsDigit(val[i]))
                {
                    if (val[i] == '0')
                    {
                        if (nonZero)
                            ret._value.Add((byte)(val[i] - '0'));
                    }
                    else
                    {
                        ret._value.Add((byte)(val[i] - '0'));
                        nonZero = true;
                    }

                }
            }
            if (ret.Length == 0)
                ret._value.Add(0);
            return ret;
        }
        public static BigInt parse(byte[] val)
        {
            BigInt ret = new BigInt();
            bool nonZero = false;
            for (int i = 0; i < val.Length; i++)
            {
                if (val[i] == 0)
                {
                    if (nonZero)
                        ret._value.Add(val[i]);
                }
                else
                {
                    ret._value.Add(val[i]);
                    nonZero = true;
                }
            }
            if (ret.Length == 0)
                ret._value.Add(0);
            return ret;
        }
        public static BigInt parse(uint val)
        {
            BigInt ret = new BigInt();
            while (val != 0)
            {
                ret._value.Add((byte)(val % 10));
                val /= 10;
            }
            ret._value.Reverse();
            if (ret.Length == 0)
                ret._value.Add(0);
            return ret;
        }
        public static BigInt parse(ulong val)
        {
            BigInt ret = new BigInt();
            while (val != 0)
            {
                ret._value.Add((byte)(val % 10));
                val /= 10;
            }
            ret._value.Reverse();
            if (ret.Length == 0)
                ret._value.Add(0);
            return ret;
        }
        #endregion
    }
}
