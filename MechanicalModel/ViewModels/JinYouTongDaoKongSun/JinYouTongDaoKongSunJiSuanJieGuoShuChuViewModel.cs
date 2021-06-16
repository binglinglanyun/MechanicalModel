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

        private string _kongSunNiuJu = "0";
        public string KongSunNiuJu
        {
            get
            {
                return _kongSunNiuJu;
            }
            set
            {
                SetValueProperty(value, ref _kongSunNiuJu);
            }
        }

        private string _chuKouWenDu = "0";
        public string ChuKouWenDu
        {
            get
            {
                return _chuKouWenDu;
            }
            set
            {
                SetValueProperty(value, ref _chuKouWenDu);
            }
        }

        private string _ruKouLiuLiang = "0";
        public string RuKouLiuLiang
        {
            get
            {
                return _ruKouLiuLiang;
            }
            set
            {
                SetValueProperty(value, ref _ruKouLiuLiang);
            }
        }

        private const string _defaultLocationString = "E:\\TorqueAnalysisSystem-NoLoadLoss\\Scripts\\results\\torque_jinyoutongdao_kongsun\\case1\\torque_kongsun_003_1500_0.2_95.txt";
        private string _locationString = _defaultLocationString;
        public string LocationString
        {
            get
            {
                return _locationString;
            }
            set
            {
                SetValueProperty(value, ref _locationString);
                this._inputJieGuoFilePaths = new List<string>() { _locationString };
            }
        }

        private string _jieGuoShuChuLocation = "E:\\TorqueAnalysisSystem-NoLoadLoss\\Temp\\output.txt";
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

        private List<string> _inputJieGuoFilePaths = new List<string>() { _defaultLocationString };
        public ICommand InputJieGuoBrowseButtonClick
        {
            get
            {
                return new DelegateCommand<object>((o) =>
                {
                    System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
                    dialog.Title = "计算结果位置";
                    dialog.Multiselect = true;
                    dialog.InitialDirectory = Path.GetDirectoryName(this.LocationString);
                    System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        this.LocationString = dialog.FileNames[0];
                        this._inputJieGuoFilePaths = new List<string>(dialog.FileNames);
                    }
                    else
                    {
                        return;
                    }
                });
            }
        }

        public ICommand OutputJieGuoBrowseButtonClick
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
                    dialog.InitialDirectory = Path.GetDirectoryName(this.JieGuoShuChuLocation);
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

        // Parse the _dieDaiBuShu-th results of the specific column.
        private const int _dieDaiBuShu = 2260;
        private const int _ruKouLiuLiangBuShu = 500; // RuKouLiuLiang is a average value.
        private Dictionary<string, string[]> _jieGuoDic = new Dictionary<string, string[]>();
        public ICommand ImportButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    foreach (var filePath in this._inputJieGuoFilePaths)
                    {
                        if (!File.Exists(filePath))
                        {
                            MessageBox.Show("结果文件不存在: " + filePath);
                        }

                        using (StreamReader sr = new StreamReader(filePath))
                        {
                            int dieDaiBuShu = _dieDaiBuShu;
                            string[] resultTitles = sr.ReadLine().Split('\t');
                            int gongLvIndex = resultTitles.ToList().IndexOf(ScriptWrapperForJinQiBiKongSun.KongSunGongLvResultTitle);
                            int niuJuIndex = resultTitles.ToList().IndexOf(ScriptWrapperForJinQiBiKongSun.KongSunNiuJuResultTitle);
                            int wenDuIndex = resultTitles.ToList().IndexOf(ScriptWrapperForJinQiBiKongSun.ChuKouWenDuResultTitle);
                            int liuLiangIndex = resultTitles.ToList().IndexOf(ScriptWrapperForJinQiBiKongSun.RuKouLiuLiangResultTitle);

                            if (gongLvIndex != -1 && niuJuIndex != -1 && wenDuIndex != -1 && liuLiangIndex != -1)
                            {
                                string st = string.Empty;
                                double sumRuKouLiuLiang = 0;
                                while (!sr.EndOfStream && --dieDaiBuShu >= 0)
                                {
                                    st = sr.ReadLine();
                                    // Sum of the last _ruKouLiuLiangBuShu right before _dieDaiBuShu.
                                    if (dieDaiBuShu < _ruKouLiuLiangBuShu)
                                    {
                                        sumRuKouLiuLiang += double.Parse(st.Split('\t')[liuLiangIndex]);
                                    }
                                }

                                // st is the dieDaiBuShu-th line.
                                this.KongSunGongLv = Math.Abs(double.Parse(st.Split('\t')[gongLvIndex])).ToString();
                                this.KongSunNiuJu = Math.Abs(double.Parse(st.Split('\t')[niuJuIndex])).ToString();
                                // - 273.15: K -> ℃
                                this.ChuKouWenDu = (Math.Abs(double.Parse(st.Split('\t')[wenDuIndex])) - 273.15).ToString();
                                // * 60000:  m3/s -> L/min
                                this.RuKouLiuLiang = Math.Abs(Math.Round(sumRuKouLiuLiang / _ruKouLiuLiangBuShu * 60000, 4)).ToString();

                                var fileName = Path.GetFileNameWithoutExtension(filePath).Replace("torque_kongsun_", "");
                                if (_jieGuoDic.ContainsKey(fileName))
                                {
                                    _jieGuoDic[fileName] = new string[] { this.KongSunGongLv, this.KongSunNiuJu, this.ChuKouWenDu, this.RuKouLiuLiang };
                                }
                                else
                                {
                                    _jieGuoDic.Add(fileName, new string[] { this.KongSunGongLv, this.KongSunNiuJu, this.ChuKouWenDu, this.RuKouLiuLiang });
                                }
                            }
                            else
                            {
                                MessageBox.Show(string.Format("结果文件内容格式不正确，找不到列名为{0}的项", ScriptWrapperForJinQiBiKongSun.KongSunGongLvResultTitle));
                            }
                        }
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

                    File.WriteAllLines(this.JieGuoShuChuLocation, _jieGuoDic.Select(x => string.Join(" ", x.Key.Split('_')) + " " + string.Join(" ", x.Value)).ToArray());
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
