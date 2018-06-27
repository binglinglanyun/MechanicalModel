using MechanicalModel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.IO;
using MechanicalModel.Scripts;
using System.Diagnostics;

namespace MechanicalModel.ViewModels
{
    public class JiHeKongSunJiSuanMoXingViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public JiHeKongSunJiSuanMoXingViewModel()
        {
            InitializeItems();
        }

        public ViewType Type
        {
            get
            {
                return ViewType.JiHeKongSunJiSuanMoXing;
            }
        }

        private void InitializeItems()
        {
            List<DataItem> items = new List<DataItem>();
            items.Add(new DataItem("动轮", true));
            items.Add(new DataItem("定轮", true));
            items.Add(new DataItem("壳体", true));
            items.Add(new DataItem("其他", true));

            this.Items = items;
        }

        #region Button Click
        public ICommand BrowseButtonClick
        {
            get
            {
                return new DelegateCommand<object>((o) =>
                {
                    string localFolder;
                    System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
                    dialog.Title = "模型位置";
                    dialog.DefaultExt = ".stl";
                    System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        localFolder = dialog.FileName;
                    }
                    else
                    {
                        return;
                    }

                    this.LocationString = localFolder;
                });
            }
        }

        public ICommand ImportButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    if (File.Exists(this.LocationString))
                    {
                        try
                        {
                            string filename = Path.GetFileName(this.LocationString);
                            string destScriptPath = Path.Combine(ConstantValues.CurrentWorkDirectory, filename);
                            if (File.Exists(destScriptPath))
                            {
                                File.Delete(destScriptPath);
                            }

                            File.Copy(this.LocationString, destScriptPath);

                            // Create import script
                            ScriptWrapperForKongSun.ImportScript = string.Format(ScriptTemplateForKongSun.ImportScript, filename);
                            string scriptContent = ScriptWrapperForKongSun.CreateScriptForImportMoXing();
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

                            MessageBox.Show("模型导入成功");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("模型导入失败，错误信息：{0}", ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("模型文件不存在");
                    }
                });
            }
        }

        public ICommand ShowButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    // Show background processes
                });
            }
        }
        #endregion

        #region Properties
        private string _locationString = "D:\\380流场计算\\几何模型";
        public string LocationString
        {
            get
            {
                return _locationString;
            }
            set
            {
                SetValueProperty(value, ref _locationString);
            }
        }

        private List<DataItem> _items = null;
        public List<DataItem> Items
        {
            get
            {
                return _items;
            }
            set
            {
                SetClassProperty(value, ref _items);
            }
        }

        public string SourceUri
        {
            get
            {
                return Path.GetFullPath("Resources/KongSunJiHeMoXing.png"); ;
            }
        }
        #endregion
    }
}
