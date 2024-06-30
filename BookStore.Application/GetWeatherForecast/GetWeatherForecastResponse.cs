using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.GetWeatherForecast
{
  public class GetWeatherForecastResponse
  {
    public List<WeatherForecast> WeatherForecastData {  get; set; }
  }
}
