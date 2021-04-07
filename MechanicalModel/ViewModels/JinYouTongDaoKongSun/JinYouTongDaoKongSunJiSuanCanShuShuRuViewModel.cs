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
    public class JinYouTongDaoKongSunJiSuanCanShuShuRuViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public JinYouTongDaoKongSunJiSuanCanShuShuRuViewModel()
        {
        }

        public ViewType Type
        {
            get
            {
                return ViewType.JinYouTongDaoKongSunJiSuanCanShuShuRu;
            }
        }

        private string _nianDuOfAir = "1.853e-5";
        public string NianDuOfAir
        {
            get
            {
                return _nianDuOfAir;
            }
            set
            {
                SetValueProperty(value, ref _nianDuOfAir);
            }
        }

        private string _reDaoLvOfAir = "0.0264";
        public string ReDaoLvOfAir
        {
            get
            {
                return _reDaoLvOfAir;
            }
            set
            {
                SetValueProperty(value, ref _reDaoLvOfAir);
            }
        }

        private string _biReRongOfAir = "1005";
        public string BiReRongOfAir
        {
            get
            {
                return _biReRongOfAir;
            }
            set
            {
                SetValueProperty(value, ref _biReRongOfAir);
            }
        }

        private string _tongQiKong = "0.1";
        public string TongQiKong
        {
            get
            {
                return _tongQiKong;
            }
            set
            {
                SetValueProperty(value, ref _tongQiKong);
            }
        }

        private string _paiQiKou = "0.1";
        public string PaiQiKou
        {
            get
            {
                return _paiQiKou;
            }
            set
            {
                SetValueProperty(value, ref _paiQiKou);
            }
        }

        private string _dongLunZhuanSu = "3600";
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

        private string _ruKouYaLi = "0.2";
        public string RuKouYaLi
        {
            get
            {
                return _ruKouYaLi;
            }
            set
            {
                SetValueProperty(value, ref _ruKouYaLi);
            }
        }

        private string _ruKouWenDu = "95";
        public string RuKouWenDu
        {
            get
            {
                return _ruKouWenDu;
            }
            set
            {
                SetValueProperty(value, ref _ruKouWenDu);
            }
        }

        private string _huanJingWenDu = "100";
        public string HuanJingWenDu
        {
            get
            {
                return _huanJingWenDu;
            }
            set
            {
                SetValueProperty(value, ref _huanJingWenDu);
            }
        }

        private string _locationString = "D:\\380流场计算\\油文件";
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

        public ICommand BrowseButtonClick
        {
            get
            {
                return new DelegateCommand<object>((o) =>
                {
                    string localFolder;
                    System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
                    dialog.Description = "文件位置";
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

        /// <summary>
        /// WuZhiDingYi = NianDuOfOil + NianDuOfAir + MiDuOfOil
        /// BianJieTiaoJianDingYi = DongLunZhuanSu + TongQiKong + PaiQiKong + YouYeTiJiFenShu
        /// </summary>
        public ICommand ConfirmButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    if (string.IsNullOrEmpty(this.LocationString))
                    {
                        MessageBox.Show("请设置油文件路径");
                        return;
                    }
                    else if (!File.Exists(Path.Combine(LocationString, ScriptWrapperForJinYouTongDaoKongSun.DensityFileName)) ||
                        !File.Exists(Path.Combine(LocationString, ScriptWrapperForJinYouTongDaoKongSun.ViscosityFileName)) ||
                        !File.Exists(Path.Combine(LocationString, ScriptWrapperForJinYouTongDaoKongSun.HeatConductivityFileName)) ||
                        !File.Exists(Path.Combine(LocationString, ScriptWrapperForJinYouTongDaoKongSun.HeatCapacityFileName)))
                    {
                        MessageBox.Show("关键油文件缺失");
                        return;
                    }

                    CommonUtils.CopyFolder(this.LocationString, ScriptWrapperForJinYouTongDaoKongSun.WorkDirectory);

                    // {0} --空气粘度 {1} --空气比热容 {2} --空气热导率
                    ScriptWrapperForJinYouTongDaoKongSun.WuZhiDingYi = string.Format(ScriptTemplateForJinYouTongDaoKongSun.WuZhiDingYi,
                         this.NianDuOfAir, this.BiReRongOfAir, this.ReDaoLvOfAir);

                    double dongLunZhuanSu = Math.Round(double.Parse(this.DongLunZhuanSu) * Math.PI / 30, 5);
                    double paiQiKou = double.Parse(this.PaiQiKou) * 1000000;
                    double tongQiKong = double.Parse(this.TongQiKong) * 1000000;

                    // {0} -- 动轮转速  {1} -- 入口压力  {2} -- 通气口压力
                    // {3} -- 排气口压力  {4} -- 入口温度
                    ScriptWrapperForJinYouTongDaoKongSun.BianJieTiaoJianDingYi = string.Format(ScriptTemplateForJinYouTongDaoKongSun.BianJieTiaoJianDingYi,
                        dongLunZhuanSu, this.RuKouYaLi, tongQiKong, paiQiKou, this.RuKouWenDu);

                    MessageBox.Show("设置成功", "空损计算参数输入");
                });
            }
        }
    }
}
