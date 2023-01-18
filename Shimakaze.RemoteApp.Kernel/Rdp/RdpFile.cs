using System.Text;

namespace Shimakaze.RemoteApp.Kernel.Rdp;

public class RDPFile
{
    public int administrative_session { get; set; } = 0;
    public int allow_desktop_composition { get; set; } = 0;
    public int allow_font_smoothing { get; set; } = 0;
    public string alternate_full_address { get; set; } = string.Empty;
    public string alternate_shell { get; set; } = string.Empty;
    public int audiocapturemode { get; set; } = 0;
    public int audiomode { get; set; } = 0;
    public int audioqualitymode { get; set; } = 0;
    public int authentication_level { get; set; } = 2;
    public int autoreconnect_max_retries { get; set; } = 20;
    public int autoreconnection_enabled { get; set; } = 1;
    public int bandwidthautodetect { get; set; } = 1;
    public int bitmapcachepersistenable { get; set; } = 1;
    public int bitmapcachesize { get; set; } = 1500;
    public int compression { get; set; } = 1;
    public int connect_to_console { get; set; } = 0;
    public int connection_type { get; set; } = 2;
    public int desktop_size_id { get; set; } = 0;
    public int desktopheight { get; set; } = 600;
    public int desktopwidth { get; set; } = 800;
    public string devicestoredirect { get; set; } = string.Empty;
    public int disable_ctrl_alt_del { get; set; } = 1;
    public int disable_full_window_drag { get; set; } = 1;
    public int disable_menu_anims { get; set; } = 1;
    public int disable_themes { get; set; } = 0;
    public int disable_wallpaper { get; set; } = 1;
    public int disableconnectionsharing { get; set; } = 0;
    public int disableremoteappcapscheck { get; set; } = 0;
    public int displayconnectionbar { get; set; } = 1;
    public string domain { get; set; } = string.Empty;
    public string drivestoredirect { get; set; } = string.Empty;
    public int enablecredsspsupport { get; set; } = 1;
    public int enablesuperpan { get; set; } = 0;
    public string full_address { get; set; } = string.Empty;
    public int gatewaycredentialssource { get; set; } = 4;
    public string gatewayhostname { get; set; } = string.Empty;
    public int gatewayprofileusagemethod { get; set; } = 0;
    public int gatewayusagemethod { get; set; } = 4;
    public int keyboardhook { get; set; } = 2;
    public int negotiate_security_layer { get; set; } = 1;
    public int networkautodetect { get; set; } = 1;
    // Public password_51 As Binary
    public int pinconnectionbar { get; set; } = 1;
    public int prompt_for_credentials { get; set; } = 0;
    public int prompt_for_credentials_on_client { get; set; } = 0;
    public int promptcredentialonce { get; set; } = 1;
    public int public_mode { get; set; } = 0;
    public int redirectclipboard { get; set; } = 1;
    public int redirectcomports { get; set; } = 0;
    public int redirectdirectx { get; set; } = 1;
    public int redirectdrives { get; set; } = 0;
    public int redirectposdevices { get; set; } = 0;
    public int redirectprinters { get; set; } = 1;
    public int redirectsmartcards { get; set; } = 1;
    public string remoteapplicationcmdline { get; set; } = string.Empty;
    public int remoteapplicationexpandcmdline { get; set; } = 1;
    public int remoteapplicationexpandworkingdir { get; set; } = 0;
    public string remoteapplicationfile { get; set; } = string.Empty;
    public string remoteapplicationfileextensions { get; set; } = string.Empty;
    public string remoteapplicationicon { get; set; } = string.Empty;
    public int remoteapplicationmode { get; set; } = 0;
    public string remoteapplicationname { get; set; } = string.Empty;
    public string remoteapplicationprogram { get; set; } = string.Empty;
    public int screen_mode_id { get; set; } = 2;
    public int server_port { get; set; } = 3389;
    public int session_bpp { get; set; } = 32;
    public string shell_working_directory { get; set; } = string.Empty;
    public int smart_sizing { get; set; } = 0;
    public int span_monitors { get; set; } = 0;
    public int superpanaccelerationfactor { get; set; } = 1;
    public string usbdevicestoredirect { get; set; } = string.Empty;
    public int use_multimon { get; set; } = 0;
    public string username { get; set; } = string.Empty;
    public int videoplaybackmode { get; set; } = 1;
    public string winposstr { get; set; } = "0,3,0,0,800,600";
    public int redirectlocation { get; set; } = 0;
    public int redirectwebauthn { get; set; } = 1;
    public string kdcproxyname { get; set; } = string.Empty;
    public int enablerdsaadauth { get; set; } = 1;

