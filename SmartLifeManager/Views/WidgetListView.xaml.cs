using System.Collections.Generic;
using System.Windows;

namespace SmartLifeManager.Views
{
    /// <summary>
    /// Interaction logic for WidgetListView.xaml
    /// </summary>
    public partial class WidgetListView : BaseViewControl
    {
        public WidgetListView()
        {
            InitializeComponent();
        }
        public WidgetListView(List<Style> style)
        {
            InitializeComponent();
            Weather.Style = style[0];
            Water.Style = style[1];
            Air.Style = style[2];
        }

        private void woda(object sender, System.Windows.RoutedEventArgs e)
        {
            onViewChange(ViewType.WaterCondition);
        }

        private void powietrze(object sender, System.Windows.RoutedEventArgs e)
        {
            onViewChange(ViewType.AirCondition);
        }

        private void harmonogram(object sender, System.Windows.RoutedEventArgs e)
        {
            onViewChange(ViewType.TimeTable);
        }

        private void ustawienia(object sender, System.Windows.RoutedEventArgs e)
        {
            onViewChange(ViewType.Settings);
        }

        private void pogoda(object sender, System.Windows.RoutedEventArgs e)
        {
            onViewChange(ViewType.Weather);
        }

        private void connectedDevices(object sender, System.Windows.RoutedEventArgs e)
        {
            onViewChange(ViewType.ConnectedDevices);
        }
    }
}
