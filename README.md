# AquariusShell

Originally created in 1997 for the Windows 95 shell, it provided a 100% replacement for Windows' Explorer.exe that acts as a file browser but is also the "graphical shell" providing services like the desktop, taskbar, etc.

## Concept: Workarea
The Aquarius Shell does not use the concepts of "desktop" and "taskbar". Instead, it uses a "workarea" that modifies and adapts its look and feel, features offered, and behaviour according to what the user is currently doing. It **MAY** resemble the desktop/taskbar **AT TIMES**, but this is not what it is.


## Features
We will attempt to recreating all of the features of the original:

Feature | Current status 
--------|----------------
Work area | Feature Complete
Apps & Docs Launcher | Feature Complete
Task manager | Planning
File browser | Feature Complete
Progress dialogs | Feature Complete
Message boxes | Feature Complete
Configuration UI | Feature Complete
Installer | Planning

## Windows Compatibility
Windows 10 and above.
(The original worked on Windows 95 to Vista, including NT/2000 Server and Workstation editions)

It is infinitely hard to support everything that happens in modern Windows (like virtual locations, shell objects, etc) without running into complicated topics like COM/DCOM, Interop issues, etc. To keep things simple, we only do in Aquarius Shell what was possible in Windows 95 and what the original Aquarius Shell could do. Everything else is... out of scope! :-)

## Dev Setup
You will need: 

- Windows 10 or 11 as your operating system
- Visual Studio 2022 v17.8 or higher
- .NET 8.0 with WinForms
It has no external package or tool dependency other than the above.

Steps:
1. Clone this repo
2. Build project and run. 

> Note: When running under Visual Studio, to test the taskbar fully, set your Windows 10/11 taskbar to Auto Hide. Right-click on the Win 10/11 taskbar, select `Taskbar Settings`, find the option named `Automatically hide the taskbar` and make sure it is checked ON. Otherwise, you may find that some operations will bring back the actual Windows taskbar to the top and you will need to ALT-TAB to the Aquarius Shell taskbar to continue.


## Install or Remove as the Shell (without running Installer)

- Open registry (regedit)
- Find the key:

```
HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon
```

- Find the named value `Shell`:

  The default value of this is simply `explorer.exe`.

  To change the shell to Aquarius Shell, replace the value of the `Shell` with the FULL PATH to the Aquarius Shell's EXE file. Example:

```
D:\src\AquariusShell\bin\Debug\net8.0-windows\AquariusShell.exe
```

REBOOT the computer after the change for it to take effect.
(Logoff/on will temporarily work, but is glitchy and you may find the other shell come back sometimes!)

