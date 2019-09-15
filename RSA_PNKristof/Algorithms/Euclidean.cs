using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Euclidean
    {
        public static BigInteger Simple(BigInteger number1, BigInteger number2)
        {
            // swap if required
            if (number2 > number1)
            {
                var temp = number2;
                number2 = number1;
                number1 = temp;
            }

            // check if one step is enough
            if (number1 % number2 == 0)
            {
                return number2;
            }

            var greatestCommonDivisor = new BigInteger(0);

            do
            {
                greatestCommonDivisor = number1 % number2;
                number1 = number2;
                number2 = greatestCommonDivisor;

            } while (number1 % number2 != 0);

            return greatestCommonDivisor;
        }


        public static BigInteger Extended(BigInteger number1, BigInteger number2)
        {
            // swap if required
            if (number2 > number1)
            {
                var temp = number2;
                number2 = number1;
                number1 = temp;
            }

            var columns = new List<ExtendedEuclideanColumn> {
                new ExtendedEuclideanColumn
                {
                    Index = 0,
                    Remainder = number1,
                    Quotient = 0,
                    x = 1,
                    y = 0
                },
                new ExtendedEuclideanColumn
                {
                    Index = 1,
                    Remainder = number2,
                    Quotient = number1 / number2,
                    x = 0,
                    y = 1
                }
            };

            int index = 1;
            Console.WriteLine(columns[0].toString() + columns[1].toString());

            while (true)
            {
                index++;

                columns.Add(new ExtendedEuclideanColumn
                {
                    Index = index,
                    Remainder = columns[index - 2].Remainder % columns[index - 1].Remainder
                });

                if (columns[index].Remainder == 0)
                {
                    break;
                }
                columns[index].Quotient = columns[index - 1].Remainder / columns[index].Remainder;
                columns[index].x = columns[index - 1].x * columns[index - 1].Quotient + columns[index - 2].x;
                columns[index].y = columns[index - 1].y * columns[index - 1].Quotient + columns[index - 2].y;

                Console.Write(columns[index].toString());
            }

            BigInteger finalX = BigInteger.Pow(-1, columns[columns.Count() - 2].Index) * columns[columns.Count() - 2].x;
            BigInteger finalY = BigInteger.Pow(-1, columns[columns.Count() - 1].Index) * columns[columns.Count() - 2].y;

            // just some writeline:
            Console.WriteLine($"final X = {finalX}\nfinal Y = {finalY}");
            Console.WriteLine($"{columns[columns.Count() - 2].Remainder} = {columns[0].Remainder} * {finalX} + {columns[1].Remainder} * {finalY}");

            // doublecheck
            if (columns[columns.Count() - 2].Remainder != columns[0].Remainder * finalX + columns[1].Remainder * finalY)
            {
                throw new Exception("Something is not right :(");
            }

            return columns[columns.Count() - 2].Remainder;
        }
    }
}
