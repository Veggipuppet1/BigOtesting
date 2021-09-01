using System;
using System.Linq;

namespace bigO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            NumberFinder finder = new NumberFinder();

            int size = 10000000;
            int[] organisedArray = generateOrganisedArray(startNumber:0, size: size);
            //int[] organisedArray = generateOrganisedArray();

            finder.DoValuesExist(organisedArray, size*2);
        }

        private static int[] generateOrganisedArray()
        {
            int[] numberArray = { -10, -8, -5, -2, 1, 5, 5, 9, 10, 10, 20, 14, 26, 30 };
            return numberArray; 
        }

        private static int[] generateOrganisedArray(int startNumber, int size)
        {
            int[] sequence = Enumerable.Range(startNumber, size).ToArray();
            return sequence;
        }
    }
}
