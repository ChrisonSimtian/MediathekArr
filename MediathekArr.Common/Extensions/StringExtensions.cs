using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MediathekArr.Common.Extensions;

public static class StringExtensions
{
    // Normalize a string to remove special characters and retain only A-Z, äöüÄÖÜß
    public static string NormalizeString(this string input)
    {
        var regex = new Regex("[^a-zA-ZäöüÄÖÜß]", RegexOptions.Compiled);
        return regex.Replace(input, "").ToLowerInvariant();
    }
}
