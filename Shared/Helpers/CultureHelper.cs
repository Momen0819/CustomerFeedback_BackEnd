using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public static class CultureHelper
    {
        public static string GetCurrentLanguage()
        {
            return CultureInfo.CurrentUICulture.Name.Contains("ar") ? "ar" : "en";
        }

        public static class Language
        {
            public static string Arabic { get; } = "ar";
            public static string English { get; } = "en";
        }
    }
}
