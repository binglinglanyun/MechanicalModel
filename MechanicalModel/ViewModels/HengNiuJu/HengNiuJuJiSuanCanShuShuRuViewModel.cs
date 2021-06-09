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
    public class HengNiuJuJiSuanCanShuShuRuViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public HengNiuJuJiSuanCanShuShuRuViewModel()
        {
        }

        public ViewType Type
        {
            get
            {
                return ViewType.HengNiuJuJiSuanCanShuShuRu;
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
        public string JinKouYaLi
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

        private string _tongQiKongYaLi = "0.1";
        public string TongQiKongYaLi
        {
            get
            {
                return _tongQiKongYaLi;
            }
            set
            {
                SetValueProperty(value, ref _tongQiKongYaLi);
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

        private string _jinKouWenDu = "45";
        public string JinKouWenDu
        {
            get
            {
                return _jinKouWenDu;
            }
            set
            {
                SetValueProperty(value, ref _jinKouWenDu);
            }
        }
        #endregion

        public ICommand ConfirmButtonClick
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
                    double beiYaFaChuKou = double.Parse(this.JinKouWenDu) * 1000000;
                    double chongYouJinKou = double.Parse(this.JinKouYaLi) * 1000000;
                    double tongQiKong = double.Parse(this.TongQiKongYaLi) * 1000000;
                    // TODO: fix the fake values.
                    ScriptWrapperForHengNiuJu.BianJieTiaoJianDingYi = string.Format(ScriptTemplateForHengNiuJu.BianJieTiaoJianDingYi,
                        dongLunChuShiZhuanSu, this.DongLunZhuanDongGuanLiang, beiYaFaChuKou, tongQiKong,
                        tongQiKong, chongYouJinKou, tongQiKong, tongQiKong);

                    // {0} - 背压阀阀芯质量 {1} - 背压阀弹簧刚度 {2} - 背压阀弹簧预紧力
                    // {3} - 滑阀阀芯质量  {4} - 滑阀弹簧刚度 {5} - 滑阀弹簧预紧力
                    // TODO: fix the fake values.
                    ScriptWrapperForHengNiuJu.FaMenCanShu = string.Format(ScriptTemplateForHengNiuJu.FaMenCanShu, 
                        this.DongLunZhuanDongGuanLiang, this.DongLunZhuanDongGuanLiang, this.DongLunZhuanDongGuanLiang, 
                        this.DongLunZhuanDongGuanLiang, this.DongLunZhuanDongGuanLiang, this.DongLunZhuanDongGuanLiang);

                    MessageBox.Show("设置成功", "恒扭矩计算参数输入");
                });
            }
        }
    }
}
