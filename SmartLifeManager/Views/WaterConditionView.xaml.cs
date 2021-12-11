using Newtonsoft.Json;
using SmartLifeManager.Data;
using SmartLifeManager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
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
            GetWaterCondition();
        }
        public async Task GetWaterCondition()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Get, "https://danepubliczne.imgw.pl/api/data/hydro/"))
                    {
                        using (var response = await client.SendAsync(request))
                        {

                            response.EnsureSuccessStatusCode();
                            var responseBody = await response.Content.ReadAsStringAsync();
                            List<Water> water = JsonConvert.DeserializeObject<List<Water>>(responseBody);
                            var selectedWater = water.FirstOrDefault(x => x.StationId == "150190340");

                            LocationLabel.Content += "\n" + selectedWater.Station;
                            RiverLabel.Content = selectedWater.River;
                            WaterStatusLabel.Content = selectedWater.WaterStatus;
                            StatusDateTimeLabel.Content = selectedWater.StatusDateTime;
                            WaterTemperatureLabel.Content = (selectedWater.WaterTemperature == null) ? "brak" : selectedWater.WaterTemperature + UserSettings.TemperatureUnit;
                            IcePhenomenLabel.Content = (selectedWater.IcePhenomen == "0") ? "brak" : selectedWater.IcePhenomen;
                        }
                    }
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Connection error");
            }

        }
    }
}
