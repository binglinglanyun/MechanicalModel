﻿using MechanicalModel.Scripts;
using MechanicalModel.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
                return Path.GetFullPath("Resources/HengNiuJuMoXingWangGe.png"); ;
            }
        }

        public ICommand WangGeHuaFenButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    ScriptWrapperForHengNiuJu.DingLunForWangGeHuaFen = string.Format(ScriptTemplateForHengNiuJu.DingLunForWangGeHuaFen,
                        this.DingLunZuiDaWangGeChiDu, this.DingLunZuiXiaoWangGeChiDu, this.DingLunZuiDaMianWangGeChiDu);

                    ScriptWrapperForHengNiuJu.DongLunForWangGeHuaFen = string.Format(ScriptTemplateForHengNiuJu.DongLunForWangGeHuaFen,
                        this.DongLunZuiDaWangGeChiDu, this.DongLunZuiXiaoWangGeChiDu, this.DongLunZuiDaMianWangGeChiDu);

                    string scriptContent = ScriptWrapperForHengNiuJu.CreateFullScriptForWangGeHuaFen();
                    if (scriptContent != null)
                    {
                        StartOtherProcessHelper.StartPumpLinxForHengNiuJu(scriptContent);
                    }
                });
            }
        }

        public ICommand ShowButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    // Show background processes
                });
            }
        }
    }
}
