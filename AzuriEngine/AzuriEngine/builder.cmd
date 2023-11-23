@echo off

REM This tool builds AzuriEngine into .exe files.
REM It is not required to run AzuriEngine, but it is required to build it.

REM If you have this script without permission, please delete it and do not share it.
REM If you have this script with permission, please do not share it.

REM If this script is found online, it means the source code of AzuriEngine has been leaked.
REM On that day, the source code will be made public, and AzuriEngine will be discontinued.

REM Check if the "-dllonly" flag is provided as a command-line argument
set "dllonly=false"
for %%x in (%*) do (
    if /I "%%x"=="-dllonly" set "dllonly=true"
)

if "%dllonly%"=="true" (
    goto dllonlybuild
)

REM Regular build process
echo AzureBlueprinter:  Building AzuriDataHandler.dll and AzuriEngine.exe
REM First Build AzuriEngine.cs into AzuriDataHandler.dll standalone.
REM using dotnet, build AzuriDataHandler.csproj into AzuriDataHandler.dll
REM folderpath: ..\Dhandler\AzuriDataHandler.csproj
cd C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\
dotnet build C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\Dhandler\AzuriDataHandler.csproj -c Release -o C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\Dhandler\bin\Release\Dlls
if not exist C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\Dhandler\bin\Release\Dlls\AzuriDataHandler.dll (
    goto buildfail
)

echo AzureBlueprinter:  Built AzuriDataHandler.dll
echo AzureBlueprinter:  Moving AzuriDataHandler.dll C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\Libs
move C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\Dhandler\bin\Release\Dlls\AzuriDataHandler.dll C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\Libs
echo AzureBlueprinter:  Moved AzuriDataHandler.dll
echo AzureBlueprinter:  Copying Libs\AzuriDataHandler.dll to C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\FinalRelease\
REM if copy C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\Libs\AzuriDataHandler.dll C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\FinalRelease\AzuriDataHandler.dll file already exists, overwrite it.
copy C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\Libs\AzuriDataHandler.dll C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\FinalRelease\AzuriDataHandler.dll /y
echo AzureBlueprinter:  Copied Libs\AzuriDataHandler.dll
echo AzureBlueprinter:  Cleaning Up Dhandler...
rmdir /s /q C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\Dhandler\bin
rmdir /s /q C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\Dhandler\obj
echo AzureBlueprinter:  Cleaned Up Dhandler
echo AzureBlueprinter:  Moving on...

REM build C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\AzuriEngine.csproj into AzuriEngine.exe
echo AzureBlueprinter:  Building AzuriEngine.exe
dotnet build AzuriEngine.csproj -c Release -o bin\Release\Exes
if not exist C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\bin\Release\Exes\AzuriEngine.exe (
    goto buildfail
)

echo AzureBlueprinter:  Built AzuriEngine.exe
echo AzureBlueprinter:  Copying AzuriEngine to C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\FinalRelease\
copy bin\Release\Exes\ C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\FinalRelease\ /y
echo AzureBlueprinter:  Copied AzuriEngine.exe

:end
echo AzureBlueprinter:  Build succeeded. Please check the FinalRelease folder.
echo AzureBlueprinter:  Press any key to continue...
pause

exit /b

:dllonlybuild
echo AzureBlueprinter:  Building AzuriDataHandler.dll (DLL only)
REM using dotnet, build AzuriDataHandler.csproj into AzuriDataHandler.dll
REM folderpath: ..\Dhandler\AzuriDataHandler.csproj
cd C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\
dotnet build C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\Dhandler\AzuriDataHandler.csproj -c Release -o C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\Dhandler\bin\Release\Dlls
if not exist C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\Dhandler\bin\Release\Dlls\AzuriDataHandler.dll (
    goto buildfail
)

echo AzureBlueprinter:  Built AzuriDataHandler.dll
echo AzureBlueprinter:  Moving AzuriDataHandler.dll C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\Libs
move C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\Dhandler\bin\Release\Dlls\AzuriDataHandler.dll C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\Libs
echo AzureBlueprinter:  Moved AzuriDataHandler.dll
echo AzureBlueprinter:  Copied AzuriDataHandler.dll (DLL only) to C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\FinalRelease\
REM if copy C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\Libs\AzuriDataHandler.dll C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\FinalRelease\AzuriDataHandler.dll file already exists, overwrite it.
copy C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\Libs\AzuriDataHandler.dll C:\Users\alexm\source\repos\AzuriEngine\AzuriEngine\FinalRelease\AzuriDataHandler.dll /y
echo AzureBlueprinter:  Copied AzuriDataHandler.dll (DLL only)

:end
echo AzureBlueprinter:  DLL-only build succeeded. Please check the FinalRelease folder for the DLL.
echo AzureBlueprinter:  Press any key to continue...
pause

exit /b

:buildfail
echo AzureBlueprinter:  Build failed. Please check the error message above.
echo AzureBlueprinter:  Press any key to continue...
pause
