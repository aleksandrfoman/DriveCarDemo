using System;
using UnityEngine;
using Random = UnityEngine.Random;
namespace Content.Scripts.Enemy.Zombie
{
    [Serializable]
    public class ZombieMovement 
    { 
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private Transform meshRotator;
        [SerializeField] private LayerMask obstacleMask; 
        [SerializeField] private ZombieSettings zombieSettings;
        [SerializeField] private Transform transform;
        private Vector3 target;
        private Vector3 spawnPos;
        
        public void Init(Transform transform,ZombieSettings zombieSettings)
        {
            this.transform = transform;
            this.zombieSettings = zombieSettings;
            
            spawnPos = transform.position;
        }
        
        public void SetTarget(Vector3 pos)
        {
            target = pos;
        }

        public bool UpdateRandomTarget()
        {
            Vector3 curTarget = GenerateRandomPointInRadius(zombieSettings.IdleRadius);
            bool checkObstacle = CheckObstacle(transform.position, curTarget);
            if (!checkObstacle)
            {
                target = curTarget;
                return true;
            }
            return false;
        }
        
        public void UpdatePlayerTarget(Vector3 playerPos)
        {
            playerPos.y = transform.position.y;
            playerPos.z += 2f;
            target = playerPos;
        }

        private Vector3 GenerateRandomPointInRadius(float radius)
        {
            Vector3 rndPoint = Random.insideUnitSphere;
            rndPoint *= radius;
            Vector3 localPos = spawnPos;
            rndPoint += localPos;
            rndPoint.y = transform.position.y;
            return rndPoint;
        }
        
        public bool IsMove(float magn = 0.75f)
        { 
            return rigidbody.velocity.magnitude >= magn;
        }
        
        public void ResetVelocity()
        {
            rigidbody.velocity = Vector3.zero;
        }

        public void MovementIdle()
        {
            Move(zombieSettings.MoveSpeed);
        }
        
        public void MovementAttack()
        {
            Move(zombieSettings.AttackMoveSpeed);
        }
        
        private void Move(float moveSpeed)
        {
            float velocityScale = 3f;
            rigidbody.velocity *= 1f - (velocityScale * Time.fixedDeltaTime);
            rigidbody.angularVelocity *= 1f - (velocityScale * Time.fixedDeltaTime);
            
            Vector3 targetDir = target - rigidbody.transform.position;
            rigidbody.AddForce(targetDir.normalized*moveSpeed*Time.fixedDeltaTime, ForceMode.VelocityChange);
        }

        public void Rotate()
        {
            Rotate(zombieSettings.RotateSpeed,target);
        }
        
        private void Rotate(float rotateSpeed,Vector3 targetPos)
        {
            var forwardDir = targetPos - transform.position;
            var angle = Mathf.Atan2(forwardDir.x, forwardDir.z) * Mathf.Rad2Deg;
            var nextRot = Quaternion.Euler(new Vector3(0, angle, 0));
            meshRotator.localRotation = Quaternion.Lerp(meshRotator.localRotation, nextRot, rotateSpeed * Time.deltaTime);
        }
    
        public bool CheckDistanceToTarget(float value = 0.25f)
        {
            Vector3 checkTarget = target;
            checkTarget.y = rigidbody.position.y;
            return Vector3.Distance(rigidbody.position,checkTarget) <= value;
        }
        
        public bool IsVisible(Vector3 pos, float offset = 0.1f)
        {
            var targetPos = pos;
            targetPos.z = meshRotator.position.z;

            return Vector3.Angle(meshRotator.forward, (targetPos - meshRotator.position).normalized) <= offset;
        }
        
        private bool CheckObstacle(Vector3 startPoint, Vector3 endPoint)
        {
            Vector3 dir =  endPoint - startPoint;
            dir.Normalize();
            if (Physics.Raycast(startPoint,dir, Vector3.Distance(startPoint,endPoint), obstacleMask))
            {
                return true;
            }
            return false;
        }

        public void DrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Vector3 localPos = spawnPos;
            Gizmos.DrawWireSphere(localPos, zombieSettings.IdleRadius);

            Gizmos.color = Color.green;
            Gizmos.DrawSphere(target, 0.35f);
            Vector3 dir = target - meshRotator.position;
            dir.Normalize();
            Gizmos.color = Color.green;
            Gizmos.DrawRay(meshRotator.position, dir * Vector3.Distance(meshRotator.position, target));
        }
    }
}
