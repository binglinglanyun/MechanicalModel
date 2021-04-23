using MechanicalModel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.IO;
using MechanicalModel.Scripts;
using System.Diagnostics;

namespace MechanicalModel.ViewModels
{
    public class JinYouTongDaoKongSunJiSuanMoXingViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public JinYouTongDaoKongSunJiSuanMoXingViewModel()
        {
            // Empty here
        }

        public ViewType Type
        {
            get
            {
                return ViewType.JinYouTongDaoJiSuanJiHeMoXing;
            }
        }

        #region Button Click
        private string _moXingLocation = null;
        public ICommand SetupButtonClick
        {
            get
            {
                return new DelegateCommand<object>((o) =>
                {
                    this._moXingLocation = Path.Combine(ScriptWrapperForJinYouTongDaoKongSun.SourceMoXingFolderPath, MoXingList[_selectedMoXingIndex]);
                });
            }
        }

        public ICommand PaoMianShowButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    if (!Directory.Exists(this._moXingLocation))
                    {
                        MessageBox.Show("请设置模型");
                        return;
                    }

                    this.PaoMianVisibility = Visibility.Visible;
                });
            }
        }

        public ICommand DongTaiShowButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    if (!Directory.Exists(this._moXingLocation))
                    {
                        MessageBox.Show("请设置模型");
                        return;
                    }

                    try
                    {
                        this.LoadingVisibility = Visibility.Visible;
                        CommonUtils.CopyFolder(this._moXingLocation, ScriptWrapperForJinYouTongDaoKongSun.WorkDirectory);
                        this.LoadingVisibility = Visibility.Collapsed;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("模型导入失败，错误信息：{0}", ex.Message));
                        return;
                    }

                    // Create import script
                    string scriptContent = ScriptWrapperForJinYouTongDaoKongSun.CreateFullScriptForImportMoXing();
                    if (scriptContent != null)
                    {
                        StartOtherProcessHelper.StartPumpLinxForJinYouTongDaoKongSun(scriptContent);
                    }
                });
            }
        }
        #endregion

        #region Properties
        public List<string> MoXingList
        {
            get
            {
                return new List<string>() { "003", "006", "008" };
            }
        }

        private int _selectedMoXingIndex = 0;
        public int SelectedMoXingIndex
        {
            get
            {
                return _selectedMoXingIndex;
            }
            set
            {
                SetValueProperty(value, ref _selectedMoXingIndex);
            }
        }

        public string SourceUri
        {
            get
            {
                return Path.GetFullPath("Resources/JinYouTongDaoJiHeMoXing.png");
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

        private Visibility _loadingVisibility = Visibility.Collapsed;
        public Visibility LoadingVisibility
        {
            get
            {
                return _loadingVisibility;
            }
            set
            {
                SetValueProperty(value, ref _loadingVisibility);
            }
        }
        #endregion
    }
}
