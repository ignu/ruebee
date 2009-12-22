using System.Linq;
using NUnit.Framework;
using ruebee;

namespace Ruebee.Specs
{
    [TestFixture]
    public class StringSpecs
    {
        [Test]
        public void can_detect_ascii_only()
        {
            "Hello there World!!".IsAsciiOnly().ShouldBeTrue();
            "This is not Ascii →".IsAsciiOnly().ShouldBeFalse();            
        }

        [Test]  
        public void can_get_bytesize()
        {
            "Hello".ByteSize().ShouldEqual(5);
            "a→".ByteSize().ShouldEqual(4);
        }

        [Test]
        public void can_capitalize()
        {
            "hello".Capitalize().ShouldEqual("Hello");
        }

        [Test]
        public void can_center()
        {
            "hello".Center(4).ShouldEqual("hello");
            "hello".Center(5).ShouldEqual("hello");
            "hello".Center(7).ShouldEqual(" hello ");
            "hello".Center(8).ShouldEqual(" hello  ");
            "hello".Center(9, '-').ShouldEqual("--hello--");
        }

        [Test]
        public void can_chomp()
        {
            "hello".Chomp().ShouldEqual("hello");
            "hello\r ".Chomp().ShouldEqual("hello");
            "hello \r\n".Chomp().ShouldEqual("hello");            
        }

        [Test]
        public void can_chop()
        {
            "hello".Chop().ShouldEqual("hell");
            "hello".Chop().Chop().ShouldEqual("hel");
        }
    }
}
