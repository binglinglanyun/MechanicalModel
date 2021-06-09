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
    public class HengNiuJuJiSuanMoXingViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public HengNiuJuJiSuanMoXingViewModel()
        {
            InitializeItems();
        }

        private void InitializeItems()
        {
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

        public ICommand ImportAndShowButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    if (!Directory.Exists(LocationString) || !Directory.Exists(ScriptWrapperForJinQiBiKongSun.WorkDirectory))
                    {
                        MessageBox.Show("请设置模型导入路径并确认设置");
                        return;
                    }

                    // Create import script
                    string scriptContent = ScriptWrapperForHengNiuJu.CreateFullScriptForImportMoXing();
                    if (scriptContent != null)
                    {
                        StartOtherProcessHelper.StartPumpLinxForHengNiuJu(scriptContent);
                    }
                });
            }
        }

        #region Properties
        private string _locationString = "D:\\380流场计算\\恒扭矩几何模型";
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

        public ViewType Type
        {
            get
            {
                return ViewType.HengNiuJuJiSuanMoXing;
            }
        }

        public string SourceUri
        {
            get
            {
                return Path.GetFullPath("Resources/FakePicture.png"); ;
            }
        }

        private Visibility _loadingVisibility = Visibility.Collapsed;
        public Visibility LoadingVisibility
        {
            get
            {
                return _loadingVisibility;
            }
            set
            {
                SetValueProperty(value, ref _loadingVisibility);
            }
        }
        #endregion
    }
}
