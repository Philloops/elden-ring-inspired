---

# Elden Ring Inspired

Elden Ring inspired combat framework. Utilizes Unity and Netcode for GameObjects. An early prototype at this stage in time. Based on the amazing series by Sebastian Graves ->
[CREATE ELDEN RING IN UNITY](https://www.youtube.com/playlist?list=PLD_vBJjpCwJvP9F9CeDRiLs08a3ldTpW5) 

## Prerequisites

Animations used were paid assets, so of course I excluded those files from being tracked. If you're curious about the animations though, since all you'll be seeing is a t-posing avatar -> 
[STRAIGHT SWORD ANIMATION SET](https://assetstore.unity.com/packages/3d/animations/straight-sword-animation-set-220752)

## Setup

1. Clone or download this repository.
2. Open the Unity project in Unity Editor.
3. Import and relink the animations from purchased asset, or provide your own alternative animation set.
4. In the ParrelSync tab, open the Clones Manager, then click Open in New Editor.
5. Once the project clone has launched, you can now freely test networking behaviour in realtime across the editors.

## Usage

1. Make sure you have the necessary dependencies and animations relinked.
2. To playtest either start a new session or load an existing one.
3. Once your primary project editor has launched the game, start it up on the cloned project.
4. Inside the project clone, once you've launched into the gameplay scene, find the Player UI Manager.
5. Once you've found this object, go to the attached script, and check Start Game As Client twice.
6. From there you're connected to the other client and session.

## Demo

Check out the project demo on YouTube:

[Elden Ring Inspired Demo](https://youtu.be/lSd5fZy0nUA)

![elden-ring-inspired](https://media.giphy.com/media/6Uw7JlFsxxxJbrE4wt/giphy.gif)

---

