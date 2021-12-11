using Newtonsoft.Json;
using SmartLifeManager.Data;
using SmartLifeManager.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SmartLifeManager.Views
{
    /// <summary>
    /// Interaction logic for WeatherView.xaml
    /// </summary>
    public partial class WeatherView : BaseViewControl
    {

        public WeatherView()
        {
            InitializeComponent();
            GetWeatherData();
        }
        public delegate void onReadDelegat(string text, string text2, string text3);
        public event onReadDelegat onSomthingRead;
        string city = UserSettings.City;
        private async Task GetWeatherData()
        {
            imageBox.Content = "\u2601";
            imageBox.Foreground = Brushes.DarkGray;
            try
            {
                using (var client = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Get, "https://danepubliczne.imgw.pl/api/data/synop/station/" + city.ToLower()))
                    {
                        using (var response = await client.SendAsync(request))
                        {
                            response.EnsureSuccessStatusCode();
                            var responseBody = await response.Content.ReadAsStringAsync();
                            Weather weather = JsonConvert.DeserializeObject<Weather>(responseBody);

                            LocationLabel.Content += "\n" + city;
                            DateAndTimeLabel.Content = weather.Date + " " + weather.Time + ":00";
                            TemperatureLabel.Content = weather.Temperature + " " + UserSettings.TemperatureUnit;
                            WindSpeedLabel.Content = weather.WindSpeed + UserSettings.Speed;
                            WindDirectionLabel.Content = weather.WindDirection;
                            WetLabel.Content = weather.Wet + " g/m³";
                            TotalPrecipitationLabel.Content = weather.TotalPrecipitation + " mm/m²";
                            PressureLabel.Content = weather.Pressure + UserSettings.Pressure;
                            onSomthingRead?.Invoke(weather.Pressure.ToString(), weather.Temperature.ToString(), weather.Wet.ToString());
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
            var value = Convert.ToDecimal(pm10);
            if (value < 980)
            {
                return Colors.Orange;
            }
            else if (value < 1000)
            {
                return Colors.LightGreen;
            }
            else if (value < 1015)
            {
                return Colors.DarkGreen;
            }
            else if (value < 1030)
            {
                return Colors.Yellow;
            }
            return Colors.Red;
        }
    }
}
