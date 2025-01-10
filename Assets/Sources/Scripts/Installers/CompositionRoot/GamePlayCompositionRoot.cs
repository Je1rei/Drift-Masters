using UnityEngine;
using Zenject;

namespace Installers.CompositionRoot
{
    public class GamePlayCompositionRoot : CompositionRoot
    {
        [SerializeField] private SceneContext _sceneContext;

        private DiContainer _sceneContainer;

        public override void Compose(DiContainer diContainer)
        {
            _sceneContext.Run();
            _sceneContainer = _sceneContext.Container;
        }
    }
}