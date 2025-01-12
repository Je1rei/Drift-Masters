using Inputs;
using Services;
using Zenject;

namespace Installers
{
    public class GamePlayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<TutorialService>().AsSingle().NonLazy();
            Container.Bind<RewardService>().AsSingle().NonLazy();
        }
    }
}