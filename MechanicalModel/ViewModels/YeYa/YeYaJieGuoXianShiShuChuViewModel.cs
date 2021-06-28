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

        private string _shuZhiFileLocation = Path.Combine(ScriptWrapperForYeYa.DefaultResultDirectory, "shuzhi_results.txt");
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

        private string _bianJie3DInputFileLocation = Path.Combine(ScriptWrapperForYeYa.WorkDirectory, "bianjie_3d_input.txt");
        public string BianJie3DInputFileLocation
        {
            get
            {
                return _bianJie3DInputFileLocation;
            }
            set
            {
                SetValueProperty(value, ref _bianJie3DInputFileLocation);
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
                    dialog.InitialDirectory = Path.GetDirectoryName(this.ShuZhiFileLocation);
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

        public ICommand BianJie3DInputFileBrowseButtonClick
        {
            get
            {
                return new DelegateCommand<object>((o) =>
                {
                    string localFolder;
                    System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
                    dialog.Title = "计算边界条件结果位置";
                    dialog.InitialDirectory = Path.GetDirectoryName(this.BianJie3DInputFileLocation);
                    System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        localFolder = dialog.FileName;
                    }
                    else
                    {
                        return;
                    }

                    this.BianJie3DInputFileLocation = localFolder;
                });
            }
        }

        private List<string> _3dInputLines = new List<string>();
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

                    string[] lines = File.ReadAllLines(this.ShuZhiFileLocation);
                    _3dInputLines.Clear();
                    _3dInputLines.Add(@"<?xml version=""1.0"" encoding=""ISO-8859-1""?>");
                    int count = 0;
                    foreach (var line in lines)
                    {
                        if (line.StartsWith("#"))
                        {
                            continue;
                        }

                        count++;
                        string[] values = System.Text.RegularExpressions.Regex.Split(line.Trim(), @"\s{1,}");
                        try
                        {
                            double value1 = Math.Round(decimal.ToDouble(decimal.Parse(values[0].Trim(), System.Globalization.NumberStyles.Float)) * 101325, 1);
                            decimal value2 = Math.Round(decimal.Parse(values[1].Trim(), System.Globalization.NumberStyles.Float), 5);
                            _3dInputLines.Add(string.Format("{0}\t{1}", value1, value2));
                        }
                        catch
                        {
                            MessageBox.Show("数值文件格式不正确： " + line);
                            _3dInputLines.Clear();
                            return;
                        }
                    }
                    _3dInputLines.Insert(1, $@"<table size=""{count}"" outside=""extrapolation"">");
                    _3dInputLines.Add(@"</table>");

                    MessageBox.Show("数值计算结果文件导入成功");
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

                    if (!Directory.Exists(Path.GetDirectoryName(this.BianJie3DInputFileLocation)))
                    {
                        MessageBoxResult result = MessageBox.Show("目录不存在, 请选择正确的目录", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    if (!this._3dInputLines.Any())
                    {
                        MessageBox.Show("请先导入数值结果文件");
                        return;
                    }

                    File.WriteAllLines(this.BianJie3DInputFileLocation, _3dInputLines.ToArray());
                    MessageBox.Show("三维流动液力计算边界条件结果文件导出成功");
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
