using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIView
{
    public abstract class UIPanel : MonoBehaviour
    {
        // private AudioService _audioService;

        // [Inject]
        // protected void Construct(AudioService audioService)
        // {
        //     _audioService = audioService;
        // }

        public void Show()
        {
            if (this != null)
            {
                gameObject.SetActive(true);
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        protected void AddButtonListener(Button button, Action onClickAction)
        {
            button.onClick.AddListener(() =>
            {
                // _audioService.PlaySound();
                // onClickAction?.Invoke();
            });
        }
    }
}