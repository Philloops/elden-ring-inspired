using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nu11ity
{
    public class WorldSoundFXManager : Singleton<WorldSoundFXManager>
    {
        [Header("Action Sounds")]
        public AudioClip rollSFX;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
