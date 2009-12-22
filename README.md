#ruebee

ruebee is a set of C# extention methods to extend .NET classes with applicable ruby methods.

##Examples

###Integers
	
		public void can_do_something_up_to_n_times()
		{
		    var count = 0;
		    5.UpTo(7, i => count += i);
		    count.ShouldEqual(18);
		}

		public void can_get_greatest_common_denominator()
		{
		    72.Gcd(168).ShouldEqual(24);
		    19.Gcd(36).ShouldEqual(1);
		}

[More Integer Specs...](http://github.com/ignu/ruebee/blob/master/src/specs/IntegerSpecs.cs)

###Strings
        
        public void can_capitalize()
        {
            "hello".Capitalize().ShouldEqual("Hello");
        }

        public void can_center()
        {
            "hello".Center(4).ShouldEqual("hello");
            "hello".Center(5).ShouldEqual("hello");
            "hello".Center(7).ShouldEqual(" hello ");
            "hello".Center(8).ShouldEqual(" hello  ");
            "hello".Center(9, '-').ShouldEqual("--hello--");
        }

        public void can_chomp()
        {
            "hello".Chomp().ShouldEqual("hello");
            "hello\r ".Chomp().ShouldEqual("hello");
            "hello \r\n".Chomp().ShouldEqual("hello");            
        }

        public void can_perform_action_on_each_line()
        {
            var builder = new StringBuilder();
            ("Hello there." + Environment.NewLine + "How are you?")
                .EachLine(l => builder.Append(l));
            builder.ToString().ShouldEndWith("Hello there.How are you?");
        }

        public void can_ljust()
        {
            "hello".LJust(4).ShouldEqual("hello");
            "hello".LJust(20).ShouldEqual("hello               ");
            "hello".LJust(20, "1234").ShouldEqual("hello123412341234123");   
        }
	
[More String Specs...](http://github.com/ignu/ruebee/blob/master/src/specs/StringSpecs.cs)
