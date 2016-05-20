#define MyAppName "BatchRename"
#define MyAppVersion "1.0"
#define MyAppPublisher "Jonas Thelemann"
#define MyAppURL "https://jonas-thelemann.de/"
#define MyAppExeName "BatchRename.exe"

[Setup]
AppId={{A440B702-744F-4631-9773-70527A1D39A9}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DisableProgramGroupPage=yes
LicenseFile=D:\Dokumente\Inno Setup\Lizenzen\GNU GPL 3.txt
OutputDir=D:\Dokumente\Visual Studio 2015\Projects\BatchRename\BatchRename
OutputBaseFilename=BatchRename-1.0-Setup
SetupIconFile=D:\Dokumente\Visual Studio 2015\Projects\BatchRename\BatchRename\BatchRename\BatchRename.ico
UninstallDisplayIcon=D:\Dokumente\Visual Studio 2015\Projects\BatchRename\BatchRename\BatchRename\BatchRename.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Files]
Source: "D:\Dokumente\Visual Studio 2015\Projects\BatchRename\BatchRename\BatchRename\bin\Release\BatchRename.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Dokumente\Visual Studio 2015\Projects\BatchRename\BatchRename\BatchRename\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{commonprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

