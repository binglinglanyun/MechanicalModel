using MechanicalModel.Scripts;
using MechanicalModel.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MechanicalModel.ViewModels
{
    public class HengNiuJuWangGeHuaFenViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public HengNiuJuWangGeHuaFenViewModel()
        {
        }

        public ViewType Type
        {
            get
            {
                return ViewType.HengNiuJuWangGeHuaFen;
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

        private Visibility _moXingVisibility = Visibility.Hidden;
        public Visibility MoXingVisibility
        {
            get
            {
                return _moXingVisibility;
            }
            set
            {
                SetValueProperty(value, ref _moXingVisibility);
            }
        }

        public ICommand ConfirmButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    ScriptWrapperForHengNiuJu.DingLunForWangGeHuaFen = string.Format(ScriptTemplateForHengNiuJu.DingLunForWangGeHuaFen,
                        this.DingLunZuiDaWangGeChiDu, this.DingLunZuiXiaoWangGeChiDu, this.DingLunZuiDaMianWangGeChiDu);

                    ScriptWrapperForHengNiuJu.DongLunForWangGeHuaFen = string.Format(ScriptTemplateForHengNiuJu.DongLunForWangGeHuaFen,
                        this.DongLunZuiDaWangGeChiDu, this.DongLunZuiXiaoWangGeChiDu, this.DongLunZuiDaMianWangGeChiDu);

                    MessageBox.Show("设置成功", "恒扭矩计算网格划分");
                });
            }
        }

        public ICommand WangGeHuaFenAndShowButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    string scriptContent = ScriptWrapperForHengNiuJu.CreateFullScriptForWangGeHuaFen();
                    if (scriptContent != null)
                    {
                        this.MoXingVisibility = Visibility.Visible;
                        // StartOtherProcessHelper.StartPumpLinxForHengNiuJu(scriptContent);
                    }
                });
            }
        }
    }
}
