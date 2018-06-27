using MechanicalModel.Scripts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalModel.Utils
{
    public class StartOtherProcessHelper
    {
        private static void StartPumpLinx(string scriptPath)
        {
            //Open with PumpLink
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "PumpLinx.exe";
            info.Arguments = scriptPath;
            info.WorkingDirectory = @"C:\Program Files\Simerics\";
            info.WindowStyle = ProcessWindowStyle.Hidden;
            info.CreateNoWindow = true;
            info.UseShellExecute = false;
            
            try
            {
                Process proc = System.Diagnostics.Process.Start(info);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                Console.WriteLine("系统找不到指定的程序文件。\r{0}", ex);
                return;
            }
        }

        public static void StartPumpLinxForKongSun(string scriptContent)
        {
            string scriptPath = Path.Combine(ConstantValues.CurrentWorkDirectory, ScriptWrapperForKongSun.ScriptName);
            File.WriteAllText(scriptPath, scriptContent);

            if (!File.Exists(ScriptWrapperForKongSun.DestSgrdFilePath))
            {
                File.Copy(ScriptWrapperForKongSun.SourceSgrdFilePath, ScriptWrapperForKongSun.DestSgrdFilePath);
            }

            StartPumpLinx(scriptPath);
        }

        public static void StartPumpLinxForHengNiuJu(string scriptContent)
        {
            string scriptPath = Path.Combine(ConstantValues.CurrentWorkDirectory, ScriptWrapperForHengNiuJu.ScriptName);
            File.WriteAllText(scriptPath, scriptContent);

            if (!File.Exists(ScriptWrapperForHengNiuJu.DestSgrdFilePath))
            {
                File.Copy(ScriptWrapperForHengNiuJu.SourceSgrdFilePath, ScriptWrapperForHengNiuJu.DestSgrdFilePath);
            }

            StartPumpLinx(scriptPath);
        }
    }
}
