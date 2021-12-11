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
    /// Interaction logic for AirConditionView.xaml
    /// </summary>
    public partial class AirConditionView : BaseViewControl
    {
        public string pm10 { get; set; }
        public string pm25 { get; set; }
        public string so2 { get; set; }
        public AirConditionView()
        {
            InitializeComponent();

            imageBox.Content = "\u263A";
            imageBox.Foreground = Brushes.DarkGray;

            GetAirCondition();
        }
        public delegate void onReadDelegat(string text, string pm25, string so2);
        public event onReadDelegat onSomthingRead;
        public async Task GetAirCondition()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpRequestMessage request_C6H6 = new HttpRequestMessage(HttpMethod.Get, "https://api.gios.gov.pl/pjp-api/rest/data/getData/2779");
                    HttpRequestMessage request_CO = new HttpRequestMessage(HttpMethod.Get, "https://api.gios.gov.pl/pjp-api/rest/data/getData/2783");
                    HttpRequestMessage request_PM10 = new HttpRequestMessage(HttpMethod.Get, "https://api.gios.gov.pl/pjp-api/rest/data/getData/2792");
                    HttpRequestMessage request_PM25 = new HttpRequestMessage(HttpMethod.Get, "https://api.gios.gov.pl/pjp-api/rest/data/getData/2794");
                    HttpRequestMessage request_NO2 = new HttpRequestMessage(HttpMethod.Get, "https://api.gios.gov.pl/pjp-api/rest/data/getData/2788");
                    HttpRequestMessage request_SO2 = new HttpRequestMessage(HttpMethod.Get, "https://api.gios.gov.pl/pjp-api/rest/data/getData/2797");
                    try
                    {
                        HttpResponseMessage response_C6H6 = await client.SendAsync(request_C6H6);
                        HttpResponseMessage response_CO = await client.SendAsync(request_CO);
                        HttpResponseMessage response_PM10 = await client.SendAsync(request_PM10);
                        HttpResponseMessage response_PM25 = await client.SendAsync(request_PM25);
                        HttpResponseMessage response_NO2 = await client.SendAsync(request_NO2);
                        HttpResponseMessage response_SO2 = await client.SendAsync(request_SO2);

                        try
                        {
                            response_C6H6.EnsureSuccessStatusCode();
                            string responseBody_C6H6 = await response_C6H6.Content.ReadAsStringAsync();
                            response_CO.EnsureSuccessStatusCode();
                            string responseBody_CO = await response_CO.Content.ReadAsStringAsync();
                            response_PM10.EnsureSuccessStatusCode();
                            string responseBody_PM10 = await response_PM10.Content.ReadAsStringAsync();
                            response_PM25.EnsureSuccessStatusCode();
                            string responseBody_PM25 = await response_PM25.Content.ReadAsStringAsync();
                            response_NO2.EnsureSuccessStatusCode();
                            string responseBody_NO2 = await response_NO2.Content.ReadAsStringAsync();
                            response_SO2.EnsureSuccessStatusCode();
                            string responseBody_SO2 = await response_SO2.Content.ReadAsStringAsync();


                            Air air_C6H6 = JsonConvert.DeserializeObject<Air>(responseBody_C6H6);
                            Air air_CO = JsonConvert.DeserializeObject<Air>(responseBody_CO);
                            Air air_PM10 = JsonConvert.DeserializeObject<Air>(responseBody_PM10);
                            Air air_PM25 = JsonConvert.DeserializeObject<Air>(responseBody_PM25);
                            Air air_NO2 = JsonConvert.DeserializeObject<Air>(responseBody_NO2);
                            Air air_SO2 = JsonConvert.DeserializeObject<Air>(responseBody_SO2);

                            int start = 0;
                            switch (start)
                            {
                                case 0:
                                    foreach (System.Collections.Generic.Dictionary<string, string> item in air_C6H6.Values)
                                    {
                                        if (item["value"] != null)
                                        {
                                            BenzenLabel.Content = Math.Round(Convert.ToDecimal(item["value"].Replace(".", ",")), 2) + UserSettings.Content;
                                            BenzenDate.Content = item["date"];
                                            goto case 1;
                                        }
                                    }
                                    goto case 1;
                                case 1:
                                    foreach (System.Collections.Generic.Dictionary<string, string> item in air_CO.Values)
                                    {
                                        if (item["value"] != null)
                                        {
                                            COLabel.Content = Math.Round(Convert.ToDecimal(item["value"].Replace(".", ",")), 2) + UserSettings.CoContent;
                                            CODate.Content = item["date"];
                                            goto case 2;
                                        }
                                    }
                                    goto case 2;
                                case 2:
                                    foreach (System.Collections.Generic.Dictionary<string, string> item in air_PM10.Values)
                                    {
                                        if (item["value"] != null)
                                        {
                                            PM10Label.Content = Math.Round(Convert.ToDecimal(item["value"].Replace(".", ",")), 2) + UserSettings.Content;
                                            PM10Date.Content = item["date"];
                                            pm10 = Math.Round(Convert.ToDecimal(item["value"].Replace(".", ",")), 2).ToString();
                                            goto case 3;
                                        }
                                    }
                                    goto case 3;
                                case 3:
                                    foreach (System.Collections.Generic.Dictionary<string, string> item in air_PM25.Values)
                                    {
                                        if (item["value"] != null)
                                        {
                                            PM25Label.Content = Math.Round(Convert.ToDecimal(item["value"].Replace(".", ",")), 2) + UserSettings.Content;
                                            PM25Date.Content = item["date"];
                                            pm25 = Math.Round(Convert.ToDecimal(item["value"].Replace(".", ",")), 2).ToString();
                                            goto case 4;
                                        }
                                    }
                                    goto case 4;
                                case 4:
                                    foreach (System.Collections.Generic.Dictionary<string, string> item in air_NO2.Values)
                                    {
                                        if (item["value"] != null)
                                        {
                                            NO2Label.Content = Math.Round(Convert.ToDecimal(item["value"].Replace(".", ",")), 2) + UserSettings.Content;
                                            NO2Date.Content = item["date"];
                                            goto case 5;
                                        }
                                    }
                                    goto case 5;
                                case 5:
                                    foreach (System.Collections.Generic.Dictionary<string, string> item in air_SO2.Values)
                                    {
                                        if (item["value"] != null)
                                        {
                                            SO2Label.Content = Math.Round(Convert.ToDecimal(item["value"].Replace(".", ",")), 2) + UserSettings.Content;
                                            SO2Date.Content = item["date"];
                                            so2 = Math.Round(Convert.ToDecimal(item["value"].Replace(".", ",")), 2).ToString();
                                            break;
                                        }
                                    }
                                    break;
                            }
                            LocationLabel.Content += "\n Krakow, ul. Bulwarowa";

                        }

                        finally
                        {
                            response_C6H6.Dispose();
                            response_CO.Dispose();
                            response_PM10.Dispose();
                            response_PM25.Dispose();
                            response_NO2.Dispose();
                            response_SO2.Dispose();
                        }
                    }
                    finally
                    {
                        request_C6H6.Dispose();
                        request_CO.Dispose();
                        request_PM10.Dispose();
                        request_PM25.Dispose();
                        request_NO2.Dispose();
                        request_SO2.Dispose();

                    }
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Connection error");
            }
            onSomthingRead?.Invoke(pm10, pm25, so2);
        }
        public Colors CalculateAirConditionColors(string pm10)
        {
            decimal value = Convert.ToDecimal(pm10);
            if (value < 40)
            {
                return Colors.DarkGreen;
            }
            else if (value < 70)
            {
                return Colors.LightGreen;
            }
            else if (value < 100)
            {
                return Colors.Yellow;
            }
            else if (value < 140)
            {
                return Colors.Orange;
            }
            return Colors.Red;
        }
        public string CalculateAirCondition(string pm10)
        {
            decimal value = Convert.ToDecimal(pm10);
            if (value < 40)
            {
                return "Bardzo dobry";
            }
            else if (value < 70)
            {
                return "Umiarkowany";
            }
            else if (value < 100)
            {
                return "Dostateczny";
            }
            else if (value < 140)
            {
                return "Zły";
            }
            return "Bardzo zły";
        }
    }
}
