using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalModel.ViewModels
{
    public class ShuXueHengNiuJuJiSuanViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public ShuXueHengNiuJuJiSuanViewModel()
        {
        }

        public ViewType Type
        {
            get
            {
                return ViewType.ShuXueHengNiuJuJiSuan;
            }
        }
    }
}
