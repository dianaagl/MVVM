
using System.Windows;

namespace Project_One_MVVM
{
   
    public partial class App : Application
    {
        public const int  ADMIN = 0;
        public const int EMPLOYEE = 1;
        private int user = -1;
        public int User
        {
            get { return user; }
            set { user = value; }
        }
    }
}