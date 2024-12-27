using System;
using Content.Scripts.Services;
using Content.Scripts.UI;
using Content.Scripts.Utils;
using UnityEngine;
namespace Content.Scripts.Enemy.Zombie
{
    [Serializable]
    public class ZombieHealth : Damageable
    {
        public event Action OnDead;

        private ZombieSettings zombieSettings;
        private Transform transform;
        private HealthBar healthBar;
        private MeshFlash meshFlash;
        private float curHealth;
        
        public void Init(Transform transform,ZombieSettings zombieSettings,HealthBar healthBar, MeshFlash meshFlash)
        {
            this.transform = transform;
            this.zombieSettings = zombieSettings;
            this.healthBar = healthBar;
            this.meshFlash = meshFlash;

            curHealth = zombieSettings.Health;
            
            healthBar.Init();
        }
        
        public override void TakeDamage(float damage)
        {
            healthBar.EnableHpBar(true);
            meshFlash.Blink();

            curHealth -= damage;
            if (curHealth <= 0f)
            {
                healthBar.EnableHpBar(false);
                OnDead?.Invoke();
            }
            float healthPercent = curHealth / zombieSettings.Health;
            healthBar.HpBarFill(healthPercent);
        }
    }

}
