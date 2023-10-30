using System.Numerics;

namespace MultiCommandCollectionView.Extensions;

internal static class BinaryIntegerExtensions
{
    private static readonly string[] sizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB", "RB", "QB" };

    /// <summary>Converts the numeric value of this instance to a string that represents the number expressed as a size-dependent value in bytes, kilobytes, megabytes, etc, up to quettabytes.</summary>
    /// <remarks>The string expression units are based on powers of 2, represented by the colloquially-understood KB, MB, GB, etc, instead of the technically correct KiB, MiB, GiB, etc.</remarks>
    /// <param name="includeTotalBytes"><c>true</c> to append the total number of bytes to the string; otherwise, <c>false</c>.</param>
    /// <returns>The string representation of the value, expressed in bytes, kilobytes, megabytes, etc, up to quettabytes.</returns>
    /// <exception cref="OverflowException">The numeric value of this instance is out of range and cannot be converted.</exception>
    internal static string ToByteSizeString<T>(this T value, bool includeTotalBytes = false) where T : IBinaryInteger<T>
    {
        string result;

        if (T.IsZero(value))
            result = $"0 {sizeSuffixes[0]}";
        else
        {
            int magnitude, decimalPlaces;
            double absolute, fullResult, roundedResult;
            string bytesPart = string.Empty;

            absolute = double.CreateChecked(T.Abs(value));
            magnitude = Math.Min((int)Math.Floor(Math.Log(absolute, 1024)), sizeSuffixes.Length - 1);
            fullResult = T.Sign(value) * (absolute / Math.Pow(1024, magnitude));

            decimalPlaces = Math.Max(0, 2 - (int)Math.Floor(Math.Log10(fullResult)));
            roundedResult = Math.Round(fullResult, decimalPlaces, MidpointRounding.AwayFromZero);

            if (includeTotalBytes && (magnitude > 0))
                bytesPart = $" ({value:N0} {sizeSuffixes[0]})";

            result = $"{roundedResult:#,#.##} {sizeSuffixes[magnitude]}{bytesPart}";
        }

        return (result);
    }
}