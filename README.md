# AquariusShell

Originally created in 1997 for the Windows 95 shell, it provided a 100% replacement for Windows' Explorer.exe that acts as a file browser but is also the "graphical shell" providing services like the desktop, taskbar, etc.

## Features
We will attempt to recreating all of the features of the original:

Feature | Current status 
--------|----------------
Desktop | In progress...
Taskbar | Working
Program launcher | Complete
Task switcher | Pending!
Sys Tray | Pending!
File system explorer | Pending!
Context-menus | Pending!
Seamless dragdrop | Pending!
Installer | Pending!

## Windows Compatibility
The original worked correctly on all versions of Windows between Windows 95 until Windows Vista. It stopped working in Vista because of requirements of the new UAC system. It used to also run on the Server and Workstation editions of Windows (i.e., NT and 2000) of that era.

The present iteration of the Shell will **NOT** have backward compatibility and will run only on `Windows 10 and above` because of the nature of several severe changes made to Windows before that.

## Dev Setup
You will need: 

- Windows 10 or 11 as your operating system
- Visual Studio 2022 v17.8 or higher
- .NET 8.0 with WinForms

Clone this repo, build and run. It has no external package or tool dependency other than the above.

When running under Visual Studio, to test the taskbar fully, set your Windows 10/11 taskbar to Auto Hide. Right-click on the Win 10/11 taskbar, select `Taskbar Settings`, find the option named `Automatically hide the taskbar` and make sure it is checked ON. Otherwise, you may find that some operations will bring back the actual Windows taskbar to the top and you will need to ALT-TAB to the Aquarius Shell taskbar to continue.


## Install as the Shell

- Open registry (regedit)
- Find the key:

```
HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon
```

- Find the named value `Shell`

The default value of this is simply `explorer.exe`.

To change the shell to Aquarius Shell, replace the value of the `Shell` with the FULL PATH to the Aquarius Shell's EXE file. Example:

```
D:\src\AquariusShell\bin\Debug\net8.0-windows\AquariusShell.exe
```

REBOOT the computer after the change for it to take effect.
(Logoff/on will temporarily work, but is glitchy and you may find the other shell come back sometimes!)

