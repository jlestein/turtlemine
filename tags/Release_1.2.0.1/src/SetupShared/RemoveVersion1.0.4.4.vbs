'This Script file uses MSIZAP to remove version 1.0.4.4 of the TortoiseSVN Redmine Issues Plugin if found

'Get current Directory from Installer
curdir = Session.Property("CustomActionData")

'Product Code for version 1.0.4.4
ProductCode="{2B40A314-5C56-407A-BF4F-B1B0C23D015F}"

'Retrieve 1.0.4.4 version from registry to confirm installation
const HKEY_LOCAL_MACHINE = &H80000002
Set oReg=GetObject("winmgmts:{impersonationLevel=impersonate}!\\.\root\default:StdRegProv")
sKeyPath = "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\" & ProductCode
sValueName = "DisplayVersion"
oReg.GetStringValue HKEY_LOCAL_MACHINE,sKeyPath,sValueName,sVersionFound
Set oReg = Nothing

If sVersionFound = "1.0.44" Then
	'Remove registry entry for version 1.0.4.4
	Set WshShell = CreateObject("WScript.Shell")
	RunPath = """" & curdir & "msizap"" TW! " & ProductCode
	WshShell.Run RunPath, 0, false
	
	'Remove program files directory for version 1.0.4.4
	On Error Resume Next
	ProgramFiles = wshShell.ExpandEnvironmentStrings("%ProgramFiles%")
	Set wshShell = Nothing
	Set fso = CreateObject("Scripting.FileSystemObject") 
	fso.DeleteFolder ProgramFiles & "\TortoiseSVN Redmine Issues Plugin x86", true
	Set fso = Nothing
End If