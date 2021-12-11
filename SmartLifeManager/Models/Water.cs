namespace SmartLifeManager.Models
{
    public class Water
    {
        public string StationId;
        public string Station;
        public string River;
        public string WaterStatus;
        public string StatusDateTime;
        public string WaterTemperature;
        public string TemperatureDateTime;
        public string IcePhenomen;
        public string IceDateTime;
        public string FoulingPhenomenon;
        public string FoulingDateTime;

        public Water(string id_stacji, string stacja, string rzeka, string stan_wody, string stan_wody_data_pomiaru, string temperatura_wody, string temperatura_wody_data_pomiaru, string zjawisko_lodowe, string zjawisko_lodowe_data_pomiaru, string zjawisko_zarastania, string zjawisko_zarastania_data_pomiaru)
        {
            StationId = id_stacji;
            River = rzeka;
            Station = stacja;
            WaterStatus = stan_wody;
            StatusDateTime = stan_wody_data_pomiaru;
            WaterTemperature = temperatura_wody;
            TemperatureDateTime = temperatura_wody_data_pomiaru;
            IcePhenomen = zjawisko_lodowe;
            IceDateTime = zjawisko_lodowe_data_pomiaru;
            FoulingPhenomenon = zjawisko_zarastania;
            FoulingDateTime = zjawisko_zarastania_data_pomiaru;
        }
    }
}
