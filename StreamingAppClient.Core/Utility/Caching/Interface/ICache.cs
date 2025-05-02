namespace StreamingAppClient.Core.Utility.Caching.Interface;

public interface ICache
{
    void AddWindowHandle(nint windowHandle);
    nint GetWindowHandle();
}