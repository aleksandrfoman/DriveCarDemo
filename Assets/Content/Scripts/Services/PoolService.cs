using Content.Scripts.PlayerVechile.Weapon;
using Content.Scripts.Pool;
using Content.Scripts.Utils;
using UnityEngine;
using Zenject;
namespace Content.Scripts.Services
{
    public class PoolService : MonoBehaviour
    {
        [SerializeField] private PlayerProjectile playerProjectilePrefab;
        [field: SerializeField] public PoolMono<PlayerProjectile> PlayerProjectile { get; private set; }
        
        [SerializeField] private ParticleEffect bloodParticlePrefab;
        [field: SerializeField] public PoolMono<ParticleEffect> BloodParticle { get; private set; }

        [Inject]
        private void Construct()
        {
            PlayerProjectile = new PoolMono<PlayerProjectile>(playerProjectilePrefab);
            BloodParticle = new PoolMono<ParticleEffect>(bloodParticlePrefab);
        }
    }
}
