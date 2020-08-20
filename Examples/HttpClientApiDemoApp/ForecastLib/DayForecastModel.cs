namespace ForecastLib
{
    public class DayForecastModel
    {
        public string Weather_state_name { get; set; }
        public string Applicable_date { get; set; }
        public float Min_temp { get; set; }
        public float Max_temp { get; set; }
        public float The_temp { get; set; }
        public float Wind_speed { get; set; }
        public float Wind_direction { get; set; }
        public float Air_pressure { get; set; }
        public int Humidity { get; set; }
        public float Visibility { get; set; }
        public int Predictability { get; set; }
    }
}
