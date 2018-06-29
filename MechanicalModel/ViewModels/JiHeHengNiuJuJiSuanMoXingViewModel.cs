using MechanicalModel.Scripts;
using MechanicalModel.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MechanicalModel.ViewModels
{
    public class JiHeHengNiuJuJiSuanMoXingViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public JiHeHengNiuJuJiSuanMoXingViewModel()
        {
            InitializeItems();
        }

        private void InitializeItems()
        {
            List<DataItem> items = new List<DataItem>();
            items.Add(new DataItem("动轮", true));
            items.Add(new DataItem("定轮", true));
            items.Add(new DataItem("壳体", true));
            items.Add(new DataItem("背压阀", true));
            items.Add(new DataItem("滑阀", true));
            items.Add(new DataItem("其他", true));

            this.Items = items;
        }

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
                        CommonUtils.CopyFolder(this.LocationString, ScriptWrapperForHengNiuJu.WorkDirectory);

                        // Create import script
                        string scriptContent = ScriptWrapperForHengNiuJu.CreateFullScriptForImportMoXing();
                        if (scriptContent != null)
                        {
                            StartOtherProcessHelper.StartPumpLinxForHengNiuJu(scriptContent);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("模型导入失败，错误信息：{0}", ex.Message));
                    }
                });
            }
        }

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

        public ViewType Type
        {
            get
            {
                return ViewType.JiHeHengNiuJuJiSuanMoXing;
            }
        }

        public string SourceUri
        {
            get
            {
                return Path.GetFullPath("Resources/HengNiuJuJiHeMoXing.png"); ;
            }
        }
        #endregion
    }
}
