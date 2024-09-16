using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Control.Command
{
    class MicroCommand : ICommand
    {
        private List<ICommand> _innerCommands;
        public MicroCommand(List<ICommand> commands)
        {
            _innerCommands = commands;
        }

        public void Execute()
        {
            foreach(var innerCommands in _innerCommands)
            {
                innerCommands.Execute();
            }
        }

        public void Undo()
        {
            foreach (var innerCommands in _innerCommands)
            {
                innerCommands.Undo();
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var innerCommands in _innerCommands)
                sb.AppendFormat("{0}, ", innerCommands);

            return sb.ToString();
        }
    }
}
