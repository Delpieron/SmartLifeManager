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
        private AirConditionView air;
        private WaterConditionView water;
        private WeatherView weather;
        public List<(Style, string, string, string, Widgets)> WidgetsStyles = new List<(Style, string, string, string, Widgets)>();
        public List<(Dictionary<Widgets, Colors>, string, string, string)> colors = new List<(Dictionary<Widgets, Colors>, string, string, string)>();
        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
            this.IsEnabled = false;

            DBAllContext allContext = new DBAllContext(AppDomain.CurrentDomain.BaseDirectory + "smartLifeDB.db");
            var a = allContext.AddTreeElement(new ScheduleModel { Event = "event", RainfallSum = "rain", Wet = "wet", WindDirection = "direction", WindSpeed = "speed", Pressure = "pressure", Temperature = "temperature", ExecutionTime = DateTime.Now });
            var b = allContext.GetElements();
            ChangeView(ViewType.WidgetList);
            air = new AirConditionView();
            air.onSomthingRead += Air_onSomthingRead;
            water = new WaterConditionView();
            water.onSomthingRead += Water_onSomthingRead;
            weather = new WeatherView();
            weather.onSomthingRead += Weather_onSomthingRead;
        }

        private void Weather_onSomthingRead(string text, string text2, string text3)
        {
            Dictionary<Widgets, Colors> a = new Dictionary<Widgets, Colors>();
            a.Add(Widgets.Weather, weather.CalculateAirConditionColors(text));
            (Dictionary<Widgets, Colors>, string, string, string) c = (a, text, text2, text3);
            colors.Add(c);
            if (colors.Count == 3)
            {
                this.IsEnabled = true;
                SetStyle(colors);
            }
        }

        private void Water_onSomthingRead(string text, string text2, string text3)
        {
            Dictionary<Widgets, Colors> a = new Dictionary<Widgets, Colors>();
            a.Add(Widgets.Water, water.CalculateAirConditionColors(text));
            (Dictionary<Widgets, Colors>, string, string, string) c = (a, text, text2, text3);
            colors.Add(c);
            if (colors.Count == 3)
            {
                this.IsEnabled = true;
                SetStyle(colors);
            }
        }

        private void Air_onSomthingRead(string text, string text2, string text3)
        {
            Dictionary<Widgets, Colors> a = new Dictionary<Widgets, Colors>();
            a.Add(Widgets.Air, air.CalculateAirConditionColors(text));
            (Dictionary<Widgets, Colors>, string, string, string) c = (a, text, text2, text3);
            colors.Add(c);
            if (colors.Count == 3)
            {
                this.IsEnabled = true;
                SetStyle(colors);
            }
        }

        public Style testowystyl { get; set; }


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
            ChangeView(ViewType.Empty);
        }

        private void openLocalization(object sender, RoutedEventArgs e)
        {
            string url = "https://www.google.pl/maps/place/Wy%C5%BCsza+Szko%C5%82a+Ekonomii+i+Informatyki+w+Krakowie/@50.0681723,19.9389599,17z/data=!3m1!4b1!4m5!3m4!1s0x47165b053d076b5d:0x3c2561cb07bc3dd2!8m2!3d50.0681689!4d19.9411486";
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
        }
        #endregion
        //weather water air
        private void SetStyle(List<(Dictionary<Widgets, Colors>, string, string, string)> colors)
        {

            foreach (var item in colors)
            {
                foreach (var item2 in item.Item1)
                {
                    switch (item2.Value)
                    {
                        case Colors.DarkGreen:
                            WidgetsStyles.Add(((Style)Application.Current.MainWindow.TryFindResource("DarkGreen"), item.Item2, item.Item3, item.Item4, item2.Key));
                            break;
                        case Colors.LightGreen:
                            WidgetsStyles.Add(((Style)Application.Current.MainWindow.TryFindResource("LightGreen"), item.Item2, item.Item3, item.Item4, item2.Key));
                            break;
                        case Colors.Yellow:
                            WidgetsStyles.Add(((Style)Application.Current.MainWindow.TryFindResource("Yellow"), item.Item2, item.Item3, item.Item4, item2.Key));
                            break;
                        case Colors.Orange:
                            WidgetsStyles.Add(((Style)Application.Current.MainWindow.TryFindResource("Orange"), item.Item2, item.Item3, item.Item4, item2.Key));
                            break;
                        case Colors.Red:
                            WidgetsStyles.Add(((Style)Application.Current.MainWindow.TryFindResource("Red"), item.Item2, item.Item3, item.Item4, item2.Key));
                            break;
                        default:
                            break;
                    }
                }

            }
            ChangeView(ViewType.Empty);
        }
    }
}
