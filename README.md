# daytripper
Daytripper is an open-source, third-party cartography tool made for EVE Online.

Quick Info:
	• Free
	• Open Source
	• Lightweight
	• Colorful (very important)
  
Advantages:
	• Easy to use. No, really. Can you copy and paste? You're a black belt.
	• Completely offline, you retain complete control of every bit and byte.
	• Sharing map snapshots is easy, just send your friend your "map.save" file.
  
Disadvantages:
	• Not useful for group play.
	• Barebones, lack of features.
	• Slow development cycle.
  
Specifications:
	• Typed, serializable data structure for easy saving & sharing of maps:
		• Type hierarchy: MapFile -> SolarSystem -> CosmicSignature
		• Disk interfacing: Save/Load/Wipe MapFile, autosave boolean toggle.
	• The Unity Scene contains monobehavior GameObjects, allowing manipulation/visualization of backend data structure:
		• The Unity scene is entirely self-building. We only ever save backend data and just reload the scene if necessary.
		• SystemObjects (prefabbed) represent SolarSystem data:
			• SystemObjects are self-parsing and change both color & label based on the system class.
		• SignatureObjects (prefabbed) represent CosmicSignature data:
			• SignatureObjects are self-parsing and change icon based on site type.
			• SignatureObjects will gravitate towards their parent system.
			• Wormholes can be 'linked' with another wormhole, with adjusted gravitation.
	• Imported packages:
		• TextMeshPro (for GameObject text labels)
    
Instructions:
  • Right click a system name in EVE (top left) and select "copy".
  • In Daytripper, paste the system in.
  • Copy all signatures and paste them on to the previous system.
  • Connect wormholes together to build chains.

Controls:
  • Left click and drag to move systems & signatures.
  • Ctrl+V to "paste" data into Daytripper. Pasting signatures requires hoving a system with your mouse.
  • Right click to delete a signature or system (and all of it's children signatures).
  • Middle click and drag to "link" wormholes together.
  • Middle click a linked wormhole to unlink it.
