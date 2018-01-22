using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MechanicalModel.ViewModels
{
    public interface IViewModelCategory
    {
        ViewType Type { get; }
    }

    public class WangGeHuaFenViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public WangGeHuaFenViewModel()
        {
        }

        public ViewType Type
        {
            get
            {
                return ViewType.WangGeHuaFen;
            }
        }
    }

    public class JiSuanCanShuShuRuViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public JiSuanCanShuShuRuViewModel()
        {
        }

        public ViewType Type
        {
            get
            {
                return ViewType.JiSuanCanShuShuRu;
            }
        }
    }

    public class JiSuanViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public JiSuanViewModel()
        {
        }

        public ViewType Type
        {
            get
            {
                return ViewType.JiSuan;
            }
        }
    }

    public class JiSuanJieGuoShuChuViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public JiSuanJieGuoShuChuViewModel()
        {
        }

        public ViewType Type
        {
            get
            {
                return ViewType.JiSuanJieGuoShuChu;
            }
        }
    }
}
