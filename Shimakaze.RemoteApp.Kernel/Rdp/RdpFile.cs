using System.Text;

namespace Shimakaze.RemoteApp.Kernel.Rdp;

public sealed class RDPFile
{
    public int AdministrativeSession { get; set; } = 0;
    public int AllowDesktopComposition { get; set; } = 0;
    public int AllowFontSmoothing { get; set; } = 0;
    public string AlternateFullAddress { get; set; } = string.Empty;
    public string AlternateShell { get; set; } = string.Empty;
    public int Audiocapturemode { get; set; } = 0;
    public int Audiomode { get; set; } = 0;
    public int Audioqualitymode { get; set; } = 0;
    public int AuthenticationLevel { get; set; } = 2;
    public int AutoreconnectMaxRetries { get; set; } = 20;
    public int AutoreconnectionEnabled { get; set; } = 1;
    public int Bandwidthautodetect { get; set; } = 1;
    public int Bitmapcachepersistenable { get; set; } = 1;
    public int Bitmapcachesize { get; set; } = 1500;
    public int Compression { get; set; } = 1;
    public int ConnectToConsole { get; set; } = 0;
    public int ConnectionType { get; set; } = 2;
    public int DesktopSizeId { get; set; } = 0;
    public int Desktopheight { get; set; } = 600;
    public int Desktopwidth { get; set; } = 800;
    public string Devicestoredirect { get; set; } = string.Empty;
    public int DisableCtrlAltDel { get; set; } = 1;
    public int DisableFullWindowDrag { get; set; } = 1;
    public int DisableMenuAnims { get; set; } = 1;
    public int DisableThemes { get; set; } = 0;
    public int DisableWallpaper { get; set; } = 1;
    public int Disableconnectionsharing { get; set; } = 0;
    public int Disableremoteappcapscheck { get; set; } = 0;
    public int Displayconnectionbar { get; set; } = 1;
    public string Domain { get; set; } = string.Empty;
    public string Drivestoredirect { get; set; } = string.Empty;
    public int Enablecredsspsupport { get; set; } = 1;
    public int Enablesuperpan { get; set; } = 0;
    public string FullAddress { get; set; } = string.Empty;
    public int Gatewaycredentialssource { get; set; } = 4;
    public string Gatewayhostname { get; set; } = string.Empty;
    public int Gatewayprofileusagemethod { get; set; } = 0;
    public int Gatewayusagemethod { get; set; } = 4;
    public int Keyboardhook { get; set; } = 2;
    public int NegotiateSecurityLayer { get; set; } = 1;
    public int Networkautodetect { get; set; } = 1;
    // Public password_51 As Binary
    public int Pinconnectionbar { get; set; } = 1;
    public int PromptForCredentials { get; set; } = 0;
    public int PromptForCredentialsOnClient { get; set; } = 0;
    public int Promptcredentialonce { get; set; } = 1;
    public int PublicMode { get; set; } = 0;
    public int Redirectclipboard { get; set; } = 1;
    public int Redirectcomports { get; set; } = 0;
    public int Redirectdirectx { get; set; } = 1;
    public int Redirectdrives { get; set; } = 0;
    public int Redirectposdevices { get; set; } = 0;
    public int Redirectprinters { get; set; } = 1;
    public int Redirectsmartcards { get; set; } = 1;
    public string Remoteapplicationcmdline { get; set; } = string.Empty;
    public int Remoteapplicationexpandcmdline { get; set; } = 1;
    public int Remoteapplicationexpandworkingdir { get; set; } = 0;
    public string Remoteapplicationfile { get; set; } = string.Empty;
    public string Remoteapplicationfileextensions { get; set; } = string.Empty;
    public string Remoteapplicationicon { get; set; } = string.Empty;
    public int Remoteapplicationmode { get; set; } = 0;
    public string Remoteapplicationname { get; set; } = string.Empty;
    public string Remoteapplicationprogram { get; set; } = string.Empty;
    public int ScreenModeId { get; set; } = 2;
    public int ServerPort { get; set; } = 3389;
    public int SessionBpp { get; set; } = 32;
    public string ShellWorkingDirectory { get; set; } = string.Empty;
    public int SmartSizing { get; set; } = 0;
    public int SpanMonitors { get; set; } = 0;
    public int Superpanaccelerationfactor { get; set; } = 1;
    public string Usbdevicestoredirect { get; set; } = string.Empty;
    public int UseMultimon { get; set; } = 0;
    public string Username { get; set; } = string.Empty;
    public int Videoplaybackmode { get; set; } = 1;
    public string Winposstr { get; set; } = "0,3,0,0,800,600";
    public int Redirectlocation { get; set; } = 0;
    public int Redirectwebauthn { get; set; } = 1;
    public string Kdcproxyname { get; set; } = string.Empty;
    public int Enablerdsaadauth { get; set; } = 1;

