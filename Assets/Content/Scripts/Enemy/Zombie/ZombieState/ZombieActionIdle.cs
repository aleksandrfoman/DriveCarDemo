using UnityEngine;
namespace Content.Scripts.Enemy.Zombie.ZombieState
{
    public class ZombieActionIdle : ZombieActionBase
    {
        private bool isPointChange;
        private bool isWait;
        private float waitTime;
        public override void StartState()
        {
            base.StartState();
            isPointChange = false;
            Machine.ZombieAnimator.PlayIdle();
        }
        
        public override void ProcessState()
        {
            base.ProcessState();
        
            if (Machine.ZombieFind.HasPlayer())
            {
                Machine.ZombieFind.SetPlayerFind();
                EndState();
            }
            
            if (isPointChange == false)
            {
                if (UpdatePoint())
                {
                    isPointChange = true;
                    Machine.ZombieAnimator.PlayMove();
                }
            }
            
            if (NearTarget())
            {
                if (!isWait)
                {
                    isWait = true;
                    waitTime = Random.Range(3f, 5f);
                    Machine.ZombieAnimator.PlayIdle();
                    Machine.ZombieMovement.ResetVelocity();
                }
                
                if (waitTime <= 0f)
                {
                    isWait = false;
                    isPointChange = false;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
            
            if (!isWait)
            {
                Machine.ZombieMovement.MovementIdle();
                Machine.ZombieMovement.Rotate();
            }
        }
        
        private bool NearTarget(float value = 0.2f)
        {
            return Machine.ZombieMovement.CheckDistanceToTarget(value);
        }
        private bool UpdatePoint()
        {
            return Machine.ZombieMovement.UpdateRandomTarget();
        }
        
        public override void EndState()
        {
            base.EndState();
        }
    }
}
