using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Control.ControllerSystems
{
    
    public class Teapot
    {
        public void TurnOn()
        {
            Console.WriteLine("Kettle included");
            State = State.On;
        }

        public void TurnOff()
        {
            Console.WriteLine("The kettle is off");
            State = State.Off;
        }

        public State State { get; set; }
    }
}
