using System;

namespace simple_iot_weather_station.Models
{
    public class WeatherReportPostDTO
    {
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public int Uv { get; set; }
        public int Raining { get; set; }
        public int Light { get; set; }
    }
}
