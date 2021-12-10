using SmartLifeManager.Data;
using System.Windows;

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
            //File.Create(@"D:\kupa.sqlite");

            DBAllContext allContext = new DBAllContext("D:\\RatMonDB.RM2");
            allContext.CreateStructure("schedule");

        }
    }
}
