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

        /// <summary>
        /// DongLunZhuanSu + TongQiKongAndPaiQiKong + MiDuNianDuOfOil
        /// </summary>
        public ICommand CanShuShuRuButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    ScriptWrapperForKongSun.DongLunZhuanSu = string.Format(ScriptTemplateForKongSun.DongLunZhuanSu,
                        this.DongLunZhuanSu);

                    ScriptWrapperForKongSun.TongQiKongAndPaiQiKong = string.Format(ScriptTemplateForKongSun.TongQiKongAndPaiQiKong,
                        this.PaiQiKou, this.TongQiKong);

                    ScriptWrapperForKongSun.MiDuNianDuOfOil = string.Format(ScriptTemplateForKongSun.MiDuNianDuOfOil,
                         this.NianDuOfOil, this.MiDuOfOil);

                    MessageBox.Show("参数输入成功");
                });
            }
        }
    }
}
