using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DarkUI.Config
{
    public class ThemeChangedEventArgs : EventArgs
    {
        public ITheme Theme { get; }

        public ThemeChangedEventArgs(ITheme theme)
        {
            Theme = theme;
        }
    }

    public interface ITheme
    {
        Color GreyBackground { get; }
        Color HeaderBackground { get; }
        Color BlueBackground { get; }
        Color DarkBlueBackground { get; }
        Color DarkBackground { get; }
        Color MediumBackground { get; }
        Color LightBackground { get; }
        Color LighterBackground { get; }
        Color LightestBackground { get; }
        Color LightBorder { get; }
        Color DarkBorder { get; }
        Color LightText { get; }
        Color DisabledText { get; }
        Color BlueHighlight { get; }
        Color BlueSelection { get; }
        Color GreyHighlight { get; }
        Color GreySelection { get; }
        Color DarkGreySelection { get; }
        Color DarkBlueBorder { get; }
        Color LightBlueBorder { get; }
        Color ActiveControl { get; }

        Color HighlightBase { get; }
        Color HighlightFill { get; }

        float Brightness { get; }
        float FontBrightness { get; }
    }

    public class DarkTheme : ITheme
    {
        public Color GreyBackground => Color.FromArgb(60, 63, 65);
        public Color HeaderBackground => Color.FromArgb(57, 60, 62);
        public Color BlueBackground => Color.FromArgb(66, 77, 95);
        public Color DarkBlueBackground => Color.FromArgb(52, 57, 66);
        public Color DarkBackground => Color.FromArgb(43, 43, 43);
        public Color MediumBackground => Color.FromArgb(49, 51, 53);
        public Color LightBackground => Color.FromArgb(69, 73, 74);
        public Color LighterBackground => Color.FromArgb(95, 101, 102);
        public Color LightestBackground => Color.FromArgb(178, 178, 178);
        public Color LightBorder => Color.FromArgb(81, 81, 81);
        public Color DarkBorder => Color.FromArgb(51, 51, 51);
        public Color LightText => Color.FromArgb(220, 220, 220);
        public Color DisabledText => Color.FromArgb(153, 153, 153);
        public Color BlueHighlight => Color.FromArgb(104, 151, 187);
        public Color BlueSelection => Color.FromArgb(75, 110, 175);
        public Color GreyHighlight => Color.FromArgb(122, 128, 132);
        public Color GreySelection => Color.FromArgb(92, 92, 92);
        public Color DarkGreySelection => Color.FromArgb(82, 82, 82);
        public Color DarkBlueBorder => Color.FromArgb(51, 61, 78);
        public Color LightBlueBorder => Color.FromArgb(86, 97, 114);
        public Color ActiveControl => Color.FromArgb(159, 178, 196);

        public Color HighlightBase => Color.FromArgb(104, 151, 187);
        public Color HighlightFill => Color.FromArgb(68, 67, 104);

        public float Brightness { get; } = 1.0f;
        public float FontBrightness { get; } = 1.0f;
    }

    public class LightTheme : ITheme
    {
        public Color GreyBackground => Color.FromArgb(195, 192, 190);
        public Color HeaderBackground => Color.FromArgb(198, 196, 193);
        public Color BlueBackground => Color.FromArgb(189, 179, 160);
        public Color DarkBlueBackground => Color.FromArgb(203, 198, 190);
        public Color DarkBackground => Color.FromArgb(212, 212, 212);
        public Color MediumBackground => Color.FromArgb(206, 204, 203);
        public Color LightBackground => Color.FromArgb(186, 182, 182);
        public Color LighterBackground => Color.FromArgb(161, 155, 154);
        public Color LightestBackground => Color.FromArgb(77, 78, 78);
        public Color LightBorder => Color.FromArgb(174, 174, 175);
        public Color DarkBorder => Color.FromArgb(204, 204, 204);
        public Color LightText => Color.FromArgb(60, 60, 60);
        public Color DisabledText => Color.FromArgb(153, 153, 153);
        public Color BlueHighlight => Color.FromArgb(152, 104, 68);
        public Color BlueSelection => Color.FromArgb(180, 146, 81);
        public Color GreyHighlight => Color.FromArgb(134, 127, 123);
        public Color GreySelection => Color.FromArgb(164, 164, 164);
        public Color DarkGreySelection => Color.FromArgb(173, 173, 173);
        public Color DarkBlueBorder => Color.FromArgb(204, 195, 177);
        public Color LightBlueBorder => Color.FromArgb(170, 158, 141);
        public Color ActiveControl => Color.FromArgb(96, 78, 60);

        public Color HighlightBase => Color.FromArgb(104, 151, 187);
        public Color HighlightFill => Color.FromArgb(68, 67, 104);

        public float Brightness { get; } = 1.0f;
        public float FontBrightness { get; } = 1.0f;
    }
}
