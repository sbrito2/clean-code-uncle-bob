using Command_Control.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Control
{
    class RemoteControl
    {
        private Dictionary<int, ICommand> _commands;
        public RemoteControl()
        {
            _commands = new Dictionary<int, ICommand>();
        }

        public void PushButton(int buttonId)
        {
            if (_commands.ContainsKey(buttonId))
                _commands[buttonId].Execute();
        }

        public void UndoButton(int buttonId)
        {
            if (_commands.ContainsKey(buttonId))
                _commands[buttonId].Undo();
        }

        public void SetCommandForButton(int buttonId, ICommand cmd)
        {
            _commands[buttonId] = cmd;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var buttonId in _commands.Keys)
            {
                Console.WriteLine("{0} \t- {1}\n", buttonId, _commands[buttonId]);
            }

            Console.WriteLine("etc. \t- Exit");
            return sb.ToString();
        }
    }
}
