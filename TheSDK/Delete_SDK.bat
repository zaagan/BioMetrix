cd /d %~dp0
if /i "%PROCESSOR_IDENTIFIER:~0,3%"=="X86" (
	echo system is x86
	regsvr32 %windir%\system32\zkemkeeper.dll -u
	del %windir%\system32\commpro.dll
	del %windir%\system32\comms.dll
	del %windir%\system32\rscagent.dll
	del %windir%\system32\rscomm.dll
	del %windir%\system32\tcpcomm.dll
	del %windir%\system32\usbcomm.dll
	del %windir%\system32\usbstd.dll
	del %windir%\system32\zkemkeeper.dll
	del %windir%\system32\zkemsdk.dll
	del %windir%\system32\plcommpro.dll
	del %windir%\system32\plcomms.dll
	del %windir%\system32\plrscagent.dll
	del %windir%\system32\plrscomm.dll
	del %windir%\system32\pltcpcomm.dll
) else (
	echo system is x64
	regsvr32 %windir%\SysWOW64\zkemkeeper.dll -u
	del %windir%\SysWOW64\commpro.dll
	del %windir%\SysWOW64\comms.dll
	del %windir%\SysWOW64\rscagent.dll
	del %windir%\SysWOW64\rscomm.dll
	del %windir%\SysWOW64\tcpcomm.dll
	del %windir%\SysWOW64\usbcomm.dll
	del %windir%\SysWOW64\usbstd.dll
	del %windir%\SysWOW64\zkemkeeper.dll
	del %windir%\SysWOW64\zkemsdk.dll
	del %windir%\SysWOW64\plcommpro.dll
	del %windir%\SysWOW64\plcomms.dll
	del %windir%\SysWOW64\plrscagent.dll
	del %windir%\SysWOW64\plrscomm.dll
	del %windir%\SysWOW64\pltcpcomm.dll
)