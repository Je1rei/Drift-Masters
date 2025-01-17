using System;
using Data;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIView
{
    public class ShopCell : UIPanel // СДЕЛТАЬ ОТДЕЛЬНЫЙ ДЛЯ ПОКУПОК ЯИ
    {
        [SerializeField] private ShopItemData _itemData;
        [SerializeField] private Image _imageModel; // -> model
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private TMP_Text _soldOutText;
        [SerializeField] private Button _buyButton;

        private string _name;
        private int _price;
        private Sprite _model; // -> model

        private AudioService _audioService;

        public ShopItemData ItemData => _itemData;

        public event Action<int, ShopCell> Purchasing;

        public void Construct(AudioService audioService)
        {
            _audioService = audioService;

            _name = _itemData.Name;
            _price = _itemData.Price;
            _model = _itemData.Model;

            SetTexts();
            AddButtonListener(_audioService, _buyButton, OnBuyButtonClick);
        }

        private void SetTexts()
        {
            _imageModel.sprite = _model;
            
            if (_nameText != null)
            {
                _nameText.text = _name;
            }

            _priceText.text = _price.ToString();
        }

        private void OnBuyButtonClick()
        {
            Purchasing?.Invoke(_price, this);
        }

        public void SetPurchasedState()
        {
            _buyButton.interactable = false;
            _priceText.gameObject.SetActive(false);
            _buyButton.gameObject.SetActive(false);

            if (_soldOutText != null)
            {
                _soldOutText.gameObject.SetActive(true);
            }
        }
    }
}