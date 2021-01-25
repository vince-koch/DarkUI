using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DarkUI.Config
{
    public static class Colors
    {
        public static void CopyColorsValuesFrom<TPalette>() where TPalette : new()
        {
            var targetProperties = typeof(Colors).GetProperties();

            var source = new TPalette();
            var sourceProperties = source.GetType().GetProperties();
            foreach (var sourceProperty in sourceProperties)
            {
                var color = (Color)sourceProperty.GetValue(source, null);
                var targetProperty = targetProperties.Single(t => t.Name == sourceProperty.Name);
                targetProperty.SetValue(null, color, null);
            }
        }

        public static void DebugProperties()
        {
            Debug.WriteLine("======================================");
            var targetProperties = typeof(Colors).GetProperties();
            foreach (var targetProperty in targetProperties)
            {
                if (targetProperty.PropertyType == typeof(Color))
                {
                    var color = (Color)targetProperty.GetValue(null, null);
                    Debug.WriteLine(string.Format(
                        "{0} {{ get; private set; }} = Color.FromArgb({1}, {2}, {3});",
                        targetProperty.Name,
                        color.R, 
                        color.G,
                        color.B));
                }
            }
        }

        private static ITheme _activeTheme = new DarkTheme();

        public static ITheme ActiveTheme 
        {
            get { return _activeTheme; }
            set
            {
                _activeTheme = value;

                var eventArgs = new ThemeChangedEventArgs(value);
                ThemeChanged(null, eventArgs);

                foreach (Form form in Application.OpenForms)
                {
                    form.Invalidate(true);
                }
            }
        } 

        public static event EventHandler<ThemeChangedEventArgs> ThemeChanged;

        // Default color values. Will be always used if brightness is unmodified.

        public static Color GreyBackground => ActiveTheme.GreyBackground;
        public static Color HeaderBackground => ActiveTheme.HeaderBackground;
        public static Color BlueBackground => ActiveTheme.BlueBackground;
        public static Color DarkBlueBackground => ActiveTheme.DarkBlueBackground;
        public static Color DarkBackground => ActiveTheme.DarkBackground;
        public static Color MediumBackground => ActiveTheme.MediumBackground;
        public static Color LightBackground => ActiveTheme.LightBackground;
        public static Color LighterBackground => ActiveTheme.LighterBackground;
        public static Color LightestBackground => ActiveTheme.LightestBackground;
        public static Color LightBorder => ActiveTheme.LightBorder;
        public static Color DarkBorder => ActiveTheme.DarkBorder;
        public static Color LightText => ActiveTheme.LightText;
        public static Color DisabledText => ActiveTheme.DisabledText;
        public static Color BlueHighlight => ActiveTheme.BlueHighlight;
        public static Color BlueSelection => ActiveTheme.BlueSelection;
        public static Color GreyHighlight => ActiveTheme.GreyHighlight;
        public static Color GreySelection => ActiveTheme.GreySelection;
        public static Color DarkGreySelection => ActiveTheme.DarkGreySelection;
        public static Color DarkBlueBorder => ActiveTheme.DarkBlueBorder;
        public static Color LightBlueBorder => ActiveTheme.LightBlueBorder;
        public static Color ActiveControl => ActiveTheme.ActiveControl;

        public static float Brightness => ActiveTheme.Brightness;
        public static float FontBrightness => ActiveTheme.FontBrightness;

        // Button/toolbar control highlight color is specified independently to allow
        // high-contrast color schemes.

        public static Color HighlightBase => ActiveTheme.HighlightBase;
        public static Color HighlightFill => ActiveTheme.HighlightFill;
        /*
        // DarkBase is base colour on which all other colours are recalculated if brightness
        // is changed.

        private static Color DarkBase { get; } = Color.FromArgb(60, 63, 65);

        // MaxBrightness should be 1.0f at all times!
        // MinBrightness can go down up to 0.1, but almost nothing will be visible...
        // So let's clamp it to 0.5 at least.

        public const float MaxBrightness = 1.0f;
        public const float MinBrightness = 0.5f;

        // AlphaBrightness is a helper value which is used in filling overlay rectangles
        // over image controls (e.g. buttons with pictures, arrows in comboboxes etc.).
        public static float AlphaBrightness => MaxBrightness - Brightness;

        // Fonts should use different brightness formula to provide enough contrast.
        public static float FontBrightness => Brightness + (MaxBrightness - Brightness) * 0.35f;

        public static bool IsInverted { get; set; }

        // Every time brightness is changed, all UI colours are automatically recalculated against DarkBase.
        public static float Brightness
        {
            get { return _brightness; }
            set
            {
                _brightness = Math.Min(Math.Max(value, MinBrightness), MaxBrightness);

                GreyBackground = DarkBase.Multiply(_brightness * 1.000f, _brightness * 1.000f, _brightness * 1.000f).MaybeInvert(IsInverted);
                HeaderBackground = DarkBase.Multiply(_brightness * 0.950f, _brightness * 0.952f, _brightness * 0.954f).MaybeInvert(IsInverted);
                BlueBackground = DarkBase.Multiply(_brightness * 1.100f, _brightness * 1.222f, _brightness * 1.462f).MaybeInvert(IsInverted);
                DarkBlueBackground = DarkBase.Multiply(_brightness * 0.867f, _brightness * 0.905f, _brightness * 1.015f).MaybeInvert(IsInverted);
                DarkBackground = DarkBase.Multiply(_brightness * 0.717f, _brightness * 0.683f, _brightness * 0.662f).MaybeInvert(IsInverted);
                MediumBackground = DarkBase.Multiply(_brightness * 0.817f, _brightness * 0.810f, _brightness * 0.815f).MaybeInvert(IsInverted);
                LightBackground = DarkBase.Multiply(_brightness * 1.150f, _brightness * 1.159f, _brightness * 1.138f).MaybeInvert(IsInverted);
                LighterBackground = DarkBase.Multiply(_brightness * 1.583f, _brightness * 1.603f, _brightness * 1.569f).MaybeInvert(IsInverted);
                LightestBackground = DarkBase.Multiply(_brightness * 2.967f, _brightness * 2.825f, _brightness * 2.738f).MaybeInvert(IsInverted);
                LightBorder = DarkBase.Multiply(_brightness * 1.350f, _brightness * 1.286f, _brightness * 1.246f).MaybeInvert(IsInverted);
                DarkBorder = DarkBase.Multiply(_brightness * 0.850f, _brightness * 0.810f, _brightness * 0.785f).MaybeInvert(IsInverted);
                BlueHighlight = DarkBase.Multiply(_brightness * 1.733f, _brightness * 2.397f, _brightness * 2.877f).MaybeInvert(IsInverted);
                BlueSelection = DarkBase.Multiply(_brightness * 1.250f, _brightness * 1.746f, _brightness * 2.692f).MaybeInvert(IsInverted);
                GreyHighlight = DarkBase.Multiply(_brightness * 2.033f, _brightness * 2.032f, _brightness * 2.031f).MaybeInvert(IsInverted);
                GreySelection = DarkBase.Multiply(_brightness * 1.533f, _brightness * 1.460f, _brightness * 1.415f).MaybeInvert(IsInverted);
                DarkGreySelection = DarkBase.Multiply(_brightness * 1.367f, _brightness * 1.302f, _brightness * 1.262f).MaybeInvert(IsInverted);
                DarkBlueBorder = DarkBase.Multiply(_brightness * 0.850f, _brightness * 0.968f, _brightness * 1.200f).MaybeInvert(IsInverted);
                LightBlueBorder = DarkBase.Multiply(_brightness * 1.433f, _brightness * 1.540f, _brightness * 1.754f).MaybeInvert(IsInverted);
                ActiveControl = DarkBase.Multiply(_brightness * 2.650f, _brightness * 2.825f, _brightness * 3.015f).MaybeInvert(IsInverted);

                // Text is multiplied by lesser value to preserve contrast
                LightText = DarkBase.Multiply(FontBrightness * 3.667f, FontBrightness * 3.492f, FontBrightness * 3.385f);
                DisabledText = DarkBase.Multiply(FontBrightness * 2.550f, FontBrightness * 2.429f, FontBrightness * 2.354f);

                DebugProperties();
            }
        }

        private static float _brightness = 1.0f; // Set it here by default, so designer will correctly show controls which use brightness natively.
        */
    }
}
