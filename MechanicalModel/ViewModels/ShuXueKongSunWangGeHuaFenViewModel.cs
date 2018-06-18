using MechanicalModel.Scripts;
using MechanicalModel.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MechanicalModel.ViewModels
{
    public class ShuXueKongSunWangGeHuaFenViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public ShuXueKongSunWangGeHuaFenViewModel()
        {
        }

        public ViewType Type
        {
            get
            {
                return ViewType.ShuXueKongSunWangGeHuaFen;
            }
        }

        #region DingLun
        private string _dingLunZuiDaWangGeChiDu = "0.006";
        public string DingLunZuiDaWangGeChiDu
        {
            get
            {
                return _dingLunZuiDaWangGeChiDu;
            }
            set
            {
                SetValueProperty(value, ref _dingLunZuiDaWangGeChiDu);
            }
        }

        private string _dingLunZuiXiaoWangGeChiDu = "0.0005";
        public string DingLunZuiXiaoWangGeChiDu
        {
            get
            {
                return _dingLunZuiXiaoWangGeChiDu;
            }
            set
            {
                SetValueProperty(value, ref _dingLunZuiXiaoWangGeChiDu);
            }
        }

        private string _dingLunZuiDaMianWangGeChiDu = "0.008";
        public string DingLunZuiDaMianWangGeChiDu
        {
            get
            {
                return _dingLunZuiDaMianWangGeChiDu;
            }
            set
            {
                SetValueProperty(value, ref _dingLunZuiDaMianWangGeChiDu);
            }
        }
        #endregion

        #region DongLun
        private string _dongLunZuiDaWangGeChiDu = "0.006";
        public string DongLunZuiDaWangGeChiDu
        {
            get
            {
                return _dongLunZuiDaWangGeChiDu;
            }
            set
            {
                SetValueProperty(value, ref _dongLunZuiDaWangGeChiDu);
            }
        }

        private string _dongLunZuiXiaoWangGeChiDu = "0.001";
        public string DongLunZuiXiaoWangGeChiDu
        {
            get
            {
                return _dongLunZuiXiaoWangGeChiDu;
            }
            set
            {
                SetValueProperty(value, ref _dongLunZuiXiaoWangGeChiDu);
            }
        }

        private string _dongLunZuiDaMianWangGeChiDu = "0.008";
        public string DongLunZuiDaMianWangGeChiDu
        {
            get
            {
                return _dongLunZuiDaMianWangGeChiDu;
            }
            set
            {
                SetValueProperty(value, ref _dongLunZuiDaMianWangGeChiDu);
            }
        }
        #endregion

        public string SourceUri
        {
            get
            {
                return Path.GetFullPath("Resources/KongSunMoXingWangGe.png"); ;
            }
        }

        /// <summary>
        /// ScriptXMLHeader + 
        /// ImportScript + WangGeHuafenConstScript + DongLunForWangGeHuaFen + DingLunForWangGeHuaFen
        /// ScriptXMLTail
        /// </summary>
        public ICommand WangGeHuaFenButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    ScriptWrapperForKongSun.DingLunForWangGeHuaFen = string.Format(ScriptTemplateForKongSun.DingLunForWangGeHuaFen,
                        this.DingLunZuiDaWangGeChiDu, this.DingLunZuiXiaoWangGeChiDu, this.DingLunZuiDaMianWangGeChiDu);

                    ScriptWrapperForKongSun.DongLunForWangGeHuaFen = string.Format(ScriptTemplateForKongSun.DongLunForWangGeHuaFen, 
                        this.DongLunZuiDaWangGeChiDu, this.DongLunZuiXiaoWangGeChiDu, this.DongLunZuiDaMianWangGeChiDu);

                    string scriptContent = ScriptWrapperForKongSun.CreateScriptForWangGeHuaFen();
                    if (scriptContent != null)
                    {
                        string scriptPath = Path.Combine(ConstantValues.CurrentWorkDirectory, ScriptWrapperForKongSun.ScriptName);
                        File.WriteAllText(scriptPath, scriptContent);
                        if (!File.Exists(ScriptWrapperForKongSun.DestSgrdFilePath))
                        {
                            File.Copy(ScriptWrapperForKongSun.SourceSgrdFilePath, ScriptWrapperForKongSun.DestSgrdFilePath);
                        }

                        //Open with PumpLink
                        ProcessStartInfo info = new ProcessStartInfo();
                        info.FileName = "PumpLinx.exe";
                        info.Arguments = scriptPath;
                        info.WorkingDirectory = @"C:\Program Files\Simerics\";
                        info.WindowStyle = ProcessWindowStyle.Hidden;
                        info.CreateNoWindow = true;
                        Process proc;
                        try
                        {
                            proc = System.Diagnostics.Process.Start(info);
                        }
                        catch (System.ComponentModel.Win32Exception ex)
                        {
                            Console.WriteLine("系统找不到指定的程序文件。\r{0}", ex);
                            return;
                        }
                    }
                });
            }
        }
    }
}
