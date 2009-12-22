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

        [Test]
        public void can_do_something_up_to_n_times()
        {
            var count = 0;
            5.UpTo(7, i => count += i);
            count.ShouldEqual(18);
        }

        [Test]
        public void can_do_something_down_to_n_times()
        {
            var count = 0;
            7.DownTo(5, i => count += i);
            count.ShouldEqual(18);
        }

        [Test]
        public void can_get_greatest_common_denominator()
        {
            72.Gcd(168).ShouldEqual(24);
            19.Gcd(36).ShouldEqual(1);
        }

        [Test]
        public void can_get_least_common_multiple()
        {
            6.Lcm(7).ShouldEqual(42);
            7.Lcm(6).ShouldEqual(42);
            6.Lcm(9).ShouldEqual(18);
            6.Lcm(6).ShouldEqual(6);
        }
    }
}