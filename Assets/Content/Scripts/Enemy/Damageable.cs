using System;
namespace Content.Scripts.Enemy
{
	[Serializable]
	public abstract class Damageable
	{
		public abstract void TakeDamage(float damage);
	}
}
