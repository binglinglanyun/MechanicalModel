using MechanicalModel.Scripts;
using MechanicalModel.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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

        #region DingLun
        private string _dingLunZuiDaWangGeChiDu = "0.006";
        public string DingLunZuiDaWangGeChiDu
        {
            get
            {
                return _dingLunZuiDaWangGeChiDu;
            }
            set
            {
                SetValueProperty(value, ref _dingLunZuiDaWangGeChiDu);
            }
        }

        private string _dingLunZuiXiaoWangGeChiDu = "0.0005";
        public string DingLunZuiXiaoWangGeChiDu
        {
            get
            {
                return _dingLunZuiXiaoWangGeChiDu;
            }
            set
            {
                SetValueProperty(value, ref _dingLunZuiXiaoWangGeChiDu);
            }
        }

        private string _dingLunZuiDaMianWangGeChiDu = "0.008";
        public string DingLunZuiDaMianWangGeChiDu
        {
            get
            {
                return _dingLunZuiDaMianWangGeChiDu;
            }
            set
            {
                SetValueProperty(value, ref _dingLunZuiDaMianWangGeChiDu);
            }
        }
        #endregion

        #region DongLun
        private string _dongLunZuiDaWangGeChiDu = "0.006";
        public string DongLunZuiDaWangGeChiDu
        {
            get
            {
                return _dongLunZuiDaWangGeChiDu;
            }
            set
            {
                SetValueProperty(value, ref _dongLunZuiDaWangGeChiDu);
            }
        }

        private string _dongLunZuiXiaoWangGeChiDu = "0.001";
        public string DongLunZuiXiaoWangGeChiDu
        {
            get
            {
                return _dongLunZuiXiaoWangGeChiDu;
            }
            set
            {
                SetValueProperty(value, ref _dongLunZuiXiaoWangGeChiDu);
            }
        }

        private string _dongLunZuiDaMianWangGeChiDu = "0.008";
        public string DongLunZuiDaMianWangGeChiDu
        {
            get
            {
                return _dongLunZuiDaMianWangGeChiDu;
            }
            set
            {
                SetValueProperty(value, ref _dongLunZuiDaMianWangGeChiDu);
            }
        }
        #endregion

        public string SourceUri
        {
            get
            {
                return Path.GetFullPath("Resources/KongSunMoXingWangGe.png"); ;
            }
        }

        public ICommand ConfirmButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    ScriptWrapperForKongSun.DingLunForWangGeHuaFen = string.Format(ScriptTemplateForKongSun.DingLunForWangGeHuaFen,
                        this.DingLunZuiDaWangGeChiDu, this.DingLunZuiXiaoWangGeChiDu, this.DingLunZuiDaMianWangGeChiDu);

                    ScriptWrapperForKongSun.DongLunForWangGeHuaFen = string.Format(ScriptTemplateForKongSun.DongLunForWangGeHuaFen, 
                        this.DongLunZuiDaWangGeChiDu, this.DongLunZuiXiaoWangGeChiDu, this.DongLunZuiDaMianWangGeChiDu);

                    MessageBox.Show("设置成功");
                });
            }
        }

        public ICommand WangGeHuaFenAndShowButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    string scriptContent = ScriptWrapperForKongSun.CreateFullScriptForWangGeHuaFen();
                    if (scriptContent != null)
                    {
                        StartOtherProcessHelper.StartPumpLinxForKongSun(scriptContent);
                    }
                });
            }
        }
    }
}
