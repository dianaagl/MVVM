using Project_One_MVVM.Model;
using Project_One_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project_One_MVVM.View
{
    /// <summary>
    /// Interaction logic for EmployeeCreateView.xaml
    /// </summary>
    public partial class InvoiceCreateView : Window
    {
        public InvoiceCreateView()
        {
            InitializeComponent();
            DataContext = new InvoiceCreateViewModel(this);
        }
    }
}
