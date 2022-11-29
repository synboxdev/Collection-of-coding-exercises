using System.Text.RegularExpressions;

namespace Services.Utility;

public static class StringExtensions
{
    public static string ToAlphaNumeric(this string input)
    {
        return Regex.Replace(input, "[^-^a-zA-Z0-9]", string.Empty);
    }
}