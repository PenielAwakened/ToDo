using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDoFront
{
    /// <summary>
    /// Interaction logic for ToDoDetail.xaml
    /// </summary>
    public partial class ToDoDetail : Page
    {
        public ToDoDetail()
        {
            InitializeComponent();
        }

        private void Cancel_Btn(object sender, RoutedEventArgs e)
        {
            ToDoHome toDoHome = new ToDoHome();
            this.NavigationService.Navigate(toDoHome);
        }
    }
}
