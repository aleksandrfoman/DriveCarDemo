using System;
using Content.Scripts.Services;
using UnityEngine;
using Zenject;

namespace Content.Scripts.Installers
{
    public class GameScope : MonoBehaviour
    {
        private PlayerService playerService;
        private CameraService cameraService;
        private LevelService levelService;
        
        [Inject]
        private void Construct(PlayerService playerService,CameraService cameraService,LevelService levelService)
        {
            this.playerService = playerService;
            this.cameraService = cameraService;
            this.levelService = levelService;
        }
        private void Awake()
        {
            Application.targetFrameRate = 60;
            
            Init();
        }
        private void Init()
        {
            levelService.InitLevel();
            playerService.SpawnPlayer();
            cameraService.SetVirtualCamera(CameraService.ECameraState.Start,0f);
        }
        
  
    }
}
