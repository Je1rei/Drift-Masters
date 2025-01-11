using UnityEngine;
using UnityEngine.UI;

namespace UIView
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Image _activeImage;
        [SerializeField] private Image _lockedImage;
        [SerializeField] private Button _button;

        public Button Button => _button;

        public void SetLock()
        {
            _lockedImage.gameObject.SetActive(true);
            _button.interactable = false;
        }

        public void SetUnlock()
        {
            _lockedImage.gameObject.SetActive(false);
            _button.interactable = true;
        }

        public void Activate()
        {
            _activeImage.gameObject.SetActive(true);
        }
    }
}