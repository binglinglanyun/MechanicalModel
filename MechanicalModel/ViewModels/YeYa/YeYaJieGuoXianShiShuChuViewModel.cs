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

        private string _kongZhiNiuJu = "0";
        public string KongZhiNiuJu
        {
            get
            {
                return _kongZhiNiuJu;
            }
            set
            {
                SetValueProperty(value, ref _kongZhiNiuJu);
            }
        }

        private string _chuKouYaLiZhi = "0";
        public string ChuKouYaLiZhi
        {
            get
            {
                return _chuKouYaLiZhi;
            }
            set
            {
                SetValueProperty(value, ref _chuKouYaLiZhi);
            }
        }

        private string _dongLunZhuanSu = "0";
        public string DongLunZhuanSu
        {
            get
            {
                return _dongLunZhuanSu;
            }
            set
            {
                SetValueProperty(value, ref _dongLunZhuanSu);
            }
        }

        private string _chuKouWenDuZhi = "0";
        public string ChuKouWenDuZhi
        {
            get
            {
                return _chuKouWenDuZhi;
            }
            set
            {
                SetValueProperty(value, ref _chuKouWenDuZhi);
            }
        }

        private string _locationString = "D:\\380流场计算\\空损几何模型\\hengniuju_integrals.txt";
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

                                this.KongZhiNiuJu = Math.Abs(double.Parse(st.Split('\t')[kongZhiNiuJuIndex])).ToString();
                                this.QiXiaoShiJian = "0.35";
                                this.DongLunZhuanSu = "3526";
                                this.ChuKouYaLiZhi = "1.5";
                                this.KongZhiNiuJu = "3612";
                            }
                            else
                            {
                                MessageBox.Show(string.Format("结果文件内容格式不正确，找不到列名为{0}或者{1}的项",
                                    ScriptWrapperForHengNiuJu.KongZhiNiuJuResultTitle, ScriptWrapperForHengNiuJu.WeiYiQuXianRusultTitle));
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

        public ICommand QuXianAndYunTuXianShiButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    this.QuXianAndYunTuVisibility = Visibility.Visible;
                });
            }
        }
    }
}
