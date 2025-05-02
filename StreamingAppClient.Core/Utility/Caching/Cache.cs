using StreamingAppClient.Core.Utility.Caching.Data;
using StreamingAppClient.Core.Utility.Caching.Interface;

namespace StreamingAppClient.Core.Utility.Caching;

public class Cache : ICache
{
    private readonly CacheData _CacheData;

    public Cache(CacheData CacheData)
    {
        _CacheData = CacheData;
    }

    public void AddWindowHandle(nint windowHandle)
    {
        _CacheData.WindowHandle = windowHandle;
    }

    public nint GetWindowHandle()
    {
        return _CacheData.WindowHandle;
    }
}
