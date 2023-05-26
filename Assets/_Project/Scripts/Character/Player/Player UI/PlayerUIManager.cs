using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace Nu11ity
{
    public class PlayerUIManager : Singleton<PlayerUIManager>
    {
        [Header("NETWORK JOIN")]
        [SerializeField] bool startGameAsClient;

        [HideInInspector] public PlayerUIHudManager playerUIHudManager;

        protected override void Awake()
        {
            base.Awake();

            playerUIHudManager = GetComponentInChildren<PlayerUIHudManager>();
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if(startGameAsClient)
            {
                startGameAsClient = false;
                // WE MUST FIRST SHUT DOWN, BECAUSE WE HAVE STARTED AS A HOST DURING THE TITLE SCREEN
                NetworkManager.Singleton.Shutdown();
                //WE THEN RESTART, AS A CLIENT
                NetworkManager.Singleton.StartClient();
            }
        }
    }
}
