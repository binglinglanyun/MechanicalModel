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
    public class ShuXueKongSunJiSuanCanShuShuRuViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public ShuXueKongSunJiSuanCanShuShuRuViewModel()
        {
        }

        public ViewType Type
        {
            get
            {
                return ViewType.ShuXueKongSunJiSuanCanShuShuRu;
            }
        }

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

        private string _youYeTiJiFenShu = "0.14";
        public string YouYeTiJiFenShu
        {
            get
            {
                return _youYeTiJiFenShu;
            }
            set
            {
                SetValueProperty(value, ref _youYeTiJiFenShu);
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
                    ScriptWrapperForKongSun.BianJieTiaoJianDingYi = string.Format(ScriptTemplateForKongSun.BianJieTiaoJianDingYi,
                        dongLunZhuanSu, paiQiKou, tongQiKong, this.YouYeTiJiFenShu);

                    double value = 1 - double.Parse(this.YouYeTiJiFenShu);
                    ScriptWrapperForKongSun.WuZhiDingYi = string.Format(ScriptTemplateForKongSun.WuZhiDingYi,
                         this.NianDuOfOil, this.NianDuOfAir, this.MiDuOfOil, value);

                    MessageBox.Show("设置成功");
                });
            }
        }
    }
}
