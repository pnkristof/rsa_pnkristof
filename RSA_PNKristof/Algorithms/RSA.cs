using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class RSA
    {
        private BigInteger P;
        private BigInteger Q;
        private BigInteger N;
        private BigInteger Fi_N;
        private BigInteger E;
        private BigInteger D;
        
        public RSA(int SizeOfPRimes)
        {

            P = Generate.Prime(SizeOfPRimes);
            Q = Generate.Prime(SizeOfPRimes);
            while (Q == P)
            {
                Q = Generate.Prime(SizeOfPRimes);
            }
            N = P * Q;
            Fi_N = (P - 1) * (Q - 1);
            E = FindE(SizeOfPRimes);
            D = FindD(SizeOfPRimes);
        }

        private BigInteger FindE(int size)
        {
            BigInteger e = Generate.BigInt(size) % Fi_N;

            while (Euclidean.Simple(e, Fi_N) != 1)
            {
                e--;
            }

            return e;
        }

        private BigInteger FindD(int size)
        {
            BigInteger d = Euclidean.Extended(Fi_N, E)[2];

            if (d > 0)
            {
                return d;
            }
            else
            {
                return d + Fi_N;
            }
        }

        public BigInteger Encrypt(BigInteger message)
        {
            //return ChineseRemainderTheorem.Solve(message, E, P, Q);
            return FastModExponentiation.DoModPow(message, E, N);
        }

        public BigInteger Decrypt(BigInteger codedMessage)
        {
            //return ChineseRemainderTheorem.Solve(codedMessage, D, P, Q);
            return FastModExponentiation.DoModPow(codedMessage, D, N);
        }

        public string toString()
        {
            return $"P: {P}\nQ: {Q}\nN: {N}\nfi N: {Fi_N}\nE: {E}\nD: {D}\n\n{E} * {D} % {Fi_N} = {(E * D % Fi_N)}";
        }
    }
}
