using Infrastructure;
using Inputs;
using Services;
using UIView;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Installers.CompositionRoot
{
    public class GamePlayCompositionRoot : CompositionRoot
    {
        [SerializeField] private SceneContext _sceneContext;
        [SerializeField] private GameplayPanel _gamePlayPanel;
        [SerializeField] private LevelFactory _levelFactory;

        private DiContainer _sceneContainer;

        [Inject]
        public override void Compose(DiContainer diContainer)
        {
            _sceneContainer = _sceneContext.Container;

            _gamePlayPanel.Construct(_sceneContainer.Resolve<AudioService>(), _sceneContainer.Resolve<RewardService>(),
                _sceneContainer.Resolve<LevelService>(),
                _sceneContainer.Resolve<SceneLoaderService>());

            _levelFactory.Create(_sceneContainer.Resolve<LevelService>().Current,
                _sceneContainer.Resolve<CarService>().Current);
        }
    }
}