using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace System.Runtime.CompilerServices
{
    public class ExtensionAttribute : Attribute { }
}


namespace Ruebee.Specs
{
    public delegate void MethodThatThrows();

    /// <summary>
    /// Extention methods that make unit test asserts more fluid and readable.
    /// 
    /// Modified from CodeIncubator: http://code.google.com/p/codeincubator/
    /// </summary>
    public static class NUnitSpecExtensions
    {
        public static void ShouldBeFalse(this bool condition)
        {
            Assert.IsFalse(condition);
        }
        
        public static void ShouldBeTrue(this bool condition)
        {
            Assert.IsTrue(condition);
        }

        public static void ShouldBeTrue(this bool condition, string message)
        {
            Assert.IsTrue(condition, message);
        }
     
        public static object ShouldEqual(this object actual, object expected)
        {
            Assert.AreEqual(expected, actual);
            return expected;
        }

        public static object ShouldNotEqual(this object actual, object expected)
        {
            Assert.AreNotEqual(expected, actual);
            return expected;
        }

        public static void ShouldBeNull(this object anObject)
        {
            Assert.IsNull(anObject);
        }

        public static void ShouldNotBeNull(this object anObject)
        {
            Assert.IsNotNull(anObject);
        }

        public static void ShouldNotBeNullOrEmpty(this string aString)
        {
            Assert.That(!String.IsNullOrEmpty(aString), "String should not be null or empty");
        }

        public static object ShouldBeTheSameAs(this object actual, object expected)
        {
            Assert.AreSame(expected, actual);
            return expected;
        }

        public static object ShouldNotBeTheSameAs(this object actual, object expected)
        {
            Assert.AreNotSame(expected, actual);
            return expected;
        }

        public static void ShouldBeOfType(this object actual, Type expected)
        {
            Assert.IsInstanceOfType(expected, actual);
        }

        public static void ShouldBeAssignableTo(this object actual, Type expected)
        {
            Assert.That(expected.IsAssignableFrom(actual.GetType()), "Expected {0} to be assignable to {1}.", actual.GetType(), expected);
        }

        public static void ShouldNotBeOfType(this object actual, Type expected)
        {
            Assert.IsNotInstanceOfType(expected, actual);
        }

        public static void ShouldContain(this IEnumerable actual, object expected)
        {
            Assert.That(actual, Has.Member(expected));
        }

        public static void ShouldNotContain(this IEnumerable actual, object expected)
        {
            Assert.That(actual, Has.No.Member(expected));
        }

        public static IComparable ShouldBeGreaterThanOrEqualTo(this IComparable arg1, IComparable arg2)
        {
            Assert.GreaterOrEqual(arg1, arg2);
            return arg2;
        }

        public static IComparable ShouldBeLessThanOrEqualTo(this IComparable arg1, IComparable arg2)
        {
            Assert.LessOrEqual(arg1, arg2);
            return arg2;
        }

        public static IComparable ShouldBeGreaterThan(this IComparable arg1, IComparable arg2)
        {
            Assert.Greater(arg1, arg2);
            return arg2;
        }

        public static IComparable ShouldBeLessThan(this IComparable arg1, IComparable arg2)
        {
            Assert.Less(arg1, arg2);
            return arg2;
        }

        public static void ShouldContainAll(this IEnumerable arg1, IEnumerable arg2)
        {
            foreach (var x in arg2)
            {
                arg1.ShouldContain(x);
            }
        }

        public static void ShouldAllEqual<T>(this IEnumerable<T> collection, T expectedValue)
        {
            foreach (var x in collection)
            {
                x.ShouldEqual(expectedValue);
            }
        }

        public static void ShouldBeEmpty(this ICollection collection)
        {
            Assert.IsEmpty(collection);
        }

        public static void ShouldBeEmpty(this string aString)
        {
            Assert.IsEmpty(aString);
        }

        public static void ShouldNotBeEmpty(this ICollection collection)
        {
            Assert.IsNotEmpty(collection);
        }

        public static void ShouldNotBeEmpty(this string aString)
        {
            Assert.IsNotEmpty(aString);
        }

        public static void ShouldContain(this string actual, string expected)
        {
            StringAssert.Contains(expected, actual);
        }

        public static void ShouldNotContain(this string actual, string expected)
        {
            Assert.That(actual.IndexOf(expected) < 0);
        }

        public static string ShouldBeEqualIgnoringCase(this string actual, string expected)
        {
            StringAssert.AreEqualIgnoringCase(expected, actual);
            return expected;
        }

        public static void ShouldEndWith(this string actual, string expected)
        {
            StringAssert.EndsWith(expected, actual);
        }

        public static void ShouldStartWith(this string actual, string expected)
        {
            StringAssert.StartsWith(expected, actual);
        }

        public static void ShouldContainErrorMessage(this Exception exception, string expected)
        {
            StringAssert.Contains(expected, exception.Message);
        }

        public static void With<T>(this T @object, Predicate<T> validation)
        {
            try
            {
                var validationResult = validation(@object);
                Assert.That(validationResult);            
            }
            catch (Exception ex)
            {                
                Assert.Fail(String.Format("Expectation was not met. [{0}]", ex.Message));
            }
            
        }

        public static T ShouldThrow<T>(this MethodThatThrows method) where T : Exception
        {           
            try
            {
                method();
            }
            catch (T e)
            {
                return e;                
            }
           
            Assert.Fail(String.Format("Expected {0} to be thrown.", typeof(T).FullName));

            return null;
        }


        public static void ShouldEqualSqlDate(this DateTime actual, DateTime expected)
        {
            TimeSpan timeSpan = actual - expected;
            Assert.Less(Math.Abs(timeSpan.TotalMilliseconds), 3);
        }

        public static void ShouldMatch(this string actual, string pattern)
        {
            Regex regex = new Regex(pattern);
            Assert.That(regex.Matches(actual).Count > 0, "Regular Expression (" + pattern + ") does not match: \r\n" + actual);
        }

        public static void ShouldContainExactly(this string actual, int count, string pattern)
        {
            Regex regex = new Regex(pattern);
            Assert.That(regex.Matches(actual).Count == count,
                        string.Format("Regular Expression ({0}) does not contain {1} matches in : {2}",
                                      pattern, count, actual));
        }

        public static void ShouldBeEquivalentTo(this IEnumerable actual, ICollection expected)
        {
            Assert.That(actual, Is.EquivalentTo(expected));
        }

        public static void ShouldBeFalse(this bool condition, string message)
        {
            Assert.That(condition, Is.False, message);
        }

        /// <summary>
        /// asserts that all properties of both objects are equal.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static void ShouldBeEquivalentTo(this object first, object second)
        {
            first.GetType().ShouldEqual(second.GetType());

            var properties = first.GetType().GetProperties();
            foreach (var property in properties)
            {
                var firstValue = property.GetGetMethod().Invoke(first, null);
                var secondValue = property.GetGetMethod().Invoke(second, null);
                firstValue.ShouldEqual(secondValue);
            }
        }
    }
}