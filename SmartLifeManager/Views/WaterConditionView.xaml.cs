using Newtonsoft.Json;
using SmartLifeManager.Data;
using SmartLifeManager.Models;
using System;
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
        public delegate void onReadDelegat(string text, string text2, string text3);
        public event onReadDelegat onSomthingRead;
        public async Task GetWaterCondition()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://danepubliczne.imgw.pl/api/data/hydro/"))
                    {
                        using (HttpResponseMessage response = await client.SendAsync(request))
                        {

                            response.EnsureSuccessStatusCode();
                            string responseBody = await response.Content.ReadAsStringAsync();
                            List<Water> water = JsonConvert.DeserializeObject<List<Water>>(responseBody);
                            Water selectedWater = water.FirstOrDefault(x => x.StationId == "150190340");

                            LocationLabel.Content += "\n" + selectedWater.Station;
                            RiverLabel.Content = selectedWater.River;
                            WaterStatusLabel.Content = selectedWater.WaterStatus;
                            StatusDateTimeLabel.Content = selectedWater.StatusDateTime;
                            WaterTemperatureLabel.Content = (selectedWater.WaterTemperature == null) ? "brak" : selectedWater.WaterTemperature + UserSettings.TemperatureUnit;
                            IcePhenomenLabel.Content = (selectedWater.IcePhenomen == "0") ? "brak" : selectedWater.IcePhenomen;
                            onSomthingRead?.Invoke(selectedWater.WaterStatus, selectedWater.WaterTemperature, selectedWater.Station);
                        }
                    }
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Connection error");
            }
        }
        public Colors CalculateAirConditionColors(string pm10)
        {
            decimal value = Convert.ToDecimal(pm10);
            if (value > 270)
            {
                return Colors.Red;
            }
            else if (value > 220)
            {
                return Colors.Orange;
            }
            else if (value > 150)
            {
                return Colors.Yellow;
            }
            else if (value > 120)
            {
                return Colors.DarkGreen;
            }
            else
            {
                return Colors.LightGreen;
            }
        }
    }
}
