﻿namespace wheatherObserver.Interfaces
{
    public interface IObserver
    {
        void Update(float temp, float humidity, float pressure);
    }
}
