using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MessagingStandards.SWIFT
{
    public static class StringExtensions
    {
        public static string ConvertFromUnix(this string value)
        {
            var s = value.Replace("\n", "\r\n");
            return s;
        }

        public static string Between(this string value, string a, string b)
        {
            int posA = value.IndexOf(a);
            int posB = value.IndexOf(b, posA);

            if (posA == -1)
            {
                return "";
            }
            if (posB == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= posB)
            {
                return "";
            }
            return value.Substring(adjustedPosA, posB - adjustedPosA);
        }

        public static string ParseFromString(this string value, string a, string b)
        {
            int posA = value.IndexOf(a);
            string result = value.Substring(posA + a.Length);
            int displacement = value.Length - result.Length;
            int posB = result.IndexOf(b);

            if (posA == -1)
            {
                return "";
            }
            if (posB == -1)
            {
                return "";
            }

            return result.Substring(0, posB);
        }

        public static string ParseWithStringAndIndex(this string value, string a, int index)
        {
            int posA = value.IndexOf(a);
            int posB = index;

            if (posA == -1)
            {
                return "";
            }
            if (posB == -1)
            {
                return "";
            }

            int adjustedPosA = posA + a.Length;

            return value.Substring(adjustedPosA, index);
        }

        public static string ToEndOfString(this string value, string a)
        {
            int posA = value.IndexOf(a) + a.Length;
            return value.Substring(posA);
        }

        public static string TrimAllNewLines(this string value)
        {
            return value.Replace(Environment.NewLine, " ").Trim();
        }

        public static string TrimColon(this string value)
        {
            value = value.Trim(new Char[] { ':' });
            return value;
        }

        public static string TrimEndOfSwift(this string value)
        {
            value = value.Trim(new Char[] { '-', '}' });
            return value;
        }

        public static int GetSwiftTag(this string value, int a)
        {
            int displacement = 6;
            int result;
            if (value.Substring(a, 2) == ":")
            {
                displacement = displacement + 1;
            }

            var startCharacter = value.Substring(a, 1);

            if (startCharacter != ":")
            {
                displacement = displacement + 1;
            }

            int posA = a + displacement;
            int posB = value.IndexOf(":", posA);

            result = posB - a;

            return result;
        }
    }
}
