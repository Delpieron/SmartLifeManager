using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartLifeManager.Views
{
    /// <summary>
    /// Interaction logic for TimeTableView.xaml
    /// </summary>
    public partial class TimeTableView : BaseViewControl
    {
        public TimeTableView()
        {
            InitializeComponent();
            imageBox.Content = "\u2618";
            imageBox.Foreground = Brushes.DarkGray;
            GotFocus += MainWindow_GotFocus;
        }

        private void MainWindow_GotFocus(object sender, RoutedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)e.OriginalSource;

            if (txtBox == element || popup == element || element.Parent == popup)
            {
                return;
            }

            popup.IsOpen = !string.IsNullOrEmpty(txtBox.Text);
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = true;
        }
        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            Calendar calendar = sender as Calendar;

            if (calendar.SelectedDate.HasValue)
            {
                DateTime date = calendar.SelectedDate.Value;
                ToolTip = date.ToShortDateString();

            }
        }

    }
}
