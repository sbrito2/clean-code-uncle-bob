using Command_Control.ControllerSystems;
using System;

namespace Command_Control.Command
{
    public class TVCommand : ICommand
    {
        private TV _tv;

        public TVCommand(TV tv)
        {
            _tv = tv;
        }
        public void Execute()
        {
            _tv.TurnOn();
        }

        public void Undo()
        {
            _tv.TurnOff();
        }
        public override string ToString()
        {
            return "Turn on the TV";
        }
    }
}
