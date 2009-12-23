using System;
using System.Collections.Generic;
using System.Linq;

namespace ruebee
{
    public static class EnumerableExtensions
    {
        public static void Each<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)            
                action(item);            
        }

        [Obsolete("Use Linq.Distinct")]
        public static IEnumerable<T> Uniq<T>(this IEnumerable<T> value)
        {
            return value.Distinct();
        }

        public static T Shift<T>(this IList<T> collection)
        {
            var rv = collection.First();
            collection.RemoveAt(0);
            return rv;
        }

        public static void Shuffle<T>(this IList<T> collection)
        {
            var rand = new Random(DateTime.Now.Millisecond);
            0.UpTo(collection.Count -1, i=>
                                         {
                                             var nextIndex = rand.Next(collection.Count - 1);
                                             var temp = collection[i];
                                             collection[i] = collection[nextIndex];
                                             collection[nextIndex] = temp;
                                         });
        }

        public static List<List<T>> Combination<T>(this IEnumerable<T> value, int combinationSize)
        {
            var listToReturn = new List<List<T>>();
            getCombination(listToReturn, new List<T>(), new List<T>(value), combinationSize);
            return listToReturn;
        }

        private static void getCombination<T>(List<List<T>> listToReturn, List<T> currentList, List<T> remainingCollection, int combinationSize)
        {

            if(remainingCollection.Count() < 1) return;
            Console.WriteLine("Getting Combination " + remainingCollection.First());            
            var currentItem = remainingCollection.Shift();
            var nextLevel = new List<T>(remainingCollection);
            while(remainingCollection.Count() > 0)
            {
                if(currentList.Count() ==0) currentList.Add(currentItem);                
                currentList.Add(remainingCollection.Shift());
                if (currentList.Count == combinationSize)
                {
                    listToReturn.Add(currentList);
                    currentList = new List<T>();
                }
            }
            getCombination(listToReturn, new List<T>(currentList), nextLevel, combinationSize);
            
        }
    }
}