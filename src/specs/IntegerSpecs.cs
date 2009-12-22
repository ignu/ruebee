using NUnit.Framework;
using ruebee;

namespace Ruebee.Specs
{
    [TestFixture]
    public class IntegerSpecs
    {
        [Test]
        public void can_do_something_n_times()
        {
            var count = 0;
            5.Times(() => count++);
            count.ShouldEqual(5);
        }
    }
}