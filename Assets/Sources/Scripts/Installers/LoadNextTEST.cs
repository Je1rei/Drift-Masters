using UnityEngine;
using UnityEngine.SceneManagement;

namespace Installers
{
    public class LoadNextTEST : MonoBehaviour
    {
        public void LoadNextScene()
        {
            SceneManager.LoadScene(2);
        }
    }
}