using SQLite;
using System;
using System.Data;
using System.Windows;

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
      //ToDo todo = new ToDo()
      //{
      //  Title = "잠자기",
      //  Content = "내용이다",
      //  PublishedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
      //  DeadLine = new DateTime(2021, 02, 14).ToString("yyyy-MM-dd HH:mm:ss"),
      //};
      //DataHandler.DB.CreateData(todo);
      //todo = new ToDo()
      //{
      //  Title = "메이플하기",
      //  PublishedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
      //};
      //DataHandler.DB.CreateData(todo);
      //todo = new ToDo()
      //{
      //  Title = "아무것도 안하기",
      //  PublishedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
      //  DeadLine = new DateTime(2021, 02, 13).ToString("yyyy-MM-dd HH:mm:ss"),
      //};
      //DataHandler.DB.CreateData(todo);
      //todo = new ToDo()
      //{
      //  Title = "하하하하하",
      //  Content = "내용내용",
      //  PublishedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
      //};
      //DataHandler.DB.CreateData(todo);

      //데이터 읽기
      var datas = DataHandler.DB.ReadAll();
      foreach (DataRow row in datas.Rows)
      {
        MessageBox.Show(row["DeadLine"].ToString());
      }


    }
  }
}
