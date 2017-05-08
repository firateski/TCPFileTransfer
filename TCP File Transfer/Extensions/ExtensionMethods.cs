using File_Transfer.LanguageManager;

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace File_Transfer.Extensions
{
    public enum MainFormInputs
    {
        SendIPAdress,
        ReceiveIPAdress,
        SendPortNumber,
        ReceivePortNumber,
        FileNameForSend,
        SaveLocationForReceive
    }

    static class ExtensionMethods
    {
        static readonly string[] sizeUnits = { "byte", "kB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        public static string formatSize(this long size)
        {
            double result = size;
            int currentUnitIndex = 0;
            while (result >= 1024 && currentUnitIndex < sizeUnits.Length - 1)
            {
                result /= 1024;
                currentUnitIndex++;
            }
            return ($"{result.ToString("0.##")} {sizeUnits[currentUnitIndex]}");
        }

        public static string calcSpeed(this long totalTime, long totalReadByte)
        {
            double totalSeconds = totalTime / 1000, bytes = totalReadByte;

            double speed = (speed = bytes / totalSeconds);

            return speed.formatSpeed() + "/" + Translator.GetStringFromResource("Second");
        }

        public static int getPercent(this long current, long total)
        {
            double curr = Convert.ToDouble(current);
            double tot = Convert.ToDouble(total);

            var result = Convert.ToInt32((100 / tot) * curr);

            if (result > 100)
                return 100;
            else
                return result;
        }

        public static string formatSpeed(this double size)
        {
            double result = size;
            int currentUnitIndex = 0;
            while (result >= 1024 && currentUnitIndex < sizeUnits.Length - 1)
            {
                result /= 1024;
                currentUnitIndex++;
            }

            return ($"{result.ToString("0.##")} {sizeUnits[currentUnitIndex]}");
        }

        public static bool IsValidIpAdress(this string ipAdressStr)
        {
            try
            {
                IPAddress.Parse(ipAdressStr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidPortNumber(this string portNumberStr)
        {
            int portNumberTemp;
            if (int.TryParse(portNumberStr, out portNumberTemp) && portNumberTemp > 0)
            {
                return true;
            }
            return false;
        }

        public static bool IsValidFilePath(this string filename)
        {
            if (File.Exists(filename))
            {
                return true;
            }
            return false;
        }

        public static bool IsValidSavePath(this string path)
        {
            if (Directory.Exists(path))
            {
                return true;
            }
            return false;
        }

        public static IEnumerable<Control> GetAllControls(Control control)
        {
            foreach (Control _control in control.Controls)
            {
                foreach (Control __control in GetAllControls(_control))
                {
                    yield return __control;
                }
            }
            yield return control;
        }
    }
}
