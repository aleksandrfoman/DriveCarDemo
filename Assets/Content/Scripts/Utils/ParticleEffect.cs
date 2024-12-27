using UnityEngine;
namespace Content.Scripts.Utils
{
    public class ParticleEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem mainParticle;

        public void Activate()
        {
            mainParticle.Play(true);
        }
    }
}
