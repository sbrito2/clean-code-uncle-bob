using Command_Control.ControllerSystems;
using System;
using System.Collections.Generic;

namespace Command_Control.Command
{
    public class LightCommand : ICommand
    {
        private Light _light;
        private Stack<LightState> _states;
        public LightCommand(Light light)
        {
            _light = light;
            _states = new Stack<LightState>();
        }
        public void Execute()
        {
            _states.Push(_light.State);
            _light.ToggleLight();
        }

        public void Undo()
        {
            var prevStates = _states.Pop();
            _light.SetState(prevStates);
        }

        public override string ToString()
        {
            return "turn on the light";
        }
    }
}
