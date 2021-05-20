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
            InitializeItems();
        }

        private void InitializeItems()
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

        public ICommand ConfirmButtonClick
        {
            get
            {
                return new DelegateCommand<object>((o) =>
                {
                    try
                    {
                        this.LoadingVisibility = Visibility.Visible;
                        CommonUtils.CopyFolder(this.LocationString, ScriptWrapperForHengNiuJu.WorkDirectory);
                        this.LoadingVisibility = Visibility.Collapsed;
                        MessageBox.Show("设置成功", "恒扭矩计算模型导入");
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
                    this.XiTongJieGouTuVisibility = Visibility.Visible;
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

        public string SourceUri
        {
            get
            {
                return Path.GetFullPath("Resources/YeYaXiTongJieGouTu.png"); ;
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
