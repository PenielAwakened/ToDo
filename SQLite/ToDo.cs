using System;

namespace SQLite
{
  public class ToDo
  {
    public uint Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime PublishedDate { get; set; }
    public DateTime? DeadLine { get; set; }
    public bool IsCompleted { get; set; }
  }
}
