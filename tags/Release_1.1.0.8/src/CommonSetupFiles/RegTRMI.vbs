On Error Resume Next

'-------------------------
'Setup common objects
'-------------------------
Dim oFSO, oShell
Set oFSO = CreateObject("Scripting.FileSystemObject")
Set oShell = CreateObject("WScript.Shell")

'-------------------------
'Debug
' Uncomment the "DebugFilePath" line below to turn on debug
'-------------------------
Dim DebugFilePath
'DebugFilePath = "C:\RegTRMILog.txt"
If DebugFilePath <> "" Then
	Dim oLogFile
	Set oLogFile = oFSO.OpenTextFile(DebugFilePath, 8, True)
	oLogFile.WriteLine (WScript.ScriptName)
	oLogFile.WriteLine (Now())
End If

'-------------------------
'Get Installer Data
'-------------------------
Dim args, arrArgs, sCurDir, sState, sVersion, sRunRegAsm, sRunRegEdit
'Check if running in installer
If (Not IsEmpty(Session)) Then
	args = Session.Property("CustomActionData")
	Call OutputErrorInfo
Else
	'Check if args passed to script for install state otherwise default to "INSTALL"
	Set scriptargs = WScript.Arguments
	If scriptargs.Count > 0 Then
		args = oFSO.GetAbsolutePathName(".") & ";" & scriptargs.Item(0) & ";Test"
	Else
		args = oFSO.GetAbsolutePathName(".") & ";INSTALL;Test"
	End If
End If

'Split out passed in Args
arrArgs = Split(args, ";")
sCurDir = arrArgs(0)
sState = arrArgs(1)
sVersion = arrArgs(2)

'Clean up sCurDir for usability
If Right(sCurDir, 1) = "\" Then
	sCurDir = Left(sCurDir, Len(sCurDir) - 1)
End If

'-------------------------
'Debug
'-------------------------
If DebugFilePath <> "" Then
	oLogFile.WriteLine ("args: " & args)
	oLogFile.WriteLine ("sCurDir: " & sCurDir)
	oLogFile.WriteLine ("sState: " & sState)
	oLogFile.WriteLine ("sVersion: " & sVersion)
End If

'-------------------------
'Check Processor type
'Machines may have multiple processors but not of different types so get first
'processor type then continue.
'-------------------------
Dim oWMI, oProcessorsCol, oProcessor, sProcessorType, procType
Set oWMI = GetObject("winmgmts:\\.\root\CIMV2")
Set oProcessorsCol = oWMI.ExecQuery("SELECT * FROM Win32_Processor")
For Each oProcessor In oProcessorsCol
	'Get the Processor type which is the first part of the caption
	procType = Split(LCase(oProcessor.Caption))

	'check for 64 in the Processor type part of the Processor caption
	If InStr(procType(0), "64") Then
		sProcessorType = "64"
		Exit For
	Else
		sProcessorType = ""
		Exit For
	End If
Next

'-------------------------
'Get Windows Root Path
'-------------------------
Dim sSystemRoot
sSystemRoot = oShell.ExpandEnvironmentStrings("%SystemRoot%")

'-------------------------
'Set Framework Path
'-------------------------
Dim sFrameworkPath
sFrameworkPath = sSystemRoot & "\microsoft.net\Framework" & sProcessorType & "\v2.0.50727\"

'Validate 64bit framework folder exists and if not fall back to 32bit folder
If sProcessorType = "64" And Not oFSO.FolderExists(sFrameworkPath) then
	sProcessorType = ""
	sFrameworkPath = sSystemRoot & "\microsoft.net\Framework\v2.0.50727\"
End If

'-------------------------
'Debug
'-------------------------
If DebugFilePath <> "" Then
	oLogFile.WriteLine ("sProcessorType: " & sProcessorType)
	oLogFile.WriteLine ("sFrameworkPath: " & sFrameworkPath)
End If

'Check Action
If sState = "INSTALL" Then
	'-------------------------
	'Register
	'-------------------------
	sRunRegAsm = sFrameworkPath & "regasm.exe """ & sCurDir & "\TRMIssues.dll"" /codebase"

	'Run RegAsm
	RunCommand sRunRegAsm
  
	'-------------------------
	'Update Display Name
	'-------------------------
	sCLSID = "CLSID\{55B7DC40-2D4A-46AB-8884-329A02D26EDE}"
	sRunRegEdit = "reg add HKCR\" & sCLSID & " /ve /t REG_SZ /d ""TortoiseRedmine (" & sVersion & ")"" /f"
	
	'check for Vista or Windows 7 64bit
	If oFSO.FileExists(sSystemRoot & "\sysnative\reg.exe") Then
		sRunRegEdit = "%WINDIR%\sysnative\" & sRunRegEdit

		'Run RegEdit
		RunCommand sRunRegEdit
	Else
		If sProcessorType = "64" Then
			'For Windows XP Pro 64bit and Server 2003 64bit use WMI to force 64 bit architecture to update name in registry
			Set oCtx = CreateObject("WbemScripting.SWbemNamedValueSet")
			oCtx.Add "__ProviderArchitecture", 64
			Set oLocator = CreateObject("Wbemscripting.SWbemLocator")
			Set oServices = oLocator.ConnectServer("","root\default","","",,,,oCtx)
			Set oStdRegProv = oServices.Get("StdRegProv") 

			Set InParams = oStdRegProv.methods_("SetStringValue").InParameters.SpawnInstance_
			InParams.hDefKey = &H80000000 'HKCR
			InParams.sSubKeyName = sCLSID
			InParams.sValueName = ""
			InParams.sValue = "TortoiseRedmine (" & sVersion & ")"

			Set OutParams = oStdRegProv.ExecMethod_("SetStringValue",InParams)

			'-------------------------
			'Debug
			'-------------------------
			If DebugFilePath <> "" Then
				oLogFile.WriteLine ("SetStringValue: " & OutParams.ReturnValue)
			End If
			
			Set oStdRegProv = Nothing
			Set oServices = Nothing
			Set oLocator = Nothing
			Set oCtx = Nothing
		Else
			'Run RegEdit
			RunCommand sRunRegEdit
		End If
	End If
Else
	'-------------------------
	'Unregister
	'-------------------------
	sRunRegAsm = sFrameworkPath & "regasm.exe """ & sCurDir & "\TRMIssues.dll"" /unregister"

	'Run RegAsm
	RunCommand sRunRegAsm
End If

'-------------------------
'Debug
'-------------------------
If DebugFilePath <> "" Then
	oLogFile.WriteLine ("")
	oLogFile.Close
End If

'-------------------------
'Cleanup
'-------------------------
Set oProcessorsCol = Nothing
Set oProcessor = Nothing
Set oWMI = Nothing
Set oShell = Nothing
Set oFSO = Nothing

'-------------------------
'Helper methods
'-------------------------
Sub RunCommand(cmdToRun)
	If DebugFilePath <> "" Then
		oLogFile.WriteLine ("cmdToRun: " & cmdToRun)
	End If
	
	oShell.Run cmdToRun, 0, True
	Call OutputErrorInfo
	
	If DebugFilePath <> "" Then
		oLogFile.WriteLine ("cmd completed")
	End If
End Sub

Sub OutputErrorInfo()
	If Err.Number <> 0 Then
		If DebugFilePath <> "" Then
			oLogFile.WriteLine ("Exception:" & vbCrLf & "    Error number: " & Err.Number & vbCrLf & "    Error description: " & Err.Description & vbCrLf & "    Error Source: " & Err.Source)
			oLogFile.WriteLine ("")
		End If
		'Clear error and continue
		Err.Clear
	End If
End Sub
