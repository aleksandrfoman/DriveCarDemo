using UnityEngine;
namespace Content.Scripts.Enemy.Zombie
{
	public class ZombieSettings : MonoBehaviour
	{
		[field: SerializeField] public float Health { get; private set; }
		[field: SerializeField] public float PlayerDetectRadius { get; private set; }
		[field: SerializeField] public float IdleRadius { get; private set; }
		[field: SerializeField] public float MoveSpeed { get; private set; }
		
		[field: SerializeField] public float AttackMoveSpeed { get; private set; }
		
		[field: SerializeField] public float RotateSpeed { get; private set; }
		[field: SerializeField] public float Damage { get; private set; }
	}
}
