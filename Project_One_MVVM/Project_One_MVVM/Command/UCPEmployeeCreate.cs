using Project_One_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Project_One_MVVM.Command
{
    class UCPEmployeeCreate : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public UserControlPanelViewModel userControlPanelViewModel;

        public UCPEmployeeCreate(UserControlPanelViewModel model)
        {
            userControlPanelViewModel = model;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("Hello world!");
        }
    }
}
