using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalModel.ViewModels
{
    public class DataItem : PropertyChangedBaseCommonClass
    {
        public DataItem(string name, bool isEnable)
        {
            this.Name = name;
            this.IsEnabled = isEnable;
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                SetValueProperty(value, ref _name);
            }
        }

        private bool _isEnabled;
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                SetValueProperty(value, ref _isEnabled);
            }
        }
    }
}
