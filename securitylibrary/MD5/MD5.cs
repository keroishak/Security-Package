using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using word = System.UInt32;

namespace SecurityLibrary.MD5
{
    public class MD5
    {
        private static word ROTATE_LEFT(word x, int n)
        {
            return ((x << n) | (x >> (32 - n)));
        }

        private static void readAsWords(word[] output, byte[] input, word inputOffset)
        {
            for (word i = 0, j = 0; j < output.Length * 4; i++, j += 4)
            {
                output[i] = ((word)input[inputOffset + j]) |
                    (((word)input[inputOffset + j + 1]) << 8) |
                    (((word)input[inputOffset + j + 2]) << 16) |
                    (((word)input[inputOffset + j + 3]) << 24);
            }
        }

        private static void readAsBytes(byte[] output, word[] input)
        {
            for (word i = 0, j = 0; j < output.Length; i++, j += 4)
            {
                output[j] = (byte)(input[i] & 0xff);
                output[j + 1] = (byte)((input[i] >> 8) & 0xff);
                output[j + 2] = (byte)((input[i] >> 16) & 0xff);
                output[j + 3] = (byte)((input[i] >> 24) & 0xff);
            }
        }

        private static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        private class Context
        {
            public readonly word[] State;
            public readonly word[] Buffer;

            public Context()
            {
                State = new word[4];
                Buffer = new word[16];
            }

            public void Clear()
            {
                Array.Clear(State, 0, State.Length);
                Array.Clear(Buffer, 0, Buffer.Length);
            }
        }

        private const int S11 = 7;
        private const int S12 = 12;
        private const int S13 = 17;
        private const int S14 = 22;

        private const int S21 = 5;
        private const int S22 = 9;
        private const int S23 = 14;
        private const int S24 = 20;

        private const int S31 = 4;
        private const int S32 = 11;
        private const int S33 = 16;
        private const int S34 = 23;

        private const int S41 = 6;
        private const int S42 = 10;
        private const int S43 = 15;
        private const int S44 = 21;

        private static word F(word x, word y, word z)
        {
            return ((x & y) | ((~x) & z));
        }

        private static word G(word x, word y, word z)
        {
            return ((x & z) | (y & (~z)));
        }

        private static word H(word x, word y, word z)
        {
            return x ^ y ^ z;
        }

        private static word I(word x, word y, word z)
        {
            return y ^ (x | ~z);
        }

        private static void FFunc(ref word a, word b, word c, word d, word m, word tableVal, int s)
        {
            a += F(b, c, d) + m + tableVal;
            a = ROTATE_LEFT(a, s);
            a += b;
        }

        private static void GFunc(ref word a, word b, word c, word d, word m, word tableVal, int s)
        {
            a += G(b, c, d) + m + tableVal;
            a = ROTATE_LEFT(a, s);
            a += b;
        }

        private static void HFunc(ref word a, word b, word c, word d, word m, word tableVal, int s)
        {
            a += H(b, c, d) + m + tableVal;
            a = ROTATE_LEFT(a, s);
            a += b;
        }

        private static void IFunc(ref word a, word b, word c, word d, word m, word tableVal, int s)
        {
            a += I(b, c, d) + m + tableVal;
            a = ROTATE_LEFT(a, s);
            a += b;
        }

        private static void init(Context context)
        {
            context.State[0] = 0x67452301;
            context.State[1] = 0xefcdab89;
            context.State[2] = 0x98badcfe;
            context.State[3] = 0x10325476;
        }

