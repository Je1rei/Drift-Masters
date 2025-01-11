using System;
using Data;
using Infrastructure;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UIView
{
    public class ShopCell : UIPanel
    {
        [SerializeField] private ShopItemData itemData;
        [SerializeField] private Image _imageModel; // -> model
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private Button _buyButton;

        private string _name;
        private int _price;
        private Sprite _model; // -> model

        private AudioService _audioService;
        
        public event Action<int> Purchasing;
        
        public void Construct(AudioService audioService)
        {
            _audioService = audioService;
            
            _name = itemData.Name;
            _price = itemData.Price;
            _model = itemData.Model;

            SetTexts();
            AddButtonListener(_audioService, _buyButton, OnBuyButtonClick);
        }

        private void SetTexts()
        {
            _imageModel.sprite = _model;
            _nameText.text = _name;
            _priceText.text = _price.ToString();
        }

        private void OnBuyButtonClick()
        {
            Purchasing?.Invoke(_price);
        }
    }
}