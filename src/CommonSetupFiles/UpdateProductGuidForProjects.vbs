Const HKEY_CURRENT_USER  = &H80000001
Set oReg=GetObject("winmgmts:{impersonationLevel=impersonate}!\\.\root\default:StdRegProv")
 
 'Update Tortoise SVN Projects
UpdateGuidValue "Software\TortoiseSVN\BugTraq Associations"

'Update Tortoise GIT Projects
UpdateGuidValue "Software\TortoiseGIT\BugTraq Associations"

sub UpdateGuidValue(keypath)
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
								oReg.SetStringValue HKEY_CURRENT_USER,sProject,aValueNames(i) ,"{55B7DC40-2D4A-46AB-8884-329A02D26EDE}"
						End If
					End If
				Next
			End If
		Next
	End If
End Sub