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
    public class HengNiuJuJiSuanCanShuShuRuViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public HengNiuJuJiSuanCanShuShuRuViewModel()
        {
        }

        public ViewType Type
        {
            get
            {
                return ViewType.HengNiuJuJiSuanCanShuShuRu;
            }
        }

        #region WuZhiDingYi
        private string _nianDuOfAir = "1.853e-005";
        public string NianDuOfAir
        {
            get
            {
                return _nianDuOfAir;
            }
            set
            {
                SetValueProperty(value, ref _nianDuOfAir);
            }
        }

        private string _reDaoLvOfAir = "0.0264";
        public string ReDaoLvOfAir
        {
            get
            {
                return _reDaoLvOfAir;
            }
            set
            {
                SetValueProperty(value, ref _reDaoLvOfAir);
            }
        }

        private string _biReRongOfAir = "1005";
        public string BiReRongOfAir
        {
            get
            {
                return _biReRongOfAir;
            }
            set
            {
                SetValueProperty(value, ref _biReRongOfAir);
            }
        }
        #endregion

        #region BianJieTiaoJianDingYi
        private string _chongYouJinKou = "0.2";
        public string JinKouYaLi
        {
            get
            {
                return _chongYouJinKou;
            }
            set
            {
                SetValueProperty(value, ref _chongYouJinKou);
            }
        }

        private string _tongQiKongYaLi = "0.1";
        public string TongQiKongYaLi
        {
            get
            {
                return _tongQiKongYaLi;
            }
            set
            {
                SetValueProperty(value, ref _tongQiKongYaLi);
            }
        }

        private string _dongLunChuShiZhuanSu = "3600";
        public string DongLunChuShiZhuanSu
        {
            get
            {
                return _dongLunChuShiZhuanSu;
            }
            set
            {
                SetValueProperty(value, ref _dongLunChuShiZhuanSu);
            }
        }

        private string _dongLunZhuanDongGuanLiang = "150";
        public string DongLunZhuanDongGuanLiang
        {
            get
            {
                return _dongLunZhuanDongGuanLiang;
            }
            set
            {
                SetValueProperty(value, ref _dongLunZhuanDongGuanLiang);
            }
        }

        private string _jinKouWenDu = "45";
        public string JinKouWenDu
        {
            get
            {
                return _jinKouWenDu;
            }
            set
            {
                SetValueProperty(value, ref _jinKouWenDu);
            }
        }

        private string _bianJieTiaoJianFileLocation = Path.Combine(ScriptWrapperForHengNiuJu.ResultsDirectory, "bianjie_3d_input.txt");
        public string BianJieTiaoJianFileLocation
        {
            get
            {
                return _bianJieTiaoJianFileLocation;
            }
            set
            {
                SetValueProperty(value, ref _bianJieTiaoJianFileLocation);
            }
        }
        #endregion

        public ICommand BianJieTiaoJianFileBrowseButtonClick
        {
            get
            {
                return new DelegateCommand<object>((o) =>
                {
                    string localFolder;
                    System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
                    dialog.Title = "出口边界条件结果位置";
                    dialog.InitialDirectory = Path.GetDirectoryName(this.BianJieTiaoJianFileLocation);
                    System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        localFolder = dialog.FileName;
                    }
                    else
                    {
                        return;
                    }

                    this.BianJieTiaoJianFileLocation = localFolder;
                });
            }
        }

        private string _oilFilesLocation = null;
        public ICommand ConfirmButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    this._oilFilesLocation = ScriptWrapperForHengNiuJu.SourceOilFilesFolderPath;
                    if (!File.Exists(Path.Combine(this._oilFilesLocation, ScriptWrapperForHengNiuJu.DensityFileName)) ||
                        !File.Exists(Path.Combine(this._oilFilesLocation, ScriptWrapperForHengNiuJu.ViscosityFileName)) ||
                        !File.Exists(Path.Combine(this._oilFilesLocation, ScriptWrapperForHengNiuJu.HeatConductivityFileName)) ||
                        !File.Exists(Path.Combine(this._oilFilesLocation, ScriptWrapperForHengNiuJu.HeatCapacityFileName)))
                    {
                        MessageBox.Show("关键油文件缺失");
                        return;
                    }

                    CommonUtils.CopyFolder(this._oilFilesLocation, ScriptWrapperForHengNiuJu.WorkDirectory);

                    if (!File.Exists(this.BianJieTiaoJianFileLocation))
                    {
                        MessageBox.Show("出口边界条件文件不存在");
                        return;
                    }

                    ScriptWrapperForHengNiuJu.OneDimThreeDimFileName = Path.GetFileName(this.BianJieTiaoJianFileLocation);
                    File.Copy(this.BianJieTiaoJianFileLocation, Path.Combine(ScriptWrapperForHengNiuJu.WorkDirectory, ScriptWrapperForHengNiuJu.OneDimThreeDimFileName), true);
                    ScriptWrapperForHengNiuJu.ImportedOilFiles = string.Format(ScriptTemplateForHengNiuJu.ImportedOilFiles, ScriptWrapperForHengNiuJu.OneDimThreeDimFileName);

                    // {0} -- 空气粘度 {1} -- 空气比热容 {2} -- 空气热导率
                    ScriptWrapperForHengNiuJu.WuZhiDingYi = string.Format(ScriptTemplateForHengNiuJu.WuZhiDingYi, this.NianDuOfAir, this.BiReRongOfAir, this.ReDaoLvOfAir);

                    double dongLunChuShiZhuanSu = Math.Round(double.Parse(this.DongLunChuShiZhuanSu) * Math.PI / 30, 5);
                    double chongYouJinKou = double.Parse(this.JinKouYaLi) * 1000000;
                    double tongQiKong = double.Parse(this.TongQiKongYaLi) * 1000000;

                    // {0} -- 动轮转速 {1} -- 动轮转动惯量 {2} -- 进口压力 {3} -- 进口温度 
                    ScriptWrapperForHengNiuJu.BianJieTiaoJianDingYi = string.Format(ScriptTemplateForHengNiuJu.BianJieTiaoJianDingYi, this.DongLunChuShiZhuanSu, this.DongLunZhuanDongGuanLiang,
                        this.JinKouYaLi, this.JinKouWenDu);

                    MessageBox.Show("设置成功", "恒扭矩计算参数输入");
                });
            }
        }
    }
}
