using SmartLifeManager.Data;
using SmartLifeManager.Models;
using SmartLifeManager.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
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

            DBAllContext allContext = new DBAllContext(AppDomain.CurrentDomain.BaseDirectory + "smartLifeDB.db");
            var a = allContext.AddTreeElement(new ScheduleModel { Event = "event", RainfallSum = "rain", Wet = "wet", WindDirection = "direction", WindSpeed = "speed", Pressure = "pressure", Temperature = "temperature", ExecutionTime = DateTime.Now });
            var b = allContext.GetElements();
            ChangeView(ViewType.WidgetList);

            SetStyle(new List<Colors> { Colors.Yellow, Colors.Orange, Colors.Red });
        }
        public Style testowystyl { get; set; }
        public List<Style> WidgetsStyles = new List<Style>();

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
                case ViewType.ConnectedDevices:
                    currentView = new ConnectedDevicesView();
                    break;
                case ViewType.Empty:
                    currentView = new WidgetListView(WidgetsStyles);
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
        private void Control_onViewChangeHandler(object sender, ViewTypeEventArgs e)
        {
            ChangeView(e.Type, e.TestPointCreated);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChangeView(ViewType.WidgetList);
        }

        private void openLocalization(object sender, RoutedEventArgs e)
        {
            string url = "https://www.google.pl/maps/place/Wy%C5%BCsza+Szko%C5%82a+Ekonomii+i+Informatyki+w+Krakowie/@50.0681723,19.9389599,17z/data=!3m1!4b1!4m5!3m4!1s0x47165b053d076b5d:0x3c2561cb07bc3dd2!8m2!3d50.0681689!4d19.9411486";
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
        }
        #endregion
        //weather water air
        private void SetStyle(List<Colors> colors)
        {
            foreach (var item in colors)
            {
                switch (item)
                {
                    case Colors.DarkGreen:
                        WidgetsStyles.Add((Style)Application.Current.MainWindow.TryFindResource("DarkGreen"));
                        break;
                    case Colors.LightGreen:
                        WidgetsStyles.Add((Style)Application.Current.MainWindow.TryFindResource("LightGreen"));
                        break;
                    case Colors.Yellow:
                        WidgetsStyles.Add((Style)Application.Current.MainWindow.TryFindResource("Yellow"));
                        break;
                    case Colors.Orange:
                        WidgetsStyles.Add((Style)Application.Current.MainWindow.TryFindResource("Orange"));
                        break;
                    case Colors.Red:
                        WidgetsStyles.Add((Style)Application.Current.MainWindow.TryFindResource("Red"));
                        break;
                    default:
                        break;
                }
            }
            ChangeView(ViewType.Empty);
        }
    }
}
