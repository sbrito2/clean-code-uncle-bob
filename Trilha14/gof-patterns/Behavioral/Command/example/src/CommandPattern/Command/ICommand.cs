using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Control.Command
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
