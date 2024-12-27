using Content.Scripts.PlayerVechile;
namespace Content.Scripts.Enemy.Zombie.ZombieState
{
    public class ZombieActionAttack : ZombieActionBase
    {
        private Player player;
        private float chaseCd;
        private bool isAttack;
        public override void StartState()
        {
            base.StartState();
            player = Machine.ZombieFind.Player;
            Machine.ZombieAnimator.PlayMove();
        }

        public override void ProcessState()
        {
            base.ProcessState();

            if (player.IsDead)
            {
                Machine.ZombieFind.ResetPlayerFind();
                Machine.ZombieMovement.ResetVelocity();
                EndState();
            }
                   
            Machine.ZombieMovement.MovementAttack();
            Machine.ZombieMovement.Rotate();
            Machine.ZombieMovement.UpdatePlayerTarget(player.transform.position);
            
            if (Machine.ZombieMovement.CheckDistanceToTarget(2.1f))
            {
                player.PlayerHealth.TakeDamage(Machine.ZombieSettings.Damage);
                Machine.Dead();
            }
        }

        public override void ProcessStateFixed()
        {
            base.ProcessStateFixed();
     
        }

        public override void EndState()
        {
            base.EndState();
        }
    }
}
