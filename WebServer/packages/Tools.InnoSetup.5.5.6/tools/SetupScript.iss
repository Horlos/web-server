;------------------------------------------------------------------------------
;   ���������� ��������� ���������
;------------------------------------------------------------------------------

; ��� ����������
#define   Name       GetStringFileInfo("..\..\..\WebServer\bin\Release\WebServer.exe", "ProductName")
; ������ ����������
#define   Version    GetFileVersion("..\..\..\WebServer\bin\Release\WebServer.exe")
; �����-�����������
#define   Publisher  GetFileCompany("..\..\..\WebServer\bin\Release\WebServer.exe")
; ��� ������������ ������
#define   ExeName    "WebServer.exe"

;------------------------------------------------------------------------------
;   ��������� ���������
;------------------------------------------------------------------------------
[Setup]

; ���������� ������������� ����������, 
;��������������� ����� Tools -> Generate GUID
AppId={{9B948383-9F68-4F19-86D5-E3A7252A5EF7}

; ������ ����������, ������������ ��� ���������
AppName={#Name}
AppVersion={#Version}
AppPublisher={#Publisher}

; ���� ��������� ��-���������
DefaultDirName={pf}\{#Name}
; ��� ������ � ���� "����"
DefaultGroupName={#Name}

; �������, ���� ����� ������� ��������� setup � ��� ������������ �����
OutputDir=..\..\..\Install
OutputBaseFileName=Setup

; ���� ������
;SetupIconFile=E:\work\Mirami\Mirami\icon.ico

; ��������� ������
Compression=lzma
SolidCompression=yes


;------------------------------------------------------------------------------
;   ����������� - ��������� ������, ������� ���� ��������� ��� ���������
;------------------------------------------------------------------------------
[Tasks]
; �������� ������ �� ������� �����
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked


;------------------------------------------------------------------------------
;   �����, ������� ���� �������� � ����� �����������
;------------------------------------------------------------------------------
[Files]

; ����������� ����
Source: "..\..\..\WebServer\bin\Release\WebServer.exe"; DestDir: "{app}"; Flags: ignoreversion

; ������������� �������
Source: "..\..\..\WebServer\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

; .NET Framework 4.0
Source: "..\..\..\Install\dotNetFx40_Full_x86_x64.exe"; DestDir: "{tmp}"; Flags: deleteafterinstall; Check: not IsRequiredDotNetDetected

;------------------------------------------------------------------------------
;   ��������� �����������, ��� �� ������ ����� ������
;------------------------------------------------------------------------------ 
[Icons]

Name: "{group}\{#Name}"; Filename: "{app}\{#ExeName}"

Name: "{commondesktop}\{#Name}"; Filename: "{app}\{#ExeName}"; Tasks: desktopicon


;------------------------------------------------------------------------------
;   ������ ���� ���������� �� ���������� �����
;------------------------------------------------------------------------------
[Code]
#include "dotnet.pas"


[Run]
;------------------------------------------------------------------------------
;   ������ ������� ����� �����������
;------------------------------------------------------------------------------
Filename: {tmp}\dotNetFx40_Full_x86_x64.exe; Parameters: "/q:a /c:""install /l /q"""; Check: not IsRequiredDotNetDetected; StatusMsg: Microsoft Framework 4.0 is installed. Please wait...