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
    public class YeYaJiSuanTiaoJianSheZhiViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public YeYaJiSuanTiaoJianSheZhiViewModel()
        {
        }

        public ViewType Type
        {
            get
            {
                return ViewType.YeYaJiSuanTiaoJianSheZhi;
            }
        }

        #region BianJieTiaoJianDingYi
        private string _youYuanYaLi = "2.5";
        public string YouYuanYaLi
        {
            get
            {
                return _youYuanYaLi;
            }
            set
            {
                SetValueProperty(value, ref _youYuanYaLi);
            }
        }

        private string _ev2KongZhiYaLi = "5";
        public string EV2KongZhiYaLi
        {
            get
            {
                return _ev2KongZhiYaLi;
            }
            set
            {
                SetValueProperty(value, ref _ev2KongZhiYaLi);
            }
        }
        #endregion

        public ICommand SetAndComputeButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    /*
                    if (!File.Exists(ScriptWrapperForYeYa.DestModulePath))
                    {
                        MessageBox.Show("系统结构模型不存在, 请选择模型文件并确认设置");
                        return;
                    }

                    StartOtherProcessHelper.StartAMESimByPython(string.Format("{0} {1}", this.YouYuanYaLi, this.EV2KongZhiYaLi));
                    */
                });
            }
        }
    }
}
