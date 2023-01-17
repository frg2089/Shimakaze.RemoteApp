using Microsoft.Win32;

namespace Shimakaze.RemoteApp.Kernel;

public sealed record RemoteApp(
    string Name,
    string FullName,
    string Path,
    string VPath = "",
    string CommandLine = "",
    string CommandLineOption = "1",
    string IconPath = "",
    int IconIndex = 0,
    int TSWA = 0,
    FileTypeAssociation[]? FileTypeAssociations = default
)
{
    public string Name { get; set; } = Name;

    public static RemoteApp LoadFrom(RegistryKey key)
    {
        using var filetypes = key.OpenSubKey("Filetypes");
        return new RemoteApp(
            System.IO.Path.GetFileName(key.Name),
            key.GetValue<string>("Name", string.Empty),
            key.GetValue<string>("Path", string.Empty),
            key.GetValue<string>("VPath", string.Empty),
            key.GetValue<string>("RequiredCommandLine", string.Empty),
            key.GetValue<string>("CommandLineSetting", "1"),
            key.GetValue<string>("IconPath", string.Empty),
            key.GetValue<int>("IconIndex", 0),
            key.GetValue<int>("ShowInTSWA", 0),
            filetypes?.GetValueNames().Select(j =>
            {
                var tmp = filetypes.GetValue<string>(j, ",").Split(',');
                return new FileTypeAssociation(j, tmp[0], tmp[1]);
            }).ToArray()
        );
    }

    public void SaveTo(RegistryKey applications)
    {
        var key = applications.CreateSubKey(Name, true);

        key.SetValue("Name", FullName, RegistryValueKind.String);

        key.SetValue("Path", Path, RegistryValueKind.String);
        key.SetValue("VPath", VPath, RegistryValueKind.String);
        key.SetValue("RequiredCommandLine", CommandLine, RegistryValueKind.String);
        key.SetValue("CommandLineSetting", CommandLineOption, RegistryValueKind.DWord);
        key.SetValue("IconPath", IconPath, RegistryValueKind.String);
        key.SetValue("IconIndex", IconIndex, RegistryValueKind.DWord);
        key.SetValue("ShowInTSWA", TSWA, RegistryValueKind.DWord);
    }
}
