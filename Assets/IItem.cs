public interface IItem
{
    public int Id { get; }
    public bool IsSingleItem { get; }
    public int Count { get; set; }
    public int MaxCount { get; }
}