using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wheatherObserver.Interfaces;

namespace wheatherObserver.Subjects
{
    public class ForecastDisplay : IObserver, IDisplayElement
    {
        private float currentPressure = 29.92f;
        private float lastPressure;
        private WeatherData weatherData;

        public ForecastDisplay(WeatherData weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }

        public void Update(float temp, float humidity, float pressure)
        {
            lastPressure = currentPressure;
            currentPressure = pressure;

            Display();
        }

        public void Display()
        {
            Console.Write("Forecast: ");
            if (currentPressure > lastPressure)
            {
                Console.WriteLine("Improving weather on the way!");
            }
            else if (currentPressure == lastPressure)
            {
                Console.WriteLine("More of the same");
            }
            else if (currentPressure < lastPressure)
            {
                Console.WriteLine("Watch out for cooler, rainy weather");
            }
        }
    }
}
