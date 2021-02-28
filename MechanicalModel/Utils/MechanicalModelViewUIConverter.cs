using MechanicalModel.Controls;
using MechanicalModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace MechanicalModel.Utils
{
    public class MechanicalModelViewUIConverter : IValueConverter
    {
        private JinQiBiKongSunJiSuanMoXingControl _jinQiBiKongSunJiSuanMoXingControl = null;
        private HengNiuJuJiSuanMoXingControl _hengNiuJuJiSuanMoXingControl = null;
        private JinQiBiKongSunWangGeHuaFenControl _jinQiBiKongSunWangGeHuaFenControl = null;
        private JinQiBiKongSunJiSuanCanShuShuRuControl _jinQiBiKongSunJiSuanCanShuShuRuControll = null;
        private JinQiBiKongSunJiSuanControl _jinQiBiKongSunJiSuanControl = null;
        private JinQiBiKongSunJiSuanJieGuoShuChuControl _jinQiBiKongSunJiSuanJieGuoShuChuControl = null;
        private ZhiDongNiuJuPiPeiTeXingGuanXiControl _zhiDongNiuJuPiPeiTeXingGuanXiControl = null;
        private HengNiuJuWangGeHuaFenControl _hengNiuJuWangGeHuaFenControl = null;
        private HengNiuJuJiSuanCanShuShuRuControl _hengNiuJuJiSuanCanShuShuRuControl = null;
        private HengNiuJuJiSuanControl _hengNiuJuJiSuanControl = null;
        private HengNiuJuJiSuanJieGuoShuChuControl _hengNiuJuJiSuanJieGuoShuChuControl = null;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Control control = null;
            IViewModelCategory viewModel = value as IViewModelCategory;
            if (viewModel != null)
            {
                switch (viewModel.Type)
                {
                    case ViewType.JiHeKongSunJiSuanMoXing:
                        _jinQiBiKongSunJiSuanMoXingControl = _jinQiBiKongSunJiSuanMoXingControl ?? new JinQiBiKongSunJiSuanMoXingControl();
                        control = _jinQiBiKongSunJiSuanMoXingControl;
                        break;
                    case ViewType.JiHeHengNiuJuJiSuanMoXing:
                        _hengNiuJuJiSuanMoXingControl = _hengNiuJuJiSuanMoXingControl ?? new HengNiuJuJiSuanMoXingControl();
                        control = _hengNiuJuJiSuanMoXingControl;
                        break;
                    case ViewType.ShuXueKongSunWangGeHuaFen:
                        _jinQiBiKongSunWangGeHuaFenControl = _jinQiBiKongSunWangGeHuaFenControl ?? new JinQiBiKongSunWangGeHuaFenControl();
                        control = _jinQiBiKongSunWangGeHuaFenControl;
                        break;
                    case ViewType.ShuXueKongSunJiSuanCanShuShuRu:
                        _jinQiBiKongSunJiSuanCanShuShuRuControll = _jinQiBiKongSunJiSuanCanShuShuRuControll ?? new JinQiBiKongSunJiSuanCanShuShuRuControl();
                        control = _jinQiBiKongSunJiSuanCanShuShuRuControll;
                        break;
                    case ViewType.ShuXueKongSunJiSuan:
                        _jinQiBiKongSunJiSuanControl = _jinQiBiKongSunJiSuanControl ?? new JinQiBiKongSunJiSuanControl();
                        control = _jinQiBiKongSunJiSuanControl;
                        break;
                    case ViewType.ShuXueKongSunJiSuanJieGuoShuChu:
                        _jinQiBiKongSunJiSuanJieGuoShuChuControl = _jinQiBiKongSunJiSuanJieGuoShuChuControl ?? new JinQiBiKongSunJiSuanJieGuoShuChuControl();
                        control = _jinQiBiKongSunJiSuanJieGuoShuChuControl;
                        break;
                    case ViewType.ShuXueZhiDongNiuJuPiPeiTeXingGuanXi:
                        _zhiDongNiuJuPiPeiTeXingGuanXiControl = _zhiDongNiuJuPiPeiTeXingGuanXiControl ?? new ZhiDongNiuJuPiPeiTeXingGuanXiControl();
                        control = _zhiDongNiuJuPiPeiTeXingGuanXiControl;
                        break;
                    case ViewType.ShuXueHengNiuJuWangGeHuaFen:
                        _hengNiuJuWangGeHuaFenControl = _hengNiuJuWangGeHuaFenControl ?? new HengNiuJuWangGeHuaFenControl();
                        control = _hengNiuJuWangGeHuaFenControl;
                        break;
                    case ViewType.ShuXueHengNiuJuJiSuanCanShuShuRu:
                        _hengNiuJuJiSuanCanShuShuRuControl = _hengNiuJuJiSuanCanShuShuRuControl ?? new HengNiuJuJiSuanCanShuShuRuControl();
                        control = _hengNiuJuJiSuanCanShuShuRuControl;
                        break;
                    case ViewType.ShuXueHengNiuJuJiSuan:
                        _hengNiuJuJiSuanControl = _hengNiuJuJiSuanControl ?? new HengNiuJuJiSuanControl();
                        control = _hengNiuJuJiSuanControl;
                        break;
                    case ViewType.ShuXueHengNiuJuJiSuanJieGuoShuChu:
                        _hengNiuJuJiSuanJieGuoShuChuControl = _hengNiuJuJiSuanJieGuoShuChuControl ?? new HengNiuJuJiSuanJieGuoShuChuControl();
                        control = _hengNiuJuJiSuanJieGuoShuChuControl;
                        break;
                }
            }

            if (control != null)
            {
                control.DataContext = value;
                return control;
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
