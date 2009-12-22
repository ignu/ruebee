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
            var myString = String.Empty;
            "abcd".Each(a=>myString+=a);
            myString.ShouldEqual("abcd");
        }

        [Test]
        public void can_get_uniq()
        {
            var ints = new List<int> {2, 3, 4, 2, 3,};
            ints.Uniq().Count().ShouldEqual(3);
            ints.Uniq().Last().ShouldEqual(4);            
        }
    }
}