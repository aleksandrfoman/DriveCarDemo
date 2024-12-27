using System;
using Content.Scripts.UI.Screens;
using UnityEngine;
namespace Content.Scripts.Services
{
    public class GameScreenService : MonoBehaviour
    {
        [SerializeField] private LoseScreen loseScreen;
        [SerializeField] private StartScreen startScreen;
        [SerializeField] private WinScreen winScreen;

        public void ActivateScreen(EGameScreen screen)
        {
            loseScreen.gameObject.SetActive(false);
            startScreen.gameObject.SetActive(false);
            winScreen.gameObject.SetActive(false);
            
            switch (screen)
            {
                case EGameScreen.Game: 
                    break;
                case EGameScreen.Lose:
                    loseScreen.gameObject.SetActive(true);
                    break;
                case EGameScreen.Start:
                    startScreen.gameObject.SetActive(true);
                    break;
                case EGameScreen.Win:
                    winScreen.gameObject.SetActive(true);
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(screen), screen, null);
            }
        }
    }

    public enum EGameScreen
    {
        Game,
        Lose,
        Start,
        Win
    }
}
