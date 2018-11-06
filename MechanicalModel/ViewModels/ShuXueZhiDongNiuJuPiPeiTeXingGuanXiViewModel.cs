using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalModel.ViewModels
{
    public class ShuXueZhiDongNiuJuPiPeiTeXingGuanXiViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public ShuXueZhiDongNiuJuPiPeiTeXingGuanXiViewModel()
        {
        }

        public ViewType Type
        {
            get
            {
                return ViewType.ShuXueZhiDongNiuJuPiPeiTeXingGuanXi;
            }
        }

        public string SourceUri
        {
            get
            {
                return Path.GetFullPath("Resources/ZhiDongNiuJu.png"); ;
            }
        }

        private string _zhiDongNiuJu = "0.006";
        public string ZhiDongNiuJu
        {
            get
            {
                return _zhiDongNiuJu;
            }
            set
            {
                SetValueProperty(value, ref _zhiDongNiuJu);
            }
        }

        private string _zhiLingYouYa = "0.001";
        public string ZhiLingYouYa
        {
            get
            {
                return _zhiLingYouYa;
            }
            set
            {
                SetValueProperty(value, ref _zhiLingYouYa);
            }
        }
    }
}
