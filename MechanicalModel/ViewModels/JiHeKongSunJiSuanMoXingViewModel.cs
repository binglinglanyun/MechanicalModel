using MechanicalModel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace MechanicalModel.ViewModels
{
    public class JiHeKongSunJiSuanMoXingViewModel : PropertyChangedBaseCommonClass, IViewModelCategory
    {
        public JiHeKongSunJiSuanMoXingViewModel()
        {
            InitializeItems();
        }

        private void InitializeItems()
        {
            List<DataItem> items = new List<DataItem>();
            items.Add(new DataItem("动轮", false));
            items.Add(new DataItem("定轮", false));
            items.Add(new DataItem("壳体", false));
            items.Add(new DataItem("其他", false));

            this.Items = items;
        }

        public ICommand BrowseButtonClick
        {
            get
            {
                return new DelegateCommand<object>((o) =>
                {
                    string localFolder;
                    System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
                    dialog.Description = "模型位置";
                    System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        localFolder = dialog.SelectedPath;
                    }
                    else
                    {
                        return;
                    }

                    this.LocationString = localFolder;
                });
            }
        }

        private string _locationString = null;
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

        public ViewType Type
        {
            get
            {
                return ViewType.JiHeKongSunJiSuanMoXing;
            }
        }
    }
}
