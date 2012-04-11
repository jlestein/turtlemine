On Error Resume Next

'-------------------------
'Setup common objects
'-------------------------
Dim oFSO, oReg
Const HKEY_CURRENT_USER  = &H80000001
Set oFSO = CreateObject("Scripting.FileSystemObject")
Set oReg=GetObject("winmgmts:{impersonationLevel=impersonate}!\\.\root\default:StdRegProv")

'-------------------------
'Debug
' Uncomment the "DebugFilePath" line below to turn on debug
'-------------------------
Dim DebugFilePath
'DebugFilePath = "C:\UpdateGuidTRMILog.txt"
If DebugFilePath <> "" Then
	Dim oLogFile
	Set oLogFile = oFSO.OpenTextFile(DebugFilePath, 8, True)
	oLogFile.WriteLine (WScript.ScriptName)
	oLogFile.WriteLine (Now())
End If

'-------------------------
'Get Installer Data
'-------------------------
Dim sProcessorType, scriptargs
'Check if running in installer
If (Not IsEmpty(Session)) Then
	sProcessorType = Session.Property("CustomActionData")
	Call OutputErrorInfo
Else
	'Check if args passed to script for install state otherwise default to "INSTALL"
	Set scriptargs = WScript.Arguments
	If scriptargs.Count > 0 Then
		sProcessorType = scriptargs.Item(0)
	Else
		sProcessorType = "32"
	End If
End If

'-------------------------
'Debug
'-------------------------
If DebugFilePath <> "" Then
	oLogFile.WriteLine ("sProcessorType: " & sProcessorType)
End If

'-------------------------
'Update Guids
'-------------------------
 
'Update Tortoise SVN Projects
UpdateGuidValue "Software\TortoiseSVN\BugTraq Associations", sProcessorType

'Update Tortoise GIT Projects
UpdateGuidValue "Software\TortoiseGIT\BugTraq Associations", sProcessorType

'Update Tortoise HG Projects
'TODO

'-------------------------
'Debug
'-------------------------
If DebugFilePath <> "" Then
	oLogFile.WriteLine ("")
	oLogFile.Close
	set oLogFile = Nothing
End If

'-------------------------
'Cleanup
'-------------------------
Set oReg = Nothing
set oFSO = Nothing

'-------------------------
'Helper methods
'-------------------------
sub UpdateGuidValue(keypath, procType)
	Dim iRC, aProjectKeys, sProject, aValueNames, aValueTypes, sval
	'Get project keys
	iRC = oReg.EnumKey(HKEY_CURRENT_USER, keypath, aProjectKeys)
	
	'Make sure we found projects
	If iRC = 0 And IsArray(aProjectKeys) Then
		'For each project check for the "Provider" key
		For Each projectkey In aProjectKeys
			sProject = keypath & "\" & projectkey
			iRC = oReg.EnumValues(HKEY_CURRENT_USER, sProject, aValueNames, aValueTypes)
		
			'Make sure we found values
			If iRC = 0 And IsArray(aProjectKeys) Then
				'Check through values for the "Provider" key
				For i=0 To UBound(aValueNames)
					If aValueNames(i) = "Provider" Then
						'Check if it matches the previous TRMIssues GUID and if so update it to the new one
						oReg.GetStringValue HKEY_CURRENT_USER,sProject,aValueNames(i) ,sval
						If sval = "{5870B3F1-8393-4C83-ACED-1D5E803A4F2B}" Then
							If sProcessorType = "32" Then
								oReg.SetStringValue HKEY_CURRENT_USER, sProject, aValueNames(i), "{55B7DC40-2D4A-46AB-8884-329A02D26EDE}"
							Else
								oReg.SetStringValue HKEY_CURRENT_USER, sProject, aValueNames(i) ,"{55B7DC40-2D4A-46AB-8884-329A02D26EDF}"
							End If
						End If
						'Check if had 32bit guid and installing 64bit
						If sProcessorType = "64" And sval = "{55B7DC40-2D4A-46AB-8884-329A02D26EDE}" Then
							oReg.SetStringValue HKEY_CURRENT_USER, sProject, aValueNames(i) ,"{55B7DC40-2D4A-46AB-8884-329A02D26EDF}"
						End If
					End If
				Next
			End If
		Next
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