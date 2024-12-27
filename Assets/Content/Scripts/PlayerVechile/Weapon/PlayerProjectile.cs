using System;
using Content.Scripts.Enemy.Zombie;
using DG.Tweening;
using UnityEngine;
namespace Content.Scripts.PlayerVechile.Weapon
{
	public class PlayerProjectile : MonoBehaviour
	{
		[SerializeField] private Rigidbody rigidbody;
		[SerializeField] private float moveSpeed;
		[SerializeField] private TrailRenderer trailRenderer;
		private bool isInit;
		private Vector3 dir;
		private float damage;
		private float curLifeTime;
		
		public void Init(Transform weaponTransform,Vector3 dir, float damage)
		{
			this.dir = dir;
			this.damage = damage;
			transform.parent = weaponTransform;
			curLifeTime = 0f;
			isInit = true;
		}
		
		private void Move()
		{
			float velocityScale = 3f;
			rigidbody.velocity *= 1f - (velocityScale * Time.fixedDeltaTime);
			rigidbody.angularVelocity *= 1f - (velocityScale * Time.fixedDeltaTime);
			rigidbody.AddForce(dir.normalized*moveSpeed*Time.fixedDeltaTime, ForceMode.VelocityChange);
		}

		private void Update()
		{
			if (isInit)
			{
				Move();

				if (curLifeTime >= 7f)
				{
					Deactivate();
				}
				else
				{
					curLifeTime += Time.deltaTime;
				}
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			Zombie zombie = other.GetComponent<Zombie>();
			if (zombie != null)
			{
				zombie.ZombieHealth.TakeDamage(damage);
				Deactivate();
			}
		}

		private void Deactivate()
		{
			gameObject.SetActive(false);
			rigidbody.velocity = Vector3.zero;
			isInit = false;
			trailRenderer.Clear();
		}
	}
}
