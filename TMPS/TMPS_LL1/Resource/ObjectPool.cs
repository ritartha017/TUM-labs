using System.Collections.Generic;

class ObjectPool
{
    private List<Resource> resources;

    static ObjectPool instance;
    public ObjectPool() { }

    /**
    * Static method for accessing class instance.
    * Part of Singleton design pattern.
    *
    * @return ObjectPool instance.
    */
    public static ObjectPool GetInstance()
    {
        if (instance == null)
        {
            instance = new ObjectPool();
        }
        return instance;
    }

    /**
     * Returns instance of Resource.
     *
     * New resource will be created if all the resources
     * were used at the time of the request.
     *
     * @return Resource instance.
     */
    public Resource GetResource()
    {
        if (!resources.Any())
        {
            Console.WriteLine("Creating new resource.\n");
            return new Resource();
        }
        else
        {
            Console.WriteLine("Reusing existing resource.\n");
            Resource resource = resources.front();
            resources.pop_front();
            return resource;
        }
    }

    /**
     * Return resource back to the pool.
     *
     * The resource must be initialized back to
     * the default settings before someone else
     * attempts to use it.
     *
     * @param object Resource instance.
     * @return void
     */
    void ReturnResource(object Resource)
    {
        object->reset();
        resources.push_back(object);
    }
};