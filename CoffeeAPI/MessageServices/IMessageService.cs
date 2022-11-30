namespace CoffeeAPI.MessageServices
{
    public interface IMessageService
    {
        bool Enqueue(string message);
    }
}
