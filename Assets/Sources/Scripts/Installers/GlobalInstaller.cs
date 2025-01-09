using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using YG;

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