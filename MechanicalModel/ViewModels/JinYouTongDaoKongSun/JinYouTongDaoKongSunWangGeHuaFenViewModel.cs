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
    public class JinYouTongDaoKongSunWangGeHuaFenViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public JinYouTongDaoKongSunWangGeHuaFenViewModel()
        {
        }

        public ViewType Type
        {
            get
            {
                return ViewType.JinYouTongDaoKongSunWangGeHuaFen;
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

        #region RuKou
        private string _ruKouZuiDaWangGeChiDu = "0.006";
        public string RuKouZuiDaWangGeChiDu
        {
            get
            {
                return _ruKouZuiDaWangGeChiDu;
            }
            set
            {
                SetValueProperty(value, ref _ruKouZuiDaWangGeChiDu);
            }
        }

        private string _ruKouZuiXiaoWangGeChiDu = "0.001";
        public string RuKouZuiXiaoWangGeChiDu
        {
            get
            {
                return _ruKouZuiXiaoWangGeChiDu;
            }
            set
            {
                SetValueProperty(value, ref _ruKouZuiXiaoWangGeChiDu);
            }
        }

        private string _ruKouZuiDaMianWangGeChiDu = "0.008";
        public string RuKouZuiDaMianWangGeChiDu
        {
            get
            {
                return _ruKouZuiDaMianWangGeChiDu;
            }
            set
            {
                SetValueProperty(value, ref _ruKouZuiDaMianWangGeChiDu);
            }
        }
        #endregion

        #region ChuKou
        private string _chuKouZuiDaWangGeChiDu = "0.006";
        public string ChuKouZuiDaWangGeChiDu
        {
            get
            {
                return _chuKouZuiDaWangGeChiDu;
            }
            set
            {
                SetValueProperty(value, ref _chuKouZuiDaWangGeChiDu);
            }
        }

        private string _chuKouZuiXiaoWangGeChiDu = "0.001";
        public string ChuKouZuiXiaoWangGeChiDu
        {
            get
            {
                return _chuKouZuiXiaoWangGeChiDu;
            }
            set
            {
                SetValueProperty(value, ref _chuKouZuiXiaoWangGeChiDu);
            }
        }

        private string _chuKouZuiDaMianWangGeChiDu = "0.008";
        public string ChuKouZuiDaMianWangGeChiDu
        {
            get
            {
                return _chuKouZuiDaMianWangGeChiDu;
            }
            set
            {
                SetValueProperty(value, ref _chuKouZuiDaMianWangGeChiDu);
            }
        }
        #endregion

        public string SourceUri
        {
            get
            {
                return Path.GetFullPath("Resources/JinYouTongDaoWangGe.png"); ;
            }
        }

        private Visibility _paoMianVisibility = Visibility.Collapsed;
        public Visibility PaoMianVisibility
        {
            get
            {
                return _paoMianVisibility;
            }
            set
            {
                SetValueProperty(value, ref _paoMianVisibility);
            }
        }

        private string _paoMianXianShiButtonContent = "显示";
        public string PaoMianXianShiButtonContent
        {
            get
            {
                return _paoMianXianShiButtonContent;
            }
            set
            {
                SetValueProperty(value, ref _paoMianXianShiButtonContent);
            }
        }

        public ICommand ConfirmButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    // 动轮
                    ScriptWrapperForJinYouTongDaoKongSun.DongLunForWangGeHuaFen = string.Format(ScriptTemplateForJinYouTongDaoKongSun.DongLunForWangGeHuaFen,
                        this.DongLunZuiDaWangGeChiDu, this.DongLunZuiXiaoWangGeChiDu, this.DongLunZuiDaMianWangGeChiDu);

                    // 定轮
                    ScriptWrapperForJinYouTongDaoKongSun.DingLunForWangGeHuaFen = string.Format(ScriptTemplateForJinYouTongDaoKongSun.DingLunForWangGeHuaFen,
                        this.DingLunZuiDaWangGeChiDu, this.DingLunZuiXiaoWangGeChiDu, this.DingLunZuiDaMianWangGeChiDu);

                    // 入口
                    ScriptWrapperForJinYouTongDaoKongSun.RuKouForWangGeHuaFen = string.Format(ScriptTemplateForJinYouTongDaoKongSun.RuKouForWangGeHuaFen,
                        this.RuKouZuiDaWangGeChiDu, this.RuKouZuiXiaoWangGeChiDu, this.RuKouZuiDaMianWangGeChiDu);

                    // 出口
                    ScriptWrapperForJinYouTongDaoKongSun.ChuKouForWangGeHuaFen = string.Format(ScriptTemplateForJinYouTongDaoKongSun.ChuKouForWangGeHuaFen,
                        this.ChuKouZuiDaWangGeChiDu, this.ChuKouZuiXiaoWangGeChiDu, this.ChuKouZuiDaMianWangGeChiDu);

                    MessageBox.Show("设置成功", "空损计算网格划分");
                });
            }
        }

        public ICommand PaoMianShowButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    if (string.IsNullOrEmpty(ScriptWrapperForJinYouTongDaoKongSun.DongLunForWangGeHuaFen) || string.IsNullOrEmpty(ScriptWrapperForJinYouTongDaoKongSun.DingLunForWangGeHuaFen) ||
                        string.IsNullOrEmpty(ScriptWrapperForJinYouTongDaoKongSun.RuKouForWangGeHuaFen) || string.IsNullOrEmpty(ScriptWrapperForJinYouTongDaoKongSun.ChuKouForWangGeHuaFen))
                    {
                        MessageBox.Show("请设置模型");
                        return;
                    }

                    if (this.PaoMianVisibility == Visibility.Visible)
                    {
                        this.PaoMianVisibility = Visibility.Collapsed;
                        this.PaoMianXianShiButtonContent = "显示";
                    }
                    else
                    {
                        this.PaoMianVisibility = Visibility.Visible;
                        this.PaoMianXianShiButtonContent = "隐藏";
                    }
                });
            }
        }

        public ICommand DongTaiShowButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    string scriptContent = ScriptWrapperForJinYouTongDaoKongSun.CreateFullScriptForWangGeHuaFen();
                    if (scriptContent != null)
                    {
                        StartOtherProcessHelper.StartPumpLinxForJinYouTongDaoKongSun(scriptContent);
                    }
                });
            }
        }
    }
}
