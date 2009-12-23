using System;
using System.Collections.Generic;
using NUnit.Framework;
using ruebee;
using System.Linq;

namespace Ruebee.Specs
{
    [TestFixture]
    public class EnumerableSpecs 
    {
        [Test]
        public void can_perform_action_on_each()
        {
            var assembly = System.Reflection.Assembly.GetAssembly(typeof (EnumerableSpecs));
            assembly.GetTypes().Each(t=>t.GetFields().Each(Console.WriteLine));

            var myString = String.Empty;
            "abcd".Each(a=>myString+=a);
            myString.ShouldEqual("abcd");
            var ints = new List<int> {1, 2, 3};
            ints.Each(Console.WriteLine);            
        }

        [Test]
        public void can_get_uniq()
        {
            var ints = new List<int> {2, 3, 4, 2, 3,};
            ints.Uniq().Count().ShouldEqual(3);
            ints.Uniq().Last().ShouldEqual(4);            
        }

        [Test]
        public void can_shift()
        {
            var ints = new List<int> {1, 2, 3, 4};
            var x = ints.Shift();
            x.ShouldEqual(1);
            ints.Count().ShouldEqual(3);
            ints.First().ShouldEqual(2);                
        }

        [Test]
        public void can_shuffle()
        {            
            var ints = new List<int>();
            1.UpTo(500, ints.Add);
            ints.Shuffle();            
            (ints[0] == 1 && ints[1] == 2 && ints.Last() == 500).ShouldBeFalse();
            ints.Distinct().Count().ShouldEqual(500);         
        }

        [Test, Ignore]
        public void can_get_combinations()
        {
            var ints = new List<int> { 1, 2, 3, 4 };
            var combinations = ints.Combination(2);
            
            combinations.Count().ShouldEqual(6);
            combinations.Last().First().ShouldEqual(3);
            combinations.Last().Last().ShouldEqual(4);
            combinations.First().First().ShouldEqual(1);
            combinations.First().Last().ShouldEqual(2);

            combinations = ints.Combination(3);
            combinations.Each(c => { c.Each(Console.Write); Console.WriteLine("------------"); });
            combinations.Count().ShouldEqual(4);
            combinations.First().First().ShouldEqual(1);
            combinations.Last().Last().ShouldEqual(3);
            combinations.Last().First().ShouldEqual(2);
            combinations.Last().Last().ShouldEqual(4);
        }
    }
}