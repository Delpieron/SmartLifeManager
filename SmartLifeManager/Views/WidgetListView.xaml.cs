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

        private void pogoda(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            onViewChange(ViewType.Weather);
        }

        private void woda(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            onViewChange(ViewType.WaterCondition);
        }

        private void powietrze(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            onViewChange(ViewType.AirCondition);
        }

        private void harmonogram(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            onViewChange(ViewType.TimeTable);
        }

        private void ustawienia(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            onViewChange(ViewType.Settings);
        }
    }
}
