using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalModel.ViewModels
{
    [Serializable]
    public abstract class PropertyChangedBaseCommonClass : INotifyPropertyChanged
    {
        /// <summary>
        /// Notify property changed with [CallerMemberName]
        /// </summary>
        /// <param name="propertyName"></param>
        protected void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary/>
        [NonSerialized]
        private PropertyChangedEventHandler _propertyChanged;

        public event PropertyChangedEventHandler PropertyChanged
        {
            add { _propertyChanged += value; }
            remove { _propertyChanged -= value; }
        }

        public void ResetPropertyChanged()
        {
            _propertyChanged = delegate { };
        }

        /// <summary>
        /// Clone the property handler of existing instance
        /// </summary>
        /// <param name="fromInstance"></param>
        protected void ClonePropertyChanged(PropertyChangedBaseCommonClass fromInstance)
        {
            _propertyChanged = fromInstance._propertyChanged;
        }

        /// <summary>
        /// Set reference
        /// </summary>
        /// <summary>
        /// Set and notify only when the value changes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="newValue"></param>
        /// <param name="currentValue"></param>
        /// <param name="propertyName">don't set for normal usage</param>
        protected void SetClassProperty<T>(T newValue, ref T currentValue, [CallerMemberName]string propertyName = null) where T : class
        {
            if (currentValue == newValue)
            {
                return;
            }

            Debug.Assert(propertyName != null, "SetProperty [CallerMemberName] propertyName == null");
            currentValue = newValue;
            NotifyPropertyChanged(propertyName);
        }

        /// <summary>
        /// Set and notify only when the value changes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="newValue"></param>
        /// <param name="currentValue"></param>
        /// <param name="propertyName">don't set for normal usage</param>
        protected void SetValueProperty<T>(T newValue, ref T currentValue, [CallerMemberName]string propertyName = null)
        {
            if (currentValue != null && currentValue.Equals(newValue)
                || currentValue == null && newValue == null)
            {
                return;
            }

            Debug.Assert(propertyName != null, "SetProperty [CallerMemberName] propertyName == null");
            currentValue = newValue;
            NotifyPropertyChanged(propertyName);
        }

        /// <summary>
        /// Set and notify regardless if the value changes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="newValue"></param>
        /// <param name="currentValue"></param>
        /// <param name="propertyName">don't set for normal usage</param>
        protected void SetPropertyAndNotifyWithoutCheck<T>(T newValue, ref T currentValue, [CallerMemberName]string propertyName = null)
        {
            Debug.Assert(propertyName != null, "SetProperty [CallerMemberName] propertyName == null");
            currentValue = newValue;
            NotifyPropertyChanged(propertyName);
        }

        /// <summary>
        /// Set value of a string property with specific comparison type 
        /// </summary>
        /// <summary>
        /// Set and notify only when the value changes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="newValue"></param>
        /// <param name="currentValue"></param>
        /// <param name="propertyName">don't set for normal usage</param>
        protected void SetStringProperty(string newValue, ref string currentValue, StringComparison compareType, [CallerMemberName]string propertyName = null)
        {
            if (String.Equals(currentValue, newValue, compareType))
            {
                return;
            }

            Debug.Assert(propertyName != null, "SetProperty [CallerMemberName] propertyName == null");
            currentValue = newValue;
            NotifyPropertyChanged(propertyName);
        }

        // NOTE: Important !!!
        // You need strong reason to call this method.
        // should only be called by the instance's owner.  
        public virtual void ResetEventHandler()
        {
            _propertyChanged = null;
        }
    }
}
