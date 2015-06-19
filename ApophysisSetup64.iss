; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Apophysis 7x (64 bit)"
#define MyAppVersion "3.0x"
#define MyAppPublisher "XyrusWorx"
#define MyAppURL "http://www.xyrus-worx.org/"
#define MyAppExeName "Apophysis7X64.exe"

[Setup]
AppId={{5C65BD77-C960-48AC-BFB3-B96ACEEFF456}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
LicenseFile=Assets\ApophysisLicense.txr
InfoBeforeFile=Assets\ApophysisReadme.txt
OutputBaseFilename=ApophysisSetup64
OutputDir=..\..\Out\deploy\x64
SetupIconFile=Assets\ApophysisIcon.ico
Compression=lzma
SolidCompression=yes
ArchitecturesAllowed=x64
ArchitecturesInstallIn64BitMode=x64

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Files]
Source: "..\..\Out\x64\Apophysis7X.exe"; DestDir: "{app}"; DestName: Apophysis7X64.exe; Flags: ignoreversion
; -gk- doesn't compile in build constellation
; Source: "..\..\Out\x64\Plugins\"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; Source: "..\..\Out\x64\Languages\"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; Source: "..\..\Out\x64\Images\"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

