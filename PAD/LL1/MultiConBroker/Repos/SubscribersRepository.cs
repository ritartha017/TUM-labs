namespace MultiConBroker;

public class SubscribersRepository
{
    private static object locker;
    private static List<Subscriber> subscribers;

    public SubscribersRepository()
	{
        subscribers = new();
        locker = new();
	}

    public static void Add(Subscriber subscriber)
    {
        lock(locker)
        {
            subscribers.Add(subscriber);
        }
    }

    public static void Remove(string address)
    {
        lock(locker)
        {
            subscribers.RemoveAll(x => x.Address == address);
        }
    }

    public static List<Subscriber> GetSubscribersByTopic(string topic)
    {
        List<Subscriber> foundSubscribers = new();

        lock(locker)
        {
            subscribers = subscribers.Where(x => x.Topic == topic).ToList();
        }

        return foundSubscribers;
    }
}