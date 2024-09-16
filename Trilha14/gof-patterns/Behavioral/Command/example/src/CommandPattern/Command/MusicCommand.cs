using Command_Control.ControllerSystems;
using System;

namespace Command_Control.Command
{
    public class MusicCommand : ICommand
    {
        private Music _music;

        public MusicCommand(Music music)
        {
            _music = music;
        }
        public void Execute()
        {
            _music.TurnOn();
        }
        public void Undo()
        {
            _music.TurnOff();
        }

        public override string ToString()
        {
            return "Play music";
        }
    }
}
