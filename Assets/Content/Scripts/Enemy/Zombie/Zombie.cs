using System;
using Content.Scripts.Enemy.Zombie.ZombieState;
using Content.Scripts.Services;
using Content.Scripts.UI;
using Content.Scripts.Utils;
using UnityEngine;
using Zenject;
namespace Content.Scripts.Enemy.Zombie
{
    public class Zombie : MonoBehaviour
    {
        public bool IsDead => isDead;
        private bool isDead;
        
        [field: SerializeField] public ZombieSettings ZombieSettings { get; private set; }
        [field: SerializeField] public ZombieAnimator ZombieAnimator { get; private set; }
        [field: SerializeField] public ZombieFind ZombieFind { get; private set; }
        [field: SerializeField] public ZombieHealth ZombieHealth { get; private set; }
        [field: SerializeField] public ZombieMovement ZombieMovement { get; private set; }
        [field: SerializeField] public ZombieAttack ZombieAttack{ get; private set; }
        [SerializeField] private HealthBar healthBar;
        [SerializeField] private MeshFlash meshFlash;
        [SerializeField] private ZombieStateMachine zombieStateMachine;

        private PlayerService playerService;
        private PoolService poolService;
        
        [Inject]
        private void Construct(PlayerService playerService, PoolService poolService)
        {
            this.playerService = playerService;
            this.poolService = poolService;
        }

        private void Start()
        {
            ZombieFind.Init(transform,ZombieSettings,playerService);
            ZombieHealth.Init(transform,ZombieSettings, healthBar, meshFlash);
            ZombieMovement.Init(transform,ZombieSettings);
            ZombieAttack.Init(ZombieSettings,playerService);
            ZombieAnimator.Init();
            
            zombieStateMachine.Init(this);
            ZombieHealth.OnDead += Dead;
        }

        public void OnDestroy()
        {
            ZombieHealth.OnDead -= Dead;
        }

        public void Dead()
        {
            isDead = true;
            zombieStateMachine.enabled = false;
            ZombieMovement.ResetVelocity();
            ParticleEffect particleEffect = poolService.BloodParticle.GetFreeElement();
            particleEffect.transform.position = transform.position+Vector3.up;
            particleEffect.Activate();
            Destroy(gameObject);
        }
        
        public void OnDrawGizmosSelected()
        {
            ZombieMovement.DrawGizmos();
            ZombieFind.DrawGizmos();
            ZombieAttack.DrawGizmos();
        }
    }

}
