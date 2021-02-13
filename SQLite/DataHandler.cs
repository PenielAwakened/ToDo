using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace SQLite
{
  public class DataHandler
  {
    private readonly static string DB_PATH = "ToDo.sqlite";
    public string DBPath { get; set; }
    private static DataHandler db;
    public static DataHandler DB
    {
      get
      {
        if (db == null)
        {
          if (File.Exists(DB_PATH))
          {
            db = new DataHandler(DB_PATH);
          }
          else
          {
            db = new DataHandler();
          }
        }
        return db;
      }
    }
    private void ExecuteQueryString(string sql)
    {
      var conn = new SQLiteConnection($"Data Source={DBPath};");
      conn.Open();

      var cmd = new SQLiteCommand(sql, conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
    private DataHandler()
    {
      DBPath = DB_PATH;
      SQLiteConnection.CreateFile(DBPath);
      var conn = new SQLiteConnection($"Data Source={DBPath};");
      conn.Open();

      string sql = "create table ToDo " +
        "(Id integer primary key autoincrement, Title varchar(50) not null, Content text null, " +
        "PublishedDate text not null, DeadLine text null, IsCompleted boolean not null)";
      ExecuteQueryString(sql);

      conn.Close();
    }
    private DataHandler(string dbPath)
    {
      DBPath = dbPath;
    }

    public List<object> GetDataByColumnName(string columnName)
    {
      var result = new List<object>();
      var conn = new SQLiteConnection($"Data Source={this.DBPath};");
      conn.Open();

      string sql = $"select {columnName} from ToDo";
      var cmd = new SQLiteCommand(sql, conn);
      SQLiteDataReader rdr = cmd.ExecuteReader();

      while (rdr.Read())
      {
        if (rdr[columnName].GetType() == typeof(DateTime))
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
    public void CreateData(ToDo toDo)
    {
      var conn = new SQLiteConnection($"Data Source={DBPath};");
      conn.Open();
      string sql = "insert into ToDo (Title, Content, PublishedDate, DeadLine, IsCompleted) " +
        $"values ('{toDo.Title}', '{toDo.Content}', '{toDo.PublishedDate}', '{toDo.DeadLine}', false)";

      ExecuteQueryString(sql);
      conn.Close();
    }
    public DataTable ReadAll()
    {
      string connStr = $"Data Source={DBPath}";

      DataTable dt = new DataTable();
      using (var conn = new SQLiteConnection(connStr))
      {
        conn.Open();
        string sql = "SELECT * FROM ToDo";

        SQLiteCommand cmd = new SQLiteCommand(sql, conn);
        SQLiteDataReader rdr = cmd.ExecuteReader();
        dt.Load(rdr);
        rdr.Close();
      }
      return dt;
    }
    public void UpdateData(ToDo toDo)
    {
      var conn = new SQLiteConnection($"Data Source={DBPath};");
      conn.Open();
      string sql = $"UPDATE ToDo SET " +
        $"Title = '{toDo.Title}', Content = '{toDo.Content}', " +
        $"DeadLine = '{toDo.DeadLine}', IsCompleted = {toDo.IsCompleted} " +
        $"WHERE Id = {toDo.Id}";

      ExecuteQueryString(sql);
      conn.Close();

    }
  }
}