    public string ToString(bool saveDefaultSettings = false)
    {
        StringBuilder rdp = new();

        RDPFile @default = new();

        if (saveDefaultSettings || @default.AdministrativeSession != AdministrativeSession)
            rdp.AppendLine("administrative session" + AdministrativeSession.GetRdpValue());
        if (saveDefaultSettings || @default.AllowDesktopComposition != AllowDesktopComposition)
            rdp.AppendLine("allow desktop composition" + AllowDesktopComposition.GetRdpValue());
        if (saveDefaultSettings || @default.AllowFontSmoothing != AllowFontSmoothing)
            rdp.AppendLine("allow font smoothing" + AllowFontSmoothing.GetRdpValue());
        if (saveDefaultSettings || @default.AlternateFullAddress != AlternateFullAddress)
            rdp.AppendLine("alternate full address" + AlternateFullAddress.GetRdpValue());
        if (saveDefaultSettings || @default.AlternateShell != AlternateShell)
            rdp.AppendLine("alternate shell" + AlternateShell.GetRdpValue());
        if (saveDefaultSettings || @default.Audiocapturemode != Audiocapturemode)
            rdp.AppendLine("audiocapturemode" + Audiocapturemode.GetRdpValue());
        if (saveDefaultSettings || @default.Audiomode != Audiomode)
            rdp.AppendLine("audiomode" + Audiomode.GetRdpValue());
        if (saveDefaultSettings || @default.Audioqualitymode != Audioqualitymode)
            rdp.AppendLine("audioqualitymode" + Audioqualitymode.GetRdpValue());
        if (saveDefaultSettings || @default.AuthenticationLevel != AuthenticationLevel)
            rdp.AppendLine("authentication level" + AuthenticationLevel.GetRdpValue());
        if (saveDefaultSettings || @default.AutoreconnectMaxRetries != AutoreconnectMaxRetries)
            rdp.AppendLine("autoreconnect max retries" + AutoreconnectMaxRetries.GetRdpValue());
        if (saveDefaultSettings || @default.AutoreconnectionEnabled != AutoreconnectionEnabled)
            rdp.AppendLine("autoreconnection enabled" + AutoreconnectionEnabled.GetRdpValue());
        if (saveDefaultSettings || @default.Bandwidthautodetect != Bandwidthautodetect)
            rdp.AppendLine("bandwidthautodetect" + Bandwidthautodetect.GetRdpValue());
        if (saveDefaultSettings || @default.Bitmapcachepersistenable != Bitmapcachepersistenable)
            rdp.AppendLine("bitmapcachepersistenable" + Bitmapcachepersistenable.GetRdpValue());
        if (saveDefaultSettings || @default.Bitmapcachesize != Bitmapcachesize)
            rdp.AppendLine("bitmapcachesize" + Bitmapcachesize.GetRdpValue());
        if (saveDefaultSettings || @default.Compression != Compression)
            rdp.AppendLine("compression" + Compression.GetRdpValue());
        if (saveDefaultSettings || @default.ConnectToConsole != ConnectToConsole)
            rdp.AppendLine("connect to console" + ConnectToConsole.GetRdpValue());
        if (saveDefaultSettings || @default.ConnectionType != ConnectionType)
            rdp.AppendLine("connection type" + ConnectionType.GetRdpValue());
        if (saveDefaultSettings || @default.DesktopSizeId != DesktopSizeId)
            rdp.AppendLine("desktop size id" + DesktopSizeId.GetRdpValue());
        if (saveDefaultSettings || @default.Desktopheight != Desktopheight)
            rdp.AppendLine("desktopheight" + Desktopheight.GetRdpValue());
        if (saveDefaultSettings || @default.Desktopwidth != Desktopwidth)
            rdp.AppendLine("desktopwidth" + Desktopwidth.GetRdpValue());
        if (saveDefaultSettings || @default.Devicestoredirect != Devicestoredirect)
            rdp.AppendLine("devicestoredirect" + Devicestoredirect.GetRdpValue());
        if (saveDefaultSettings || @default.DisableCtrlAltDel != DisableCtrlAltDel)
            rdp.AppendLine("disable ctrl+alt+del" + DisableCtrlAltDel.GetRdpValue());
        if (saveDefaultSettings || @default.DisableFullWindowDrag != DisableFullWindowDrag)
            rdp.AppendLine("disable full window drag" + DisableFullWindowDrag.GetRdpValue());
        if (saveDefaultSettings || @default.DisableMenuAnims != DisableMenuAnims)
            rdp.AppendLine("disable menu anims" + DisableMenuAnims.GetRdpValue());
        if (saveDefaultSettings || @default.DisableThemes != DisableThemes)
            rdp.AppendLine("disable themes" + DisableThemes.GetRdpValue());
        if (saveDefaultSettings || @default.DisableWallpaper != DisableWallpaper)
            rdp.AppendLine("disable wallpaper" + DisableWallpaper.GetRdpValue());
        if (saveDefaultSettings || @default.Disableconnectionsharing != Disableconnectionsharing)
            rdp.AppendLine("disableconnectionsharing" + Disableconnectionsharing.GetRdpValue());
        if (saveDefaultSettings || @default.Disableremoteappcapscheck != Disableremoteappcapscheck)
            rdp.AppendLine("disableremoteappcapscheck" + Disableremoteappcapscheck.GetRdpValue());
        if (saveDefaultSettings || @default.Displayconnectionbar != Displayconnectionbar)
            rdp.AppendLine("displayconnectionbar" + Displayconnectionbar.GetRdpValue());
        if (saveDefaultSettings || @default.Domain != Domain)
            rdp.AppendLine("domain" + Domain.GetRdpValue());
        if (saveDefaultSettings || @default.Drivestoredirect != Drivestoredirect)
            rdp.AppendLine("drivestoredirect" + Drivestoredirect.GetRdpValue());
        if (saveDefaultSettings || @default.Enablecredsspsupport != Enablecredsspsupport)
            rdp.AppendLine("enablecredsspsupport" + Enablecredsspsupport.GetRdpValue());
        if (saveDefaultSettings || @default.Enablesuperpan != Enablesuperpan)
            rdp.AppendLine("enablesuperpan" + Enablesuperpan.GetRdpValue());
        if (saveDefaultSettings || @default.FullAddress != FullAddress)
            rdp.AppendLine("full address" + FullAddress.GetRdpValue());
        if (saveDefaultSettings || @default.Gatewaycredentialssource != Gatewaycredentialssource)
            rdp.AppendLine("gatewaycredentialssource" + Gatewaycredentialssource.GetRdpValue());
        if (saveDefaultSettings || @default.Gatewayhostname != Gatewayhostname)
            rdp.AppendLine("gatewayhostname" + Gatewayhostname.GetRdpValue());
        if (saveDefaultSettings || @default.Gatewayprofileusagemethod != Gatewayprofileusagemethod)
            rdp.AppendLine("gatewayprofileusagemethod" + Gatewayprofileusagemethod.GetRdpValue());
        if (saveDefaultSettings || @default.Gatewayusagemethod != Gatewayusagemethod)
            rdp.AppendLine("gatewayusagemethod" + Gatewayusagemethod.GetRdpValue());
        if (saveDefaultSettings || @default.Keyboardhook != Keyboardhook)
            rdp.AppendLine("keyboardhook" + Keyboardhook.GetRdpValue());
        if (saveDefaultSettings || @default.NegotiateSecurityLayer != NegotiateSecurityLayer)
            rdp.AppendLine("negotiate security layer" + NegotiateSecurityLayer.GetRdpValue());
        if (saveDefaultSettings || @default.Networkautodetect != Networkautodetect)
            rdp.AppendLine("networkautodetect" + Networkautodetect.GetRdpValue());
        // If SaveDefaultSettings Or Not DefaultRDP.password_51 = password_51 Then RDPstring.AppendLine( "password 51" & ":" & password_51.GetType().ToString.Replace("System.", string.Empty).ToLower.Substring(0, 1) & ":" & password_51.ToString & vbCrLf
        if (saveDefaultSettings || @default.Pinconnectionbar != Pinconnectionbar)
            rdp.AppendLine("pinconnectionbar" + Pinconnectionbar.GetRdpValue());
        if (saveDefaultSettings || @default.PromptForCredentials != PromptForCredentials)
            rdp.AppendLine("prompt for credentials" + PromptForCredentials.GetRdpValue());
        if (saveDefaultSettings || @default.PromptForCredentialsOnClient != PromptForCredentialsOnClient)
            rdp.AppendLine("prompt for credentials on client" + PromptForCredentialsOnClient.GetRdpValue());
        if (saveDefaultSettings || @default.Promptcredentialonce != Promptcredentialonce)
            rdp.AppendLine("promptcredentialonce" + Promptcredentialonce.GetRdpValue());
        if (saveDefaultSettings || @default.PublicMode != PublicMode)
            rdp.AppendLine("public mode" + PublicMode.GetRdpValue());
        if (saveDefaultSettings || @default.Redirectclipboard != Redirectclipboard)
            rdp.AppendLine("redirectclipboard" + Redirectclipboard.GetRdpValue());
        if (saveDefaultSettings || @default.Redirectcomports != Redirectcomports)
            rdp.AppendLine("redirectcomports" + Redirectcomports.GetRdpValue());
        if (saveDefaultSettings || @default.Redirectdirectx != Redirectdirectx)
            rdp.AppendLine("redirectdirectx" + Redirectdirectx.GetRdpValue());
        if (saveDefaultSettings || @default.Redirectdrives != Redirectdrives)
            rdp.AppendLine("redirectdrives" + Redirectdrives.GetRdpValue());
        if (saveDefaultSettings || @default.Redirectposdevices != Redirectposdevices)
            rdp.AppendLine("redirectposdevices" + Redirectposdevices.GetRdpValue());
        if (saveDefaultSettings || @default.Redirectprinters != Redirectprinters)
            rdp.AppendLine("redirectprinters" + Redirectprinters.GetRdpValue());
        if (saveDefaultSettings || @default.Redirectsmartcards != Redirectsmartcards)
            rdp.AppendLine("redirectsmartcards" + Redirectsmartcards.GetRdpValue());
        if (saveDefaultSettings || @default.Remoteapplicationcmdline != Remoteapplicationcmdline)
            rdp.AppendLine("remoteapplicationcmdline" + Remoteapplicationcmdline.GetRdpValue());
        if (saveDefaultSettings || @default.Remoteapplicationexpandcmdline != Remoteapplicationexpandcmdline)
            rdp.AppendLine("remoteapplicationexpandcmdline" + Remoteapplicationexpandcmdline.GetRdpValue());
        if (saveDefaultSettings || @default.Remoteapplicationexpandworkingdir != Remoteapplicationexpandworkingdir)
            rdp.AppendLine("remoteapplicationexpandworkingdir" + Remoteapplicationexpandworkingdir.GetRdpValue());
        if (saveDefaultSettings || @default.Remoteapplicationfile != Remoteapplicationfile)
            rdp.AppendLine("remoteapplicationfile" + Remoteapplicationfile.GetRdpValue());
        if (saveDefaultSettings || @default.Remoteapplicationfileextensions != Remoteapplicationfileextensions)
            rdp.AppendLine("remoteapplicationfileextensions" + Remoteapplicationfileextensions.GetRdpValue());
        if (saveDefaultSettings || @default.Remoteapplicationicon != Remoteapplicationicon)
            rdp.AppendLine("remoteapplicationicon" + Remoteapplicationicon.GetRdpValue());
        if (saveDefaultSettings || @default.Remoteapplicationmode != Remoteapplicationmode)
            rdp.AppendLine("remoteapplicationmode" + Remoteapplicationmode.GetRdpValue());
        if (saveDefaultSettings || @default.Remoteapplicationname != Remoteapplicationname)
            rdp.AppendLine("remoteapplicationname" + Remoteapplicationname.GetRdpValue());
        if (saveDefaultSettings || @default.Remoteapplicationprogram != Remoteapplicationprogram)
            rdp.AppendLine("remoteapplicationprogram" + Remoteapplicationprogram.GetRdpValue());
        if (saveDefaultSettings || @default.ScreenModeId != ScreenModeId)
            rdp.AppendLine("screen mode id" + ScreenModeId.GetRdpValue());
        if (saveDefaultSettings || @default.ServerPort != ServerPort)
            rdp.AppendLine("server port" + ServerPort.GetRdpValue());
        if (saveDefaultSettings || @default.SessionBpp != SessionBpp)
            rdp.AppendLine("session bpp" + SessionBpp.GetRdpValue());
        if (saveDefaultSettings || @default.ShellWorkingDirectory != ShellWorkingDirectory)
            rdp.AppendLine("shell working directory" + ShellWorkingDirectory.GetRdpValue());
        if (saveDefaultSettings || @default.SmartSizing != SmartSizing)
            rdp.AppendLine("smart sizing" + SmartSizing.GetRdpValue());
        if (saveDefaultSettings || @default.SpanMonitors != SpanMonitors)
            rdp.AppendLine("span monitors" + SpanMonitors.GetRdpValue());
        if (saveDefaultSettings || @default.Superpanaccelerationfactor != Superpanaccelerationfactor)
            rdp.AppendLine("superpanaccelerationfactor" + Superpanaccelerationfactor.GetRdpValue());
        if (saveDefaultSettings || @default.Usbdevicestoredirect != Usbdevicestoredirect)
            rdp.AppendLine("usbdevicestoredirect" + Usbdevicestoredirect.GetRdpValue());
        if (saveDefaultSettings || @default.UseMultimon != UseMultimon)
            rdp.AppendLine("use multimon" + UseMultimon.GetRdpValue());
        if (saveDefaultSettings || @default.Username != Username)
            rdp.AppendLine("username" + Username.GetRdpValue());
        if (saveDefaultSettings || @default.Videoplaybackmode != Videoplaybackmode)
            rdp.AppendLine("videoplaybackmode" + Videoplaybackmode.GetRdpValue());
        if (saveDefaultSettings || @default.Winposstr != Winposstr)
            rdp.AppendLine("winposstr" + Winposstr.GetRdpValue());
        if (saveDefaultSettings || @default.Redirectlocation != Redirectlocation)
            rdp.AppendLine("redirectlocation" + Redirectlocation.GetRdpValue());
        if (saveDefaultSettings || @default.Redirectwebauthn != Redirectwebauthn)
            rdp.AppendLine("redirectwebauthn" + Redirectwebauthn.GetRdpValue());
        if (saveDefaultSettings || @default.Kdcproxyname != Kdcproxyname)
            rdp.AppendLine("kdcproxyname" + Kdcproxyname.GetRdpValue());
        if (saveDefaultSettings || @default.Enablerdsaadauth != Enablerdsaadauth)
            rdp.AppendLine("enablerdsaadauth" + Enablerdsaadauth.GetRdpValue());

        return rdp.ToString();
    }

