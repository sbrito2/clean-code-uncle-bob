using System;
using wheatherObserver.Interfaces;

namespace wheatherObserver.Subjects
{
    public class CurrentConditionsDisplay : IObserver, IDisplayElement
    {
        private float temperature;
        private float humidity;
        private ISubject wheaterData;

        public CurrentConditionsDisplay(ISubject weatherData)
        {
            this.wheaterData = weatherData;
            weatherData.RegisterObserver(this);
        }

        public void Update(float temp, float humidity, float pressure)
        {
            this.temperature = temp;
            this.humidity = humidity;
            Display();
        }

        public void Display()
        {
            string line = String.Format("Current conditions: {0:f1}F degrees and {1:f1}% humidity",
                                        temperature, humidity);
            Console.WriteLine(line);
        }
    }
}
