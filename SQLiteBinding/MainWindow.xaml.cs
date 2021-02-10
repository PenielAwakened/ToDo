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
using SQLite;
using System.Data.SQLite;

namespace SQLiteBinding
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      //데이터 추가 예제
      //ToDo todo1 = new ToDo()
      //{
      //  Title = "잠자기",
      //  PublishedDate = DateTime.Now,
      //  DeadLine = new DateTime(2021, 02, 14),
      //};
      //DataHandler.DB.CreateData(todo1);
    }
  }
}
