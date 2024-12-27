using System;
using PathCreation;
using UnityEngine;

namespace Content.Scripts.PlayerVechile
{
    [Serializable]
    public class PlayerMovement
    {
        public event Action OnFinish;
        
        [SerializeField] private Transform rotateTransform;
        [SerializeField] private Vector3 angleOffset;
        private Vector3 curOffset;
        private PlayerSettings playerSettings;
        private Transform transform;
        private float distanceTravelled;
        private PathCreator pathCreator;
        private bool isFinish;
        private bool isDeactivate;
        public void Init(Transform transform,PlayerSettings playerSettings, PathCreator path)
        {
            this.transform = transform;
            this.playerSettings = playerSettings;
            pathCreator = path;
            isFinish = false;
            isDeactivate = false;
            transform.position = pathCreator.path.GetPointAtDistance(0f);
        }

        public void MovePath()
        {
            if (pathCreator != null && !isFinish && !isDeactivate)
            {
                distanceTravelled += playerSettings.MovementSpeed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
                rotateTransform.localRotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
                Quaternion newRot = rotateTransform.localRotation * Quaternion.Euler(angleOffset);
                rotateTransform.localRotation = newRot;

                if (distanceTravelled>=pathCreator.path.length)
                {
                    isFinish = true;
                    OnFinish?.Invoke();
                }
            }
        }

        public void DeactivateMovement() => isDeactivate = true;
    }
}
