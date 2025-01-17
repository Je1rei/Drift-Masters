using Infrastructure;
using Inputs;
using Services;
using UIView;
using UnityEngine;
using YG;
using Zenject;

namespace Installers.CompositionRoot
{
    public class GamePlayCompositionRoot : CompositionRoot
    {
        [SerializeField] private SceneContext _sceneContext;
        [SerializeField] private GameplayPanel _gamePlayPanel;
        [SerializeField] private WalletView _walletView;
        [SerializeField] private LevelFactory _levelFactory;
        [SerializeField] private Player _player;
        [SerializeField] private InputHandler _inputHandler;

        private DiContainer _sceneContainer;

        [Inject]
        public override void Compose(DiContainer diContainer)
        {
            _sceneContainer = _sceneContext.Container;

            _sceneContainer.Resolve<CarService>().Load(YG2.saves.ChoisedCarID);
            _sceneContainer.Resolve<WalletGamePlay>().Construct(0);
            _walletView.Construct(_sceneContainer.Resolve<WalletGamePlay>());

            _gamePlayPanel.Construct(_sceneContainer.Resolve<InputPause>(),
                _sceneContainer.Resolve<AudioService>(),
                _sceneContainer.Resolve<RewardService>(),
                _sceneContainer.Resolve<LevelService>(),
                _sceneContainer.Resolve<SceneLoaderService>());

            _levelFactory.Create(_sceneContainer.Resolve<WalletGamePlay>(), _sceneContainer.Resolve<AudioService>(), _sceneContainer.Resolve<InputPause>(),
                _sceneContainer.Resolve<LevelService>().Current,
                _sceneContainer.Resolve<CarService>().Current);

            _sceneContainer.Resolve<RewardService>().Construct(_player, _sceneContainer.Resolve<Wallet>(),
                _sceneContainer.Resolve<LevelService>());
        }
    }
}