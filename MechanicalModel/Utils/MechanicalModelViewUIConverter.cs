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
        private WangGeHuaFenControl _wangGeHuaFenControl = null;
        private JiSuanCanShuShuRuControl _jiSuanCanShuShuRuControl = null;
        private JiSuanControl _jiSuanControl = null;
        private JiSuanJieGuoShuChuControl _jiSuanJieGuoShuChuControl = null;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Control control = null;
            IViewModelCategory viewModel = value as IViewModelCategory;
            if (viewModel != null)
            {
                switch (viewModel.Type)
                {
                    case ViewType.WangGeHuaFen:
                        _wangGeHuaFenControl = _wangGeHuaFenControl ?? new WangGeHuaFenControl();
                        control = _wangGeHuaFenControl;
                        break;
                    case ViewType.JiSuanCanShuShuRu:
                        _jiSuanCanShuShuRuControl = _jiSuanCanShuShuRuControl ?? new JiSuanCanShuShuRuControl();
                        control = _jiSuanCanShuShuRuControl;
                        break;
                    case ViewType.JiSuan:
                        _jiSuanControl = _jiSuanControl ?? new JiSuanControl();
                        control = _jiSuanControl;
                        break;
                    case ViewType.JiSuanJieGuoShuChu:
                        _jiSuanJieGuoShuChuControl = _jiSuanJieGuoShuChuControl ?? new JiSuanJieGuoShuChuControl();
                        control = _jiSuanJieGuoShuChuControl;
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
