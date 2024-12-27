using System.Collections;
using DG.Tweening;
using UnityEngine;
namespace Content.Scripts.Utils
{
    public class MeshFlash : MonoBehaviour
    {
        [SerializeField] private Renderer[] renderers;
        [SerializeField] private Color color;
        [SerializeField] private int blinkCount;
        [SerializeField] private float blinkDelay = 0.3f;
        [SerializeField] private float blinkDuration;
        [SerializeField] private bool isDisable;
        
        private bool isBlink;
        private static readonly int s_emissionColor = Shader.PropertyToID("_EmissionColor");

        public void Blink()
        {
            if(isDisable || isBlink) return;
            StartCoroutine(BlinkEmissionCor());
        }
        private IEnumerator BlinkEmissionCor()
        {
            isBlink = true;
            int temp = 0;
        
            while (temp<blinkCount)
            {
                for (int i = 0; i < renderers.Length; i++)
                {
                    for (int j = 0; j < renderers[i].materials.Length; j++)
                    {
                        renderers[i].materials[j].DOColor(color,s_emissionColor,blinkDuration);
                    }
                }

                yield return new WaitForSeconds(blinkDuration);
        
                for (int i = 0; i < renderers.Length; i++)
                {
                    for (int j = 0; j < renderers[i].materials.Length; j++)
                    {
                        renderers[i].materials[j].DOColor(Color.black, s_emissionColor,blinkDuration);
                    }
                }
                temp++;
            }
            isBlink = false;
        }
    }
}
