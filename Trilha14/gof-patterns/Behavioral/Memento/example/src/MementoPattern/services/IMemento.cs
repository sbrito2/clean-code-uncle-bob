using System;

namespace MementoPattern.services
{
    public interface IMemento
    {
        string GetName();
        string GetState();
        DateTime GetDate();
    }
}