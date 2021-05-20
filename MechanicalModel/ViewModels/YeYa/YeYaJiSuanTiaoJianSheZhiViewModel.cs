using MechanicalModel.Scripts;
using MechanicalModel.Utils;
using System;
using System.Collections.Generic;
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

        private string _ev2KongZhiYaLi = "2.5";
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

        private string _yeYaYou = "15W40";
        public string YeYaYou
        {
            get
            {
                return _yeYaYou;
            }
            set
            {
                SetValueProperty(value, ref _yeYaYou);
            }
        }

        private string _hanQiLiang = "0.1%";
        public string HanQiLiang
        {
            get
            {
                return _hanQiLiang;
            }
            set
            {
                SetValueProperty(value, ref _hanQiLiang);
            }
        }
        #endregion

        public ICommand ConfirmButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    MessageBox.Show("设置成功", "参数输入");
                });
            }
        }
    }
}
