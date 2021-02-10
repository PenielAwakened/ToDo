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
    /// Interaction logic for ToDoHome.xaml
    /// </summary>
    public partial class ToDoHome : Page
    {
        public ToDoHome()
        {
            InitializeComponent();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            ToDoDetail toDoDetail = new ToDoDetail();
            this.NavigationService.Navigate(toDoDetail);
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
