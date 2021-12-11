namespace SmartLifeManager.Models
{
    public class Weather
    {
        public string Date;
        public string Time;
        public float Temperature;
        public float WindSpeed;
        public int WindDirection;
        public float Wet;
        public float TotalPrecipitation;
        public float Pressure;

        public Weather(string data_pomiaru, string godzina_pomiaru, float temperatura, float predkosc_wiatru, int kierunek_wiatru, float wilgotnosc_wzgledna, float suma_opadu, float cisnienie)
        {
            Date = data_pomiaru;
            Time = godzina_pomiaru;
            Temperature = temperatura;
            WindSpeed = predkosc_wiatru;
            WindDirection = kierunek_wiatru;
            Wet = wilgotnosc_wzgledna;
            TotalPrecipitation = suma_opadu;
            Pressure = cisnienie;
        }
    }
}
