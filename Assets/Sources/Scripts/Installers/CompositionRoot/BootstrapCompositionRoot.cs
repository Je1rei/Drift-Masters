using System;
using Infrastructure;
using Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Installers.CompositionRoot
{
    public class BootstrapCompositionRoot : CompositionRoot
    {
        [SerializeField] private SceneContext _sceneContext;
        private SceneLoaderService _sceneLoader;

        private DiContainer _sceneContainer;

        [Inject]
        public override void Compose(DiContainer diContainer)
        {
            _sceneContainer = _sceneContext.Container;
            
            _sceneContainer.Resolve<AudioService>().Construct();
            _sceneLoader = diContainer.Resolve<SceneLoaderService>();
        
            SceneManager.LoadScene(_sceneLoader.MainMenuScene);
        }
    }
}