    public string ToString(bool SaveDefaultSettings = false)
    {
        StringBuilder RDPstring = new();

        RDPFile DefaultRDP = new RDPFile();

        if (SaveDefaultSettings || DefaultRDP.administrative_session != administrative_session)
            RDPstring.AppendLine("administrative session" + administrative_session.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.allow_desktop_composition != allow_desktop_composition)
            RDPstring.AppendLine("allow desktop composition" + allow_desktop_composition.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.allow_font_smoothing != allow_font_smoothing)
            RDPstring.AppendLine("allow font smoothing" + allow_font_smoothing.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.alternate_full_address != alternate_full_address)
            RDPstring.AppendLine("alternate full address" + alternate_full_address.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.alternate_shell != alternate_shell)
            RDPstring.AppendLine("alternate shell" + alternate_shell.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.audiocapturemode != audiocapturemode)
            RDPstring.AppendLine("audiocapturemode" + audiocapturemode.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.audiomode != audiomode)
            RDPstring.AppendLine("audiomode" + audiomode.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.audioqualitymode != audioqualitymode)
            RDPstring.AppendLine("audioqualitymode" + audioqualitymode.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.authentication_level != authentication_level)
            RDPstring.AppendLine("authentication level" + authentication_level.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.autoreconnect_max_retries != autoreconnect_max_retries)
            RDPstring.AppendLine("autoreconnect max retries" + autoreconnect_max_retries.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.autoreconnection_enabled != autoreconnection_enabled)
            RDPstring.AppendLine("autoreconnection enabled" + autoreconnection_enabled.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.bandwidthautodetect != bandwidthautodetect)
            RDPstring.AppendLine("bandwidthautodetect" + bandwidthautodetect.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.bitmapcachepersistenable != bitmapcachepersistenable)
            RDPstring.AppendLine("bitmapcachepersistenable" + bitmapcachepersistenable.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.bitmapcachesize != bitmapcachesize)
            RDPstring.AppendLine("bitmapcachesize" + bitmapcachesize.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.compression != compression)
            RDPstring.AppendLine("compression" + compression.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.connect_to_console != connect_to_console)
            RDPstring.AppendLine("connect to console" + connect_to_console.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.connection_type != connection_type)
            RDPstring.AppendLine("connection type" + connection_type.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.desktop_size_id != desktop_size_id)
            RDPstring.AppendLine("desktop size id" + desktop_size_id.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.desktopheight != desktopheight)
            RDPstring.AppendLine("desktopheight" + desktopheight.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.desktopwidth != desktopwidth)
            RDPstring.AppendLine("desktopwidth" + desktopwidth.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.devicestoredirect != devicestoredirect)
            RDPstring.AppendLine("devicestoredirect" + devicestoredirect.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.disable_ctrl_alt_del != disable_ctrl_alt_del)
            RDPstring.AppendLine("disable ctrl+alt+del" + disable_ctrl_alt_del.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.disable_full_window_drag != disable_full_window_drag)
            RDPstring.AppendLine("disable full window drag" + disable_full_window_drag.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.disable_menu_anims != disable_menu_anims)
            RDPstring.AppendLine("disable menu anims" + disable_menu_anims.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.disable_themes != disable_themes)
            RDPstring.AppendLine("disable themes" + disable_themes.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.disable_wallpaper != disable_wallpaper)
            RDPstring.AppendLine("disable wallpaper" + disable_wallpaper.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.disableconnectionsharing != disableconnectionsharing)
            RDPstring.AppendLine("disableconnectionsharing" + disableconnectionsharing.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.disableremoteappcapscheck != disableremoteappcapscheck)
            RDPstring.AppendLine("disableremoteappcapscheck" + disableremoteappcapscheck.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.displayconnectionbar != displayconnectionbar)
            RDPstring.AppendLine("displayconnectionbar" + displayconnectionbar.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.domain != domain)
            RDPstring.AppendLine("domain" + domain.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.drivestoredirect != drivestoredirect)
            RDPstring.AppendLine("drivestoredirect" + drivestoredirect.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.enablecredsspsupport != enablecredsspsupport)
            RDPstring.AppendLine("enablecredsspsupport" + enablecredsspsupport.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.enablesuperpan != enablesuperpan)
            RDPstring.AppendLine("enablesuperpan" + enablesuperpan.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.full_address != full_address)
            RDPstring.AppendLine("full address" + full_address.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.gatewaycredentialssource != gatewaycredentialssource)
            RDPstring.AppendLine("gatewaycredentialssource" + gatewaycredentialssource.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.gatewayhostname != gatewayhostname)
            RDPstring.AppendLine("gatewayhostname" + gatewayhostname.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.gatewayprofileusagemethod != gatewayprofileusagemethod)
            RDPstring.AppendLine("gatewayprofileusagemethod" + gatewayprofileusagemethod.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.gatewayusagemethod != gatewayusagemethod)
            RDPstring.AppendLine("gatewayusagemethod" + gatewayusagemethod.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.keyboardhook != keyboardhook)
            RDPstring.AppendLine("keyboardhook" + keyboardhook.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.negotiate_security_layer != negotiate_security_layer)
            RDPstring.AppendLine("negotiate security layer" + negotiate_security_layer.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.networkautodetect != networkautodetect)
            RDPstring.AppendLine("networkautodetect" + networkautodetect.GetRdpValue());
        // If SaveDefaultSettings Or Not DefaultRDP.password_51 = password_51 Then RDPstring.AppendLine( "password 51" & ":" & password_51.GetType().ToString.Replace("System.", string.Empty).ToLower.Substring(0, 1) & ":" & password_51.ToString & vbCrLf
        if (SaveDefaultSettings || DefaultRDP.pinconnectionbar != pinconnectionbar)
            RDPstring.AppendLine("pinconnectionbar" + pinconnectionbar.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.prompt_for_credentials != prompt_for_credentials)
            RDPstring.AppendLine("prompt for credentials" + prompt_for_credentials.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.prompt_for_credentials_on_client != prompt_for_credentials_on_client)
            RDPstring.AppendLine("prompt for credentials on client" + prompt_for_credentials_on_client.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.promptcredentialonce != promptcredentialonce)
            RDPstring.AppendLine("promptcredentialonce" + promptcredentialonce.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.public_mode != public_mode)
            RDPstring.AppendLine("public mode" + public_mode.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.redirectclipboard != redirectclipboard)
            RDPstring.AppendLine("redirectclipboard" + redirectclipboard.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.redirectcomports != redirectcomports)
            RDPstring.AppendLine("redirectcomports" + redirectcomports.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.redirectdirectx != redirectdirectx)
            RDPstring.AppendLine("redirectdirectx" + redirectdirectx.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.redirectdrives != redirectdrives)
            RDPstring.AppendLine("redirectdrives" + redirectdrives.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.redirectposdevices != redirectposdevices)
            RDPstring.AppendLine("redirectposdevices" + redirectposdevices.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.redirectprinters != redirectprinters)
            RDPstring.AppendLine("redirectprinters" + redirectprinters.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.redirectsmartcards != redirectsmartcards)
            RDPstring.AppendLine("redirectsmartcards" + redirectsmartcards.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.remoteapplicationcmdline != remoteapplicationcmdline)
            RDPstring.AppendLine("remoteapplicationcmdline" + remoteapplicationcmdline.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.remoteapplicationexpandcmdline != remoteapplicationexpandcmdline)
            RDPstring.AppendLine("remoteapplicationexpandcmdline" + remoteapplicationexpandcmdline.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.remoteapplicationexpandworkingdir != remoteapplicationexpandworkingdir)
            RDPstring.AppendLine("remoteapplicationexpandworkingdir" + remoteapplicationexpandworkingdir.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.remoteapplicationfile != remoteapplicationfile)
            RDPstring.AppendLine("remoteapplicationfile" + remoteapplicationfile.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.remoteapplicationfileextensions != remoteapplicationfileextensions)
            RDPstring.AppendLine("remoteapplicationfileextensions" + remoteapplicationfileextensions.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.remoteapplicationicon != remoteapplicationicon)
            RDPstring.AppendLine("remoteapplicationicon" + remoteapplicationicon.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.remoteapplicationmode != remoteapplicationmode)
            RDPstring.AppendLine("remoteapplicationmode" + remoteapplicationmode.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.remoteapplicationname != remoteapplicationname)
            RDPstring.AppendLine("remoteapplicationname" + remoteapplicationname.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.remoteapplicationprogram != remoteapplicationprogram)
            RDPstring.AppendLine("remoteapplicationprogram" + remoteapplicationprogram.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.screen_mode_id != screen_mode_id)
            RDPstring.AppendLine("screen mode id" + screen_mode_id.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.server_port != server_port)
            RDPstring.AppendLine("server port" + server_port.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.session_bpp != session_bpp)
            RDPstring.AppendLine("session bpp" + session_bpp.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.shell_working_directory != shell_working_directory)
            RDPstring.AppendLine("shell working directory" + shell_working_directory.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.smart_sizing != smart_sizing)
            RDPstring.AppendLine("smart sizing" + smart_sizing.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.span_monitors != span_monitors)
            RDPstring.AppendLine("span monitors" + span_monitors.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.superpanaccelerationfactor != superpanaccelerationfactor)
            RDPstring.AppendLine("superpanaccelerationfactor" + superpanaccelerationfactor.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.usbdevicestoredirect != usbdevicestoredirect)
            RDPstring.AppendLine("usbdevicestoredirect" + usbdevicestoredirect.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.use_multimon != use_multimon)
            RDPstring.AppendLine("use multimon" + use_multimon.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.username != username)
            RDPstring.AppendLine("username" + username.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.videoplaybackmode != videoplaybackmode)
            RDPstring.AppendLine("videoplaybackmode" + videoplaybackmode.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.winposstr != winposstr)
            RDPstring.AppendLine("winposstr" + winposstr.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.redirectlocation != redirectlocation)
            RDPstring.AppendLine("redirectlocation" + redirectlocation.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.redirectwebauthn != redirectwebauthn)
            RDPstring.AppendLine("redirectwebauthn" + redirectwebauthn.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.kdcproxyname != kdcproxyname)
            RDPstring.AppendLine("kdcproxyname" + kdcproxyname.GetRdpValue());
        if (SaveDefaultSettings || DefaultRDP.enablerdsaadauth != enablerdsaadauth)
            RDPstring.AppendLine("enablerdsaadauth" + enablerdsaadauth.GetRdpValue());

        return RDPstring.ToString();
    }