    public override string ToString() => ToString(false);

    public static RDPFile LoadRDPfile(string filePath)
    {
        using StreamReader sr = File.OpenText(filePath);
        RDPFile result = new();

        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine()!;
            var splits = line.Split(":");

            if (splits[2] == string.Empty)
                continue;

            switch (splits[0])
            {
                case "administrative session":
                    result.AdministrativeSession = int.Parse(splits[2]);
                    break;
                case "allow desktop composition":
                    result.AllowDesktopComposition = int.Parse(splits[2]);
                    break;
                case "allow font smoothing":
                    result.AllowFontSmoothing = int.Parse(splits[2]);
                    break;
                case "alternate full address":
                    result.AlternateFullAddress = splits[2];
                    break;
                case "alternate shell":
                    result.AlternateShell = splits[2];
                    break;
                case "audiocapturemode":
                    result.Audiocapturemode = int.Parse(splits[2]);
                    break;
                case "audiomode":
                    result.Audiomode = int.Parse(splits[2]);
                    break;
                case "audioqualitymode":
                    result.Audioqualitymode = int.Parse(splits[2]);
                    break;
                case "authentication level":
                    result.AuthenticationLevel = int.Parse(splits[2]);
                    break;
                case "autoreconnect max retries":
                    result.AutoreconnectMaxRetries = int.Parse(splits[2]);
                    break;
                case "autoreconnection enabled":
                    result.AutoreconnectionEnabled = int.Parse(splits[2]);
                    break;
                case "bandwidthautodetect":
                    result.Bandwidthautodetect = int.Parse(splits[2]);
                    break;
                case "bitmapcachepersistenable":
                    result.Bitmapcachepersistenable = int.Parse(splits[2]);
                    break;
                case "bitmapcachesize":
                    result.Bitmapcachesize = int.Parse(splits[2]);
                    break;
                case "compression":
                    result.Compression = int.Parse(splits[2]);
                    break;
                case "connect to console":
                    result.ConnectToConsole = int.Parse(splits[2]);
                    break;
                case "connection type":
                    result.ConnectionType = int.Parse(splits[2]);
                    break;
                case "desktop size id":
                    result.DesktopSizeId = int.Parse(splits[2]);
                    break;
                case "desktopheight":
                    result.Desktopheight = int.Parse(splits[2]);
                    break;
                case "desktopwidth":
                    result.Desktopwidth = int.Parse(splits[2]);
                    break;
                case "devicestoredirect":
                    result.Devicestoredirect = splits[2];
                    break;
                case "disable ctrl+alt+del":
                    result.DisableCtrlAltDel = int.Parse(splits[2]);
                    break;
                case "disable full window drag":
                    result.DisableFullWindowDrag = int.Parse(splits[2]);
                    break;
                case "disable menu anims":
                    result.DisableMenuAnims = int.Parse(splits[2]);
                    break;
                case "disable themes":
                    result.DisableThemes = int.Parse(splits[2]);
                    break;
                case "disable wallpaper":
                    result.DisableWallpaper = int.Parse(splits[2]);
                    break;
                case "disableconnectionsharing":
                    result.Disableconnectionsharing = int.Parse(splits[2]);
                    break;
                case "disableremoteappcapscheck":
                    result.Disableremoteappcapscheck = int.Parse(splits[2]);
                    break;
                case "displayconnectionbar":
                    result.Displayconnectionbar = int.Parse(splits[2]);
                    break;
                case "domain":
                    result.Domain = splits[2];
                    break;
                case "drivestoredirect":
                    result.Drivestoredirect = splits[2];
                    break;
                case "enablecredsspsupport":
                    result.Enablecredsspsupport = int.Parse(splits[2]);
                    break;
                case "enablesuperpan":
                    result.Enablesuperpan = int.Parse(splits[2]);
                    break;
                case "full address":
                    result.FullAddress = splits[2];
                    break;
                case "gatewaycredentialssource":
                    result.Gatewaycredentialssource = int.Parse(splits[2]);
                    break;
                case "gatewayhostname":
                    result.Gatewayhostname = splits[2];
                    break;
                case "gatewayprofileusagemethod":
                    result.Gatewayprofileusagemethod = int.Parse(splits[2]);
                    break;
                case "gatewayusagemethod":
                    result.Gatewayusagemethod = int.Parse(splits[2]);
                    break;
                case "keyboardhook":
                    result.Keyboardhook = int.Parse(splits[2]);
                    break;
                case "negotiate security layer":
                    result.NegotiateSecurityLayer = int.Parse(splits[2]);
                    break;
                case "networkautodetect":
                    result.Networkautodetect = int.Parse(splits[2]);
                    break;
                case "pinconnectionbar":
                    result.Pinconnectionbar = int.Parse(splits[2]);
                    break;
                case "prompt for credentials":
                    result.PromptForCredentials = int.Parse(splits[2]);
                    break;
                case "prompt for credentials on client":
                    result.PromptForCredentialsOnClient = int.Parse(splits[2]);
                    break;
                case "promptcredentialonce":
                    result.Promptcredentialonce = int.Parse(splits[2]);
                    break;
                case "public mode":
                    result.PublicMode = int.Parse(splits[2]);
                    break;
                case "redirectclipboard":
                    result.Redirectclipboard = int.Parse(splits[2]);
                    break;
                case "redirectcomports":
                    result.Redirectcomports = int.Parse(splits[2]);
                    break;
                case "redirectdirectx":
                    result.Redirectdirectx = int.Parse(splits[2]);
                    break;
                case "redirectdrives":
                    result.Redirectdrives = int.Parse(splits[2]);
                    break;
                case "redirectposdevices":
                    result.Redirectposdevices = int.Parse(splits[2]);
                    break;
                case "redirectprinters":
                    result.Redirectprinters = int.Parse(splits[2]);
                    break;
                case "redirectsmartcards":
                    result.Redirectsmartcards = int.Parse(splits[2]);
                    break;
                case "remoteapplicationcmdline":
                    result.Remoteapplicationcmdline = splits[2];
                    break;
                case "remoteapplicationexpandcmdline":
                    result.Remoteapplicationexpandcmdline = int.Parse(splits[2]);
                    break;
                case "remoteapplicationexpandworkingdir":
                    result.Remoteapplicationexpandworkingdir = int.Parse(splits[2]);
                    break;
                case "remoteapplicationfile":
                    result.Remoteapplicationfile = splits[2];
                    break;
                case "remoteapplicationfileextensions":
                    result.Remoteapplicationfileextensions = splits[2];
                    break;
                case "remoteapplicationicon":
                    result.Remoteapplicationicon = splits[2];
                    break;
                case "remoteapplicationmode":
                    result.Remoteapplicationmode = int.Parse(splits[2]);
                    break;
                case "remoteapplicationname":
                    result.Remoteapplicationname = splits[2];
                    break;
                case "remoteapplicationprogram":
                    result.Remoteapplicationprogram = splits[2];
                    break;
                case "screen mode id":
                    result.ScreenModeId = int.Parse(splits[2]);
                    break;
                case "server port":
                    result.ServerPort = int.Parse(splits[2]);
                    break;
                case "session bpp":
                    result.SessionBpp = int.Parse(splits[2]);
                    break;
                case "shell working directory":
                    result.ShellWorkingDirectory = splits[2];
                    break;
                case "smart sizing":
                    result.SmartSizing = int.Parse(splits[2]);
                    break;
                case "span monitors":
                    result.SpanMonitors = int.Parse(splits[2]);
                    break;
                case "superpanaccelerationfactor":
                    result.Superpanaccelerationfactor = int.Parse(splits[2]);
                    break;
                case "usbdevicestoredirect":
                    result.Usbdevicestoredirect = splits[2];
                    break;
                case "use multimon":
                    result.UseMultimon = int.Parse(splits[2]);
                    break;
                case "username":
                    result.Username = splits[2];
                    break;
                case "videoplaybackmode":
                    result.Videoplaybackmode = int.Parse(splits[2]);
                    break;
                case "winposstr":
                    result.Winposstr = splits[2];
                    break;
                case "redirectlocation":
                    result.Redirectlocation = int.Parse(splits[2]);
                    break;
                case "redirectwebauthn":
                    result.Redirectwebauthn = int.Parse(splits[2]);
                    break;
                case "kdcproxyname":
                    result.Kdcproxyname = splits[2];
                    break;
                case "enablerdsaadauth":
                    result.Enablerdsaadauth = int.Parse(splits[2]);
                    break;
            }
        }
        return result;
    }
}
internal static class TypeExtensions
{
    public static string GetRdpValue<T>(this T value)
        => $":{typeof(T).ToString().Replace("System.", string.Empty).ToLower()[0]}:{value}";
}
