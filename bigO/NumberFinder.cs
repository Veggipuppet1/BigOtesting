using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bigO
{
    class NumberFinder
    {
        public NumberFinder()
        {

        }

        public void DoValuesExist(int[] numberArray, int number)
        {
            Timer(BinarySearch, numberArray, number);
            Timer(DictionarySearch, numberArray, number);
            Timer(DoubleDictionarySearch, numberArray, number);
        }

        private void Timer(Func<int[],int,bool> searchFunction, int[] numberArray, int number)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            watch.Start();
            bool valueExists = searchFunction(numberArray, number);
            watch.Stop();
            Console.WriteLine($"{searchFunction.Method.Name} returned: {valueExists}, duration: {watch.ElapsedMilliseconds} ms");

        }

        private bool BruteForce(int[] numberArray, int number)
        {
            for (int i = 0; i < numberArray.Length; i++)
            {
                for (int j = 0; j < numberArray.Length; j++)
                {
                    if (i != j)
                    {
                        int summedValue = numberArray[i] + numberArray[j];
                        if (summedValue == number)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool BinarySearch(int[] numberArray, int number)
        {
            for (int i = 0; i < numberArray.Length; i++)
            {
                int valueToFind = number - numberArray[i];

                int index = Array.BinarySearch(numberArray, valueToFind);
                if (index > 0 && index != i)
                {
                    return true;
                }
            }
            return false;
        }

        private bool DoubleDictionarySearch(int[] numberArray, int number)
        {
            Dictionary<int, int> resultDictionary= new Dictionary<int, int>();
            //var watch = new System.Diagnostics.Stopwatch();
            //watch = System.Diagnostics.Stopwatch.StartNew();
            //watch.Start();
            for (int i = 0; i < numberArray.Length; i++)
            {
                int valueToFind = number - numberArray[i];
                // Dictionary containing value to find, index
                resultDictionary.TryAdd(valueToFind, i);
                if (resultDictionary.ContainsKey(numberArray[i]))
                {
                    if(resultDictionary[numberArray[i]] != i)
                    {
                        return true;
                    }
                }

            }
            //watch.Stop();
            //Console.WriteLine($"containsKey duration: {watch.ElapsedMilliseconds}");

            return false;
        } 

        private bool DictionarySearch(int[] numberArray, int number=1)
        {
            // Dictionary<int, int> numberDictionary = numberArray.ToDictionary(value => value, value => value);
            // var test = numberArray.GroupBy(x => x);
            var watch = new System.Diagnostics.Stopwatch();
            //watch = System.Diagnostics.Stopwatch.StartNew();
            //watch.Start();
            //// Dictionary<int, int> numberDictionary = test.ToDictionary(x => x.Key, x => x.Count());
            //Dictionary<int, int> numberDictionary = numberArray.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            //watch.Stop();
            //Console.WriteLine($"numberDictionary assignment duration: {watch.ElapsedMilliseconds}");
            

            //watch = System.Diagnostics.Stopwatch.StartNew();
            //watch.Start();
            // Dictionary<int, int> numberDictionary = test.ToDictionary(x => x.Key, x => x.Count());
            Dictionary<int, int> numberDictionary = new Dictionary<int, int>();
            foreach (var item in numberArray)
            {
                if (numberDictionary.ContainsKey(item))
                {
                    numberDictionary[item]++;
                }
                else
                {
                    numberDictionary.Add(item, 1);
                }                
            }
            //watch.Stop();
            //Console.WriteLine($"numberDictionary loop assignment duration: {watch.ElapsedMilliseconds}");
            



            foreach (var item in numberArray)
            {
                int valueToFind = number - item;
                if(numberDictionary.ContainsKey(valueToFind))
                {
                    var lookupVal = numberDictionary[valueToFind];
                    if (lookupVal == 1 && valueToFind != item || valueToFind == item && lookupVal > 1)
                    {
                        return true;
                    }
                }
                //Console.WriteLine($"looking for: {valueToFind} dictionary response: {numberDictionary[valueToFind]}");

            }
            return false;
        }
    }

}
