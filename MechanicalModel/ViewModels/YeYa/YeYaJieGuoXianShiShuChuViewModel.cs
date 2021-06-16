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
    public class YeYaJieGuoXianShiShuChuViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public YeYaJieGuoXianShiShuChuViewModel()
        {
        }

        public ViewType Type
        {
            get
            {
                return ViewType.YeYaJieGuoXianShiShuChu;
            }
        }

        public string P2P3SourceUri
        {
            get
            {
                return Path.GetFullPath("Resources/YeYaP2P3.png"); ;
            }
        }

        public string RuKouLiuLiangShiJianSourceUri
        {
            get
            {
                return Path.GetFullPath("Resources/YeYaRuKouLiuLiangShiJian.png"); ;
            }
        }

        public string RuKouLiuLiangYaLiSourceUri
        {
            get
            {
                return Path.GetFullPath("Resources/YeYaRuKouLiuLiangYaLi.png"); ;
            }
        }

        public string QiTiZhiLiangFenShuSourceUri
        {
            get
            {
                return Path.GetFullPath("Resources/YeYaQiTiZhiLiangFenShu.png"); ;
            }
        }

        private string _shuZhiFileLocation = "E:\\TorqueAnalysisSystem-BrakingProcess\\Scripts\\results\\shuzhi.txt";
        public string ShuZhiFileLocation
        {
            get
            {
                return _shuZhiFileLocation;
            }
            set
            {
                SetValueProperty(value, ref _shuZhiFileLocation);
            }
        }

        private string _jieGuoFileLocation = "E:\\TorqueAnalysisSystem-BrakingProcess\\Temp\\yeya\\bianjie_result.txt";
        public string JieGuoFileLocation
        {
            get
            {
                return _jieGuoFileLocation;
            }
            set
            {
                SetValueProperty(value, ref _jieGuoFileLocation);
            }
        }

        private string _quXianXianShiButtonContent = "显示";
        public string QuXianXianShiButtonContent
        {
            get
            {
                return _quXianXianShiButtonContent;
            }
            set
            {
                SetValueProperty(value, ref _quXianXianShiButtonContent);
            }
        }

        private Visibility _quXianXianShiVisibility = Visibility.Collapsed;
        public Visibility QuXianXianShiVisibility
        {
            get
            {
                return _quXianXianShiVisibility;
            }
            set
            {
                SetValueProperty(value, ref _quXianXianShiVisibility);
            }
        }

        public ICommand ShuZhiFileBrowseButtonClick
        {
            get
            {
                return new DelegateCommand<object>((o) =>
                {
                    string localFolder;
                    System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
                    dialog.Title = "数值计算结果位置";
                    System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        localFolder = dialog.FileName;
                    }
                    else
                    {
                        return;
                    }

                    this.JieGuoFileLocation = localFolder;
                });
            }
        }

        public ICommand JieGuoFileBrowseButtonClick
        {
            get
            {
                return new DelegateCommand<object>((o) =>
                {
                    string localFolder;
                    System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
                    dialog.Title = "计算边界条件结果位置";
                    System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        localFolder = dialog.FileName;
                    }
                    else
                    {
                        return;
                    }

                    this.ShuZhiFileLocation = localFolder;
                });
            }
        }

        public ICommand ImportButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    if (!File.Exists(this.ShuZhiFileLocation))
                    {
                        MessageBox.Show("数值计算结果文件不存在： " + this.ShuZhiFileLocation);
                        return;
                    }

                    // Do nothing currently
                    // Should parse the input file to see if the formats are correct.
                });
            }
        }

        public ICommand ExportButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    if (!File.Exists(this.ShuZhiFileLocation))
                    {
                        MessageBox.Show("数值计算结果文件不存在： " + this.ShuZhiFileLocation + ", 请先导入数值结果文件");
                        return;
                    }

                    if (!Directory.Exists(Path.GetDirectoryName(this.JieGuoFileLocation)))
                    {
                        MessageBoxResult result = MessageBox.Show("目录不存在, 请选择正确的目录", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    File.Copy(this.ShuZhiFileLocation, this.JieGuoFileLocation, true);
                });
            }
        }

        public ICommand QuXianXianShiButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    if (this.QuXianXianShiVisibility == Visibility.Visible)
                    {
                        this.QuXianXianShiVisibility = Visibility.Collapsed;
                        this.QuXianXianShiButtonContent = "显示";
                    }
                    else
                    {
                        this.QuXianXianShiVisibility = Visibility.Visible;
                        this.QuXianXianShiButtonContent = "隐藏";
                    }
                });
            }
        }
    }
}
