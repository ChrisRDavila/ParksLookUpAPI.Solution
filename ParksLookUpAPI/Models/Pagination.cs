namespace ParksLookUpAPI.Models
{
  public class Pagination
  {
    public List<Park> Parks { get; set; }
    public int PageItems { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
  }
}