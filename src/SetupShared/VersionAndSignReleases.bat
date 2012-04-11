@ECHO OFF

:: -------------------------------------------
:: Check if non mapable help switch  was used (?)
:: -------------------------------------------
IF (%1) EQU (?) GOTO ShowUsage
IF (%1) EQU (/?) GOTO ShowUsage
IF (%1) EQU (\?) GOTO ShowUsage
IF (%1) EQU (-?) GOTO ShowUsage

:: -------------------------------------------
:: Validate provided values
:: -------------------------------------------
IF (%1) EQU () GOTO ShowUsage
IF (%2) EQU () GOTO ShowUsage
IF (%3) EQU () GOTO ShowUsage

:: -------------------------------------------
:: Setup
:: -------------------------------------------
:: Set Version
SET TMVersion=%1
:: Set Configuration
SET TMConfig=%2
:: Set Build platform
SET TMPlatform=%3

:: Set paths
IF %TMPlatform% EQU x86 (
	SET TMMSI="%~dp0..\bin\%TMPlatform%\%TMConfig%\TurtleMine_32bit.msi"
) ELSE (
	SET TMMSI="%~dp0..\bin\%TMPlatform%\%TMConfig%\TurtleMine_64bit.msi"
)

:: -------------------------------------------
:: Version and Sign MSI
:: -------------------------------------------
ECHO Processing MSI for %TMConfig% %TMPlatform%
CALL :RenameWithVersion %TMMSI% %TMVersion% TMNewFile
IF /i %TMConfig% EQU RELEASE CALL :SignMSI %TMNewFile%

:: GoTo Cleanup
GOTO End

:: -------------------------------------------
:: Functions
:: -------------------------------------------
goto:eof
:RenameWithVersion
::			-- str [in] - File Path
::			-- str [in] - Version Number
::          -- res [out] - Updated File Path
SET TMFilePath=%1
SET TMVersionedName=%~n1_%2.msi
SET TMOutputPath=%~dp1%TMVersionedName%

ECHO Rename MSI
IF EXIST %TMFilePath% (
	IF EXIST %TMOutputPath% (
		ECHO File has already been renamed. Removing previous version...
		DEL %TMOutputPath% /F /Q
	)
	ECHO Renaming %TMFilePath% to %TMVersionedName%
	rename %TMFilePath% %TMVersionedName%
) ELSE (
	IF EXIST %TMOutputPath% (
		ECHO File Already Renamed! [%TMVersionedName%]
	) ELSE (
		ECHO File Not Found: %TMFilePath%
	)
)
ECHO.

( ENDLOCAL & :: RETURN VALUES
    IF "%~3" NEQ "" (SET %~3=%TMOutputPath%) ELSE ECHO.%TMOutputPath%
)

EXIT /b %ERRORLEVEL%
:: _____________________________________________________

goto:eof
:SignMSI
::			-- str [in] - File Path
ECHO Sign MSI
IF EXIST %1 (
	ECHO Signing %~nx1
	"C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\signtool.exe" sign /f ..\..\..\SetupShared\TurtleMine.pfx /d TurtleMine /du http://code.google.com/p/turtlemine/ /t http://timestamp.globalsign.com/scripts/timstamp.dll %1
) ELSE (
	ECHO File Not Found: %1
)
ECHO.

EXIT /b %ERRORLEVEL%
:: _____________________________________________________

:: -------------------------------------------
:: Cleanup And Usage
:: -------------------------------------------
:End
:: From Batch
SET TMVersion=
SET TMConfig=
SET TMPlatform=
SET TMMSI=
SET TMNewFile=
:: From Functions
SET TMFilePath=
SET TMVersionedName=
SET TMOutputPath=
goto:eof

:NoPassword
	ECHO Password File not found or unable to read password!
	GOTO End

:ShowUsage
	ECHO.
	ECHO	Usage:
	ECHO		%~nx0 [VersionNumber] [Configuration] [Platform]