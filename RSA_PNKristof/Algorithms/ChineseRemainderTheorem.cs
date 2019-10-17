using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class ChineseRemainderTheorem
    {
        public static BigInteger Solve(BigInteger c, BigInteger d, BigInteger p, BigInteger q)
        {
            var c_1 = BigInteger.ModPow(c, BigInteger.ModPow(d, 1, p - 1), p);
            var c_2 = BigInteger.ModPow(c, BigInteger.ModPow(d, 1, q - 1), q);
            var M = p * q;
            var M_1 = M / p;
            var M_2 = M / q;

            Console.WriteLine($"c1: {c_1}\nc2: {c_2}\nM: {M}\nM1: {M_1}\nM2: {M_2}\n");

            var y_1 = Euclidean.Extended(M_1, M_2)[1];
            var y_2 = Euclidean.Extended(M_1, M_2)[2];

            Console.WriteLine($"y1: {y_1}\ny2:{y_2}\n");

            var m = BigInteger.ModPow(c_1 * y_1 * M_1 + c_2 * y_2 * M_2, 1, M);

            Console.WriteLine(m);
            return m;
        }

    }
}
