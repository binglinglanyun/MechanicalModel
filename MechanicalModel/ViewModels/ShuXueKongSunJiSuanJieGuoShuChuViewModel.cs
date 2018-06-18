using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalModel.ViewModels
{
    public class ShuXueKongSunJiSuanJieGuoShuChuViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public ShuXueKongSunJiSuanJieGuoShuChuViewModel()
        {
        }

        public ViewType Type
        {
            get
            {
                return ViewType.ShuXueKongSunJiSuanJieGuoShuChu;
            }
        }

        private string _kongSunGongLv = "11,700";
        public string KongSunGongLv
        {
            get
            {
                return _kongSunGongLv;
            }
            set
            {
                SetValueProperty(value, ref _kongSunGongLv);
            }
        }
    }
}
