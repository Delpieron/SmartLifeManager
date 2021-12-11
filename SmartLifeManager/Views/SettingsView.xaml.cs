﻿using System.Windows.Media;

namespace SmartLifeManager.Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : BaseViewControl
    {
        public SettingsView()
        {
            InitializeComponent();
            imageBox.Content = "\u2699";
            imageBox.Foreground = Brushes.Gray;
        }
    }
}
