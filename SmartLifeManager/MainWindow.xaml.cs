using SmartLifeManager.Views;
using System;
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
            InitializeComponent();
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
