using System.Windows.Media;

namespace SmartLifeManager.Views
{
    /// <summary>
    /// Interaction logic for AirConditionView.xaml
    /// </summary>
    public partial class AirConditionView : BaseViewControl
    {
        public AirConditionView()
        {
            InitializeComponent();

            imageBox.Content = "\u263A";
            imageBox.Foreground = Brushes.DarkGray;
        }
    }
}
