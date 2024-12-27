using System;
using Content.Scripts.PlayerVechile.Weapon;
using Content.Scripts.Services;
using UnityEngine;

namespace Content.Scripts.PlayerVechile
{
    [Serializable]
    public class PlayerWeapon
    {
        [SerializeField] private Transform weaponRotate;
        [SerializeField] private Transform shootPoint;
        [SerializeField] private PlayerProjectile projPrefab;
        [SerializeField] private float clamp;
        [SerializeField] private LineRenderer ray;
        
        private PlayerSettings playerSettings;
        private float curDelay;
        private Vector2 dir;
        private Vector3 localEuler;
        private Transform transform;
        private PoolService poolService;
        
        public void Init(Transform transform, PlayerSettings playerSettings,PoolService poolService)
        {
            this.transform = transform;
            this.playerSettings = playerSettings;
            this.poolService = poolService;
            
            curDelay = playerSettings.ShootDelay;
        }
        
        public void UpdateWeapon()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                ray.gameObject.SetActive(true);
                
                float xInput = Input.GetAxis("Mouse X");
                xInput = Mathf.Clamp(xInput,-1f,1f);
                localEuler.y += xInput;
                localEuler = new Vector3(0f,Mathf.Clamp(localEuler.y, -clamp, clamp),0f);
                Quaternion euler = Quaternion.Euler(localEuler);
                weaponRotate.transform.localRotation = Quaternion.Lerp(weaponRotate.transform.localRotation,euler,playerSettings.WeaponRotateSpeed*Time.deltaTime);

                if (curDelay <= 0f)
                {
                    PlayerProjectile playerProjectile = poolService.PlayerProjectile.GetFreeElement();
                    playerProjectile.transform.position = shootPoint.position;
                    playerProjectile.Init(transform,shootPoint.forward,playerSettings.Damage);
                    curDelay = playerSettings.ShootDelay;
                }
                else
                {
                    curDelay -= Time.deltaTime;
                }
            }
            else
            {
                ray.gameObject.SetActive(false);
            }
        }
    }
}
