using Algorithms;
using System;
using System.Diagnostics;
using System.Numerics;

namespace RSA_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // examples
            //BigInteger a = Algorithms.Generate.OddBigInt(2048);
            //BigInteger b = Algorithms.Generate.OddBigInt(2048);
            //BigInteger mod = Algorithms.Generate.BigInt(2048);
            ////BigInteger.TryParse("124986489464654654546553252352352562352335235235234521452352352365492124986489464654654546553252352352562352335235235234521452352352365492", out a);
            ////BigInteger.TryParse("189416185949848949852323423222342342355235325235235235235235223523494897212498648946465465454655325235235252335235235234521452352352365492", out b);
            ////BigInteger.TryParse("1000000000", out mod);
            ////Console.WriteLine(mod.ToByteArray().Length*8);


            //Console.WriteLine($"Greatest Common Divisor of {a} and {b} computed with Simple Euclidean Algorithm: " + Algorithms.Euclidean.Simple(a, b));
            //Console.WriteLine($"Greatest Common Divisor of {a} and {b} computed with Extended Euclidean Algorithm: " + Algorithms.Euclidean.Extended(a, b));
            //Console.WriteLine($"Greatest Common Divisor of {a} and {b} computed with Integrated function: " + BigInteger.GreatestCommonDivisor(a, b));
            //var sw = new Stopwatch();
            //sw.Start();
            //Console.WriteLine(Algorithms.FastModExponentiation.DoModPow(a, b, mod));
            //sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds);
            //sw.Reset();
            //sw.Start();
            //Console.WriteLine(BigInteger.ModPow(a, b, mod));
            //sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds);
            var c = new BigInteger(1280000000);
            var d = BigInteger.Parse("23");
            var p = BigInteger.Parse("5");
            var q = BigInteger.Parse("11");

            var asd = ChineseRemainderTheorem.Solve(c, d, p, q);
            var counter = 0;

            // Miller Rabin test: this should return 1000 prime numbers
            for (int i = 2; i < 7920; i++)
            {
                if (MillerRabin.IsPrime(i))
                {
                    Console.WriteLine(++counter + ".\t" + i);
                }

            }
            Console.ReadKey();



        }
    }
}
