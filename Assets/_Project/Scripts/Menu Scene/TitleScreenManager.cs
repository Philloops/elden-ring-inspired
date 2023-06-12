using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

namespace Nu11ity
{
    public class TitleScreenManager : Singleton<TitleScreenManager>
    {
        [Header("Menus")]
        [SerializeField] GameObject titleScreenMainMenu;
        [SerializeField] GameObject titleScreenLoadMenu;

        [Header("Buttons")]
        [SerializeField] Button loadMenuReturnButton;
        [SerializeField] Button mainMenuLoadGameButton;
        [SerializeField] Button mainMenuNewGameButton;

        [Header("Pop Ups")]
        [SerializeField] GameObject noCharacterSlotsPopUp;
        [SerializeField] Button noCharacterSlotsOkayButton;

        public void StartNetworkAsHost()
        {
            NetworkManager.Singleton.StartHost();
        }

        public void StartNewGame()
        {
            WorldSaveGameManager.Instance.AttemptToCreateNewGame();
        }

        public void OpenLoadGameMenu()
        {
            // CLOSE MAIN MENU
            titleScreenMainMenu.SetActive(false); 

            // OPEN LOAD MENU
            titleScreenLoadMenu.SetActive(true);

            // SELECT THE RETURN BUTTON FIRST
            loadMenuReturnButton.Select();
        }

        public void CloseLoadGameMenu()
        {
            // CLOSE LOAD MENU
            titleScreenLoadMenu.SetActive(false);

            // OPEN MAIN MENU
            titleScreenMainMenu.SetActive(true);

            // SELECT THE LOAD BUTTON FIRST
            mainMenuLoadGameButton.Select();
        }

        public void DisplayNoFreeCharacterSlotsPopUp()
        {
            noCharacterSlotsPopUp.SetActive(true);
            noCharacterSlotsOkayButton.Select();
        }

        public void CloseNoFreeCharactersSlotsPopUp()
        {
            noCharacterSlotsPopUp.SetActive(false);
            mainMenuNewGameButton.Select();
        }
    }
}
