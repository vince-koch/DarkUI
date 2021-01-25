using DarkUI.Config;
using System.Drawing;
using System.Windows.Forms;

namespace DarkUI.Controls
{
    public class DarkPanel : Panel
    {
        public DarkPanel()
        {
            SetStyle(ControlStyles.UserPaint    | 
                     ControlStyles.ResizeRedraw | 
                     ControlStyles.DoubleBuffer | 
                     ControlStyles.AllPaintingInWmPaint, true);

            base.BorderStyle = BorderStyle.None;

            Colors.ThemeChanged += HandleThemeChanged;
        }

        protected override void DestroyHandle()
        {
            Colors.ThemeChanged -= HandleThemeChanged;
            base.DestroyHandle();
        }

        private void HandleThemeChanged(object sender, ThemeChangedEventArgs e)
        {
            BackColor = e.Theme.GreyBackground;
            ForeColor = e.Theme.LightText;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (BorderStyle == BorderStyle.FixedSingle)
            {
                using (var p = new Pen(Colors.GreySelection, 1))
                    e.Graphics.DrawRectangle(p, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (var b = new SolidBrush(BackColor))
                e.Graphics.FillRectangle(b, ClientRectangle);

            if (BorderStyle == BorderStyle.FixedSingle)
            {
                using (var p = new Pen(Colors.GreySelection, 1))
                    e.Graphics.DrawRectangle(p, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            }
        }
    }
}
