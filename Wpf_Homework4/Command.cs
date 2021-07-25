using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wpf_Homework4
{
    class Command : ICommand
    {
        private Action<object> exec;
        private Func<bool> canExec;

        public event EventHandler CanExecuteChanged;


        public Command(Action<object> exec, Func<bool> canExec)
        {
            this.exec = exec;
            this.canExec = canExec;
        }

        public Command(Action<object> exec)
        {
            this.exec = exec;
            canExec = () => true;
        }


        public bool CanExecute(object parameter)
        {
            return canExec();
        }

        public void Execute(object parameter)
        {
            exec(parameter);
        }
    }
}
