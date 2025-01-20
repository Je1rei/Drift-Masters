using Infrastructure;
using Inputs;
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
        [SerializeField] private ShopService _shopServicePrefab;
        [SerializeField] private LevelService _levelServicePrefab;
        [SerializeField] private AudioService _audioServicePrefab;
        [SerializeField] private SettingsService _settingsServicePrefab;
        [SerializeField] private CarService _carServicePrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<SceneLoaderService>().FromComponentInNewPrefab(_sceneLoaderPrefab).AsSingle().NonLazy();
            Container.Bind<ShopService>().FromComponentInNewPrefab(_shopServicePrefab).AsSingle().NonLazy();
            Container.Bind<LevelService>().FromComponentInNewPrefab(_levelServicePrefab).AsSingle().NonLazy();
            Container.Bind<AudioService>().FromComponentInNewPrefab(_audioServicePrefab).AsSingle().NonLazy();
            Container.Bind<SettingsService>().FromComponentInNewPrefab(_settingsServicePrefab).AsSingle().NonLazy();
            Container.Bind<CarService>().FromComponentInNewPrefab(_carServicePrefab).AsSingle().NonLazy();
            
            Container.Bind<Wallet>().AsSingle().NonLazy();
            Container.Bind<InputPause>().AsSingle().NonLazy();
        }
    }
}