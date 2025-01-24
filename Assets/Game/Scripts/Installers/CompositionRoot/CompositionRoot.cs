using UnityEngine;
using Zenject;

namespace Installers.CompositionRoot
{
    public abstract class CompositionRoot : MonoBehaviour
    {
        public abstract void Compose(DiContainer diContainer);
    }
}