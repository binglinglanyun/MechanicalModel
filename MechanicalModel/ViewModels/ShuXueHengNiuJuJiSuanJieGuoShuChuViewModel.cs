using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalModel.ViewModels
{
    public class ShuXueHengNiuJuJiSuanJieGuoShuChuViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public ShuXueHengNiuJuJiSuanJieGuoShuChuViewModel()
        {
        }

        public ViewType Type
        {
            get
            {
                return ViewType.ShuXueHengNiuJuJiSuanJieGuoShuChu;
            }
        }
    }
}
