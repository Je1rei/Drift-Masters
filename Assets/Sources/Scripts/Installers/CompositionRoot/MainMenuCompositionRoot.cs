using System.Collections.Generic;
using Infrastructure;
using Players;
using Services;
using UIView;
using UnityEngine;
using YG;
using Zenject;

namespace Installers.CompositionRoot
{
    public class MainMenuCompositionRoot : CompositionRoot
    {
        [SerializeField] private SceneContext _sceneContext;

        [SerializeField] private RotatorTarget _rotator;
        [SerializeField] private WalletView _walletView;
        [SerializeField] private MainMenuPanel _mainMenuPanel;
        [SerializeField] private ShopCell[] _shopCells;

        private DiContainer _sceneContainer;

        [Inject]
        public override void Compose(DiContainer diContainer)
        {
            _sceneContainer = _sceneContext.Container;

            _sceneContainer.Resolve<Wallet>().Construct(YG2.saves.Coins);

            _rotator.Construct();
            _sceneContainer.Resolve<CarService>().Construct(_rotator.Target);

            _sceneContainer.Resolve<ShopService>().Construct(_sceneContainer.Resolve<AudioService>(),
                _sceneContainer.Resolve<CarService>(),
                _sceneContainer.Resolve<Wallet>(), _shopCells);
            _mainMenuPanel.Construct(_sceneContainer.Resolve<AudioService>(), _sceneContainer.Resolve<LevelService>(),
                _sceneContainer.Resolve<SettingsService>(), _sceneContainer.Resolve<SceneLoaderService>(),
                _sceneContainer.Resolve<CarService>());

            _walletView.Construct(_sceneContainer.Resolve<Wallet>());
        }
    }
}