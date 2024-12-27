using Content.Scripts.PlayerVechile;
using UnityEngine;
using Zenject;

namespace Content.Scripts.Services
{
    public class PlayerService : MonoBehaviour
    {
        public Player Player => player;
        private AssetProviderService assetProvider;
        private AssetFactory assetFactory;
        private LevelService levelService;
        private Player player;

        [Inject]
        private void Construct(AssetFactory assetFactory, AssetProviderService assetProviderService,LevelService levelService)
        {
            this.assetFactory = assetFactory;
            this.levelService = levelService;
            assetProvider = assetProviderService;
        }
        
        public void SpawnPlayer()
        {
            player = assetFactory.InstantiateAndInject<Player>(assetProvider.GameData.PlayerPrefab);
            player.Init();
        }
    }
}