        private static void update(Context context, byte[] input, word inputOffset)
        {
            readAsWords(context.Buffer, input, inputOffset);


            word a = context.State[0], b = context.State[1], c = context.State[2], d = context.State[3];

            //Round One
            FFunc(ref a, b, c, d, context.Buffer[0], 0xd76aa478, S11);
            FFunc(ref d, a, b, c, context.Buffer[1], 0xe8c7b756, S12);
            FFunc(ref c, d, a, b, context.Buffer[2], 0x242070db, S13);
            FFunc(ref b, c, d, a, context.Buffer[3], 0xc1bdceee, S14);

            FFunc(ref a, b, c, d, context.Buffer[4], 0xf57c0faf, S11);
            FFunc(ref d, a, b, c, context.Buffer[5], 0x4787c62a, S12);
            FFunc(ref c, d, a, b, context.Buffer[6], 0xa8304613, S13);
            FFunc(ref b, c, d, a, context.Buffer[7], 0xfd469501, S14);

            FFunc(ref a, b, c, d, context.Buffer[8], 0x698098d8, S11);
            FFunc(ref d, a, b, c, context.Buffer[9], 0x8b44f7af, S12);
            FFunc(ref c, d, a, b, context.Buffer[10], 0xffff5bb1, S13);
            FFunc(ref b, c, d, a, context.Buffer[11], 0x895cd7be, S14);

            FFunc(ref a, b, c, d, context.Buffer[12], 0x6b901122, S11);
            FFunc(ref d, a, b, c, context.Buffer[13], 0xfd987193, S12);
            FFunc(ref c, d, a, b, context.Buffer[14], 0xa679438e, S13);
            FFunc(ref b, c, d, a, context.Buffer[15], 0x49b40821, S14);

            //Round Two
            GFunc(ref a, b, c, d, context.Buffer[1], 0xf61e2562, S21);
            GFunc(ref d, a, b, c, context.Buffer[6], 0xc040b340, S22);
            GFunc(ref c, d, a, b, context.Buffer[11], 0x265e5a51, S23);
            GFunc(ref b, c, d, a, context.Buffer[0], 0xe9b6c7aa, S24);

            GFunc(ref a, b, c, d, context.Buffer[5], 0xd62f105d, S21);
            GFunc(ref d, a, b, c, context.Buffer[10], 0x02441453, S22);
            GFunc(ref c, d, a, b, context.Buffer[15], 0xd8a1e681, S23);
            GFunc(ref b, c, d, a, context.Buffer[4], 0xe7d3fbc8, S24);

            GFunc(ref a, b, c, d, context.Buffer[9], 0x21e1cde6, S21);
            GFunc(ref d, a, b, c, context.Buffer[14], 0xc33707d6, S22);
            GFunc(ref c, d, a, b, context.Buffer[3], 0xf4d50d87, S23);
            GFunc(ref b, c, d, a, context.Buffer[8], 0x455a14ed, S24);

            GFunc(ref a, b, c, d, context.Buffer[13], 0xa9e3e905, S21);
            GFunc(ref d, a, b, c, context.Buffer[2], 0xfcefa3f8, S22);
            GFunc(ref c, d, a, b, context.Buffer[7], 0x676f02d9, S23);
            GFunc(ref b, c, d, a, context.Buffer[12], 0x8d2a4c8a, S24);

            //Round Three
            HFunc(ref a, b, c, d, context.Buffer[5], 0xfffa3942, S31);
            HFunc(ref d, a, b, c, context.Buffer[8], 0x8771f681, S32);
            HFunc(ref c, d, a, b, context.Buffer[11], 0x6d9d6122, S33);
            HFunc(ref b, c, d, a, context.Buffer[14], 0xfde5380c, S34);

            HFunc(ref a, b, c, d, context.Buffer[1], 0xa4beea44, S31);
            HFunc(ref d, a, b, c, context.Buffer[4], 0x4bdecfa9, S32);
            HFunc(ref c, d, a, b, context.Buffer[7], 0xf6bb4b60, S33);
            HFunc(ref b, c, d, a, context.Buffer[10], 0xbebfbc70, S34);

            HFunc(ref a, b, c, d, context.Buffer[13], 0x289b7ec6, S31);
            HFunc(ref d, a, b, c, context.Buffer[0], 0xeaa127fa, S32);
            HFunc(ref c, d, a, b, context.Buffer[3], 0xd4ef3085, S33);
            HFunc(ref b, c, d, a, context.Buffer[6], 0x04881d05, S34);

            HFunc(ref a, b, c, d, context.Buffer[9], 0xd9d4d039, S31);
            HFunc(ref d, a, b, c, context.Buffer[12], 0xe6db99e5, S32);
            HFunc(ref c, d, a, b, context.Buffer[15], 0x1fa27cf8, S33);
            HFunc(ref b, c, d, a, context.Buffer[2], 0xc4ac5665, S34);

            //Round Four
            IFunc(ref a, b, c, d, context.Buffer[0], 0xf4292244, S41);
            IFunc(ref d, a, b, c, context.Buffer[7], 0x432aff97, S42);
            IFunc(ref c, d, a, b, context.Buffer[14], 0xab9423a7, S43);
            IFunc(ref b, c, d, a, context.Buffer[5], 0xfc93a039, S44);

            IFunc(ref a, b, c, d, context.Buffer[12], 0x655b59c3, S41);
            IFunc(ref d, a, b, c, context.Buffer[3], 0x8f0ccc92, S42);
            IFunc(ref c, d, a, b, context.Buffer[10], 0xffeff47d, S43);
            IFunc(ref b, c, d, a, context.Buffer[1], 0x85845dd1, S44);

            IFunc(ref a, b, c, d, context.Buffer[8], 0x6fa87e4f, S41);
            IFunc(ref d, a, b, c, context.Buffer[15], 0xfe2ce6e0, S42);
            IFunc(ref c, d, a, b, context.Buffer[6], 0xa3014314, S43);
            IFunc(ref b, c, d, a, context.Buffer[13], 0x4e0811a1, S44);

            IFunc(ref a, b, c, d, context.Buffer[4], 0xf7537e82, S41);
            IFunc(ref d, a, b, c, context.Buffer[11], 0xbd3af235, S42);
            IFunc(ref c, d, a, b, context.Buffer[2], 0x2ad7d2bb, S43);
            IFunc(ref b, c, d, a, context.Buffer[9], 0xeb86d391, S44);

            context.State[0] += a;
            context.State[1] += b;
            context.State[2] += c;
            context.State[3] += d;

            Array.Clear(context.Buffer, 0, context.Buffer.Length);
        }

