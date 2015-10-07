namespace WebServer.Infrastructure
{
    public interface IAggregate<out T>
    {
        IIterator<T> GetIterator();
    }
}
