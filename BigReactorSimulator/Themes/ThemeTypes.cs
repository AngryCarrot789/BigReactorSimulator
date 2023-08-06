using System.Collections;

namespace TheRWPFTemplateMinimum.Themes
{
    public enum ThemeType
    {
        Light,
        Dark
    }

    public static class ThemeTypeExtension
    {
        public static string GetName(this ThemeType type)
        {
            switch (type)
            {
                case ThemeType.Light: return "LightTheme";
                case ThemeType.Dark: return "DarkTheme";
                default: return null;
            }
        }
    }
}
