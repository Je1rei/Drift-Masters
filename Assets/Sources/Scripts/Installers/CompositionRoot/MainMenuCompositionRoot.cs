using Infrastructure;
using UnityEngine;
using Zenject;

namespace Installers.CompositionRoot
{
    public class MainMenuCompositionRoot : CompositionRoot
    {
        [SerializeField] private SceneContext _sceneContext;
        
        private DiContainer _sceneContainer;
        
        [Inject]
        public override void Compose(DiContainer diContainer)
        {
            _sceneContainer = _sceneContext.Container;
            _sceneContainer.Resolve<Wallet>().Construct();
            
            Debug.Log("Compsoe MaiNMenu");
        }
    }
}