using System.Windows;

namespace SmartLifeManager.Views
{
    /// <summary>
    /// Interaction logic for AddNewCalendarEventWindow.xaml
    /// </summary>
    public partial class AddNewCalendarEventWindow : Window
    {
        public AddNewCalendarEventWindow()
        {
            InitializeComponent();
            GotFocus += MainWindow_GotFocus;
        }

        void MainWindow_GotFocus(object sender, RoutedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)e.OriginalSource;

            if (txtBox == element || popup == element || element.Parent == popup)
                return;

            popup.IsOpen = !string.IsNullOrEmpty(txtBox.Text);
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = true;
        }
    }
}
