using System.Collections;

using Microsoft.Win32;

namespace Shimakaze.RemoteApp.Kernel;


public sealed class RemoteApps : IDisposable
{
    // ***
    const string RegistryCurrentVersion = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
    const string RegistryTerminalServer = "Terminal Server";
    const string RegistryTSAppAllowList = "TSAppAllowList";
    const string RegistryApplications = "Applications";
    // ***
    const string RegistryfDisableAllowList = "fDisableAllowList";
    // ***
    const string RegistryPolicyMicrosoft = @"SOFTWARE\Policies\Microsoft";
    const string RegistryPolicyWindowsNT = @"Windows NT";
    const string RegistryPolicyTerminalServer = @"Terminal Services";
    // ***
    const string RegistryMaxDisconnectionTime = "MaxDisconnectionTime";
    const string RegistryMaxIdleTime = "MaxIdleTime";
    const string RegistryfResetBroken = "fResetBroken";
    const string RegistryfAllowUnlistedRemotePrograms = "fAllowUnlistedRemotePrograms";

    RegistryKey CurrentVersion;
    RegistryKey TerminalServer;
    RegistryKey TSAppAllowList;
    RegistryKey Applications;
    RegistryKey PolicyMicrosoft;
    RegistryKey PolicyWindowsNT;
    RegistryKey PolicyTerminalServer;

    private bool _disposedValue;


    public bool DisableAppAllowList
    {
        get => TSAppAllowList.GetValue<int>(RegistryfDisableAllowList, 0) is 1;
        set => TSAppAllowList.SetValue(RegistryfDisableAllowList, value ? 1 : 0, RegistryValueKind.DWord);
    }

    public bool ResetBroken
    {
        get => PolicyTerminalServer.GetValue<int>(RegistryfResetBroken, 0) is 1;
        set => PolicyTerminalServer.SetValue(RegistryfResetBroken, value ? 1 : 0, RegistryValueKind.DWord);
    }

    public bool AllowUnlistedRemotePrograms
    {
        get => PolicyTerminalServer.GetValue<int>(RegistryfAllowUnlistedRemotePrograms, 0) is 1;
        set => PolicyTerminalServer.SetValue(RegistryfAllowUnlistedRemotePrograms, value ? 1 : 0, RegistryValueKind.DWord);
    }

    public int? MaxDisconnectionTime
    {
        get => PolicyTerminalServer.GetValue<int?>(RegistryMaxDisconnectionTime, null);
        set
        {
            if (value is null)
            {
                PolicyTerminalServer.DeleteSubKeyTree(RegistryMaxDisconnectionTime);
            }
            else
            {
                PolicyTerminalServer.SetValue(RegistryMaxDisconnectionTime, value, RegistryValueKind.DWord);
            }
        }
    }

    public int? MaxIdleTime
    {
        get => PolicyTerminalServer.GetValue<int?>(RegistryMaxIdleTime, null);
        set
        {
            if (value is null)
            {
                PolicyTerminalServer.DeleteSubKeyTree(RegistryMaxIdleTime);
            }
            else
            {
                PolicyTerminalServer.SetValue(RegistryMaxIdleTime, value, RegistryValueKind.DWord);
            }
        }
    }


    public RemoteApps()
    {
        CurrentVersion = Registry.LocalMachine.OpenSubKey(RegistryCurrentVersion, true) ?? Registry.LocalMachine.CreateSubKey(RegistryCurrentVersion, true);
        TerminalServer = CurrentVersion.OpenSubKey(RegistryTerminalServer, true) ?? CurrentVersion.CreateSubKey(RegistryTerminalServer, true);
        TSAppAllowList = TerminalServer.OpenSubKey(RegistryTSAppAllowList, true) ?? TerminalServer.CreateSubKey(RegistryTSAppAllowList, true);
        Applications = TSAppAllowList.OpenSubKey(RegistryApplications, true) ?? TSAppAllowList.CreateSubKey(RegistryApplications, true);
        PolicyMicrosoft = Registry.LocalMachine.OpenSubKey(RegistryPolicyMicrosoft, true) ?? Registry.LocalMachine.CreateSubKey(RegistryPolicyMicrosoft, true);
        PolicyWindowsNT = PolicyMicrosoft.OpenSubKey(RegistryPolicyWindowsNT, true) ?? PolicyMicrosoft.CreateSubKey(RegistryPolicyWindowsNT, true);
        PolicyTerminalServer = PolicyWindowsNT.OpenSubKey(RegistryPolicyTerminalServer, true) ?? PolicyWindowsNT.CreateSubKey(RegistryPolicyTerminalServer, true);
    }

    public RemoteApp[] GetRemoteApps()
    {
        return Applications.GetSubKeyNames().AsParallel().Select(i => Applications.OpenSubKey(i)!).Select(RemoteApp.LoadFrom).ToArray();
    }

    public void SaveRemoteApps(IEnumerable<RemoteApp> apps)
    {
        foreach (var app in apps)
            app.SaveTo(Applications);
    }

    public void RemoveApp(string name) => Applications.DeleteSubKeyTree(name);
    public void RenameApp(RemoteApp app, string name)
    {
        Applications.DeleteSubKeyTree(app.Name);
        app.Name = name;
        app.SaveTo(Applications);
    }

    private void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                Applications.Dispose();
                TSAppAllowList.Dispose();
                TerminalServer.Dispose();
                CurrentVersion.Dispose();
                PolicyTerminalServer.Dispose();
                PolicyWindowsNT.Dispose();
                PolicyMicrosoft.Dispose();
            }

            _disposedValue = true;
        }
    }

    // ~RemoteApps()
    // {
    //     // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
