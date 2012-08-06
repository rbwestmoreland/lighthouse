@echo Off

rd /s /q artifacts
md artifacts

%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild ..\Lighthouse.sln /p:Configuration=Release /p:Platform="Any CPU" /p:OutDir=..\Build\artifacts\bin\ /flp:LogFile=artifacts\msbuild.log;Verbosity=Normal
::pause