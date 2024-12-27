using UnityEngine;
using Zenject;

namespace Content.Scripts.Services
{
    public class AssetFactory
    {
        private DiContainer container;

        [Inject]
        public AssetFactory(DiContainer container) => this.container = container;

        public T InstantiateAndInject<T>(Object prefab, Vector3 position, Quaternion rotation, Transform parent = null)
        {
            return container.InstantiatePrefabForComponent<T>(prefab, position, rotation, parent);
        }

        public T InstantiateAndInject<T>(Object prefab, Transform parent = null)
        {
            return container.InstantiatePrefabForComponent<T>(prefab, parent);
        }

    }
}