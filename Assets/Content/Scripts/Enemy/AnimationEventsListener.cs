using System;
using UnityEngine;
namespace Content.Scripts.Enemy
{
    public class AnimationEventsListener : MonoBehaviour
    {
        public event Action OnAttack;
        
        public void Attack()
        {
            OnAttack?.Invoke();
        }
        
    }
}
