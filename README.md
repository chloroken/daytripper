# Daytripper

Daytripper is an offline, open-source, visual mapping tool for EVE Online designed specifically for solo players.

![v0.1.0 Demo Footage](https://i.imgur.com/0JwoUM9.gif)

Please see the [releases page](https://github.com/chloroken/daytripper/releases) for the latest download links.

Quick Info:

	• Open-source.

	• Completely offline.

	• Colorful (very important).

Advantages:

	• Easy to use. No, really. Can you copy and paste? You're a black belt at this.

	• Daytripper colors site by purpose, not class. Combat-relic are NOT relic sites!

	• Sharing map snapshots is easy, just send your friend your "map.save" file.

Disadvantages:

	• Not useful for group play.

	• Barebones, lack of features.

	• Slow development cycle.

Specifications:

	• Typed backend for easy saving & sharing of maps.

		• Type hierarchy: MapFile -> SolarSystem -> CosmicSignature.

	• Unity GameObjects provide a visualization of backend.

		• The Unity scene is self-assembling.

		• SystemObjects (prefabbed) represent SolarSystem data.

		• SignatureObjects (prefabbed) represent CosmicSignature data.

	• Imported Unity packages:

		• TextMeshPro (for GameObject text labels).

How to demo:

	• Visit the releases page for portable builds.
	
How to build:

	• To compile the source code, clone this repo and open the entire folder with Unity.

How to contribute:
	
	• Clone the repo, tinker with Unity, and submit a pull request when done.
	
	• Specifically, changes like refactoring & code cleaning are most helpful at this time.
	
	• Once the framework is further developed, feature addition will open up.
