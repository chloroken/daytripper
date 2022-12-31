# Daytripper

Daytripper is an offline, open-source, visual mapping tool for EVE Online designed specifically for solo players.

![v0.1.0 Demo Footage](https://i.imgur.com/0JwoUM9.gif)

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

	• The Unity Scene contains Unity GameObjects, allowing visualization of backend data structure:

		• The Unity scene is self-building. We just save backend data and just reload the scene.

		• SystemObjects (prefabbed) represent SolarSystem data:

			• SystemObjects are self-parsing and change color & label based on system class.

		• SignatureObjects (prefabbed) represent CosmicSignature data:

			• SignatureObjects are self-parsing and change icon based on site type.

			• SignatureObjects will gravitate towards their parent system.

			• Wormholes can be 'linked' with another wormhole, with adjusted gravitation.

	• Imported packages:

		• TextMeshPro (for GameObject text labels)

How to demo:

	• Visit the releases page for portable builds.
	
How to build:

	• To compile the source code, clone this repo and open the entire folder with Unity.

How to contribute:
	
	• Clone the repo, tinker with Unity, and submit a pull request when done.
	
	• Specifically, changes like refactoring & code cleaning are most helpful at this time.
	
	• Once the framework is further developed, feature addition will open up.
