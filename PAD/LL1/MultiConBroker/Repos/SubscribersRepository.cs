namespace MultiConBroker;

public static class SubscribersRepository
{
    private static object locker;
    private static List<Subscriber> subscribers;

    static SubscribersRepository()
	{
        subscribers = new();
        locker = new();
	}

    public static void Add(Subscriber subscriber)
    {
        lock (locker)
        {
            subscribers.Add(subscriber);
        }
    }

    public static void Remove(string address)
    {
        lock (locker)
        {
            subscribers.RemoveAll(x => x.Address == address);
        }
    }

    public static List<Subscriber> GetSubscribersByTopic(string topic)
    {
        List<Subscriber> foundSubscribers = new();

        lock (locker)
        {
            foundSubscribers = subscribers.Where(x => x.Topic.ToLower() == topic.ToLower()).ToList();
        }

        return foundSubscribers;
    }

    public static List<Subscriber> GetAllSubscribers()
    {
        List<Subscriber> foundSubscribers = new();

        lock (locker)
        {
            foundSubscribers = subscribers.Where(x => x.Topic != null).ToList();
        }

        return foundSubscribers;
    }
}