using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnableOldVolumeMixer
{
    class RegistryEditor : IDisposable
    {
        private bool _disposed = false;

        private string keyString;
        private string subKey;
        private RegistryKey key;

        public RegistryEditor(string keyString, string subKey)
        {
            this.keyString = @keyString;
            this.subKey = subKey;
            key = Registry.LocalMachine.OpenSubKey(@keyString, true);
        }

        public bool KeyExists()
        {
            return ((key.OpenSubKey(subKey, true) != null));
        }

        public void CreateKey()
        {
            if (!KeyExists())
            {
                key.CreateSubKey(subKey);
            }
        }

        public void CreateDWordValue(DWord dWord)
        {
            if (KeyExists())
            {
                key.OpenSubKey(subKey, true).SetValue(dWord.Name, dWord.Value, RegistryValueKind.DWord);
            }         
        }

        public void DeleteKey()
        {
            if(KeyExists())
            {
                key.DeleteSubKey(subKey);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!_disposed)
            {
                key.Close();
            }

            _disposed = true;
        }
    }
}
