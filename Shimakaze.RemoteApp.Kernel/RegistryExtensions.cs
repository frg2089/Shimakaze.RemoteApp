using Microsoft.Win32;

namespace Shimakaze.RemoteApp.Kernel;

internal static class RegistryExtensions
{
    public static T GetValue<T>(this RegistryKey key, string name, T defaultValue) => key.GetValue(name, defaultValue) switch
    {
        T t => t,
        _ => defaultValue
    };
}
