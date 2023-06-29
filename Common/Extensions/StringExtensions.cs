using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace System;

public static class StringExtensions
{
    public static string OfuscatePasswords(this string source)
    {
        if (string.IsNullOrWhiteSpace(source))
            return source;

        var match = Regex.Match(source, @"(pwd|password)=.*?(;|$|\z)", RegexOptions.IgnoreCase);
        if (match.Success)
        {
            var splits = match.Value.Split('=');
            int passwordLength = splits[1].Length;
            string blankedPassword = passwordLength <= 0 ? "{none}" : new string('*', passwordLength);
            source = source.Replace(splits[1], $"{blankedPassword};", StringComparison.InvariantCulture);
        }

        return source;
    }

    public static string Sha256(this string value)
    {
        var sb = new StringBuilder();

        using var hash = Security.Cryptography.SHA256.Create();
        byte[] result = hash.ComputeHash(Encoding.UTF8.GetBytes(value));

        foreach (byte b in result)
            sb.Append(b.ToString("x2", CultureInfo.InvariantCulture));


        return sb.ToString();
    }

    public static string Md5(this string value)
    {
        var sb = new StringBuilder();

        using var hash = System.Security.Cryptography.MD5.Create();
        byte[] result = hash.ComputeHash(Encoding.UTF8.GetBytes(value));

        foreach (byte b in result)
            sb.Append(b.ToString("x2", CultureInfo.InvariantCulture));

        return sb.ToString();
    }

}
