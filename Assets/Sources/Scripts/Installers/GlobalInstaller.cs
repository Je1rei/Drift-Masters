using Infrastructure;
using Installers.CompositionRoot;
using Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using Zenject;

namespace Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        [SerializeField] private SceneLoaderService _sceneLoaderPrefab;
        
        public override void InstallBindings()
        {
            BindInputService();
            Container.Bind<SceneLoaderService>().FromComponentInNewPrefab(_sceneLoaderPrefab).AsSingle().NonLazy();
            // Container.Bind<AudioService>().FromInstance(_audioService).AsSingle().NonLazy();
            Container.Bind<Wallet>().AsSingle().NonLazy();
        }

        private void BindInputService()
        {
            if (YG2.envir.isMobile)
            {
                Debug.Log("isMobile");
            }
            else
            {
                Debug.Log("isDesktop");
            }
        }
    }
}