using System;
using Content.Scripts.Enemy.Zombie;
using Content.Scripts.UI;
using Content.Scripts.Utils;
using DG.Tweening;
using UnityEngine;

namespace Content.Scripts.PlayerVechile
{
    [Serializable]
    public class PlayerHealth
    {
        [SerializeField] private Transform meshScaler;
        
        public event Action OnDead;
        private PlayerSettings playerSettings;
        private Transform transform;
        private HealthBar healthBar;
        private MeshFlash meshFlash;
        private float curHealth;
        
        public void Init(Transform transform,PlayerSettings playerSettings,HealthBar healthBar, MeshFlash meshFlash)
        {
            this.transform = transform;
            this.playerSettings = playerSettings;
            this.healthBar = healthBar;
            this.meshFlash = meshFlash;
            
            curHealth = playerSettings.Health;
            healthBar.Init();
        }
        
        public void TakeDamage(float damage)
        {
            healthBar.EnableHpBar(true);
            curHealth -= damage;
            Anim();
            if (curHealth <= 0f)
            {
                healthBar.EnableHpBar(false);
                OnDead?.Invoke();
            }
            float healthPercent = curHealth / playerSettings.Health;
            healthBar.HpBarFill(healthPercent);
        }

        private void Anim()
        {
            meshFlash.Blink();
            meshScaler.DOShakeScale(0.2f, 0.3f, 3,0f,true,ShakeRandomnessMode.Harmonic).SetEase(Ease.OutBack).
                OnComplete((() =>
                {
                    meshScaler.localScale = Vector3.one;
                }));
        }
    }
}