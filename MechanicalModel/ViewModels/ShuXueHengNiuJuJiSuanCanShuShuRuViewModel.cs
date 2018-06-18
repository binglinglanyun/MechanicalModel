using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
