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
    public class ShuXueKongSunJiSuanJieGuoShuChuViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public ShuXueKongSunJiSuanJieGuoShuChuViewModel()
        {
        }

        public ViewType Type
        {
            get
            {
                return ViewType.ShuXueKongSunJiSuanJieGuoShuChu;
            }
        }

        private string _kongSunGongLv = "11,700";
        public string KongSunGongLv
        {
            get
            {
                return _kongSunGongLv;
            }
            set
            {
                SetValueProperty(value, ref _kongSunGongLv);
            }
        }

        private string _locationString = "D:\\380流场计算\\空损几何模型\\kongsun_integrals.txt";
        public string LocationString
        {
            get
            {
                return _locationString;
            }
            set
            {
                SetValueProperty(value, ref _locationString);
            }
        }

        public ICommand BrowseButtonClick
        {
            get
            {
                return new DelegateCommand<object>((o) =>
                {
                    string localFolder;
                    System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
                    dialog.Title = "计算结果位置";
                    System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        localFolder = dialog.FileName;
                    }
                    else
                    {
                        return;
                    }

                    this.LocationString = localFolder;
                });
            }
        }

        public ICommand ImportButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    if (File.Exists(this.LocationString))
                    {
                        using (StreamReader sr = new StreamReader(this.LocationString))
                        {
                            string[] resultTitles = sr.ReadLine().Split('\t');
                            int index = resultTitles.ToList().IndexOf(ScriptWrapperForKongSun.KongSunGongLvResultTitle);
                            if (index != -1)
                            {
                                string st = string.Empty;
                                while (!sr.EndOfStream)
                                {
                                    st = sr.ReadLine();
                                }

                                this.KongSunGongLv = st.Split('\t')[index];
                            }
                            else
                            {
                                MessageBox.Show(string.Format("结果文件内容格式不正确，找不到列名为{0}的项", ScriptWrapperForKongSun.KongSunGongLvResultTitle));
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("结果文件不存在");
                    }
                });
            }
        }

        public ICommand QuXianAndYunTuImportButtonClick
        {
            get
            {
                return new TaskCommand<object>((o) =>
                {
                    StartOtherProcessHelper.StartPumpLinx(null);
                });
            }
        }
    }
}
