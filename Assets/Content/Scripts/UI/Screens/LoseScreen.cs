using Content.Scripts.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
namespace Content.Scripts.UI.Screens
{
    public class LoseScreen : MonoBehaviour
    {
        [SerializeField] private Button btn;
        private LevelService levelService;
		
        [Inject]
        private void Construct(LevelService levelService)
        {
            this.levelService = levelService;
			
            btn.onClick.AddListener(OnClickBtn);
        }

        private void OnDestroy()
        {
            btn.onClick.RemoveAllListeners();
        }
		
        private void OnClickBtn()
        {
            levelService.Restart();	
        }
    }
}
