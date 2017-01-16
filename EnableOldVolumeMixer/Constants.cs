using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnableOldVolumeMixer
{
    public static class Constants
    {
        public static readonly string MixerRegistryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
        public static readonly string MixerSubKey = "MTCUVC";
        public static readonly string MixerDwordName = "EnableMtcUvc";
        public static readonly UInt32 MixerDwordValue = 0;
    }
}
    