using System.Windows.Media;

namespace SmartLifeManager.Views
{
    /// <summary>
    /// Interaction logic for WeatherView.xaml
    /// </summary>
    public partial class WeatherView : BaseViewControl
    {
        public WeatherView()
        {
            InitializeComponent();
            imageBox.Content = "\u2601";
            imageBox.Foreground = Brushes.DarkGray;
        }

        private void test(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            imageBox.Content = "\u2600";
            imageBox.Foreground = Brushes.Yellow;
        }
    }
}
