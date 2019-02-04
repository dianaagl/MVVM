using Project_One_MVVM.Utilities;
using Project_One_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project_One_MVVM.Command
{
    class ReadCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;
        public event EventHandler CanExecuteChanged;
    

        public ReadCommand( Action<object> execute,UserControlPanelViewModel model = null, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
       
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
