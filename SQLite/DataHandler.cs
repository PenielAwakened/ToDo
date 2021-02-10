using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SQLite;

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
    private static void ExecuteQueryString(SQLiteConnection conn, string sql)
    {
      var cmd = new SQLiteCommand(sql, conn);
      cmd.ExecuteNonQuery();
    }
    private DataHandler()
    {
      DBPath = DB_PATH;
      SQLiteConnection.CreateFile(DBPath);
      var conn = new SQLiteConnection($"Data Source={DBPath};");
      conn.Open();

      string sql = "create table ToDo " +
        "(Id integer primary key autoincrement, Title varchar(50) not null, " +
        "PublishedDate datetime not null, DeadLine datetime null, IsCompleted boolean not null)";
      ExecuteQueryString(conn, sql);

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
    public void CreateData(ToDo toDo)
    {
      var conn = new SQLiteConnection($"Data Source={DBPath};");
      conn.Open();
      string sql = "insert into ToDo (Title, PublishedDate, DeadLine, IsCompleted) " +
        $"values ('{toDo.Title}', '{toDo.PublishedDate}', '{toDo.DeadLine}', false)";

      ExecuteQueryString(conn, sql);
      conn.Close();
    }
  }
}
