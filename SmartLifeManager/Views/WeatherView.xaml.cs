using Newtonsoft.Json;
using SmartLifeManager.Data;
using SmartLifeManager.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

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

        string city = UserSettings.City;
        private async Task GetWeatherData()
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
                        DateAndTimeLabel.Content = weather.Date + "  " + weather.Time + ":00";
                        TemperatureLabel.Content = weather.Temperature + " °C";
                        WindSpeedLabel.Content = weather.WindSpeed + " m/s";
                        WindDirectionLabel.Content = weather.WindDirection;
                        WetLabel.Content = weather.Wet + " g/m³";
                        TotalPrecipitationLabel.Content = weather.TotalPrecipitation + " mm/m²";
                        PressureLabel.Content = weather.Pressure + " hPa";
                    }
                }
            }


        }
    }
}
