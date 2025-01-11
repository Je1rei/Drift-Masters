using Infrastructure;
using Input;
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
        
        private DiContainer _sceneContainer;

        [Inject]
        public override void Compose(DiContainer diContainer)
        {
            _sceneContainer = _sceneContext.Container;
            
            _gamePlayPanel.Construct(_sceneContainer.Resolve<AudioService>(), _sceneContainer.Resolve<RewardService>(),
                _sceneContainer.Resolve<LevelService>(),
                _sceneContainer.Resolve<SceneLoaderService>()); // тестить
        }
    }
}