using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class ExtendedEuclideanColumn
    {
        public int Index { get; set; }
        public BigInteger Remainder { get; set; }
        public BigInteger Quotient { get; set; }
        public BigInteger x { get; set; }
        public BigInteger y { get; set; }


        public string toString()
        {
            return $"I = {Index}\tr = {Remainder}\tq = {Quotient}\tx = {x}\ty = {y}\n";
        }
    }
}
