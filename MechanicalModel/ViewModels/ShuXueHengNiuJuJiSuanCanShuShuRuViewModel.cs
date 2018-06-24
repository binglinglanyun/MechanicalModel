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
    public class ShuXueHengNiuJuJiSuanCanShuShuRuViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public ShuXueHengNiuJuJiSuanCanShuShuRuViewModel()
        {
        }

        public ViewType Type
        {
            get
            {
                return ViewType.ShuXueHengNiuJuJiSuanCanShuShuRu;
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

        private string _chongYouJinKou = "0.2";
        public string ChongYouJinKou
        {
            get
            {
                return _chongYouJinKou;
            }
            set
            {
                SetValueProperty(value, ref _chongYouJinKou);
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

        private string _beiYaFaChuKou = "0.1";
        public string BeiYaFaChuKou
        {
            get
            {
                return _beiYaFaChuKou;
            }
            set
            {
                SetValueProperty(value, ref _beiYaFaChuKou);
            }
        }

        private string _fanKuiYaLiRuKou = "2.1";
        public string FanKuiYaLiRuKou
        {
            get
            {
                return _fanKuiYaLiRuKou;
            }
            set
            {
                SetValueProperty(value, ref _fanKuiYaLiRuKou);
            }
        }

        private string _zhiLingYouRuKou = "0.6";
        public string ZhiLingYouRuKou
        {
            get
            {
                return _zhiLingYouRuKou;
            }
            set
            {
                SetValueProperty(value, ref _zhiLingYouRuKou);
            }
        }

        private string _huaFaHuiYouChuKou = "0.2";
        public string HuaFaHuiYouChuKou
        {
            get
            {
                return _huaFaHuiYouChuKou;
            }
            set
            {
                SetValueProperty(value, ref _huaFaHuiYouChuKou);
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
                    ScriptWrapperForHengNiuJu.WuZhiDingYi = string.Format(ScriptTemplateForHengNiuJu.WuZhiDingYi,
                         this.NianDuOfOil, this.MiDuOfOil);

                    ScriptWrapperForHengNiuJu.BianJieTiaoJianDingYi = string.Format(ScriptTemplateForHengNiuJu.BianJieTiaoJianDingYi,
                        this.HuaFaHuiYouChuKou, this.BeiYaFaChuKou, this.ZhiLingYouRuKou, this.FanKuiYaLiRuKou);

                    MessageBox.Show("参数输入成功");
                });
            }
        }
    }
}
