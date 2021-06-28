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

        public static void StartPumpLinx(string scriptPath)
        {
            //Open with PumpLink
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "PumpLinx.exe";
            info.Arguments = scriptPath;
            info.WorkingDirectory = @"C:\Program Files\Simerics\";
            info.WindowStyle = ProcessWindowStyle.Minimized;
            info.CreateNoWindow = true;
            
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

        public static void StartPumpLinxForJinQiBiKongSun(string scriptContent)
        {
            string scriptPath = Path.Combine(ScriptWrapperForJinQiBiKongSun.WorkDirectory, ScriptWrapperForJinQiBiKongSun.ScriptName);
            File.WriteAllText(scriptPath, scriptContent);

            if (!File.Exists(ScriptWrapperForJinQiBiKongSun.DestSgrdFilePath))
            {
                File.Copy(ScriptWrapperForJinQiBiKongSun.SourceSgrdFilePath, ScriptWrapperForJinQiBiKongSun.DestSgrdFilePath);
            }

            StartPumpLinx(scriptPath);
        }

        public static void StartPumpLinxForJinYouTongDaoKongSun(string scriptContent)
        {
            string scriptPath = Path.Combine(ScriptWrapperForJinYouTongDaoKongSun.WorkDirectory, ScriptWrapperForJinYouTongDaoKongSun.ScriptName);
            File.WriteAllText(scriptPath, scriptContent);

            if (!File.Exists(ScriptWrapperForJinYouTongDaoKongSun.DestSgrdFilePath))
            {
                File.Copy(ScriptWrapperForJinYouTongDaoKongSun.SourceSgrdFilePath, ScriptWrapperForJinYouTongDaoKongSun.DestSgrdFilePath);
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

        public static void LoadResultsForKongSun()
        {
            string destFolderPath = Path.GetDirectoryName(ScriptWrapperForJinQiBiKongSun.DestLoadResultScriptPath);
            if (!Directory.Exists(destFolderPath))
            {
                Directory.CreateDirectory(destFolderPath);
            }

            File.Copy(ScriptWrapperForJinQiBiKongSun.SourceLoadResultsSgrdFilePath, ScriptWrapperForJinQiBiKongSun.DestLoadResultsSgrdFilePath, true);
            File.Copy(ScriptWrapperForJinQiBiKongSun.SourceLoadResultScriptPath, ScriptWrapperForJinQiBiKongSun.DestLoadResultScriptPath, true);

            StartPumpLinx(ScriptWrapperForJinQiBiKongSun.DestLoadResultScriptPath);
        }

        public static void LoadResultsForHengNiuJu()
        {
            string destFolderPath = Path.GetDirectoryName(ScriptWrapperForHengNiuJu.DestLoadResultScriptPath);
            if (!Directory.Exists(destFolderPath))
            {
                Directory.CreateDirectory(destFolderPath);
            }

            File.Copy(ScriptWrapperForHengNiuJu.SourceLoadResultsSgrdFilePath, ScriptWrapperForHengNiuJu.DestLoadResultsSgrdFilePath, true);
            File.Copy(ScriptWrapperForHengNiuJu.SourceLoadResultScriptPath, ScriptWrapperForHengNiuJu.DestLoadResultScriptPath, true);
            StartPumpLinx(ScriptWrapperForHengNiuJu.DestLoadResultScriptPath);
        }

        public static void StartAMESim()
        {
            // Open with AMESim
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "AMESim.exe";
            info.Arguments = ScriptWrapperForYeYa.DestModulePath;
            info.WorkingDirectory = Directory.Exists(@"C:\Program Files\Simcenter\2019.1\Amesim\win64") 
                ? @"C:\Program Files\Simcenter\2019.1\Amesim\win64"
                : @"D:\Program Files\Simcenter\2019.1\Amesim\win64";
            info.WindowStyle = ProcessWindowStyle.Normal;
            info.CreateNoWindow = true;

            try
            {
                Process proc = System.Diagnostics.Process.Start(info);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                Console.WriteLine(string.Format("系统找不到指定的程序文件。\r{0}", ex.ToString()));
                return;
            }
        }

        public static void StartAMESimByPython(string args)
        {
            File.Copy(ScriptWrapperForYeYa.SourceScriptPath, ScriptWrapperForYeYa.DestScriptPath, true);

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "AMEPython";
            info.WorkingDirectory = ScriptWrapperForYeYa.WorkDirectory;
            info.Arguments = string.Format("{0} {1}", ScriptWrapperForYeYa.DestScriptPath, args);
            info.UseShellExecute = true;

            try
            {
                Process proc = System.Diagnostics.Process.Start(info);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                Console.WriteLine(string.Format("系统找不到指定的程序文件。\r{0}", ex.ToString()));
                return;
            }
        }
    }
}
