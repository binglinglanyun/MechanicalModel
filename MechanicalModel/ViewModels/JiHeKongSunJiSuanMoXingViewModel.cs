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
                    System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
                    dialog.Description = "模型位置";
                    System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        localFolder = dialog.SelectedPath;
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
                    try
                    {
                        CommonUtils.CopyFolder(this.LocationString, ScriptWrapperForKongSun.WorkDirectory);

                        // Create import script
                        string scriptContent = ScriptWrapperForKongSun.CreateFullScriptForImportMoXing();
                        if (scriptContent != null)
                        {
                            StartOtherProcessHelper.StartPumpLinxForKongSun(scriptContent);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("模型导入失败，错误信息：{0}", ex.Message));
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
