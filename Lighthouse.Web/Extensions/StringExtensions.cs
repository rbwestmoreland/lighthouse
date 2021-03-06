﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace System
{
    public static class StringExtensions
    {
        public static string SafeSubString(this string text, int startIndex)
        {
            if (text.Length >= startIndex)
            {
                return text.Substring(startIndex);
            }
            else
            {
                return text;
            }
        }

        public static string SafeSubString(this string text, int startIndex, int length)
        {
            if (text.Length >= startIndex + length)
            {
                return text.Substring(startIndex, length);
            }
            else
            {
                return text;
            }
        }

        public static string SafeSubString(this string text, int startIndex, int length, string continuationString)
        {
            if (text.Length >= startIndex + length)
            {
                var subString = text.Substring(startIndex, length);

                if (startIndex > 0)
                {
                    subString = string.Concat(continuationString, subString);
                }

                if (text.Length > startIndex + length)
                {
                    subString = string.Concat(subString, continuationString);
                }

                return subString;
            }
            else
            {
                return text;
            }
        }
    }
}