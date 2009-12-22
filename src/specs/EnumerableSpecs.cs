using System;
using NUnit.Framework;
using ruebee;

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
    }
}