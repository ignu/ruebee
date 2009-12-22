﻿using System;
using System.IO;
using System.Linq;

namespace ruebee
{
    public static class StringExtensions
    {
        public static bool IsAsciiOnly(this string value)
        {
            return !value.ToCharArray().Any(t => (int)t >= 255);            
        }

        // TODO: make this work in cases outside of UTF8
        public static int ByteSize(this string value)
        {
            return System.Text.Encoding.UTF8.GetBytes(value).Length;
        }

        public static string Capitalize(this string value)
        {
            return value.First().ToString().ToUpperInvariant() + value.Substring(1, value.Length - 1);            
        }

        public static string Center(this string value, int paddingAmount)
        {
            return Center(value, paddingAmount, ' ');
        }

        public static string Center(this string value, int paddingAmount, char padding)
        {
            var leftPadding = (paddingAmount - value.Length) / 2;
            if (leftPadding < 0) leftPadding = 0;
            var rightPadding = (paddingAmount - value.Length);
            rightPadding = rightPadding / 2 + rightPadding % 2;
            if (rightPadding < 0) rightPadding = 0;
            return String.Format("{0}{1}{2}",
                new String(padding, leftPadding),
                value,
                new String(padding, rightPadding));
        }

        // TODO: use regex and supply an option string to chomp
        public static string Chomp(this string value)
        {
            return value.TrimEnd("\r\n ".ToCharArray());
        }

        public static string Chop(this string value)
        {
            return value.Substring(0, value.Length - 1);
        }
    }
}