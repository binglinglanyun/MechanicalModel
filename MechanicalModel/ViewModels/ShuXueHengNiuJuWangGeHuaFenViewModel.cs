using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalModel.ViewModels
{
    public class ShuXueHengNiuJuWangGeHuaFenViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public ShuXueHengNiuJuWangGeHuaFenViewModel()
        {
        }

        public ViewType Type
        {
            get
            {
                return ViewType.ShuXueHengNiuJuWangGeHuaFen;
            }
        }

        public string SourceUri
        {
            get
            {
                return Path.GetFullPath("Resources/HengNiuJuMoXingWangGe.png"); ;
            }
        }
    }
}
