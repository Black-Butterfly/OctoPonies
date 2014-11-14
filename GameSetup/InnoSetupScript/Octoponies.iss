#define MyAppName "Octoponies"
#define MyAppVersion "0.1"
#define MyAppPublisher "Octoponies"
#define MyAppExeName "Octoponies.exe"

[Setup]
AppId={{F37B5335-7C77-4847-A431-F12E0B635611}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
OutputBaseFilename=Octopoines_setup
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "french"; MessagesFile: "compiler:Languages\French.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
; Don't forget to change this path for your PC
Source: "C:\Users\jerome\Desktop\UnityProject\Octoponies.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\jerome\Desktop\UnityProject\Octoponies_Data\*"; DestDir: "{app}\Octoponies_Data"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

