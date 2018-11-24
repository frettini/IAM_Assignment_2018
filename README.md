# IAM_Assignment_2018

### Welcome to this unity and pure data project. 

This repo is composed of the Unity project called PDproject and of the Pure Data patches found in the folder PureData patches.
The build version for windows can be found in the build folder. However the OSC transmission doesn't work with extOSC.
A commentary can be found in the commentary folder.

## Aim of the game/composition

This project is an audio visual composition which uses games and unity as a platform to enhance its experience.

The aim of the game is to bring back the cubes that correspond to the color of the tile in the middle of the map.

The controls are:
WASD to move around
Space to jump
Left Click to grab a cube
Left Click again to drop the cube

The cube will also drop if it gets in contact with any other objects.
No code has been implemented yet in case you drop a cube:
if you drop a cube you will have to **restart** the game. 

## Unity project

The unity project has been developed in unity 2018.2.12f and thus can  be opened with any version of unity equal or higher than that.

Three scenes are used in the final project : Main Menu, Level2Ambient and GameOver.
The rest of the scenes are test scenes that are not included in the build.

The project uses the plugin extOSC to establish a communication between unity and Pure Data. 
Most of the sound is dealt with in Pure Data.
The communicating ports are 8000 and 8001. The pure data patches are set to the same ports.

To have the project up and running, you just need to have the pure data patch and unity project opne at the same time.
To replay the game, you will have to **RESTART** the PD patch (it doesn't reboot automatically.

## Pure Data Patch

The patch doesn't have to be interacted with during the course of the game.

It is divided into several parts:
 
  - a mixer where all the volumes can be agjusted.
  - the OSCManager subpatch which ensures the communication from unity to pure data.
  - the background subpatch which handles the back ground sounds.
  - the pick up object subpatch which handles the effects created every time a cube is brought back to the tile.
  - the ennemy subpatch which handles the sound of the ennemy every time it gets close to the player.
  
This part of the project is completely automated (except when you need to restart the game).

## Builds

A build for windows is available in this project.
However, the OSC communication doesn't work from Unity to PD. I am still trying to find a fix for it.

No build is available yet for Mac.


If you encounter any issues to run the project please contact me.
