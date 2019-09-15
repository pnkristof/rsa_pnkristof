using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class FastModExponentiation
    {
        public static BigInteger DoModPow(BigInteger b, BigInteger exponent, BigInteger mod)
        {
            var binaryString = ToBinaryString(exponent);

            var relevantBits = new List<double>();
            var _b = b;
            var pows = new List<BigInteger> { _b };

            for (double i = 0; i < binaryString.Length; i++)
            {
                if (binaryString[(int)i] == '1')
                {
                    relevantBits.Add(binaryString.Length - i - 1);
                }

                pows.Add(_b = BigInteger.ModPow(_b, 2, mod));

            }

            var result = new BigInteger(1);

            foreach (var bit in relevantBits)
            {
                result *= pows[(int)bit];
            }

            result = result % mod;

            return result;
        }

        // from external source
        static string ToBinaryString(BigInteger bigint)
        {
            var bytes = bigint.ToByteArray();
            var idx = bytes.Length - 1;

            // Create a StringBuilder having appropriate capacity.
            var base2 = new StringBuilder(bytes.Length * 8);

            // Convert first byte to binary.
            var binary = Convert.ToString(bytes[idx], 2);

            // Ensure leading zero exists if value is positive.
            if (binary[0] != '0' && bigint.Sign == 1)
            {
                base2.Append('0');
            }

            // Append binary string to StringBuilder.
            base2.Append(binary);

            // Convert remaining bytes adding leading zeros.
            for (idx--; idx >= 0; idx--)
            {
                base2.Append(Convert.ToString(bytes[idx], 2).PadLeft(8, '0'));
            }

            return base2.ToString();
        }
    }
}