    public override string ToString() => ToString(false);

    public static RDPFile LoadRDPfile(string FilePath)
    {
        using StreamReader sr = File.OpenText(FilePath);
        RDPFile result = new();

        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine()!;
            var SplitLine = line.Split(":");

            if (SplitLine[2] == string.Empty)
                continue;

            switch (SplitLine[0])
            {
                case "administrative session":
                    result.administrative_session = int.Parse(SplitLine[2]);
                    break;
                case "allow desktop composition":
                    result.allow_desktop_composition = int.Parse(SplitLine[2]);
                    break;
                case "allow font smoothing":
                    result.allow_font_smoothing = int.Parse(SplitLine[2]);
                    break;
                case "alternate full address":
                    result.alternate_full_address = SplitLine[2];
                    break;
                case "alternate shell":
                    result.alternate_shell = SplitLine[2];
                    break;
                case "audiocapturemode":
                    result.audiocapturemode = int.Parse(SplitLine[2]);
                    break;
                case "audiomode":
                    result.audiomode = int.Parse(SplitLine[2]);
                    break;
                case "audioqualitymode":
                    result.audioqualitymode = int.Parse(SplitLine[2]);
                    break;
                case "authentication level":
                    result.authentication_level = int.Parse(SplitLine[2]);
                    break;
                case "autoreconnect max retries":
                    result.autoreconnect_max_retries = int.Parse(SplitLine[2]);
                    break;
                case "autoreconnection enabled":
                    result.autoreconnection_enabled = int.Parse(SplitLine[2]);
                    break;
                case "bandwidthautodetect":
                    result.bandwidthautodetect = int.Parse(SplitLine[2]);
                    break;
                case "bitmapcachepersistenable":
                    result.bitmapcachepersistenable = int.Parse(SplitLine[2]);
                    break;
                case "bitmapcachesize":
                    result.bitmapcachesize = int.Parse(SplitLine[2]);
                    break;
                case "compression":
                    result.compression = int.Parse(SplitLine[2]);
                    break;
                case "connect to console":
                    result.connect_to_console = int.Parse(SplitLine[2]);
                    break;
                case "connection type":
                    result.connection_type = int.Parse(SplitLine[2]);
                    break;
                case "desktop size id":
                    result.desktop_size_id = int.Parse(SplitLine[2]);
                    break;
                case "desktopheight":
                    result.desktopheight = int.Parse(SplitLine[2]);
                    break;
                case "desktopwidth":
                    result.desktopwidth = int.Parse(SplitLine[2]);
                    break;
                case "devicestoredirect":
                    result.devicestoredirect = SplitLine[2];
                    break;
                case "disable ctrl+alt+del":
                    result.disable_ctrl_alt_del = int.Parse(SplitLine[2]);
                    break;
                case "disable full window drag":
                    result.disable_full_window_drag = int.Parse(SplitLine[2]);
                    break;
                case "disable menu anims":
                    result.disable_menu_anims = int.Parse(SplitLine[2]);
                    break;
                case "disable themes":
                    result.disable_themes = int.Parse(SplitLine[2]);
                    break;
                case "disable wallpaper":
                    result.disable_wallpaper = int.Parse(SplitLine[2]);
                    break;
                case "disableconnectionsharing":
                    result.disableconnectionsharing = int.Parse(SplitLine[2]);
                    break;
                case "disableremoteappcapscheck":
                    result.disableremoteappcapscheck = int.Parse(SplitLine[2]);
                    break;
                case "displayconnectionbar":
                    result.displayconnectionbar = int.Parse(SplitLine[2]);
                    break;
                case "domain":
                    result.domain = SplitLine[2];
                    break;
                case "drivestoredirect":
                    result.drivestoredirect = SplitLine[2];
                    break;
                case "enablecredsspsupport":
                    result.enablecredsspsupport = int.Parse(SplitLine[2]);
                    break;
                case "enablesuperpan":
                    result.enablesuperpan = int.Parse(SplitLine[2]);
                    break;
                case "full address":
                    result.full_address = SplitLine[2];
                    break;
                case "gatewaycredentialssource":
                    result.gatewaycredentialssource = int.Parse(SplitLine[2]);
                    break;
                case "gatewayhostname":
                    result.gatewayhostname = SplitLine[2];
                    break;
                case "gatewayprofileusagemethod":
                    result.gatewayprofileusagemethod = int.Parse(SplitLine[2]);
                    break;
                case "gatewayusagemethod":
                    result.gatewayusagemethod = int.Parse(SplitLine[2]);
                    break;
                case "keyboardhook":
                    result.keyboardhook = int.Parse(SplitLine[2]);
                    break;
                case "negotiate security layer":
                    result.negotiate_security_layer = int.Parse(SplitLine[2]);
                    break;
                case "networkautodetect":
                    result.networkautodetect = int.Parse(SplitLine[2]);
                    break;
                case "pinconnectionbar":
                    result.pinconnectionbar = int.Parse(SplitLine[2]);
                    break;
                case "prompt for credentials":
                    result.prompt_for_credentials = int.Parse(SplitLine[2]);
                    break;
                case "prompt for credentials on client":
                    result.prompt_for_credentials_on_client = int.Parse(SplitLine[2]);
                    break;
                case "promptcredentialonce":
                    result.promptcredentialonce = int.Parse(SplitLine[2]);
                    break;
                case "public mode":
                    result.public_mode = int.Parse(SplitLine[2]);
                    break;
                case "redirectclipboard":
                    result.redirectclipboard = int.Parse(SplitLine[2]);
                    break;
                case "redirectcomports":
                    result.redirectcomports = int.Parse(SplitLine[2]);
                    break;
                case "redirectdirectx":
                    result.redirectdirectx = int.Parse(SplitLine[2]);
                    break;
                case "redirectdrives":
                    result.redirectdrives = int.Parse(SplitLine[2]);
                    break;
                case "redirectposdevices":
                    result.redirectposdevices = int.Parse(SplitLine[2]);
                    break;
                case "redirectprinters":
                    result.redirectprinters = int.Parse(SplitLine[2]);
                    break;
                case "redirectsmartcards":
                    result.redirectsmartcards = int.Parse(SplitLine[2]);
                    break;
                case "remoteapplicationcmdline":
                    result.remoteapplicationcmdline = SplitLine[2];
                    break;
                case "remoteapplicationexpandcmdline":
                    result.remoteapplicationexpandcmdline = int.Parse(SplitLine[2]);
                    break;
                case "remoteapplicationexpandworkingdir":
                    result.remoteapplicationexpandworkingdir = int.Parse(SplitLine[2]);
                    break;
                case "remoteapplicationfile":
                    result.remoteapplicationfile = SplitLine[2];
                    break;
                case "remoteapplicationfileextensions":
                    result.remoteapplicationfileextensions = SplitLine[2];
                    break;
                case "remoteapplicationicon":
                    result.remoteapplicationicon = SplitLine[2];
                    break;
                case "remoteapplicationmode":
                    result.remoteapplicationmode = int.Parse(SplitLine[2]);
                    break;
                case "remoteapplicationname":
                    result.remoteapplicationname = SplitLine[2];
                    break;
                case "remoteapplicationprogram":
                    result.remoteapplicationprogram = SplitLine[2];
                    break;
                case "screen mode id":
                    result.screen_mode_id = int.Parse(SplitLine[2]);
                    break;
                case "server port":
                    result.server_port = int.Parse(SplitLine[2]);
                    break;
                case "session bpp":
                    result.session_bpp = int.Parse(SplitLine[2]);
                    break;
                case "shell working directory":
                    result.shell_working_directory = SplitLine[2];
                    break;
                case "smart sizing":
                    result.smart_sizing = int.Parse(SplitLine[2]);
                    break;
                case "span monitors":
                    result.span_monitors = int.Parse(SplitLine[2]);
                    break;
                case "superpanaccelerationfactor":
                    result.superpanaccelerationfactor = int.Parse(SplitLine[2]);
                    break;
                case "usbdevicestoredirect":
                    result.usbdevicestoredirect = SplitLine[2];
                    break;
                case "use multimon":
                    result.use_multimon = int.Parse(SplitLine[2]);
                    break;
                case "username":
                    result.username = SplitLine[2];
                    break;
                case "videoplaybackmode":
                    result.videoplaybackmode = int.Parse(SplitLine[2]);
                    break;
                case "winposstr":
                    result.winposstr = SplitLine[2];
                    break;
                case "redirectlocation":
                    result.redirectlocation = int.Parse(SplitLine[2]);
                    break;
                case "redirectwebauthn":
                    result.redirectwebauthn = int.Parse(SplitLine[2]);
                    break;
                case "kdcproxyname":
                    result.kdcproxyname = SplitLine[2];
                    break;
                case "enablerdsaadauth":
                    result.enablerdsaadauth = int.Parse(SplitLine[2]);
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
