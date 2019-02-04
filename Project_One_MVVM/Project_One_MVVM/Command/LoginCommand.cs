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
    internal class LoginCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public LoginViewModel employeeViewModel;

        public LoginCommand(LoginViewModel model)
        {
            employeeViewModel = model;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            employeeViewModel.Login();
        }


    }
}