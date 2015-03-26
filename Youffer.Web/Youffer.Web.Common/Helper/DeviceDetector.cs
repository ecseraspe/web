using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Youffer.Web.Common.Helper
{
    public static class DeviceDetector
    {

        public static string GetDeviceType(string ua)
        {
            string ret = string.Empty;
            if (Regex.IsMatch(ua, "android", RegexOptions.IgnoreCase))
            {
                if ((Regex.IsMatch(ua, "iP(a|ro)d", RegexOptions.IgnoreCase) || (Regex.IsMatch(ua, "tablet", RegexOptions.IgnoreCase)) && (!Regex.IsMatch(ua, "RX-34", RegexOptions.IgnoreCase)) || (Regex.IsMatch(ua, "FOLIO", RegexOptions.IgnoreCase))))
                {
                    ret = "tablet";
                }
                // Check if user agent is an Android Tablet
                else if ((Regex.IsMatch(ua, "Linux", RegexOptions.IgnoreCase)) && (Regex.IsMatch(ua, "Android", RegexOptions.IgnoreCase)) && (!Regex.IsMatch(ua, "Fennec|mobi|HTC.Magic|HTCX06HT|Nexus.One|SC-02B|fone.945", RegexOptions.IgnoreCase)))
                {
                    ret = "tablet";
                }
                // Check if user agent is a Kindle or Kindle Fire
                else if ((Regex.IsMatch(ua, "Kindle", RegexOptions.IgnoreCase)) || (Regex.IsMatch(ua, "Mac.OS", RegexOptions.IgnoreCase)) && (Regex.IsMatch(ua, "Silk", RegexOptions.IgnoreCase)))
                {
                    ret = "tablet";
                }
                // Check if user agent is a pre Android 3.0 Tablet
                else if ((Regex.IsMatch(ua, @"GT-P10|SC-01C|SHW-M180S|SGH-T849|SCH-I800|SHW-M180L|SPH-P100|SGH-I987|zt180|HTC(.Flyer|\\_Flyer)|Sprint.ATP51|ViewPad7|pandigital(sprnova|nova)|Ideos.S7|Dell.Streak.7|Advent.Vega|A101IT|A70BHT|MID7015|Next2|nook", RegexOptions.IgnoreCase)) || (Regex.IsMatch(ua, "MB511", RegexOptions.IgnoreCase)) && (Regex.IsMatch(ua, "RUTEM", RegexOptions.IgnoreCase)))
                {
                    ret = "tablet";
                }
                else
                {
                    ret = "android_mobile";
                }
            }

            return ret;
        }
    }
}
