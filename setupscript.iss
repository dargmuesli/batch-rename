#define MyAppName "BatchRename"
#define MyAppVersion "1.0.1.0"
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
LicenseFile={#SourcePath}\LICENSE
OutputDir={#SourcePath}
OutputBaseFilename={#MyAppName}-{#MyAppVersion}-Setup
SetupIconFile={#SourcePath}\BatchRename\Resources\Images\Icons\128.ico
UninstallDisplayIcon={#SourcePath}\BatchRename\Resources\Images\Icons\128.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Files]
Source: "{#SourcePath}\BatchRename\bin\Release\BatchRename.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourcePath}\BatchRename\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{commonprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

