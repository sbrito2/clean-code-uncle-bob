using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Control.ControllerSystems
{
    public enum State
    {
        Off = 0,
        On = 1
    }
    public class Music
    {
        public void TurnOn()
        {
            Console.WriteLine("Music on");
            State = State.On;
        }

        public void TurnOff()
        {
            Console.WriteLine("Music off");
            State = State.Off;
        }

        public State State { get; set; }
    }
}
