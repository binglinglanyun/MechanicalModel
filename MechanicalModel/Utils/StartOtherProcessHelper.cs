using MechanicalModel.Scripts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalModel.Utils
{
    public class StartOtherProcessHelper
    {
        private const int SW_HIDE = 0;
        private const int SW_RESTORE = 9;

        [DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr handle, int nCmdShow);

        private static void StartPumpLinx(string scriptPath)
        {
            //Open with PumpLink
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "PumpLinx.exe";
            info.Arguments = scriptPath;
            info.WorkingDirectory = @"C:\Program Files\Simerics\";
            info.WindowStyle = ProcessWindowStyle.Minimized;
            info.CreateNoWindow = true;
            //info.UseShellExecute = false;
            
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
            string scriptPath = Path.Combine(ScriptWrapperForKongSun.WorkDirectory, ScriptWrapperForKongSun.ScriptName);
            File.WriteAllText(scriptPath, scriptContent);

            if (!File.Exists(ScriptWrapperForKongSun.DestSgrdFilePath))
            {
                File.Copy(ScriptWrapperForKongSun.SourceSgrdFilePath, ScriptWrapperForKongSun.DestSgrdFilePath);
            }

            StartPumpLinx(scriptPath);
        }

        public static void StartPumpLinxForHengNiuJu(string scriptContent)
        {
            string scriptPath = Path.Combine(ScriptWrapperForHengNiuJu.WorkDirectory, ScriptWrapperForHengNiuJu.ScriptName);
            File.WriteAllText(scriptPath, scriptContent);

            if (!File.Exists(ScriptWrapperForHengNiuJu.DestSgrdFilePath))
            {
                File.Copy(ScriptWrapperForHengNiuJu.SourceSgrdFilePath, ScriptWrapperForHengNiuJu.DestSgrdFilePath);
            }

            StartPumpLinx(scriptPath);
        }

        public static void StartPumpLinxForTempScript()
        {
            string folderPath = Path.Combine(CommonUtils.CurrentWorkDirectory, "Temp");
            string scriptPath = Path.Combine(folderPath, "temp.spro");
            string scriptContent = ScriptWrapperForKongSun.CreateFullScriptForTempScript();
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            File.WriteAllText(scriptPath, scriptContent);
            StartPumpLinx(scriptPath);
        }
    }
}
