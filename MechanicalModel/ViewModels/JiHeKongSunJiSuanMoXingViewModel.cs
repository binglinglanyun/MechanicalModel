﻿using MechanicalModel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.IO;
using MechanicalModel.Scripts;

namespace MechanicalModel.ViewModels
{
    public class JiHeKongSunJiSuanMoXingViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public JiHeKongSunJiSuanMoXingViewModel()
        {
            InitializeItems();
        }

        public ViewType Type
        {
            get
            {
                return ViewType.JiHeKongSunJiSuanMoXing;
            }
        }

        private void InitializeItems()
        {
            List<DataItem> items = new List<DataItem>();
            items.Add(new DataItem("动轮", true));
            items.Add(new DataItem("定轮", true));
            items.Add(new DataItem("壳体", true));
            items.Add(new DataItem("其他", true));

            this.Items = items;
        }

        #region Button Click
        public ICommand BrowseButtonClick
        {
            get
            {
                return new DelegateCommand<object>((o) =>
                {
                    string localFolder;
                    System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
                    dialog.Title = "模型位置";
                    dialog.DefaultExt = ".stl";
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
                        try
                        {
                            string filename = Path.GetFileName(this.LocationString);
                            ScriptWrapperForKongSun.ImportScript = string.Format(ScriptTemplateForKongSun.ImportScript, filename);
                            string destScriptPath = Path.Combine(ConstantValues.CurrentWorkDirectory, filename);
                            if (File.Exists(destScriptPath))
                            {
                                File.Delete(destScriptPath);
                            }

                            File.Copy(this.LocationString, destScriptPath);
                            MessageBox.Show("模型导入成功");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("模型导入失败，错误信息：{0}", ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("模型文件不存在");
                    }
                });
            }
        }
        #endregion

        #region Properties
        private string _locationString = "D:\\380流场计算\\几何模型";
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

        private List<DataItem> _items = null;
        public List<DataItem> Items
        {
            get
            {
                return _items;
            }
            set
            {
                SetClassProperty(value, ref _items);
            }
        }

        public string SourceUri
        {
            get
            {
                return Path.GetFullPath("Resources/KongSunJiHeMoXing.png"); ;
            }
        }
        #endregion
    }
}
