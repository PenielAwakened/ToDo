using System;

namespace SQLite
{
  public class ToDo
  {
    private string _content;
    private string _deadLine;
    public uint Id { get; set; }
    public string Title { get; set; }
    public string Content
    {
      get
      {
        if (_content == null)
        {
          return "null";
        }
        else
        {
          return "'" + _content + "'";
        }
      }
      set
      {
        _content = value;
      }
    }
    public string PublishedDate { get; set; }
    public string DeadLine
    {
      get
      {
        if (_deadLine == null)
        {
          return "''";//"null";
        }
        else
        {
          return "'" + _deadLine + "'";
        }
      }
      set
      {
        _deadLine = value;
      }
    }
    public bool IsCompleted { get; set; }
  }
}
