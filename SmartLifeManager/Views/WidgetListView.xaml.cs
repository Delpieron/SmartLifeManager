using SmartLifeManager.Data;
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
        public WidgetListView(List<(Style, string, string, string, Widgets)> colors)
        {
            InitializeComponent();
            foreach (var item in colors)
            {
                switch (item.Item5)
                {
                    case Widgets.Weather:
                        Weather.Style = item.Item1;
                        temp.Content = item.Item3 + UserSettings.TemperatureUnit;
                        pre.Content = item.Item2 + UserSettings.Pressure;
                        wet.Content = item.Item4 + " g/m³";
                        break;
                    case Widgets.Water:
                        Water.Style = item.Item1;
                        sta.Content = item.Item4;
                        wodtemp.Content = item.Item3 + UserSettings.TemperatureUnit;
                        wodstan.Content = item.Item2;
                        break;
                    case Widgets.Air:
                        Air.Style = item.Item1;
                        pm10.Content = item.Item2 + UserSettings.Content;
                        pm25.Content = item.Item3 + UserSettings.Content;
                        so2.Content = item.Item4 + UserSettings.Content;
                        break;
                    default:
                        break;
                }
            }

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
