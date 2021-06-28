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
                    dialog.SelectedPath = this.LocationString;
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

        public ICommand ConfirmButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    try
                    {
                        this.LoadingVisibility = Visibility.Visible;
                        CommonUtils.CopyFolder(this.LocationString, ScriptWrapperForHengNiuJu.WorkDirectory);
                        this.LoadingVisibility = Visibility.Collapsed;
                        MessageBox.Show("设置成功", "三维计算几何模型导入");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("模型导入失败，错误信息：{0}", ex.Message));
                        this.LoadingVisibility = Visibility.Collapsed;
                    }
                });
            }
        }

        public ICommand PaoMianShowButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    if (!Directory.Exists(this._locationString))
                    {
                        MessageBox.Show("请设置模型");
                        return;
                    }

                    if (this.PaoMianVisibility == Visibility.Visible)
                    {
                        this.PaoMianVisibility = Visibility.Collapsed;
                        this.PaoMianXianShiButtonContent = "显示";
                    }
                    else
                    {
                        this.PaoMianVisibility = Visibility.Visible;
                        this.PaoMianXianShiButtonContent = "隐藏";
                    }
                });
            }
        }

        public ICommand DongTaiShowButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    if (!Directory.Exists(LocationString) || !Directory.Exists(ScriptWrapperForHengNiuJu.WorkDirectory))
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
        private string _locationString = ScriptWrapperForHengNiuJu.SurfaceDirectory;
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
                return Path.GetFullPath("Resources/HengNiuJuJiHeMoXing.png"); ;
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

        private string _paoMianXianShiButtonContent = "显示";
        public string PaoMianXianShiButtonContent
        {
            get
            {
                return _paoMianXianShiButtonContent;
            }
            set
            {
                SetValueProperty(value, ref _paoMianXianShiButtonContent);
            }
        }

        private Visibility _paoMianVisibility = Visibility.Hidden;
        public Visibility PaoMianVisibility
        {
            get
            {
                return _paoMianVisibility;
            }
            set
            {
                SetValueProperty(value, ref _paoMianVisibility);
            }
        }
        #endregion
    }
}
