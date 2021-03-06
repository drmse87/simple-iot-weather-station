using System;
using System.ComponentModel.DataAnnotations;

namespace simple_iot_weather_station.Models
{
    public class WeatherReport
    {
        [Key]
        public string ReportId { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public int Uv { get; set; }
        public int Raining { get; set; }
        public int Light { get; set; }
        public DateTime ReportDate { get; set; }
    }
}
