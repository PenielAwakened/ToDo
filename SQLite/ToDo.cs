namespace SQLite
{
  public class ToDo
  {
    public uint Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string PublishedDate { get; set; }
    public string DeadLine { get; set; }
    public bool IsCompleted { get; set; }
  }
}
