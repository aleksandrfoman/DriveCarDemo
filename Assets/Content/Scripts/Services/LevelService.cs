using System;
using PathCreation;
using UnityEngine;
using Zenject;

namespace Content.Scripts.Services
{
    public class LevelService : MonoBehaviour
    {
        public PathCreator PathCreator => path;
        [SerializeField] private PathCreator path;

        private CameraService cameraService;
        private PlayerService playerService;
        private GameScreenService gameScreenService;
        private SceneService sceneService;
        
        [Inject]
        private void Construct(CameraService cameraService, PlayerService playerService,GameScreenService gameScreenService,SceneService sceneService)
        {
            this.cameraService = cameraService;
            this.playerService = playerService;
            this.gameScreenService = gameScreenService;
            this.sceneService = sceneService;
        }

        public void InitLevel()
        {
            gameScreenService.ActivateScreen(EGameScreen.Start);
        }

        public void WinLevel()
        {
            gameScreenService.ActivateScreen(EGameScreen.Win);
        }

        public void LoseLevel()
        {
            gameScreenService.ActivateScreen(EGameScreen.Lose);
        }

        public void Restart()
        {
            sceneService.LoadGameScene();
        }

        public void LevelStart()
        {
            gameScreenService.ActivateScreen(EGameScreen.Game);
            cameraService.SetVirtualCamera(CameraService.ECameraState.Player,1f);
            playerService.Player.ActivatePlayer();
        }
    }
}
