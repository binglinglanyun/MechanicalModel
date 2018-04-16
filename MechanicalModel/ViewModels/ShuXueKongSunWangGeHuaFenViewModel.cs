using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalModel.ViewModels
{
    public class ShuXueKongSunWangGeHuaFenViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public ShuXueKongSunWangGeHuaFenViewModel()
        {
        }

        public ViewType Type
        {
            get
            {
                return ViewType.ShuXueKongSunWangGeHuaFen;
            }
        }

        public string SourceUri
        {
            get
            {
                return Path.GetFullPath("Resources/KongSunMoXingWangGe.png"); ;
            }
        }
    }
}
