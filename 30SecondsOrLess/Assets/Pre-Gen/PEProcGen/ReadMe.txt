PEProcGen for Unity v 0.6

PEProcGen does the following:

1) Creates procedurally generated 2D terrains
2) Currently creates caves, rooms and lanscapes
3) In the future may create better landscapes...

Here's the process:

Create a Unity Project 
Import the PEProcGen package
Create an empty GameObject
Add a TerrainRenderer Script
Add a CaveGenerator/RoomGenerator/HillGenerator Script
In TerrainRenderer:
	1) Set the Tile Sets Size to at least 1
	2) Set the Tile Data Size to at least 2
	3) Drag a sprite into each of the 2 elements

Click Generate in the CaveGenerator/RoomGenerator/HillGenerator

See the Demo_Simple/MainScene scene for a scripting example
See the Demo_Simple/TerrainManager for the main script example
 