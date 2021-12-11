using System.Windows.Media;

namespace SmartLifeManager.Views
{
    /// <summary>
    /// Interaction logic for WaterConditionView.xaml
    /// </summary>
    public partial class WaterConditionView : BaseViewControl
    {
        public WaterConditionView()
        {
            InitializeComponent();
            imageBox.Content = "\u2693";
            imageBox.Foreground = Brushes.DarkGray;
        }
    }
}
