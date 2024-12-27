using UnityEngine;

namespace Content.Scripts.PlayerVechile
{
    public class PlayerSettings : MonoBehaviour
    {
        [field: SerializeField] public float FollowSpeed { get; private set; }
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField] public float Health { get; private set; }
        
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float ShootDelay { get; private set; }
        [field: SerializeField] public float WeaponRotateSpeed { get; private set; }
    }
}