        public string GetHash(string text)
        {
            Context context = new Context();
            init(context);

            byte[] ASCII_bytes = Encoding.ASCII.GetBytes(text);

            int sizeinbits = ASCII_bytes.Length * 8;
            int mod = sizeinbits % 512;
            byte[] M;
            if (mod == 0)
            {
                //append 512
                M = new byte[ASCII_bytes.Length + 64];
                System.Buffer.BlockCopy(ASCII_bytes, 0, M, 0, ASCII_bytes.Length);
                M[ASCII_bytes.Length] = 128;
                word[] ll = { (word)ASCII_bytes.Length * 8 };
                byte[] llb = new byte[4];
                readAsBytes(llb, ll);
                M[ASCII_bytes.Length + 56] = llb[0];
                M[ASCII_bytes.Length + 57] = llb[1];
                M[ASCII_bytes.Length + 58] = llb[2];
                M[ASCII_bytes.Length + 59] = llb[3];
            }
            else
            {
                int tobeappended = 512 - mod;
                int size_offset = tobeappended / 8 - 8;
                M = new byte[ASCII_bytes.Length + tobeappended / 8];
                System.Buffer.BlockCopy(ASCII_bytes, 0, M, 0, ASCII_bytes.Length);
                M[ASCII_bytes.Length] = 128;
                word[] ll = { (word)ASCII_bytes.Length * 8 };
                byte[] llb = new byte[4];
                readAsBytes(llb, ll);
                M[ASCII_bytes.Length + size_offset] = llb[0];
                M[ASCII_bytes.Length + size_offset + 1] = llb[1];
                M[ASCII_bytes.Length + size_offset + 2] = llb[2];
                M[ASCII_bytes.Length + size_offset + 3] = llb[3];

            }

            for (int i = 0; i < M.Length / 64; i++)
            {
                update(context, M, (word)i * 64);
            }
            byte[] output = new byte[16];
            readAsBytes(output, context.State);
            string res = ByteArrayToString(output);
            return res;
        }
    }
}
