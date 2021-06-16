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
    public class YeYaXiTongJieGouTuViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public YeYaXiTongJieGouTuViewModel()
        {
        }

        public ViewType Type
        {
            get
            {
                return ViewType.YeYaXiTongJieGouTu;
            }
        }

        public ICommand BrowseButtonClick
        {
            get
            {
                return new DelegateCommand<object>((o) =>
                {
                    string localFolder;
                    System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
                    dialog.Title = "模型位置";
                    dialog.InitialDirectory = Path.GetDirectoryName(this.LocationString);
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

        public ICommand ConfirmButtonClick
        {
            get
            {
                return new DelegateCommand<object>((o) =>
                {
                    try
                    {
                        if (!File.Exists(this.LocationString))
                        {
                            MessageBox.Show(string.Format("系统结构模型不存在： {0}", this.LocationString),
                                "系统结构图搭建", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }

                        this.LoadingVisibility = Visibility.Visible;
                        if (!Directory.Exists(ScriptWrapperForYeYa.WorkDirectory))
                        {
                            Directory.CreateDirectory(ScriptWrapperForYeYa.WorkDirectory);
                        }

                        File.Copy(this.LocationString, ScriptWrapperForYeYa.DestModulePath, true);
                        this.LoadingVisibility = Visibility.Collapsed;
                        MessageBox.Show("设置成功", "系统结构模型导入");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("模型导入失败，错误信息：{0}", ex.Message));
                    }
                });
            }
        }

        public ICommand JingTaiShowButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    if (this.XiTongJieGouTuVisibility == Visibility.Visible)
                    {
                        this.XiTongJieGouTuVisibility = Visibility.Collapsed;
                        this.JingTaiShowButtonContent = "显示";
                    }
                    else
                    {
                        this.XiTongJieGouTuVisibility = Visibility.Visible;
                        this.JingTaiShowButtonContent = "隐藏";
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
                    if (!File.Exists(this.LocationString))
                    {
                        MessageBox.Show(string.Format("系统结构模型不存在： {0}, 请选择模型文件并确认设置", this.LocationString),
                            "系统结构图搭建", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    if (!File.Exists(ScriptWrapperForYeYa.DestModulePath))
                    {
                        MessageBox.Show("请确认设置模型文件", "系统结构图搭建", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    StartOtherProcessHelper.StartAMESim();
                });
            }
        }

        #region Properties
        private string _locationString = "E:\\TorqueAnalysisSystem-BrakingProcess\\Scripts\\Surface\\YeYa\\HydrSys_retarder.ame";
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

        public string SourceUri
        {
            get
            {
                return Path.GetFullPath("Resources/YeYaXiTongJieGouTu.png"); ;
            }
        }

        private string _jingTaiShowButtonContent = "显示";
        public string JingTaiShowButtonContent
        {
            get
            {
                return _jingTaiShowButtonContent;
            }
            set
            {
                SetValueProperty(value, ref _jingTaiShowButtonContent);
            }
        }

        private Visibility _xiTongJieGouTuVisibility = Visibility.Collapsed;
        public Visibility XiTongJieGouTuVisibility
        {
            get
            {
                return _xiTongJieGouTuVisibility;
            }
            set
            {
                SetValueProperty(value, ref _xiTongJieGouTuVisibility);
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
