using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Generate
    {
        public static BigInteger BigInt(int bits)
        {
            Random rnd = new Random();
            int intToGenerate = bits / 8;
            string bigInteger = "";

            for (int i = 0; i < intToGenerate; i++)
            {
                string smallInt = "1";

                for (int j = 0; j < 7; j++)
                {
                    smallInt += rnd.Next(2).ToString();
                }

                bigInteger += Convert.ToInt32(smallInt, 2).ToString();
            }

            return BigInteger.Parse(bigInteger);
        }

        public static BigInteger OddBigInt(int bits)
        {
            BigInteger oddBigInt;

            if ((oddBigInt = BigInt(bits)) % 2 == 0)
            {
                oddBigInt -= 1;
            }

            return oddBigInt;
        }

        public static BigInteger Prime(int bits)
        {
            var prime = OddBigInt(bits);

            while (!MillerRabin.IsPrime(prime))
            {
                if (prime.IsEven)
                {
                    prime += 3;
                }
                else
                {
                    prime += 2;
                }
            }

            return prime;
        }
    }
}
