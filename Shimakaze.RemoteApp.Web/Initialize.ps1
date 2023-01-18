#requires -version 5
#requires -runasadministrator
#requires -modules PKI

using namespace System.Runtime.InteropServices
using namespace System.Security

function Get-String {
  param (
    [System.Security.SecureString]
    $Source
  )
  $ptr = [System.IntPtr]::Zero
  try {
    $ptr = [Marshal]::SecureStringToBSTR($Source)
    [Marshal]::PtrToStringBSTR($ptr)
  }
  finally {
    [Marshal]::ZeroFreeBSTR($ptr)
  }
}
function Get-SecureString {
  while ($true) {
    $pwd1 = Read-Host -Prompt "Please enter your certificate password" -AsSecureString
    $pwd2 = Read-Host -Prompt "Please confirm your password" -AsSecureString
    $pwd1r = Get-String $pwd1
    $pwd2r = Get-String $pwd2
    if ($pwd1r -eq $pwd2r) {
      return $pwd1
    }
    Write-Error "Two inconsistent passwords"
  }
}
$dns = [System.Net.Dns]::GetHostName()
$hostname = Read-Host -Prompt "Please enter your host name [$dns]"
if ([string]::IsNullOrWhiteSpace($hostname)) {
  $hostname = $dns
}

$spwd = Get-SecureString

New-SelfSignedCertificate `
  -DnsName $hostname `
  -CertStoreLocation "Cert:\CurrentUser\My" `
  -FriendlyName "Shimakaze RDS" `
| Export-PfxCertificate `
  -FilePath ".\Shimakaze.RemoteApp.Web.pfx" `
  -Password $spwd

$obj = Get-Content "$PSScriptRoot\appsettings.json" | ConvertFrom-Json
$obj.AllowedHosts = $hostname
$obj.StaticResourcesPath = "$PSScriptRoot\wwwroot"
$obj.DefaultIconPath = "$([System.Environment]::GetFolderPath('System'))\shell32.dll"
$obj.Kestrel.Certificates.Default.Password = Get-String $spwd
$obj | ConvertTo-Json -Depth 5 | Out-File "$PSScriptRoot\appsettings.json" -Force

New-Item -ItemType Directory -Path "wwwroot"
