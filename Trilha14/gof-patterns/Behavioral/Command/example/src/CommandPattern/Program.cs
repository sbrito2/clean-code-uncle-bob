using Command_Control.Command;
using Command_Control.ControllerSystems;
using System;
using System.Collections.Generic;

namespace Command_Control
{
    class Program
    {
        static void Main(string[] args)
        {
            RemoteControl remote = new RemoteControl();
            string userimput;

            remote.SetCommandForButton(1, new LightCommand(new Light()));
            remote.SetCommandForButton(2, new TVCommand(new TV()));
            remote.SetCommandForButton(3, new MusicCommand(new Music()));
            remote.SetCommandForButton(4, new TeapotCommand(new Teapot()));

            var teapotCommand = new TeapotCommand(new Teapot());
            var tvCommand = new TVCommand(new TV());
            var macroCommand = new MicroCommand(new List<ICommand> { teapotCommand, tvCommand });

            remote.SetCommandForButton(5, macroCommand);

            do
            {
                Console.WriteLine("Select an option below:");
                Console.WriteLine(remote);

                Console.WriteLine("Your vibor: ");
                var input = Console.ReadLine();
                int buttonId;
                int.TryParse(input, out buttonId);

                remote.PushButton(buttonId);
                remote.UndoButton(buttonId);

               // remote.DrawMenu();
              //  remote.PerformAction();

                Console.WriteLine("\nAlso (y/n)?: ");
                userimput = Console.ReadLine();
            } while (userimput == "y");
        }
    }
}
