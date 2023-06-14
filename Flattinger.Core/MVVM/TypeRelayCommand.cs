using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Flattinger.Core.MVVM
{
    public class TypeRelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;

        public TypeRelayCommand(Action<T> execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

#pragma warning disable CS0067 // Das Ereignis "TypeRelayCommand<T>.CanExecuteChanged" wird nie verwendet.
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS0067 // Das Ereignis "TypeRelayCommand<T>.CanExecuteChanged" wird nie verwendet.
    }
}
