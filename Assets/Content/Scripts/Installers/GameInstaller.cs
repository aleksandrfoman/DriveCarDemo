using Content.Scripts.Services;

namespace Content.Scripts.Installers
{
    public class GameInstaller : MonoBinder
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AssetFactory>().AsSingle().NonLazy();
            BindService<PoolService>();
            BindService<LevelService>();
            BindService<CameraService>();
            BindService<PlayerService>();
            BindService<GameScreenService>();
        }
    }
}
