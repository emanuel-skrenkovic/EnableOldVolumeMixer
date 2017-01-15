using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnableOldVolumeMixer
{
    class Constants
    {
        public static readonly string MixerRegistryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
        public static readonly string MixerSubKey = "MTCUVC";

        public string GetMixerRegistryPath()
        {
            return MixerRegistryPath;
        }

        public string GetMixerSubKey()
        {
            return MixerSubKey;
        }
    }
}
    