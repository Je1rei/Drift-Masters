using System;
using Services;
using UnityEngine;
using UnityEngine.UI;

namespace UIView
{
    public abstract class UIPanel : MonoBehaviour
    {
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

        protected void AddButtonListener(AudioService audioService, Button button, Action onClickAction)
        {
            button.onClick.AddListener(() =>
            {
                audioService.PlaySound();
                onClickAction?.Invoke();
            });
        }
    }
}