# daytripper

Daytripper is an open-source mapping program for EVE Online built with Unity, designed for solo players.

Please see the [releases page](https://github.com/chloroken/daytripper/releases) for the latest download links.

Quick Info:

	• Open Source

	• Completely offline.

	• Colorful (very important)

Advantages:

	• Easy to use. No, really. Can you copy and paste? You're a black belt at this.

	• Daytripper colors site by purpose, not class. Combat-relic are NOT relic sites!

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

		• The Unity scene is entirely self-building. We only ever save backend data and just reload the scene if 
		necessary.

		• SystemObjects (prefabbed) represent SolarSystem data:

			• SystemObjects are self-parsing and change both color & label based on the system class.

		• SignatureObjects (prefabbed) represent CosmicSignature data:

			• SignatureObjects are self-parsing and change icon based on site type.

			• SignatureObjects will gravitate towards their parent system.

			• Wormholes can be 'linked' with another wormhole, with adjusted gravitation.

	• Imported packages:

		• TextMeshPro (for GameObject text labels)

How to contribute:

	• To compile the source code, clone this repo and open the entire folder with Unity.
	
	• Add features, clean up code, tweak things, or whatever you'd like, then submit a pull request.
	
	• I will merge any changes that help the project move forward.

How to demo:

	• Visit the releases page for portable builds.
