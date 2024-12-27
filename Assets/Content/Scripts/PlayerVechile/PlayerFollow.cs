using System;
using UnityEngine;

namespace Content.Scripts.PlayerVechile
{
    [Serializable]
    public class PlayerFollow 
    {
        [SerializeField,HideInInspector] private Transform followPoint;
        [SerializeField] private Vector3 followOffset;
        private PlayerSettings playerSettings;
        private Transform transform;
        
        public void Init(Transform transform,PlayerSettings playerSettings,Transform followPoint)
        {
            this.transform = transform;
            this.playerSettings = playerSettings;
            this.followPoint = followPoint;
            this.followPoint.parent = null;
        }

        public void UpdateFollowPoint()
        {
            Vector3 followPos = new Vector3(0f, transform.position.y, transform.position.z)+followOffset;
            followPoint.position = Vector3.Lerp(followPoint.position, followPos,
                playerSettings.FollowSpeed*Time.deltaTime);
        }
    }
}
