using Command_Control.ControllerSystems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Control.Command
{
    public class TeapotCommand : ICommand
    {
        private Teapot _teapot;

        public TeapotCommand(Teapot teapot)
        {
            _teapot = teapot;
        }
        public void Execute()
        {
            _teapot.TurnOn();
        }

        public void Undo()
        {
            _teapot.TurnOff();
        }

        public override string ToString()
        {
            return "Turn on the kettle";
        }
    }
}
