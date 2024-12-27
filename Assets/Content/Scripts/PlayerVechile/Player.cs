using System;
using Content.Scripts.Services;
using Content.Scripts.UI;
using Content.Scripts.Utils;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Content.Scripts.PlayerVechile
{
    public class Player : MonoBehaviour
    {
        public bool IsDead => isDead;
        [field: SerializeField] public PlayerSettings PlayerSettings { get; private set; }
        [field: SerializeField] public PlayerFollow PlayerFollow { get; private set; }
        [field: SerializeField] public PlayerMovement PlayerMovement { get; private set; }
        [field: SerializeField] public PlayerWeapon PlayerWeapon { get; private set; }
        [field: SerializeField] public PlayerHealth PlayerHealth { get; private set; }
        [SerializeField] private HealthBar healthBar;
        [SerializeField] private MeshFlash meshFlash;
        private bool isDead;
        private CameraService cameraService;
        private LevelService levelService;
        private PoolService poolService;
        
        private bool isActivate;


        [Inject]
        private void Construct(CameraService cameraService,LevelService levelService, PoolService poolService)
        {
            this.cameraService = cameraService;
            this.levelService = levelService;
            this.poolService = poolService;
        }
        public void Init()
        {
            PlayerFollow.Init(transform,PlayerSettings,cameraService.PlayerFollowPoint);
            PlayerMovement.Init(transform,PlayerSettings,levelService.PathCreator);
            PlayerHealth.Init(transform,PlayerSettings,healthBar,meshFlash);
            PlayerWeapon.Init(transform,PlayerSettings,poolService);

            PlayerHealth.OnDead += Dead;
            PlayerMovement.OnFinish += Finish;
        }

        public void OnDestroy()
        {
            PlayerHealth.OnDead -= Dead;
            PlayerMovement.OnFinish -= Finish;
        }

        public void ActivatePlayer()
        {
            isActivate = true;
        }

        public void Update()
        {
            if(!isActivate || isDead) return;
            
            PlayerMovement.MovePath();
            PlayerFollow.UpdateFollowPoint();
            PlayerWeapon.UpdateWeapon();
        }

        public void Dead()
        {
            if(isDead) return;
            
            PlayerMovement.DeactivateMovement();
            isDead = true;
            isActivate = false;
            levelService.LoseLevel();
        }

        public void Finish()
        {
            isActivate = false;
            levelService.WinLevel();
        }
    }

}
