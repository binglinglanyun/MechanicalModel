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
    public class JinYouTongDaoKongSunJiSuanJieGuoShuChuViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public JinYouTongDaoKongSunJiSuanJieGuoShuChuViewModel()
        {
        }

        public ViewType Type
        {
            get
            {
                return ViewType.JinYouTongDaoKongSunJiSuanJieGuoShuChu;
            }
        }

        private string _kongSunGongLv = "0";
        public string KongSunGongLv
        {
            get
            {
                return _kongSunGongLv;
            }
            set
            {
                SetValueProperty(value, ref _kongSunGongLv);
            }
        }

        private string _locationString = "D:\\Script\\results\\kongsun_integrals.txt";
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

        private string _jieGuoShuChuLocation = "D:\\temp\\output.txt";
        public string JieGuoShuChuLocation
        {
            get
            {
                return _jieGuoShuChuLocation;
            }
            set
            {
                SetValueProperty(value, ref _jieGuoShuChuLocation);
            }
        }


        public string ZhuanLunDingLunYaLiFenBuUri
        {
            get
            {
                return Path.GetFullPath("Resources/JinYouTongDaoZhuanDingYaLi.png");
            }
        }

        public string ZhuanLunDingLunSuDuFenBuUri
        {
            get
            {
                return Path.GetFullPath("Resources/JinYouTongDaoZhuanDingSuDu.png");
            }
        }

        public string ZhuanLunDingLunWenDuFenBuUri
        {
            get
            {
                return Path.GetFullPath("Resources/JinYouTongDaoZhuanDingWenDu.png");
            }
        }

        public string JieMianSuDuFenBuUri
        {
            get
            {
                return Path.GetFullPath("Resources/JinYouTongDaoJieMianSuDu.png");
            }
        }

        public string JieMianWenDuFenBuUri
        {
            get
            {
                return Path.GetFullPath("Resources/JinYouTongDaoJieMianWenDu.png");
            }
        }

        private Visibility _quXianAndYunTuVisibility = Visibility.Collapsed;
        public Visibility QuXianAndYunTuVisibility
        {
            get
            {
                return _quXianAndYunTuVisibility;
            }
            set
            {
                SetValueProperty(value, ref _quXianAndYunTuVisibility);
            }
        }

        private string _quXianAndYunTuXianShiButtonContent = "显示";
        public string QuXianAndYunTuXianShiButtonContent
        {
            get
            {
                return _quXianAndYunTuXianShiButtonContent;
            }
            set
            {
                SetValueProperty(value, ref _quXianAndYunTuXianShiButtonContent);
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
                    dialog.Title = "计算结果位置";
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

        public ICommand JieGuoBrowseButtonClick
        {
            get
            {
                return new DelegateCommand<object>((o) =>
                {
                    string localFolder;
                    System.Windows.Forms.SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog();
                    dialog.Title = "结果另存为";
                    dialog.DefaultExt = "txt";
                    dialog.Filter = "All Files (*.*)|*.*";
                    System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        localFolder = dialog.FileName;
                    }
                    else
                    {
                        return;
                    }

                    this.JieGuoShuChuLocation = localFolder;
                });
            }
        }

        private Dictionary<string, string> _jieGuoDic = new Dictionary<string, string>();
        public ICommand ImportButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    if (File.Exists(this.LocationString))
                    {
                        using (StreamReader sr = new StreamReader(this.LocationString))
                        {
                            string[] resultTitles = sr.ReadLine().Split('\t');
                            int index = resultTitles.ToList().IndexOf(ScriptWrapperForJinQiBiKongSun.KongSunGongLvResultTitle);
                            if (index != -1)
                            {
                                string st = string.Empty;
                                while (!sr.EndOfStream)
                                {
                                    st = sr.ReadLine();
                                }

                                this.KongSunGongLv = Math.Abs(double.Parse(st.Split('\t')[index])).ToString();

                                var fileName = Path.GetFileNameWithoutExtension(this.LocationString);
                                if (_jieGuoDic.ContainsKey(fileName))
                                {
                                    _jieGuoDic[fileName] = this.KongSunGongLv;
                                }
                                else
                                {
                                    _jieGuoDic.Add(fileName, this.KongSunGongLv);
                                }
                            }
                            else
                            {
                                MessageBox.Show(string.Format("结果文件内容格式不正确，找不到列名为{0}的项", ScriptWrapperForJinQiBiKongSun.KongSunGongLvResultTitle));
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("结果文件不存在");
                    }
                });
            }
        }

        public ICommand ExportButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    if (!Directory.Exists(Path.GetDirectoryName(this.JieGuoShuChuLocation)))
                    {
                        MessageBoxResult result = MessageBox.Show("目录不存在, 请选择正确的目录", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    if (_jieGuoDic.Count == 0)
                    {
                        MessageBox.Show("请先导入结果文件", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    File.WriteAllLines(this.JieGuoShuChuLocation, _jieGuoDic.Select(x => x.Key + " " + x.Value).ToArray());
                    MessageBox.Show("结果文件导出成功", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                });
            }
        }

        public ICommand QuXianAndYunTuImportButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    try
                    {
                        StartOtherProcessHelper.LoadResultsForKongSun();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("Failed to load results, error: {0}", ex.ToString()));
                    }
                });
            }
        }

        public ICommand QuXianAndYunTuXianShiButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    if (this.QuXianAndYunTuVisibility == Visibility.Visible)
                    {
                        this.QuXianAndYunTuVisibility = Visibility.Collapsed;
                        this.QuXianAndYunTuXianShiButtonContent = "显示";
                    }
                    else
                    {
                        this.QuXianAndYunTuVisibility = Visibility.Visible;
                        this.QuXianAndYunTuXianShiButtonContent = "隐藏";
                    }
                });
            }
        }
    }
}
