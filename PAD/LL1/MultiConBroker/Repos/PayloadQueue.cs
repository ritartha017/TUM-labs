using System.Collections.Concurrent;
using Common.Data;

namespace MultiConBroker.Repos;

static class PayloadQueue
{
	private static ConcurrentQueue<Payload> payloads;

	static bool IsEmpty { get => payloads.IsEmpty; }

	static PayloadQueue()
	{
		payloads = new();
	}

	public static void Add(Payload payload)
	{
		payloads.Enqueue(payload);
	}

	public static Payload GetNext()
	{
        payloads.TryDequeue(out Payload payload);
        return payload;
	}
}