using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnableOldVolumeMixer
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;

            Constants constants = new Constants();
            RegistryEditor regEditor = new RegistryEditor(
                constants.GetMixerRegistryPath(), 
                constants.GetMixerSubKey()
                );
            CommandParser parser = new CommandParser(regEditor);

            Console.WriteLine("This program makes changes to the Windows registry. " + "\n" +
            "Use at your own risk." + "\n" +
            "\n");

            Console.WriteLine("Enter line number for command you wish to execute: " + "\n" +
                "1) Enable old volume mixer" + "\n" +
                "2) Disable old volume mixer" + "\n" +
                "3) Exit program\n");

            Console.WriteLine("If you don't see any changes, try relogging or restarting the computer");

            while (true)
            {
                command = Console.ReadLine();
                if(command == "1" || command == "2" || command == "3")
                {
                    break;
                }
            }
            parser.TakeCommands(command);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

            regEditor.Dispose();
        }
    }
}
