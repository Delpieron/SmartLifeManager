﻿using Newtonsoft.Json;
using SmartLifeManager.Data;
using SmartLifeManager.Models;
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
