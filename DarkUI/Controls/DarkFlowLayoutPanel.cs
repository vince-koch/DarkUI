using System;
using System.Windows.Forms;

using DarkUI.Config;

namespace DarkUI.Controls
{
    public class DarkFlowLayoutPanel : FlowLayoutPanel
    {
        public DarkFlowLayoutPanel()
        {
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
    }
}
