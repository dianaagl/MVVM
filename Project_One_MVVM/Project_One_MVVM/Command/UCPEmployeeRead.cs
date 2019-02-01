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
    class UCPEmployeeRead : ICommand
    {
        public event EventHandler CanExecuteChanged;
        UserControlPanelViewModel userControlPanel;

        public UCPEmployeeRead(UserControlPanelViewModel model)
        {
            userControlPanel = model;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            userControlPanel.ReadEmployee();
        }
    }
}
