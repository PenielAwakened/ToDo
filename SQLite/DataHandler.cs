using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SQLite;

namespace SQLite
{
  public class DataHandler
  {
    private readonly string FILE_PATH = "ToDo.sqlite";
    public string FilePath { get; set; }
    private DataHandler db;
    public DataHandler DB
    {
      get
      {
        if (File.Exists(FILE_PATH))
        {
          db = new DataHandler(FILE_PATH);
        }
        else
        {
          db = new DataHandler();
        }
        return db;
      }
    }
    private static void ExecuteQueryString(SQLiteConnection conn, string sql)
    {
      var cmd = new SQLiteCommand(sql, conn);
      cmd.ExecuteNonQuery();
    }
    private DataHandler()
    {
      SQLiteConnection.CreateFile(FILE_PATH);
      var conn = new SQLiteConnection($"Data Source={FILE_PATH};");
      conn.Open();

      string sql = "create table ToDo " +
        "(Id integer primary key autoincrement, Tltle varchar(50), " +
        "PublishedDate datetime, DeadLine datetime, IsCompleted boolean)";
      ExecuteQueryString(conn, sql);

      conn.Close();
    }
    private DataHandler(string filePath)
    {
      FilePath = filePath;
    }
    public string DBPath { get; set; }

    public List<object> GetDataFromColumn(string columnName)
    {
      var result = new List<object>();
      var conn = new SQLiteConnection($"Data Source={this.DBPath};");
      conn.Open();

      string sql = $"select {columnName} from ToDo";
      var cmd = new SQLiteCommand(sql, conn);
      SQLiteDataReader rdr = cmd.ExecuteReader();

      while (rdr.Read())
      {
        if(rdr[columnName].GetType() == typeof(DateTime))
        {
          result.Add(rdr[columnName]);
        }
        else
        {
          result.Add(rdr[columnName].ToString());
        }
      }
      rdr.Close();
      conn.Close();

      return result;
    }
  }
}
