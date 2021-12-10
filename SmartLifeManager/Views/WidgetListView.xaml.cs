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
    }
}
