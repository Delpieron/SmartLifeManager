using SmartLifeManager.Data;
using SmartLifeManager.Views;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static SmartLifeManager.Views.BaseViewControl;

namespace SmartLifeManager
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
            //File.Create(@"D:\kupa.sqlite");

            DBAllContext allContext = new DBAllContext("D:\\RatMonDB.RM2");
            allContext.CreateStructure("schedule");

            ChangeView(ViewType.WidgetList);
        }


        #region ViewManager
        BaseViewControl currentView = null;
        public void ChangeView(ViewType view, bool testPointCreated = false)
        {
            if (currentView != null)
            {
                currentView.prepareToCloseControl(); //mozna dodac bool zabezpiecznie
                MainView.Children.Remove(currentView);
                currentView = null;
            }
            switch (view)
            {
                case ViewType.AirCondition:
                    currentView = new AirConditionView();
                    break;
                case ViewType.Settings:
                    currentView = new SettingsView();
                    break;
                case ViewType.TimeTable:
                    currentView = new TimeTableView();
                    break;
                case ViewType.WaterCondition:
                    currentView = new WaterConditionView();
                    break;
                case ViewType.Weather:
                    currentView = new WeatherView();
                    break;
                case ViewType.WidgetList:
                    currentView = new WidgetListView();
                    break;
                default:
                    currentView = new WidgetListView();
                    break;
            }
            if (currentView != null)
            {
                currentView.onViewChangeHandler += Control_onViewChangeHandler;
                MainView.Children.Add(currentView);
                currentView.PrepareOnStart();
            }
        }

        private void Btn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static ICommand CustomRoutedCommand = new RoutedCommand();
        private void CanExecuteCustomCommand(object sender,
    CanExecuteRoutedEventArgs e)
        {
            Control target = e.Source as Control;

            if (target != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }
        private void Control_onViewChangeHandler(object sender, ViewTypeEventArgs e)
        {
            ChangeView(e.Type, e.TestPointCreated);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChangeView(ViewType.WidgetList);
        }

        private bool _hasValidURI;

        public bool HasValidURI
        {
            get { return _hasValidURI; }
            set { _hasValidURI = value; OnPropertyChanged("HasValidURI"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(name));
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Uri uri;
            HasValidURI = Uri.TryCreate((sender as TextBox).Text, UriKind.Absolute, out uri);
        }


        private void openLocalization(object sender, RoutedEventArgs e)
        {
            string url = "https://www.google.pl/maps/place/Wy%C5%BCsza+Szko%C5%82a+Ekonomii+i+Informatyki+w+Krakowie/@50.0681723,19.9389599,17z/data=!3m1!4b1!4m5!3m4!1s0x47165b053d076b5d:0x3c2561cb07bc3dd2!8m2!3d50.0681689!4d19.9411486";
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
        }
        #endregion

        //private void GoToSelectName(object sender, MouseButtonEventArgs e)
        //{
        //    ChangeView(ViewType.SelectNameView, new TestPointElement());
        //}

        //private void GoToMainMenu(object sender, MouseButtonEventArgs e)
        //{
        //    ChangeView(ViewType.SelectionMeasureView, new TestPointElement());
        //}
    }
}
