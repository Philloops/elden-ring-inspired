using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nu11ity
{
    [System.Serializable]
    // SINCE WE WANT TO REFERENCE THIS DATA FOR EVERY SAVE FILE, THIS SCRIPT IS NOT A MONOBEHAVIOR AND IS INSTEAD SERIALIZABLE
    public class CharacterSaveData
    {
        [Header("Scene Index")]
        public int sceneIndex = 1;

        [Header("Character Name")]
        public string characterName = "Character";

        [Header("Time Played")]
        public float secondsPlayed;

        // QUESTION: WHY NOT USE A VECTOR3?
        // ANSWER: WE CAN ONLY SAVE DATA FROM "BASIC" VARIABLE TYPES (float, int, string, bool, etc)
        [Header("World Coordinates")]
        public float xPosition;
        public float yPosition;
        public float zPosition;
    }
}
