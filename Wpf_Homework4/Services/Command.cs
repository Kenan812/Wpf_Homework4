using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wpf_Homework4.Services
{
    abstract class Command : ICommand
    {


        public event EventHandler CanExecuteChanged;

        
        
        // Execution Check

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        public virtual bool CanExecute()
        {
            return true;
        }



        // Execution

        void ICommand.Execute(object parameter)
        {
            Execute(parameter);
        }

        public abstract void Execute(object parameter);



        // When canExecute changes

        public virtual void OnCanExecuteChanged(EventArgs e)
        {
            CanExecuteChanged.Invoke(this, e);
        }

        public void RiseCanExecuteChanged()
        {
            OnCanExecuteChanged(EventArgs.Empty);
        }
    }


    class DelegateCommand : Command
    {
        static Func<bool> defaultCanExec = () => true;
        private Func<bool> canExec;
        private Action<object> exec;


        public DelegateCommand(Action<object> executeMethod) : this(executeMethod, defaultCanExec) { }

        public DelegateCommand(Action<object> executeMethod, Func<bool> canExecMethod)
        {
            exec = executeMethod;
            canExec = canExecMethod;
        }


        public override bool CanExecute()
        {
            return canExec();
        }

        public override void Execute(object parameter)
        {
            exec(parameter);
        }
    }
}
