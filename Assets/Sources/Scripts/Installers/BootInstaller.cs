using UnityEngine;
using Zenject;

namespace Installers
{
    public class BootInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log("Boot Scene is Loaded");
        }
    }
}
