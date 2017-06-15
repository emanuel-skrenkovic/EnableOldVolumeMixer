using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EnableOldVolumeMixer
{
    class Program
    {
        static void Main(string[] args)
        {
            if(!IsElevated())
            {
                Console.WriteLine("This program needs to be run as administrator");
                Console.ReadKey();
                Environment.Exit(0);
            }

            string command;

            RegistryEditor regEditor = new RegistryEditor(
                Constants.MixerRegistryPath, 
                Constants.MixerSubKey
                );
            CommandHandler commandHandler = new CommandHandler(regEditor);

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
            commandHandler.TakeCommands(command);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

            regEditor.Dispose();
        }

        private static bool IsElevated()
        {
            return new WindowsPrincipal(
                WindowsIdentity.GetCurrent())
                .IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
