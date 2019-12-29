﻿namespace WeatherConsole
{
	using System.Threading.Tasks;
	using static System.Console;

	public class Program
	{
		public static void Main(string[] args)
		{
			Run().Wait();
		}

		private static async Task Run()
		{
			var city = "Indore, IN";
			var client = new OpenWeatherMapClient();
			WriteLine($"Fetching weather for {city}");
			var weather = await client.GetCurrentWeatherByCity(city);
			if (weather == null)
			{
				WriteLine("Failed to fetch weather information.");
				return;
			}
			WriteLine($"\nTemp: {weather.Main?.Temperature}");
			WriteLine($"Low: {weather.Main?.MinTemperature}");
			WriteLine($"High: {weather.Main?.MaxTemperature}");
			WriteLine($"Humidity: {weather.Main?.Humidity}%");
			WriteLine($"Condition: {weather.FirstCondition?.Description}");
		}
	}
}