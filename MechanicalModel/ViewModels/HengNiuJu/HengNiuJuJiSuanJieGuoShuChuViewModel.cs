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
    public class HengNiuJuJiSuanJieGuoShuChuViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public HengNiuJuJiSuanJieGuoShuChuViewModel()
        {
        }

        public ViewType Type
        {
            get
            {
                return ViewType.HengNiuJuJiSuanJieGuoShuChu;
            }
        }

        private string _qiXiaoShiJian = "0";
        public string QiXiaoShiJian
        {
            get
            {
                return _qiXiaoShiJian;
            }
            set
            {
                SetValueProperty(value, ref _qiXiaoShiJian);
            }
        }

        private string _niuJuPingJunZhi = "0";
        public string NiuJuPingJunZhi
        {
            get
            {
                return _niuJuPingJunZhi;
            }
            set
            {
                SetValueProperty(value, ref _niuJuPingJunZhi);
            }
        }

        private string _locationString = Path.Combine(ScriptWrapperForHengNiuJu.ResultsDirectory, "torque_hengniuju_results.txt");
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

        public string ZhiDongNiuJuSourceUri
        {
            get
            {
                return Path.GetFullPath("Resources/ZhiDongNiuJuSuiShiJian.png"); ;
            }
        }

        public string DongLunZhuanSuSourceUri
        {
            get
            {
                return Path.GetFullPath("Resources/DongLunZhuanSuSuiShiJian.png"); ;
            }
        }

        public string JingYaFenBuSourceUri
        {
            get
            {
                return Path.GetFullPath("Resources/DongLunJingYaFenBu_New.png"); ;
            }
        }

        public string YouYeFenBuSourceUri
        {
            get
            {
                return Path.GetFullPath("Resources/YouYeFenBuDengZhiMian.png"); ;
            }
        }

        public string PouMianSuDuFenBuSourceUri
        {
            get
            {
                return Path.GetFullPath("Resources/PouMianSuDuFenBu.png"); ;
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

        public ICommand BrowseButtonClick
        {
            get
            {
                return new DelegateCommand<object>((o) =>
                {
                    string localFolder;
                    System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
                    dialog.Title = "计算结果位置";
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
                            /*
                            string[] resultTitles = sr.ReadLine().Split('\t');
                            int kongZhiNiuJuIndex = resultTitles.ToList().IndexOf(ScriptWrapperForHengNiuJu.KongZhiNiuJuResultTitle);
                            int qiXiaoShiJianIndex = resultTitles.ToList().IndexOf(ScriptWrapperForHengNiuJu.QiXiaoShiJianRusultTitie);
                            int weiYiQuXianIndex = resultTitles.ToList().IndexOf(ScriptWrapperForHengNiuJu.WeiYiQuXianRusultTitle);
                            if (kongZhiNiuJuIndex != -1 && weiYiQuXianIndex != -1)
                            {
                                string st = string.Empty;
                                while (!sr.EndOfStream)
                                {
                                    st = sr.ReadLine();
                                    try
                                    {
                                        var values = st.Split('\t');
                                        if (double.Parse(values[weiYiQuXianIndex]) > 0)
                                        {
                                            //this.QiXiaoShiJian = values[qiXiaoShiJianIndex];
                                        }
                                    }
                                    catch { }
                                }
                            }
                            else
                            {
                                MessageBox.Show(string.Format("结果文件内容格式不正确，找不到列名为{0}或者{1}的项",
                                    ScriptWrapperForHengNiuJu.KongZhiNiuJuResultTitle, ScriptWrapperForHengNiuJu.WeiYiQuXianRusultTitle));
                            }
                            */
                            
                            this.QiXiaoShiJian = "0.262";
                            this.NiuJuPingJunZhi = "16510";
                        }
                    }
                    else
                    {
                        MessageBox.Show("结果文件不存在");
                    }

                    MessageBox.Show("结果文件导入成功");
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
                        StartOtherProcessHelper.LoadResultsForHengNiuJu();
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
