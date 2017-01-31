namespace domain.Model
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}