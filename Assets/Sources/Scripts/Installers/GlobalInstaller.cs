using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using Zenject;

namespace Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInputService();

            SceneManager.LoadScene(1);
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