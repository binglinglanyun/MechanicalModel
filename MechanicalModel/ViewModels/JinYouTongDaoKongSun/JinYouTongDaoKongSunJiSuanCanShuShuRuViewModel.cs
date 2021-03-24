using MechanicalModel.Scripts;
using MechanicalModel.Utils;
using System;
using System.Collections.Generic;
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
        /*
        private string _miDuOfOil = "860";
        public string MiDuOfOil
        {
            get
            {
                return _miDuOfOil;
            }
            set
            {
                SetValueProperty(value, ref _miDuOfOil);
            }
        }

        private string _nianDuOfOil = "0.026";
        public string NianDuOfOil
        {
            get
            {
                return _nianDuOfOil;
            }
            set
            {
                SetValueProperty(value, ref _nianDuOfOil);
            }
        }
        */
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

        private string _daoReLvOfAir = "0.0264";
        public string DaoReLvOfAir
        {
            get
            {
                return _daoReLvOfAir;
            }
            set
            {
                SetValueProperty(value, ref _daoReLvOfAir);
            }
        }

        private string _biReRongOfAir = "1005";
        public string BiReRong
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

        /// <summary>
        /// BianJieTiaoJianDingYi = DongLunZhuanSu + TongQiKong + PaiQiKong + YouYeTiJiFenShu
        /// WuZhiDingYi = NianDuOfOil + NianDuOfAir + MiDuOfOil
        /// </summary>
        public ICommand ConfirmButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    double dongLunZhuanSu = Math.Round(double.Parse(this.DongLunZhuanSu) * Math.PI / 30, 5);
                    double paiQiKou = double.Parse(this.PaiQiKou) *  1000000;
                    double tongQiKong = double.Parse(this.TongQiKong) * 1000000;
                    // TODO: fix
                    ScriptWrapperForJinQiBiKongSun.BianJieTiaoJianDingYi = string.Format(ScriptTemplateForJinQiBiKongSun.BianJieTiaoJianDingYi,
                        dongLunZhuanSu, paiQiKou, tongQiKong, this.NianDuOfAir);

                    double value = 1 - double.Parse(this.NianDuOfAir);
                    //TODO: Fix
                    ScriptWrapperForJinQiBiKongSun.WuZhiDingYi = string.Format(ScriptTemplateForJinQiBiKongSun.WuZhiDingYi,
                         this.NianDuOfAir, this.NianDuOfAir, this.NianDuOfAir, value);

                    MessageBox.Show("设置成功", "空损计算参数输入");
                });
            }
        }
    }
}
