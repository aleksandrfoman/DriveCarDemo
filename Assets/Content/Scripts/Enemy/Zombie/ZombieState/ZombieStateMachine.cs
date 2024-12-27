using Content.Scripts.StateMachine;
namespace Content.Scripts.Enemy.Zombie.ZombieState
{
	public class ZombieStateMachine : StateMachine<Zombie,EZombieState>
	{
		public override void StateSwitch()
		{
			if (CurrentStateType == EZombieState.Idle && Machine.ZombieFind.IsPlayerFind)
			{
				StartAction(EZombieState.Attack);
			}
			else
			{
				StartAction(EZombieState.Idle);
			}
		}
	}
}
