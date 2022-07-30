# Drone Attack

#### By _**Patrick Dolan**_

#### _A Unity VR game inspired by Pistolwhip made for the Oculus Quest 2 where you shoot drones while moving through a scene dodging enemy return fire._

## Technologies Used

* Unity (Editor version 2021.3.1f1)
* C#
* XR Interaction Toolkit

## Description

A Unity VR game inspired by Pistolwhip made for the Oculus Quest 2 where you shoot drones while moving through a scene dodging enemy return fire. 

Controls:
All menus and game are interacted with by shooting.
Reload by pointing gun down.

## Demo 
[YouTube Video](https://youtu.be/LMh-I_4ewSs)
![Drone Attack Screenshot]()

## Download
You can download the current release version at (See "Installing on Quest" section for installation instructions):
[Drone Attack Game on Itch.io](https://patrick-dolan.itch.io/drone-attack)

## Setup/Installation Requirements

### Project setup for Unity
Installation instruction work on Unity Hub 3.2.0 with Editor version 2021.3.1f1
* Download or Clone the repo down to a directory on your computer.
* Open Unity Hub and make sure you have the <code>2021.3.1f1</code> editor version installed.
* In the Unity Hub click the open dropdown arrow on the top right and click <code>Add project from disk</code>.
* Navigate to the directory you downloaded to your computer in the explorer window that pops up and click add project on the bottom of the window.
* Click on the project named <code>drone-attack</code> (Or whatever you named it if you renamed it) and it will launch the project in Unity.
* In the scenes folder in the project assets folder double click the main scene and it will open the game in the editor.

### How to build project
* Once the project is open in Unity you cane click File > Build Settings (Or the keyboard shortcut Ctrl+Shift+B) to open the build settings menu.
* Make sure your Quest is connected and linked up to your computer if you want to immediately run/install.
* Select the Android Platform, install it if you dont the platform setup, then match up your settings to the ones in the picture below:
<br />

![Project Build Settings](https://raw.githubusercontent.com/Patrick-Dolan/drone-attack/main/README_IMGS/Build_settings.PNG)

* Once your settings match select build and run, which will build it then install it on your quest if its connected, or just build it and proceed to Installing on Quest.

### Installing on Quest
In order to install the game on your quest you will need Sidequest(The advanced installer), a piece of software designed to side load games on your quest.
* Download the <code>DroneAttack_v1.0.0.apk</code> file from Itch.io at the link above in the <strong>Download</strong> section.
* Open Sidequest and click on the <code>Install APK from file on computer</code> button. It looks like a download button on the top of the Sidequest window.
* Navigate to the place you downloaded/built the project and click open on the APK file. 
* The game will then be installed and can be found inside your quest in the unknown sources section of your apps. (Dropdown found in the top right of the Apps to access unknown sources)

## Known Bugs

* Gun can sometimes be used as a shield to redirect enemy fire.

## Contact Me

Let me know if you run into any issues or have questions, ideas or concerns:
dolanp1992@gmail.com

## License

_MIT_

Copyright (c) _2022_ _Patrick Dolan_

## Research and Planning Log
### Saturday 06/18
* 8:00AM Create and setup Unity project template and README
* 8:30AM - 9:30AM Create capstone proposal and begin research on assets needed to complete project
* 5:00PM - 7:00PM Work through some basic tutorials on Unity for FPS games

### Sunday 06/19
* 10:00AM - 12:00PM Prototyping gun mechanic 

### Saturday 07/02
* 5:30PM - 7:00PM Work through more advanced unity scripting lessons online
* 7:00 - 9:30PM Work through XR interaction toolkit tutorials to learn how to use VR control systems

### Sunday 07/24
* 9:20AM - 10:30AM Research how to make vr user interfaces
* 4:00PM - 5:00PM Research how to setup a leaderboard system

### Monday 07/25
* 5:50PM - 8:30PM Research how to take input in a form for leaderboard