using DG.Tweening;
using UnityEngine;
namespace Content.Scripts.UI
{
    public class CustomFill : MonoBehaviour
    {
        [SerializeField] private RectTransform fillRect;
        
        private float maxFillSize;
        private float lastValue;
        
        public void Init()
        {
            maxFillSize = fillRect.sizeDelta.x;
            fillRect.sizeDelta = new Vector2(maxFillSize * 0f, fillRect.sizeDelta.y);
        }
    
        public void Fill(float newValue, float duration)
        {
            if(Mathf.Approximately(lastValue, newValue)) return;
        
            if (newValue > 1) newValue = 1;
            else if (newValue < 0) newValue = 0;

            if (newValue <= 0)
            {
                DOVirtual.Float(lastValue, 0f, duration, (value) =>
                {
                    fillRect.sizeDelta = new Vector2(maxFillSize * value, fillRect.sizeDelta.y);
                });
            
            }
            else
            {
                DOVirtual.Float(lastValue, newValue, duration, (value) =>
                {
                    fillRect.sizeDelta = new Vector2(maxFillSize * value, fillRect.sizeDelta.y);
                });
            }
        
            lastValue = newValue;
        }
    }
}
