using System.Windows.Media;

namespace SmartLifeManager.Views
{
    /// <summary>
    /// Interaction logic for ConnectedDevicesView.xaml
    /// </summary>
    public partial class ConnectedDevicesView : BaseViewControl
    {
        public ConnectedDevicesView()
        {
            InitializeComponent();
            imageBox.Content = "\u26CA";
            imageBox.Foreground = Brushes.Gray;
        }
    }
}
