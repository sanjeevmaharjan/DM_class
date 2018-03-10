using System;
using System.Collections.Generic;
using System.Linq;

namespace AssociationRuleMining
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> letters = new List<char>(){ 'A', 'B', 'C' };
            int[] numbers = { 1, 2, 3, 4 };
            List<List<char>> cartesianProduct = new List<List<char>>();
            var temp = letters;
            for (int i = 0; i < letters.Count; i++) {
                
                for (int j = 0; j < temp.Count; j++) {
                    cartesianProduct.Add(new List<char>(){letters[i], temp[j]});
                }
                
                temp = letters.GetRange(i + 1, letters.Count - i - 1);
            }

            foreach (var tuple in cartesianProduct)
            {
                foreach(var item in tuple) {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            }

        }
    }
}
