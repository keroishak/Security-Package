using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary.AES
{
    public class ExtendedEuclid
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="baseN"></param>
        /// <returns>Mul inverse, -1 if no inv</returns>
        public int GetMultiplicativeInverse(int number, int baseN)
        {
            int a1 = 1, a2 = 0, a3 = baseN, b1 = 0, b2 = 1, b3 = number, q, tmpb1, tmpb2, tmpb3;

            while (b3 > 1)
            {
                q = a3 / b3;
                tmpb1 = b1;
                tmpb2 = b2;
                tmpb3 = b3;
                b1 = a1 - q * b1;
                b2 = a2 - q * b2;
                b3 = a3 % b3;

                a1 = tmpb1; a2 = tmpb2; a3 = tmpb3;
            }

            if (b3 == 1)
            {
                if (b2 < 0) 
                    do
                    {
                        b2 += baseN;
                    }
                    while (b2 < 0);
                return b2; //multiplicative inverse..
            }

            else
                return -1;
        }
    }
}
