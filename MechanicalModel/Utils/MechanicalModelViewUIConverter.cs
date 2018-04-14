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
        private JiHeKongSunJiSuanMoXingControl _jiHeKongSunJiSuanMoXingControl = null;
        private JiHeHengNiuJuJiSuanMoXingControl _jiHeHengNiuJuJiSuanMoXingControl = null;
        private ShuXueKongSunWangGeHuaFenControl _shuXueKongSunWangGeHuaFenControl = null;
        private ShuXueKongSunJiSuanCanShuShuRuControl _shuXueKongSunJiSuanCanShuShuRuControll = null;
        private ShuXueKongSunJiSuanControl _shuXueKongSunJiSuanControl = null;
        private ShuXueKongSunJiSuanJieGuoShuChuControl _shuXueKongSunJiSuanJieGuoShuChuControl = null;
        private ShuXueHengNiuJuWangGeHuaFenControl _shuXueHengNiuJuWangGeHuaFenControl = null;
        private ShuXueHengNiuJuJiSuanCanShuShuRuControl _shuXueHengNiuJuJiSuanCanShuShuRuControl = null;
        private ShuXueHengNiuJuJiSuanControl _shuXueHengNiuJuJiSuanControl = null;
        private ShuXueHengNiuJuJiSuanJieGuoShuChuControl _shuXueHengNiuJuJiSuanJieGuoShuChuControl = null;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Control control = null;
            IViewModelCategory viewModel = value as IViewModelCategory;
            if (viewModel != null)
            {
                switch (viewModel.Type)
                {
                    case ViewType.JiHeKongSunJiSuanMoXing:
                        _jiHeKongSunJiSuanMoXingControl = _jiHeKongSunJiSuanMoXingControl ?? new JiHeKongSunJiSuanMoXingControl();
                        control = _jiHeKongSunJiSuanMoXingControl;
                        break;
                    case ViewType.JiHeHengNiuJuJiSuanMoXing:
                        _jiHeHengNiuJuJiSuanMoXingControl = _jiHeHengNiuJuJiSuanMoXingControl ?? new JiHeHengNiuJuJiSuanMoXingControl();
                        control = _jiHeHengNiuJuJiSuanMoXingControl;
                        break;
                    case ViewType.ShuXueKongSunWangGeHuaFen:
                        _shuXueKongSunWangGeHuaFenControl = _shuXueKongSunWangGeHuaFenControl ?? new ShuXueKongSunWangGeHuaFenControl();
                        control = _shuXueKongSunWangGeHuaFenControl;
                        break;
                    case ViewType.ShuXueKongSunJiSuanCanShuShuRu:
                        _shuXueKongSunJiSuanCanShuShuRuControll = _shuXueKongSunJiSuanCanShuShuRuControll ?? new ShuXueKongSunJiSuanCanShuShuRuControl();
                        control = _shuXueKongSunJiSuanCanShuShuRuControll;
                        break;
                    case ViewType.ShuXueKongSunJiSuan:
                        _shuXueKongSunJiSuanControl = _shuXueKongSunJiSuanControl ?? new ShuXueKongSunJiSuanControl();
                        control = _shuXueKongSunJiSuanControl;
                        break;
                    case ViewType.ShuXueKongSunJiSuanJieGuoShuChu:
                        _shuXueKongSunJiSuanJieGuoShuChuControl = _shuXueKongSunJiSuanJieGuoShuChuControl ?? new ShuXueKongSunJiSuanJieGuoShuChuControl();
                        control = _shuXueKongSunJiSuanJieGuoShuChuControl;
                        break;
                    case ViewType.ShuXueHengNiuJuWangGeHuaFen:
                        _shuXueHengNiuJuWangGeHuaFenControl = _shuXueHengNiuJuWangGeHuaFenControl ?? new ShuXueHengNiuJuWangGeHuaFenControl();
                        control = _shuXueHengNiuJuWangGeHuaFenControl;
                        break;
                    case ViewType.ShuXueHengNiuJuJiSuanCanShuShuRu:
                        _shuXueHengNiuJuJiSuanCanShuShuRuControl = _shuXueHengNiuJuJiSuanCanShuShuRuControl ?? new ShuXueHengNiuJuJiSuanCanShuShuRuControl();
                        control = _shuXueHengNiuJuJiSuanCanShuShuRuControl;
                        break;
                    case ViewType.ShuXueHengNiuJuJiSuan:
                        _shuXueHengNiuJuJiSuanControl = _shuXueHengNiuJuJiSuanControl ?? new ShuXueHengNiuJuJiSuanControl();
                        control = _shuXueHengNiuJuJiSuanControl;
                        break;
                    case ViewType.ShuXueHengNiuJuJiSuanJieGuoShuChu:
                        _shuXueHengNiuJuJiSuanJieGuoShuChuControl = _shuXueHengNiuJuJiSuanJieGuoShuChuControl ?? new ShuXueHengNiuJuJiSuanJieGuoShuChuControl();
                        control = _shuXueHengNiuJuJiSuanJieGuoShuChuControl;
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
