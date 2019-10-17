using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class MillerRabin
    {
        public static bool IsPrime(BigInteger number)
        {

            // handle evens
            if (number == 2)
            {
                return true;
            }
            else if (number % 2 == 0)
            {
                return false;
            }

            // get S
            var S = 1;
            while (((number - 1) % BigInteger.Pow(2, ++S)) == 0) ;
            S--;

            // get d
            var d = (number - 1) / BigInteger.Pow(2, S);

            //Console.WriteLine($"{S}, {d}");

            Random rnd = new Random();
            int randomBase;

            // repeat 8 times to be sure :)
            for (int i = 0; i < 8; i++)
            {
                // get random base that meets gcd(b,n)=1 condition
                do
                {
                    randomBase = rnd.Next();
                } while (Euclidean.Simple(randomBase, number) != 1);


                if (FastModExponentiation.DoModPow(randomBase, d, number) != 1)
                {
                    bool existR = false;
                    for (int r = 0; r < S; r++)
                    {
                        if (FastModExponentiation.DoModPow(randomBase, d * (BigInteger.Pow(2, r)), number) == number - 1)
                        {
                            existR = true;
                            break;
                        }
                    }
                    if (existR) continue;

                }
                else continue;
            
                return false;
            }

            return true;
        }

    }
}
