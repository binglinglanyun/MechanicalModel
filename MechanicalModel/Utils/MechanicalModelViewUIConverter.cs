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
        // "进气比空损"
        private JinQiBiKongSunJiSuanMoXingControl _jinQiBiKongSunJiSuanMoXingControl = null;
        private JinQiBiKongSunWangGeHuaFenControl _jinQiBiKongSunWangGeHuaFenControl = null;
        private JinQiBiKongSunJiSuanCanShuShuRuControl _jinQiBiKongSunJiSuanCanShuShuRuControl = null;
        private JinQiBiKongSunJiSuanControl _jinQiBiKongSunJiSuanControl = null;
        private JinQiBiKongSunJiSuanJieGuoShuChuControl _jinQiBiKongSunJiSuanJieGuoShuChuControl = null;

        // "进油通道空损"
        private JinYouTongDaoJiSuanJiHeMoXingControl _jinYouTongDaoJiSuanJiHeMoXingControl = null;
        private JinYouTongDaoKongSunWangGeHuaFenControl _jinYouTongDaoKongSunWangGeHuaFenControl = null;
        private JinYouTongDaoKongSunJiSuanCanShuShuRuControl _jinYouTongDaoKongSunJiSuanCanShuShuRuControl = null;
        private JinYouTongDaoKongSunJiSuanControl _jinYouTongDaoKongSunJiSuanControl = null;
        private JinYouTongDaoKongSunJiSuanJieGuoShuChuControl _jinYouTongDaoKongSunJiSuanJieGuoShuChuControl = null;

        // "制动特性计算"
        private ZhiDongNiuJuPiPeiTeXingGuanXiControl _zhiDongNiuJuPiPeiTeXingGuanXiControl = null;
        private HengNiuJuJiSuanMoXingControl _hengNiuJuJiSuanMoXingControl = null;
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
                    // "进气比空损"
                    case ViewType.JinQiBiKongSunJiSuanMoXing:
                        _jinQiBiKongSunJiSuanMoXingControl = _jinQiBiKongSunJiSuanMoXingControl ?? new JinQiBiKongSunJiSuanMoXingControl();
                        control = _jinQiBiKongSunJiSuanMoXingControl;
                        break;
                    case ViewType.JinQiBiKongSunWangGeHuaFen:
                        _jinQiBiKongSunWangGeHuaFenControl = _jinQiBiKongSunWangGeHuaFenControl ?? new JinQiBiKongSunWangGeHuaFenControl();
                        control = _jinQiBiKongSunWangGeHuaFenControl;
                        break;
                    case ViewType.JinQiBiKongSunJiSuanCanShuShuRu:
                        _jinQiBiKongSunJiSuanCanShuShuRuControl = _jinQiBiKongSunJiSuanCanShuShuRuControl ?? new JinQiBiKongSunJiSuanCanShuShuRuControl();
                        control = _jinQiBiKongSunJiSuanCanShuShuRuControl;
                        break;
                    case ViewType.JinQiBiKongSunJiSuan:
                        _jinQiBiKongSunJiSuanControl = _jinQiBiKongSunJiSuanControl ?? new JinQiBiKongSunJiSuanControl();
                        control = _jinQiBiKongSunJiSuanControl;
                        break;
                    case ViewType.JinQiBiKongSunJiSuanJieGuoShuChu:
                        _jinQiBiKongSunJiSuanJieGuoShuChuControl = _jinQiBiKongSunJiSuanJieGuoShuChuControl ?? new JinQiBiKongSunJiSuanJieGuoShuChuControl();
                        control = _jinQiBiKongSunJiSuanJieGuoShuChuControl;
                        break;

                    // "进油通道空损"
                    case ViewType.JinYouTongDaoJiSuanJiHeMoXing:
                        _jinYouTongDaoJiSuanJiHeMoXingControl = _jinYouTongDaoJiSuanJiHeMoXingControl ?? new JinYouTongDaoJiSuanJiHeMoXingControl();
                        control = _jinYouTongDaoJiSuanJiHeMoXingControl;
                        break;
                    case ViewType.JinYouTongDaoKongSunWangGeHuaFen:
                        _jinYouTongDaoKongSunWangGeHuaFenControl = _jinYouTongDaoKongSunWangGeHuaFenControl ?? new JinYouTongDaoKongSunWangGeHuaFenControl();
                        control = _jinYouTongDaoKongSunWangGeHuaFenControl;
                        break;
                    case ViewType.JinYouTongDaoKongSunJiSuanCanShuShuRu:
                        _jinYouTongDaoKongSunJiSuanCanShuShuRuControl = _jinYouTongDaoKongSunJiSuanCanShuShuRuControl ?? new JinYouTongDaoKongSunJiSuanCanShuShuRuControl();
                        control = _jinYouTongDaoKongSunJiSuanCanShuShuRuControl;
                        break;
                    case ViewType.JinYouTongDaoKongSunJiSuan:
                        _jinYouTongDaoKongSunJiSuanControl = _jinYouTongDaoKongSunJiSuanControl ?? new JinYouTongDaoKongSunJiSuanControl();
                        control = _jinYouTongDaoKongSunJiSuanControl;
                        break;
                    case ViewType.JinYouTongDaoKongSunJiSuanJieGuoShuChu:
                        _jinYouTongDaoKongSunJiSuanJieGuoShuChuControl = _jinYouTongDaoKongSunJiSuanJieGuoShuChuControl ?? new JinYouTongDaoKongSunJiSuanJieGuoShuChuControl();
                        control = _jinYouTongDaoKongSunJiSuanJieGuoShuChuControl;
                        break;

                    // "制动特性计算"
                    case ViewType.ZhiDongNiuJuPiPeiTeXingGuanXi:
                        _zhiDongNiuJuPiPeiTeXingGuanXiControl = _zhiDongNiuJuPiPeiTeXingGuanXiControl ?? new ZhiDongNiuJuPiPeiTeXingGuanXiControl();
                        control = _zhiDongNiuJuPiPeiTeXingGuanXiControl;
                        break;
                    case ViewType.HengNiuJuJiSuanMoXing:
                        _hengNiuJuJiSuanMoXingControl = _hengNiuJuJiSuanMoXingControl ?? new HengNiuJuJiSuanMoXingControl();
                        control = _hengNiuJuJiSuanMoXingControl;
                        break;
                    case ViewType.HengNiuJuWangGeHuaFen:
                        _hengNiuJuWangGeHuaFenControl = _hengNiuJuWangGeHuaFenControl ?? new HengNiuJuWangGeHuaFenControl();
                        control = _hengNiuJuWangGeHuaFenControl;
                        break;
                    case ViewType.HengNiuJuJiSuanCanShuShuRu:
                        _hengNiuJuJiSuanCanShuShuRuControl = _hengNiuJuJiSuanCanShuShuRuControl ?? new HengNiuJuJiSuanCanShuShuRuControl();
                        control = _hengNiuJuJiSuanCanShuShuRuControl;
                        break;
                    case ViewType.HengNiuJuJiSuan:
                        _hengNiuJuJiSuanControl = _hengNiuJuJiSuanControl ?? new HengNiuJuJiSuanControl();
                        control = _hengNiuJuJiSuanControl;
                        break;
                    case ViewType.HengNiuJuJiSuanJieGuoShuChu:
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
