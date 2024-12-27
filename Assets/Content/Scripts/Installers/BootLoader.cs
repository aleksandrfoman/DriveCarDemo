using Content.Scripts.Services;
using UnityEngine;
using Zenject;
namespace Content.Scripts.Installers
{
    public class BootLoader : MonoBehaviour
    {
        [Inject]
        private void Construct(SceneService sceneService)
        {
            sceneService.LoadGameScene();
        }
    }
}
