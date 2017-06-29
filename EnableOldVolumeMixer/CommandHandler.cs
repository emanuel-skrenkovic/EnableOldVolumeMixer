using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnableOldVolumeMixer
{
    class CommandHandler
    { 
        private RegistryEditor regEditor;

        public CommandHandler(RegistryEditor regEditor)
        {
            this.regEditor = regEditor;
        }


        public void TakeCommands(string command)
        {
            bool keyExists = regEditor.KeyExists();
            switch (command)
            {  
                case "1":
                    Enable();
                    break;
                case "2":
                    Disable();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            } 
        }

        private void Enable()
        {
            if (regEditor.KeyExists())
            {
                Console.WriteLine("Already enabled");
            }
            else
            {
                DWord dWord = new DWord
                {
                    Name = Constants.MixerDwordName,
                    Value = Constants.MixerDwordValue,
                };

                regEditor.CreateKey();
                regEditor.CreateDWordValue(dWord);
                Console.WriteLine("Successfully changed.");
            }
        }

        private void Disable()
        {
            if (!regEditor.KeyExists())
            {
                Console.WriteLine("Already disabled");
            }
            else
            {
                regEditor.DeleteKey();
                Console.WriteLine("Successfully disabled");
            }
            
        }
    }

}
