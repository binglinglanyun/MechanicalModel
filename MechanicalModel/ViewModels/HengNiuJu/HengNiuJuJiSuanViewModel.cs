using MechanicalModel.Scripts;
using MechanicalModel.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MechanicalModel.ViewModels
{
    public class HengNiuJuJiSuanViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public HengNiuJuJiSuanViewModel()
        {
        }

        public ViewType Type
        {
            get
            {
                return ViewType.HengNiuJuJiSuan;
            }
        }

        private string _dieDaiBuShu = "200000";
        public string ShiJianBuChang
        {
            get
            {
                return _dieDaiBuShu;
            }
            set
            {
                SetValueProperty(value, ref _dieDaiBuShu);
            }
        }

        private string _baoCunPinLv = "50";
        public string BaoCunPinLv
        {
            get
            {
                return _baoCunPinLv;
            }
            set
            {
                SetValueProperty(value, ref _baoCunPinLv);
            }
        }

        private string _canShuX1 = "-0.05";
        public string CanShuX1
        {
            get
            {
                return _canShuX1;
            }
            set
            {
                SetValueProperty(value, ref _canShuX1);
            }
        }

        private string _canShuY1 = "0.083";
        public string CanShuY1
        {
            get
            {
                return _canShuY1;
            }
            set
            {
                SetValueProperty(value, ref _canShuY1);
            }
        }

        private string _canShuZ1 = "0.224";
        public string CanShuZ1
        {
            get
            {
                return _canShuZ1;
            }
            set
            {
                SetValueProperty(value, ref _canShuZ1);
            }
        }

        private string _canShuX2 = "-0.05";
        public string CanShuX2
        {
            get
            {
                return _canShuX2;
            }
            set
            {
                SetValueProperty(value, ref _canShuX2);
            }
        }

        private string _canShuY2 = "0.083";
        public string CanShuY2
        {
            get
            {
                return _canShuY2;
            }
            set
            {
                SetValueProperty(value, ref _canShuY2);
            }
        }

        private string _canShuZ2 = "0.224";
        public string CanShuZ2
        {
            get
            {
                return _canShuZ2;
            }
            set
            {
                SetValueProperty(value, ref _canShuZ2);
            }
        }

        public ICommand JiSuanButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    ScriptWrapperForHengNiuJu.JiSuanKongZhiCanShu = string.Format(ScriptTemplateForHengNiuJu.JiSuanKongZhiCanShu,
                        this.ShiJianBuChang, this.BaoCunPinLv);

                    // TODO: fix
                    ScriptWrapperForHengNiuJu.JianKongDianZuoBiaoCanShu = string.Format(ScriptTemplateForHengNiuJu.JianKongDianZuoBiaoCanShu, 
                        this.CanShuX1, this.CanShuY1, this.CanShuZ1);

                    string scriptContent = ScriptWrapperForHengNiuJu.CreateFullScriptForJiSuan();
                    if (scriptContent != null)
                    {
                        StartOtherProcessHelper.StartPumpLinxForHengNiuJu(scriptContent);
                    }
                });
            }
        }


    }
}
