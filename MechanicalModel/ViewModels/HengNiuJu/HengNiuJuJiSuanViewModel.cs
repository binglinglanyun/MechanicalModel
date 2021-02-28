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
                return ViewType.ShuXueHengNiuJuJiSuan;
            }
        }

        private string _shiJianBuChang = "200000";
        public string ShiJianBuChang
        {
            get
            {
                return _shiJianBuChang;
            }
            set
            {
                SetValueProperty(value, ref _shiJianBuChang);
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

        private string _canShuX = "-0.05";
        public string CanShuX
        {
            get
            {
                return _canShuX;
            }
            set
            {
                SetValueProperty(value, ref _canShuX);
            }
        }

        private string _canShuY = "0.083";
        public string CanShuY
        {
            get
            {
                return _canShuY;
            }
            set
            {
                SetValueProperty(value, ref _canShuY);
            }
        }

        private string _canShuZ = "0.224";
        public string CanShuZ
        {
            get
            {
                return _canShuZ;
            }
            set
            {
                SetValueProperty(value, ref _canShuZ);
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

                    ScriptWrapperForHengNiuJu.JianKongDianZuoBiaoCanShu = string.Format(ScriptTemplateForHengNiuJu.JianKongDianZuoBiaoCanShu, 
                        this.CanShuX, this.CanShuY, this.CanShuZ);

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
