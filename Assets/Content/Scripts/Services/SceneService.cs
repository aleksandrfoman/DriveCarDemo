using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
namespace Content.Scripts.Services
{
    public class SceneService : MonoBehaviour
    {
        private AssetProviderService assetProvider;
        
        [Inject]
        private void Construct(AssetProviderService assetProviderService)
        {
            assetProvider = assetProviderService;
        }

        public void LoadGameScene()
        {
            SceneManager.LoadScene(assetProvider.GameData.GameSceneName);
        }
    }
}
