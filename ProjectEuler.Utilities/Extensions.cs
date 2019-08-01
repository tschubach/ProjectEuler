using System.Globalization;
using System.Threading;

namespace ProjectEuler.Utilities
{
    public static class Extensions
    {
        public static string ToTitleCase(this string source)
        {
            TextInfo textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;

            return textInfo.ToTitleCase(source);

        }
    }
}
