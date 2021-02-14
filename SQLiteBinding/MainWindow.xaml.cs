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

    private void CreateDataSample()
    {
      ToDo todo = new ToDo()
      {
        Title = "잠자기",
        Content = "내용이다",
        PublishedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
        DeadLine = new DateTime(2021, 02, 14).ToString("yyyy-MM-dd HH:mm:ss"),
      };
      DataHandler.DB.CreateData(todo);
      todo = new ToDo()
      {
        Title = "메이플하기",
        PublishedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
      };
      DataHandler.DB.CreateData(todo);
      todo = new ToDo()
      {
        Title = "아무것도 안하기",
        PublishedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
        DeadLine = new DateTime(2021, 02, 13).ToString("yyyy-MM-dd HH:mm:ss"),
      };
      DataHandler.DB.CreateData(todo);
      todo = new ToDo()
      {
        Title = "하하하하하",
        Content = "내용내용",
        PublishedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
      };
      DataHandler.DB.CreateData(todo);
    }
    private void ReadData()
    {
      var datas = DataHandler.DB.ReadAll();
      foreach (DataRow row in datas.Rows)
      {
        MessageBox.Show(row["DeadLine"].ToString());
      }
    }
    private void UpdateData()
    {
      ToDo todo = new ToDo()
      {
        Id = 2,
        Title = "수정하기",
        Content = "내용수정수정",
        PublishedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
        DeadLine = new DateTime(2021, 02, 23).ToString("yyyy-MM-dd HH:mm:ss"),
      };
      DataHandler.DB.UpdateData(todo);
    }
    private void DeleteData()
    {
      ToDo todo = new ToDo()
      {
        Id = 2
      };
      DataHandler.DB.DeleteData(todo);
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
      DeleteData();
    }
  }
}
