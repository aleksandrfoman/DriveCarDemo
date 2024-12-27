using System;
using Content.Scripts.PlayerVechile;
using Content.Scripts.Services;
using UnityEngine;
namespace Content.Scripts.Enemy.Zombie
{
    [Serializable]
    public class ZombieFind 
    {
        public bool IsPlayerFind => isPlayerFind;
        public Player Player => player;
        
        [SerializeField] private Transform transform; 
        [SerializeField] private ZombieSettings zombieSettings;
        private Player player;
        private bool isPlayerFind;
        
        public void Init(Transform transform,ZombieSettings zombieSettings,PlayerService playerService)
        {
            this.transform = transform;
            this.zombieSettings = zombieSettings;
            
            player = playerService.Player;
        }

        public bool HasPlayer(float scale = 1f)
        {
            return CheckDist() && !player.IsDead;
        }
        
        public void SetPlayerFind()
        {
            isPlayerFind = true;
        }
        
        public void ResetPlayerFind()
        {
            isPlayerFind = false;
        }
        
        private bool CheckDist()
        {
            return Vector3.Distance(transform.position, player.transform.position) <= zombieSettings.PlayerDetectRadius;
        }
        
        public void DrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position,zombieSettings.PlayerDetectRadius);
        }
    }

}
