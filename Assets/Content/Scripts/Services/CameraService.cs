using System;
using Cinemachine;
using UnityEngine;
using Zenject;

namespace Content.Scripts.Services
{
    public class CameraService : MonoBehaviour
    {
        public Transform PlayerFollowPoint => playerFollow;
        
        [SerializeField] private CameraVirtualControl cameraVirtualControl;
        [SerializeField] private Transform playerFollow;
        
        public void SetVirtualCamera(ECameraState eCameraState, float duration) =>
            cameraVirtualControl.SetVirtualCamera(eCameraState, duration);
        
        [Serializable]
        public class CameraVirtualControl
        {
            [SerializeField] private CinemachineBrain cinemaBrain;
            [SerializeField] private CinemachineVirtualCamera playerCamera;
            
            private float _curFov;
            
            public void SetVirtualCamera(ECameraState eCameraState, float duration = 0f)
            {
                cinemaBrain.m_DefaultBlend.m_Time = duration;
                
                playerCamera.Priority = 10;
                
                switch (eCameraState)
                {
                    case ECameraState.Player:
                        playerCamera.Priority = 12;
                        break;
                }
            }

            public void SetTarget(ECameraState eCameraState,Transform target)
            {
                switch (eCameraState)
                {
                    case ECameraState.Player:
                        playerCamera.Follow = target;
                        break;
                }
            }
        }
        
        public enum ECameraState
        {
            Start,
            Player
        }
    }
}
