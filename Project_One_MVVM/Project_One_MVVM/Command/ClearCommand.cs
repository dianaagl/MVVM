using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Project_One_MVVM.ViewModel;

namespace Project_One_MVVM.Commands
{
    internal class ClearCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        LoginViewModel employeeViewModel;

        public ClearCommand(LoginViewModel employeeViewModel)
        {
            this.employeeViewModel = employeeViewModel;

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            employeeViewModel.Clear();
        }
    }
}