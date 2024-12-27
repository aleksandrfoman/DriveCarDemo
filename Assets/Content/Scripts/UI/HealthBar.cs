using DG.Tweening;
using UnityEngine;

namespace Content.Scripts.UI
{
	public class HealthBar : MonoBehaviour
	{
		[SerializeField] private Transform mainBar;
		[SerializeField] private CustomFill customHpFill;
		[SerializeField] private CustomFill customHpWhiteFill;
		private Camera camera;
		public void Init()
		{
			customHpFill.Init();
			customHpWhiteFill.Init();
			gameObject.SetActive(false);
			camera = Camera.main;
		}
        
		public void Update()
		{
			if (camera != null && gameObject.activeSelf)
			{
				transform.LookAt(camera.transform);
			}
		}
		public void HpBarFill(float value)
		{
			customHpFill.Fill(value,0f);
			customHpWhiteFill.Fill(value,0.35f);
		}
        
		private bool isEnableHpBar;
        
		public void EnableHpBar(bool value)
		{
			if(value == isEnableHpBar) return;

			isEnableHpBar = value;
            
			if (value)
			{
				gameObject.SetActive(true);
				mainBar.localScale = Vector3.zero;
				mainBar.DOScale(Vector3.one, 0.02f);
			}
			else
			{
				mainBar.DOScale(Vector3.zero, 0.02f).OnComplete((() =>
				{
					mainBar.gameObject.SetActive(false);
				}));
			}
		}
	}
}
