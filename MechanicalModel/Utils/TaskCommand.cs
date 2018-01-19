using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MechanicalModel.Utils
{
    public class TaskCommand<T> : ICommand where T : class
    {
        private Action<T> _action;
        private EventWaitHandle _waitHandle = new EventWaitHandle(false, EventResetMode.ManualReset);

        public TaskCommand(Action<T> action)
        {
            _action = (o) =>
            {
                action(o);
                _waitHandle.Set();
            };

            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }


        public void Execute(object parameter)
        {
            Task.Run(() => _action(parameter as T));
        }

        public bool Wait(int millisecondsTimeout)
        {
            return _waitHandle.WaitOne(millisecondsTimeout);
        }

        public event EventHandler CanExecuteChanged;
    }

    public class TaskCommand : TaskCommand<object>
    {
        public TaskCommand(Action action)
            : base((o) => action())
        {
        }
    }
}
