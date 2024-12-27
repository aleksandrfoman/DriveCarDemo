using UnityEngine;
using Zenject;

namespace Content.Scripts.Installers
{
    [CreateAssetMenu(fileName = "ScriptablesInstaller", menuName = "Installers/ScriptablesInstaller")]
    public class ScriptablesInstaller : ScriptableObjectInstaller<ScriptablesInstaller>
    {
        [SerializeField] private ScriptableObject[] scriptables;

        public override void InstallBindings()
        {
            foreach (var scriptable in scriptables)
                Container.BindInterfacesAndSelfTo(scriptable.GetType()).FromInstance(scriptable).AsSingle();
        }
    }
}