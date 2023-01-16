using System.Text;

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

    public void SaveRDPfile(string FilePath, bool SaveDefaultSettings = false)
    {
        // while (!(FileLocked == "No locks"))
        // {
        //     if ((MessageBox.Show("The file " + FilePath + " is currently locked.  Lock information:" + FileLocked + Environment.NewLine + "Do you want to try again?", "File Locked", MessageBoxButtons.YesNo) == DialogResult.Yes))
        //         FileLocked = LockCheck.CheckLock(FilePath);
        //     else
        //     {
        //         MessageBox.Show("The following file will not be copied:" + Environment.NewLine + FilePath);
        //         SkipFile = true;
        //         FileLocked = "No locks";
        //     }
        // }
        File.WriteAllText(FilePath, GetRDPstring(SaveDefaultSettings));
    }

    public string GetRDPstring(bool SaveDefaultSettings = false)
    {
        StringBuilder RDPstring = new();

        RDPFile DefaultRDP = new RDPFile();

        if (SaveDefaultSettings || DefaultRDP.administrative_session != administrative_session)
            RDPstring.AppendLine("administrative session" + ":" + administrative_session.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + administrative_session.ToString());
        if (SaveDefaultSettings || DefaultRDP.allow_desktop_composition != allow_desktop_composition)
            RDPstring.AppendLine("allow desktop composition" + ":" + allow_desktop_composition.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + allow_desktop_composition.ToString());
        if (SaveDefaultSettings || DefaultRDP.allow_font_smoothing != allow_font_smoothing)
            RDPstring.AppendLine("allow font smoothing" + ":" + allow_font_smoothing.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + allow_font_smoothing.ToString());
        if (SaveDefaultSettings || DefaultRDP.alternate_full_address != alternate_full_address)
            RDPstring.AppendLine("alternate full address" + ":" + alternate_full_address.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + alternate_full_address.ToString());
        if (SaveDefaultSettings || DefaultRDP.alternate_shell != alternate_shell)
            RDPstring.AppendLine("alternate shell" + ":" + alternate_shell.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + alternate_shell.ToString());
        if (SaveDefaultSettings || DefaultRDP.audiocapturemode != audiocapturemode)
            RDPstring.AppendLine("audiocapturemode" + ":" + audiocapturemode.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + audiocapturemode.ToString());
        if (SaveDefaultSettings || DefaultRDP.audiomode != audiomode)
            RDPstring.AppendLine("audiomode" + ":" + audiomode.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + audiomode.ToString());
        if (SaveDefaultSettings || DefaultRDP.audioqualitymode != audioqualitymode)
            RDPstring.AppendLine("audioqualitymode" + ":" + audioqualitymode.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + audioqualitymode.ToString());
        if (SaveDefaultSettings || DefaultRDP.authentication_level != authentication_level)
            RDPstring.AppendLine("authentication level" + ":" + authentication_level.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + authentication_level.ToString());
        if (SaveDefaultSettings || DefaultRDP.autoreconnect_max_retries != autoreconnect_max_retries)
            RDPstring.AppendLine("autoreconnect max retries" + ":" + autoreconnect_max_retries.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + autoreconnect_max_retries.ToString());
        if (SaveDefaultSettings || DefaultRDP.autoreconnection_enabled != autoreconnection_enabled)
            RDPstring.AppendLine("autoreconnection enabled" + ":" + autoreconnection_enabled.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + autoreconnection_enabled.ToString());
        if (SaveDefaultSettings || DefaultRDP.bandwidthautodetect != bandwidthautodetect)
            RDPstring.AppendLine("bandwidthautodetect" + ":" + bandwidthautodetect.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + bandwidthautodetect.ToString());
        if (SaveDefaultSettings || DefaultRDP.bitmapcachepersistenable != bitmapcachepersistenable)
            RDPstring.AppendLine("bitmapcachepersistenable" + ":" + bitmapcachepersistenable.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + bitmapcachepersistenable.ToString());
        if (SaveDefaultSettings || DefaultRDP.bitmapcachesize != bitmapcachesize)
            RDPstring.AppendLine("bitmapcachesize" + ":" + bitmapcachesize.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + bitmapcachesize.ToString());
        if (SaveDefaultSettings || DefaultRDP.compression != compression)
            RDPstring.AppendLine("compression" + ":" + compression.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + compression.ToString());
        if (SaveDefaultSettings || DefaultRDP.connect_to_console != connect_to_console)
            RDPstring.AppendLine("connect to console" + ":" + connect_to_console.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + connect_to_console.ToString());
        if (SaveDefaultSettings || DefaultRDP.connection_type != connection_type)
            RDPstring.AppendLine("connection type" + ":" + connection_type.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + connection_type.ToString());
        if (SaveDefaultSettings || DefaultRDP.desktop_size_id != desktop_size_id)
            RDPstring.AppendLine("desktop size id" + ":" + desktop_size_id.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + desktop_size_id.ToString());
        if (SaveDefaultSettings || DefaultRDP.desktopheight != desktopheight)
            RDPstring.AppendLine("desktopheight" + ":" + desktopheight.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + desktopheight.ToString());
        if (SaveDefaultSettings || DefaultRDP.desktopwidth != desktopwidth)
            RDPstring.AppendLine("desktopwidth" + ":" + desktopwidth.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + desktopwidth.ToString());
        if (SaveDefaultSettings || DefaultRDP.devicestoredirect != devicestoredirect)
            RDPstring.AppendLine("devicestoredirect" + ":" + devicestoredirect.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + devicestoredirect.ToString());
        if (SaveDefaultSettings || DefaultRDP.disable_ctrl_alt_del != disable_ctrl_alt_del)
            RDPstring.AppendLine("disable ctrl+alt+del" + ":" + disable_ctrl_alt_del.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + disable_ctrl_alt_del.ToString());
        if (SaveDefaultSettings || DefaultRDP.disable_full_window_drag != disable_full_window_drag)
            RDPstring.AppendLine("disable full window drag" + ":" + disable_full_window_drag.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + disable_full_window_drag.ToString());
        if (SaveDefaultSettings || DefaultRDP.disable_menu_anims != disable_menu_anims)
            RDPstring.AppendLine("disable menu anims" + ":" + disable_menu_anims.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + disable_menu_anims.ToString());
        if (SaveDefaultSettings || DefaultRDP.disable_themes != disable_themes)
            RDPstring.AppendLine("disable themes" + ":" + disable_themes.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + disable_themes.ToString());
        if (SaveDefaultSettings || DefaultRDP.disable_wallpaper != disable_wallpaper)
            RDPstring.AppendLine("disable wallpaper" + ":" + disable_wallpaper.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + disable_wallpaper.ToString());
        if (SaveDefaultSettings || DefaultRDP.disableconnectionsharing != disableconnectionsharing)
            RDPstring.AppendLine("disableconnectionsharing" + ":" + disableconnectionsharing.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + disableconnectionsharing.ToString());
        if (SaveDefaultSettings || DefaultRDP.disableremoteappcapscheck != disableremoteappcapscheck)
            RDPstring.AppendLine("disableremoteappcapscheck" + ":" + disableremoteappcapscheck.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + disableremoteappcapscheck.ToString());
        if (SaveDefaultSettings || DefaultRDP.displayconnectionbar != displayconnectionbar)
            RDPstring.AppendLine("displayconnectionbar" + ":" + displayconnectionbar.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + displayconnectionbar.ToString());
        if (SaveDefaultSettings || DefaultRDP.domain != domain)
            RDPstring.AppendLine("domain" + ":" + domain.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + domain.ToString());
        if (SaveDefaultSettings || DefaultRDP.drivestoredirect != drivestoredirect)
            RDPstring.AppendLine("drivestoredirect" + ":" + drivestoredirect.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + drivestoredirect.ToString());
        if (SaveDefaultSettings || DefaultRDP.enablecredsspsupport != enablecredsspsupport)
            RDPstring.AppendLine("enablecredsspsupport" + ":" + enablecredsspsupport.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + enablecredsspsupport.ToString());
        if (SaveDefaultSettings || DefaultRDP.enablesuperpan != enablesuperpan)
            RDPstring.AppendLine("enablesuperpan" + ":" + enablesuperpan.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + enablesuperpan.ToString());
        if (SaveDefaultSettings || DefaultRDP.full_address != full_address)
            RDPstring.AppendLine("full address" + ":" + full_address.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + full_address.ToString());
        if (SaveDefaultSettings || DefaultRDP.gatewaycredentialssource != gatewaycredentialssource)
            RDPstring.AppendLine("gatewaycredentialssource" + ":" + gatewaycredentialssource.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + gatewaycredentialssource.ToString());
        if (SaveDefaultSettings || DefaultRDP.gatewayhostname != gatewayhostname)
            RDPstring.AppendLine("gatewayhostname" + ":" + gatewayhostname.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + gatewayhostname.ToString());
        if (SaveDefaultSettings || DefaultRDP.gatewayprofileusagemethod != gatewayprofileusagemethod)
            RDPstring.AppendLine("gatewayprofileusagemethod" + ":" + gatewayprofileusagemethod.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + gatewayprofileusagemethod.ToString());
        if (SaveDefaultSettings || DefaultRDP.gatewayusagemethod != gatewayusagemethod)
            RDPstring.AppendLine("gatewayusagemethod" + ":" + gatewayusagemethod.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + gatewayusagemethod.ToString());
        if (SaveDefaultSettings || DefaultRDP.keyboardhook != keyboardhook)
            RDPstring.AppendLine("keyboardhook" + ":" + keyboardhook.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + keyboardhook.ToString());
        if (SaveDefaultSettings || DefaultRDP.negotiate_security_layer != negotiate_security_layer)
            RDPstring.AppendLine("negotiate security layer" + ":" + negotiate_security_layer.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + negotiate_security_layer.ToString());
        if (SaveDefaultSettings || DefaultRDP.networkautodetect != networkautodetect)
            RDPstring.AppendLine("networkautodetect" + ":" + networkautodetect.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + networkautodetect.ToString());
        // If SaveDefaultSettings Or Not DefaultRDP.password_51 = password_51 Then RDPstring.AppendLine( "password 51" & ":" & password_51.GetType().ToString.Replace("System.", string.Empty).ToLower.Substring(0, 1) & ":" & password_51.ToString & vbCrLf
        if (SaveDefaultSettings || DefaultRDP.pinconnectionbar != pinconnectionbar)
            RDPstring.AppendLine("pinconnectionbar" + ":" + pinconnectionbar.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + pinconnectionbar.ToString());
        if (SaveDefaultSettings || DefaultRDP.prompt_for_credentials != prompt_for_credentials)
            RDPstring.AppendLine("prompt for credentials" + ":" + prompt_for_credentials.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + prompt_for_credentials.ToString());
        if (SaveDefaultSettings || DefaultRDP.prompt_for_credentials_on_client != prompt_for_credentials_on_client)
            RDPstring.AppendLine("prompt for credentials on client" + ":" + prompt_for_credentials_on_client.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + prompt_for_credentials_on_client.ToString());
        if (SaveDefaultSettings || DefaultRDP.promptcredentialonce != promptcredentialonce)
            RDPstring.AppendLine("promptcredentialonce" + ":" + promptcredentialonce.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + promptcredentialonce.ToString());
        if (SaveDefaultSettings || DefaultRDP.public_mode != public_mode)
            RDPstring.AppendLine("public mode" + ":" + public_mode.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + public_mode.ToString());
        if (SaveDefaultSettings || DefaultRDP.redirectclipboard != redirectclipboard)
            RDPstring.AppendLine("redirectclipboard" + ":" + redirectclipboard.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + redirectclipboard.ToString());
        if (SaveDefaultSettings || DefaultRDP.redirectcomports != redirectcomports)
            RDPstring.AppendLine("redirectcomports" + ":" + redirectcomports.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + redirectcomports.ToString());
        if (SaveDefaultSettings || DefaultRDP.redirectdirectx != redirectdirectx)
            RDPstring.AppendLine("redirectdirectx" + ":" + redirectdirectx.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + redirectdirectx.ToString());
        if (SaveDefaultSettings || DefaultRDP.redirectdrives != redirectdrives)
            RDPstring.AppendLine("redirectdrives" + ":" + redirectdrives.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + redirectdrives.ToString());
        if (SaveDefaultSettings || DefaultRDP.redirectposdevices != redirectposdevices)
            RDPstring.AppendLine("redirectposdevices" + ":" + redirectposdevices.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + redirectposdevices.ToString());
        if (SaveDefaultSettings || DefaultRDP.redirectprinters != redirectprinters)
            RDPstring.AppendLine("redirectprinters" + ":" + redirectprinters.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + redirectprinters.ToString());
        if (SaveDefaultSettings || DefaultRDP.redirectsmartcards != redirectsmartcards)
            RDPstring.AppendLine("redirectsmartcards" + ":" + redirectsmartcards.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + redirectsmartcards.ToString());
        if (SaveDefaultSettings || DefaultRDP.remoteapplicationcmdline != remoteapplicationcmdline)
            RDPstring.AppendLine("remoteapplicationcmdline" + ":" + remoteapplicationcmdline.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + remoteapplicationcmdline.ToString());
        if (SaveDefaultSettings || DefaultRDP.remoteapplicationexpandcmdline != remoteapplicationexpandcmdline)
            RDPstring.AppendLine("remoteapplicationexpandcmdline" + ":" + remoteapplicationexpandcmdline.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + remoteapplicationexpandcmdline.ToString());
        if (SaveDefaultSettings || DefaultRDP.remoteapplicationexpandworkingdir != remoteapplicationexpandworkingdir)
            RDPstring.AppendLine("remoteapplicationexpandworkingdir" + ":" + remoteapplicationexpandworkingdir.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + remoteapplicationexpandworkingdir.ToString());
        if (SaveDefaultSettings || DefaultRDP.remoteapplicationfile != remoteapplicationfile)
            RDPstring.AppendLine("remoteapplicationfile" + ":" + remoteapplicationfile.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + remoteapplicationfile.ToString());
        if (SaveDefaultSettings || DefaultRDP.remoteapplicationfileextensions != remoteapplicationfileextensions)
            RDPstring.AppendLine("remoteapplicationfileextensions" + ":" + remoteapplicationfileextensions.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + remoteapplicationfileextensions.ToString());
        if (SaveDefaultSettings || DefaultRDP.remoteapplicationicon != remoteapplicationicon)
            RDPstring.AppendLine("remoteapplicationicon" + ":" + remoteapplicationicon.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + remoteapplicationicon.ToString());
        if (SaveDefaultSettings || DefaultRDP.remoteapplicationmode != remoteapplicationmode)
            RDPstring.AppendLine("remoteapplicationmode" + ":" + remoteapplicationmode.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + remoteapplicationmode.ToString());
        if (SaveDefaultSettings || DefaultRDP.remoteapplicationname != remoteapplicationname)
            RDPstring.AppendLine("remoteapplicationname" + ":" + remoteapplicationname.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + remoteapplicationname.ToString());
        if (SaveDefaultSettings || DefaultRDP.remoteapplicationprogram != remoteapplicationprogram)
            RDPstring.AppendLine("remoteapplicationprogram" + ":" + remoteapplicationprogram.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + remoteapplicationprogram.ToString());
        if (SaveDefaultSettings || DefaultRDP.screen_mode_id != screen_mode_id)
            RDPstring.AppendLine("screen mode id" + ":" + screen_mode_id.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + screen_mode_id.ToString());
        if (SaveDefaultSettings || DefaultRDP.server_port != server_port)
            RDPstring.AppendLine("server port" + ":" + server_port.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + server_port.ToString());
        if (SaveDefaultSettings || DefaultRDP.session_bpp != session_bpp)
            RDPstring.AppendLine("session bpp" + ":" + session_bpp.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + session_bpp.ToString());
        if (SaveDefaultSettings || DefaultRDP.shell_working_directory != shell_working_directory)
            RDPstring.AppendLine("shell working directory" + ":" + shell_working_directory.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + shell_working_directory.ToString());
        if (SaveDefaultSettings || DefaultRDP.smart_sizing != smart_sizing)
            RDPstring.AppendLine("smart sizing" + ":" + smart_sizing.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + smart_sizing.ToString());
        if (SaveDefaultSettings || DefaultRDP.span_monitors != span_monitors)
            RDPstring.AppendLine("span monitors" + ":" + span_monitors.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + span_monitors.ToString());
        if (SaveDefaultSettings || DefaultRDP.superpanaccelerationfactor != superpanaccelerationfactor)
            RDPstring.AppendLine("superpanaccelerationfactor" + ":" + superpanaccelerationfactor.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + superpanaccelerationfactor.ToString());
        if (SaveDefaultSettings || DefaultRDP.usbdevicestoredirect != usbdevicestoredirect)
            RDPstring.AppendLine("usbdevicestoredirect" + ":" + usbdevicestoredirect.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + usbdevicestoredirect.ToString());
        if (SaveDefaultSettings || DefaultRDP.use_multimon != use_multimon)
            RDPstring.AppendLine("use multimon" + ":" + use_multimon.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + use_multimon.ToString());
        if (SaveDefaultSettings || DefaultRDP.username != username)
            RDPstring.AppendLine("username" + ":" + username.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + username.ToString());
        if (SaveDefaultSettings || DefaultRDP.videoplaybackmode != videoplaybackmode)
            RDPstring.AppendLine("videoplaybackmode" + ":" + videoplaybackmode.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + videoplaybackmode.ToString());
        if (SaveDefaultSettings || DefaultRDP.winposstr != winposstr)
            RDPstring.AppendLine("winposstr" + ":" + winposstr.GetType().ToString().Replace("System.", string.Empty).ToLower().Substring(0, 1) + ":" + winposstr.ToString());

        return RDPstring.ToString();
    }

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
            }
        }
        return result;
    }
}
