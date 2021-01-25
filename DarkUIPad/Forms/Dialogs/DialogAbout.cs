﻿using System.Windows.Forms;
using DarkUI.Forms;

namespace DarkUIPad.Forms.Dialogs
{
    public partial class DialogAbout : DarkDialog
    {
        #region Constructor Region

        public DialogAbout()
        {
            InitializeComponent();

            lblVersion.Text = $"Version: {Application.ProductVersion}";
            btnOk.Text = "Close";
        }

        #endregion
    }
}
