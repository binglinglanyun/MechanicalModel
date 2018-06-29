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

        #region WuZhiDingYi
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

        private string _nianDuOfAir = "1.853e-005";
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
        #endregion

        #region BianJieTiaoJianDingYi
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

        private string _dongLunChuShiZhuanSu = "3600";
        public string DongLunChuShiZhuanSu
        {
            get
            {
                return _dongLunChuShiZhuanSu;
            }
            set
            {
                SetValueProperty(value, ref _dongLunChuShiZhuanSu);
            }
        }

        private string _dongLunZhuanDongGuanLiang = "150";
        public string DongLunZhuanDongGuanLiang
        {
            get
            {
                return _dongLunZhuanDongGuanLiang;
            }
            set
            {
                SetValueProperty(value, ref _dongLunZhuanDongGuanLiang);
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
        #endregion

        #region FaMenCanShu
        private string _beiYaFaFaXinZhiLiang = "0.55";
        public string BeiYaFaFaXinZhiLiang
        {
            get
            {
                return _beiYaFaFaXinZhiLiang;
            }
            set
            {
                SetValueProperty(value, ref _beiYaFaFaXinZhiLiang);
            }
        }

        private string _beiYaFaTanHuangGangDu = "12800";
        public string BeiYaFaTanHuangGangDu
        {
            get
            {
                return _beiYaFaTanHuangGangDu;
            }
            set
            {
                SetValueProperty(value, ref _beiYaFaTanHuangGangDu);
            }
        }

        private string _beiYaFaTanHuangYuJinLi = "156";
        public string BeiYaFaTanHuangYuJinLi
        {
            get
            {
                return _beiYaFaTanHuangYuJinLi;
            }
            set
            {
                SetValueProperty(value, ref _beiYaFaTanHuangYuJinLi);
            }
        }

        private string _huaFaFaXinZhiLiang = "0.01";
        public string HuaFaFaXinZhiLiang
        {
            get
            {
                return _huaFaFaXinZhiLiang;
            }
            set
            {
                SetValueProperty(value, ref _huaFaFaXinZhiLiang);
            }
        }

        private string _huaFaTanHuangGangDu = "0";
        public string HuaFaTanHuangGangDu
        {
            get
            {
                return _huaFaTanHuangGangDu;
            }
            set
            {
                SetValueProperty(value, ref _huaFaTanHuangGangDu);
            }
        }

        private string _huaFaTanHuangYuJinLi = "0";
        public string HuaFaTanHuangYuJinLi
        {
            get
            {
                return _huaFaTanHuangYuJinLi;
            }
            set
            {
                SetValueProperty(value, ref _huaFaTanHuangYuJinLi);
            }
        }
        #endregion

        public ICommand CanShuShuRuButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    ScriptWrapperForHengNiuJu.WuZhiDingYi = string.Format(ScriptTemplateForHengNiuJu.WuZhiDingYi,
                         this.NianDuOfOil, this.NianDuOfAir, this.MiDuOfOil);

                    // {0} - 动轮初始转速(rad/s)  {1} - 动轮转动惯量 {2} - 背压阀出口  {3} - 滑阀回油出口
                    // {4} - 指令油入口   {5} - 充油进口   {6} - 通气孔   {7} - 反馈压力入口
                    double dongLunChuShiZhuanSu = Math.Round(double.Parse(this.DongLunChuShiZhuanSu) * Math.PI / 30, 5);
                    double beiYaFaChuKou = double.Parse(this.BeiYaFaChuKou) * 1000000;
                    double huaFaHuiYouChuKou = double.Parse(this.HuaFaHuiYouChuKou) * 1000000;
                    double zhiLingYouRuKou = double.Parse(this.ZhiLingYouRuKou) * 1000000;
                    double chongYouJinKou = double.Parse(this.ChongYouJinKou) * 1000000;
                    double tongQiKong = double.Parse(this.TongQiKong) * 1000000;
                    double fanKuiYaLiRuKou = double.Parse(this.FanKuiYaLiRuKou) * 1000000;
                    ScriptWrapperForHengNiuJu.BianJieTiaoJianDingYi = string.Format(ScriptTemplateForHengNiuJu.BianJieTiaoJianDingYi,
                        dongLunChuShiZhuanSu, this.DongLunZhuanDongGuanLiang, beiYaFaChuKou, huaFaHuiYouChuKou,
                        zhiLingYouRuKou, chongYouJinKou, tongQiKong, fanKuiYaLiRuKou);

                    // {0} - 背压阀阀芯质量 {1} - 背压阀弹簧刚度 {2} - 背压阀弹簧预紧力
                    // {3} - 滑阀阀芯质量  {4} - 滑阀弹簧刚度 {5} - 滑阀弹簧预紧力
                    ScriptWrapperForHengNiuJu.FaMenCanShu = string.Format(ScriptTemplateForHengNiuJu.FaMenCanShu, 
                        this.BeiYaFaFaXinZhiLiang, this.BeiYaFaTanHuangGangDu, this.BeiYaFaTanHuangYuJinLi, 
                        this.HuaFaFaXinZhiLiang, this.HuaFaTanHuangGangDu, this.HuaFaTanHuangYuJinLi);

                    MessageBox.Show("参数输入成功");
                });
            }
        }
    }
}
